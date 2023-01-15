// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.IndicatedAirSpeed
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;

namespace FpAssistantCore.GeneralAviation
{
  public struct IndicatedAirSpeed
  {
    private readonly AirSpeedUnits _AirSpeedUnits;
    private readonly double _IndicatedAirSpeedValue;
    private Altitude _Altitude;
    private readonly double _Var;
    private double _k;
    private const double _C171233 = 171233.0;
    private const double _C288 = 288.0;
    private const double _C0_006496Si = 0.006496;
    private const double _C0_00198NonSi = 0.00198;

    public IndicatedAirSpeed(AirSpeed airSpeed, Altitude altitude)
      : this()
    {
      this._IndicatedAirSpeedValue = airSpeed.Value;
      this._AirSpeedUnits = airSpeed.ValueUnit;
      this._Altitude = altitude;
      this._Var = 15.0;
    }

    public IndicatedAirSpeed(AirSpeed airSpeed, Altitude altitude, double var)
      : this(airSpeed, altitude)
    {
      this._Var = var;
    }

    public AirSpeedUnits AirSpeedUnit => this._AirSpeedUnits;

    public double TrueAirSpeed => this.CalculateTrueAirSpeed();

    public double K
    {
      get
      {
        this.CalculateTrueAirSpeed();
        return this._k;
      }
    }

    private double CalculateTrueAirSpeed()
    {
      double num = 0.0;
      LinearDistance linearDistance = this._Altitude.AsLinearDistance();
      switch (this._AirSpeedUnits)
      {
        case AirSpeedUnits.Kt:
          num = 0.00198;
          linearDistance = linearDistance.ConvertTo(LinearDistanceUnits.Feet);
          break;
        case AirSpeedUnits.Kph:
          num = 0.006496;
          linearDistance = linearDistance.ConvertTo(LinearDistanceUnits.Metres);
          break;
      }
      this._k = 171233.0 * Math.Sqrt(288.0 + this._Var - num * linearDistance.Value) / Math.Pow(288.0 - num * linearDistance.Value, 2.628);
      return this._k * this._IndicatedAirSpeedValue;
    }
  }
}
