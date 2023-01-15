// Decompiled with JetBrains decompiler
// Type: ArincReader.IcaoPansOps.WaypointStabilizationDistance
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.GeneralAviation;
using System;

namespace ArincReader.IcaoPansOps
{
    public class WaypointStabilizationDistance
    {
        private AircraftTypes _AircraftType;
        private AirSpeed _AirSpeed;
        private readonly WaypointTypes _WaypointType;
        private Angle _TrackAngleChange;
        private Angle _AngleOfBank;
        private LinearDistance _Waypoint2RadiusOfTurn;

        public WaypointStabilizationDistance(WaypointTypes waypointType)
        {
            this._WaypointType = waypointType;
            this._AircraftType = AircraftTypes.Aeroplane;
            this._AirSpeed = new AirSpeed(0.0, AirSpeedUnits.Kph);
            this._TrackAngleChange = new Angle(50.0);
            this._AngleOfBank = new Angle(0.0);
        }

        public AircraftTypes AircraftType
        {
            get => this._AircraftType;
            set
            {
                this._AircraftType = value;
                this.TrackAngleChange = this._TrackAngleChange;
            }
        }

        public AirSpeed Airspeed
        {
            get => this._AirSpeed;
            set => this._AirSpeed = value;
        }

        public Angle AngleOfBank
        {
            get => this._AngleOfBank;
            set => this._AngleOfBank = value;
        }

        public Angle TrackAngleChange
        {
            get => this._TrackAngleChange;
            set
            {
                if (value.AsDegrees() < 50.0 && this._AircraftType == AircraftTypes.Aeroplane)
                    this._TrackAngleChange = new Angle(50.0);
                else if (value.AsDegrees() < 30.0 && this._AircraftType == AircraftTypes.Helicopter)
                    this._TrackAngleChange = new Angle(30.0);
                else
                    this._TrackAngleChange = value;
            }
        }

        public double RateOfTurn() => this._AirSpeed.RateOfTurn(this._AngleOfBank, false);

        public LinearDistance RadiusOfTurn() => this._AirSpeed.RadiusOfTurn(this._AngleOfBank);

        public LinearDistance EarliestTurnInitiation()
        {
            LinearDistance linearDistance = this.RadiusOfTurn();
            switch (this._WaypointType)
            {
                case WaypointTypes.Flyby:
                    linearDistance.Value = this.RadiusOfTurn().Value * Math.Tan(new Angle(this._TrackAngleChange.AsDegrees() / 2.0).AsRadians());
                    break;
                case WaypointTypes.Flyover:
                    linearDistance = this.RadiusOfTurn() * Math.Sin(this._TrackAngleChange.AsRadians());
                    break;
            }
            return linearDistance;
        }

        public LinearDistance L1() => this.EarliestTurnInitiation();

        public LinearDistance L2()
        {
            LinearDistance linearDistance = this._AirSpeed.ValueUnit == AirSpeedUnits.Kph ? new LinearDistance(0.0, LinearDistanceUnits.KM) : new LinearDistance(0.0, LinearDistanceUnits.NM);
            switch (this._WaypointType)
            {
                case WaypointTypes.Flyby:
                    linearDistance.Value = this._AirSpeed.Value * (double)this.DeriveBankEstablishmentTime().Seconds / 3600.0;
                    break;
                case WaypointTypes.Flyover:
                    linearDistance = this.RadiusOfTurn() * Math.Cos(this._TrackAngleChange.AsRadians()) * Math.Tan(Angle.DegreesToRadians(30.0));
                    break;
            }
            return linearDistance;
        }

        public LinearDistance L3()
        {
            LinearDistance linearDistance = this._AirSpeed.ValueUnit == AirSpeedUnits.Kph ? new LinearDistance(0.0, LinearDistanceUnits.KM) : new LinearDistance(0.0, LinearDistanceUnits.NM);
            switch (this._WaypointType)
            {
                case WaypointTypes.Flyover:
                    double num1 = 1.0 / Math.Sin(Angle.DegreesToRadians(30.0));
                    double num2 = 2.0 * Math.Cos(this._TrackAngleChange.AsRadians());
                    double num3 = Math.Sin(Angle.DegreesToRadians(60.0));
                    linearDistance = this.RadiusOfTurn() * (num1 - num2 / num3);
                    break;
            }
            return linearDistance;
        }

        public LinearDistance L4()
        {
            LinearDistance linearDistance = this._AirSpeed.ValueUnit == AirSpeedUnits.Kph ? new LinearDistance(0.0, LinearDistanceUnits.KM) : new LinearDistance(0.0, LinearDistanceUnits.NM);
            switch (this._WaypointType)
            {
                case WaypointTypes.Flyover:
                    linearDistance = this._Waypoint2RadiusOfTurn * Math.Tan(Angle.DegreesToRadians(15.0));
                    break;
            }
            return linearDistance;
        }

        public LinearDistance L5()
        {
            LinearDistance linearDistance = this._AirSpeed.ValueUnit == AirSpeedUnits.Kph ? new LinearDistance(0.0, LinearDistanceUnits.KM) : new LinearDistance(0.0, LinearDistanceUnits.NM);
            switch (this._WaypointType)
            {
                case WaypointTypes.Flyover:
                    linearDistance.Value = this._AirSpeed.Value * (double)this.DeriveBankEstablishmentTime().Seconds / 3600.0;
                    break;
            }
            return linearDistance;
        }

        public LinearDistance MinimumStabilizationDistanceFlyby()
        {
            this._Waypoint2RadiusOfTurn = this._AirSpeed.ValueUnit == AirSpeedUnits.Kph ? new LinearDistance(0.0, LinearDistanceUnits.KM) : new LinearDistance(0.0, LinearDistanceUnits.NM);
            return this.MinimumStabilizationDistance();
        }

        public LinearDistance MinimumStabilizationDistanceFlyover(
          LinearDistance waypoint2RadiusOfTurn)
        {
            this._Waypoint2RadiusOfTurn = waypoint2RadiusOfTurn;
            return this.MinimumStabilizationDistance();
        }

        public LinearDistance MinimumStabilizationDistance() => this.L1() + this.L2() + this.L3() + this.L4() + this.L5();

        private TimeSpan DeriveBankEstablishmentTime()
        {
            TimeSpan timeSpan = new TimeSpan();
            switch (this._AircraftType)
            {
                case AircraftTypes.Aeroplane:
                    switch (this._WaypointType)
                    {
                        case WaypointTypes.Flyby:
                            timeSpan = WaypointStabilizationDistance.Constants.FlybyBankEstablishingTimeAeroplane;
                            break;
                        case WaypointTypes.Flyover:
                            timeSpan = WaypointStabilizationDistance.Constants.FlyoverBankEstablishingTimeAeroplane;
                            break;
                    }
                    break;
                case AircraftTypes.Helicopter:
                    switch (this._WaypointType)
                    {
                        case WaypointTypes.Flyby:
                            timeSpan = WaypointStabilizationDistance.Constants.FlybyBankEstablishingTimeHelicopter;
                            break;
                        case WaypointTypes.Flyover:
                            timeSpan = WaypointStabilizationDistance.Constants.FlyoverBankEstablishingTimeHelicopter;
                            break;
                    }
                    break;
            }
            return timeSpan;
        }

        public static class Constants
        {
            public static readonly TimeSpan FlybyBankEstablishingTimeAeroplane = new TimeSpan(0, 0, 5);
            public static readonly TimeSpan FlybyBankEstablishingTimeHelicopter = new TimeSpan(0, 0, 3);
            public static readonly TimeSpan FlyoverBankEstablishingTimeAeroplane = new TimeSpan(0, 0, 10);
            public static readonly TimeSpan FlyoverBankEstablishingTimeHelicopter = new TimeSpan(0, 0, 5);
        }
    }
}
