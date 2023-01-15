// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.IcaoPansOps.MinimumLengthRnavSegment
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.GeneralAviation;
using System;

namespace FpAssistantCore.IcaoPansOps
{
  public class MinimumLengthRnavSegment : BaseObjectPansOps
  {
    private WaypointStabilizationDistance _Waypoint1 = new WaypointStabilizationDistance(WaypointTypes.Flyby);
    private WaypointStabilizationDistance _Waypoint2 = new WaypointStabilizationDistance(WaypointTypes.Flyby);
    private AircraftTypes _AircraftType;
    private readonly WaypointSequences _WaypointSequence;

    public MinimumLengthRnavSegment(CriteriaUnits pansOpsUnit, WaypointSequences waypointSequence)
      : base(pansOpsUnit)
    {
      this._AircraftType = AircraftTypes.Aeroplane;
      this._WaypointSequence = waypointSequence;
      switch (this._WaypointSequence)
      {
        case WaypointSequences.Flyby2Flyby:
          this._Waypoint1 = new WaypointStabilizationDistance(WaypointTypes.Flyby);
          this._Waypoint2 = new WaypointStabilizationDistance(WaypointTypes.Flyby);
          break;
        case WaypointSequences.Flyby2Flyover:
          this._Waypoint1 = new WaypointStabilizationDistance(WaypointTypes.Flyby);
          this._Waypoint2 = new WaypointStabilizationDistance(WaypointTypes.Flyover);
          break;
        case WaypointSequences.Flyover2Flyover:
          this._Waypoint1 = new WaypointStabilizationDistance(WaypointTypes.Flyover);
          this._Waypoint2 = new WaypointStabilizationDistance(WaypointTypes.Flyover);
          break;
        case WaypointSequences.Flyover2Flyby:
          this._Waypoint1 = new WaypointStabilizationDistance(WaypointTypes.Flyover);
          this._Waypoint2 = new WaypointStabilizationDistance(WaypointTypes.Flyby);
          break;
      }
    }

    public AircraftTypes AircraftType
    {
      get => this._AircraftType;
      set => this._AircraftType = this._Waypoint1.AircraftType = this._Waypoint2.AircraftType = value;
    }

    public WaypointStabilizationDistance Waypoint1
    {
      get => this._Waypoint1;
      set => this._Waypoint1 = value;
    }

    public WaypointStabilizationDistance Waypoint2
    {
      get => this._Waypoint2;
      set => this._Waypoint2 = value;
    }

    public Tuple<LinearDistance, LinearDistance, LinearDistance> MinimumLength()
    {
      if (this.PansOpsUnit != CriteriaUnits.Si)
      {
        LinearDistance linearDistance1 = new LinearDistance(0.0, LinearDistanceUnits.Metres);
      }
      else
      {
        LinearDistance linearDistance2 = new LinearDistance(0.0, LinearDistanceUnits.Metres);
      }
      LinearDistance linearDistance3 = this.PansOpsUnit == CriteriaUnits.Si ? new LinearDistance(0.0, LinearDistanceUnits.Metres) : new LinearDistance(0.0, LinearDistanceUnits.Metres);
      LinearDistance linearDistance4 = this.PansOpsUnit == CriteriaUnits.Si ? new LinearDistance(0.0, LinearDistanceUnits.Metres) : new LinearDistance(0.0, LinearDistanceUnits.Metres);
      switch (this._WaypointSequence)
      {
        case WaypointSequences.Flyby2Flyby:
          overrideSlowSpeedWp1();
          linearDistance3 = this._Waypoint1.MinimumStabilizationDistanceFlyby();
          linearDistance4 = this._Waypoint2.MinimumStabilizationDistanceFlyby();
          break;
        case WaypointSequences.Flyby2Flyover:
          overrideSlowSpeedWp1();
          linearDistance3 = this._Waypoint1.MinimumStabilizationDistanceFlyby();
          break;
        case WaypointSequences.Flyover2Flyover:
          overrideSlowSpeedWp1();
          this._Waypoint2.AngleOfBank = new Angle(15.0);
          linearDistance3 = this._Waypoint1.MinimumStabilizationDistanceFlyover(this._Waypoint2.RadiusOfTurn());
          break;
        case WaypointSequences.Flyover2Flyby:
          overrideSlowSpeedWp1();
          AirSpeed airspeed = this._Waypoint1.Airspeed;
          airspeed.RateOfTurn(new Angle(15.0), false);
          airspeed = this._Waypoint1.Airspeed;
          linearDistance3 = this._Waypoint1.MinimumStabilizationDistanceFlyover(airspeed.RadiusOfTurn(new Angle(15.0)));
          linearDistance4 = this._Waypoint2.MinimumStabilizationDistanceFlyby();
          break;
      }
      return Tuple.Create<LinearDistance, LinearDistance, LinearDistance>(linearDistance3 + linearDistance4, linearDistance3, linearDistance4);

      void overrideSlowSpeedWp1()
      {
        switch (this._AircraftType)
        {
          case AircraftTypes.Aeroplane:
            AirSpeed airspeed1 = this._Waypoint1.Airspeed;
            if (airspeed1.ValueUnit == AirSpeedUnits.Kph)
            {
              airspeed1 = this._Waypoint1.Airspeed;
              if (airspeed1.Value < 240.0)
              {
                this._Waypoint1.Airspeed = new AirSpeed(240.0, AirSpeedUnits.Kph);
                break;
              }
            }
            airspeed1 = this._Waypoint1.Airspeed;
            if (airspeed1.ValueUnit != AirSpeedUnits.Kt)
              break;
            airspeed1 = this._Waypoint1.Airspeed;
            if (airspeed1.Value >= 130.0)
              break;
            this._Waypoint1.Airspeed = new AirSpeed(130.0, AirSpeedUnits.Kt);
            break;
          case AircraftTypes.Helicopter:
            AirSpeed airspeed2 = this._Waypoint1.Airspeed;
            if (airspeed2.ValueUnit == AirSpeedUnits.Kph)
            {
              airspeed2 = this._Waypoint1.Airspeed;
              if (airspeed2.Value < 130.0)
              {
                this._Waypoint1.Airspeed = new AirSpeed(130.0, AirSpeedUnits.Kph);
                this._Waypoint2.Airspeed = new AirSpeed(130.0, AirSpeedUnits.Kph);
                break;
              }
            }
            airspeed2 = this._Waypoint1.Airspeed;
            if (airspeed2.ValueUnit != AirSpeedUnits.Kt)
              break;
            airspeed2 = this._Waypoint1.Airspeed;
            if (airspeed2.Value >= 70.0)
              break;
            this._Waypoint1.Airspeed = new AirSpeed(70.0, AirSpeedUnits.Kt);
            this._Waypoint2.Airspeed = new AirSpeed(70.0, AirSpeedUnits.Kt);
            break;
        }
      }
    }
  }
}
