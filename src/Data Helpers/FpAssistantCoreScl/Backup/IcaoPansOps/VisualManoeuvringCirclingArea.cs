// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.IcaoPansOps.VisualManoeuvringCirclingArea
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.GeneralAviation;

namespace FpAssistantCore.IcaoPansOps
{
  public class VisualManoeuvringCirclingArea : BaseObjectPansOps
  {
    private Altitude _AerodromeElevation;
    private AngleOfBank _BankAngle;
    private double _IsaDelta;
    private VisualManoeuvringAircraftCategory _AircraftCategory;

    public VisualManoeuvringCirclingArea(CriteriaUnits pansOpsUnit)
      : base(pansOpsUnit)
    {
      switch (pansOpsUnit)
      {
        case CriteriaUnits.Si:
          this._AircraftCategory = VisualManoeuvringAircraftCategory.A185;
          this.AerodromeElevation = new Altitude(0.0, AltitudeUnits.Metres);
          break;
        case CriteriaUnits.NonSi:
          this._AircraftCategory = VisualManoeuvringAircraftCategory.A100;
          this.AerodromeElevation = new Altitude(0.0, AltitudeUnits.Feet);
          break;
      }
      this._IsaDelta = 15.0;
      this._BankAngle = VisualManoeuvringCirclingArea.IcaoValues.AngleOfBankDefault;
      this.Calculate();
    }

    public Altitude AerodromeElevation
    {
      get => this._AerodromeElevation;
      set
      {
        this._AerodromeElevation = value;
        this.Calculate();
      }
    }

    public AngleOfBank BankAngle
    {
      get => this._BankAngle;
      set
      {
        this._BankAngle = value;
        this.Calculate();
      }
    }

    public double IsaDelta
    {
      get => this._IsaDelta;
      set
      {
        this._IsaDelta = value;
        this.Calculate();
      }
    }

    public VisualManoeuvringAircraftCategory AircraftCategory
    {
      get => this._AircraftCategory;
      set
      {
        this._AircraftCategory = value;
        this.Calculate();
      }
    }

    public Altitude AltitudeTAS { get; private set; }

    public AirSpeed TASwithWind { get; private set; }

    public LinearDistance RadiusOfTurn { get; private set; }

    public double RateOfTurn { get; private set; }

    public LinearDistance CirclingRadius { get; private set; }

    private void Calculate()
    {
      double num = 0.0;
      AirSpeedUnits airSpeedUnit = AirSpeedUnits.Kph;
      switch (this.PansOpsUnit)
      {
        case CriteriaUnits.Si:
          this.AltitudeTAS = new Altitude(300.0, AltitudeUnits.Metres) + this.AerodromeElevation;
          num = VisualManoeuvringCirclingArea.IcaoValues.WindSiDefault.Value;
          airSpeedUnit = AirSpeedUnits.Kph;
          break;
        case CriteriaUnits.NonSi:
          this.AltitudeTAS = new Altitude(1000.0, AltitudeUnits.Feet) + this.AerodromeElevation;
          num = VisualManoeuvringCirclingArea.IcaoValues.WindNonSiDefault.Value;
          airSpeedUnit = AirSpeedUnits.Kt;
          break;
      }
      this.TASwithWind = new AirSpeed(new IndicatedAirSpeed(new AirSpeed((double) this.AircraftCategory, airSpeedUnit), this.AltitudeTAS, this._IsaDelta).TrueAirSpeed + num, airSpeedUnit);
      this.RadiusOfTurn = this.TASwithWind.RadiusOfTurn(this._BankAngle.AsAngle());
      this.RateOfTurn = this.TASwithWind.RateOfTurn(this._BankAngle.AsAngle(), false);
      this.CirclingRadius = this.RadiusOfTurn * 2.0;
      switch (this.AircraftCategory)
      {
        case VisualManoeuvringAircraftCategory.A100:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatAStraightSegmentNonSiDefault;
          break;
        case VisualManoeuvringAircraftCategory.B135:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatBStraightSegmentNonSiDefault;
          break;
        case VisualManoeuvringAircraftCategory.C180:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatCStraightSegmentNonSiDefault;
          break;
        case VisualManoeuvringAircraftCategory.A185:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatAStraightSegmentSiDefault;
          break;
        case VisualManoeuvringAircraftCategory.D205:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatDStraightSegmentNonSiDefault;
          break;
        case VisualManoeuvringAircraftCategory.E240:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatEStraightSegmentNonSiDefault;
          break;
        case VisualManoeuvringAircraftCategory.B250:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatBStraightSegmentSiDefault;
          break;
        case VisualManoeuvringAircraftCategory.C335:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatCStraightSegmentSiDefault;
          break;
        case VisualManoeuvringAircraftCategory.D380:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatDStraightSegmentSiDefault;
          break;
        case VisualManoeuvringAircraftCategory.E445:
          this.CirclingRadius += VisualManoeuvringCirclingArea.IcaoValues.CatEStraightSegmentSiDefault;
          break;
      }
    }

    public static class IcaoValues
    {
      public static readonly AngleOfBank AngleOfBankDefault = new AngleOfBank(20.0);
      public static readonly AirSpeed WindSiDefault = new AirSpeed(46.0, AirSpeedUnits.Kph);
      public static readonly LinearDistance CatAStraightSegmentSiDefault = new LinearDistance(0.56, LinearDistanceUnits.KM);
      public static readonly LinearDistance CatBStraightSegmentSiDefault = new LinearDistance(0.74, LinearDistanceUnits.KM);
      public static readonly LinearDistance CatCStraightSegmentSiDefault = new LinearDistance(0.93, LinearDistanceUnits.KM);
      public static readonly LinearDistance CatDStraightSegmentSiDefault = new LinearDistance(1.11, LinearDistanceUnits.KM);
      public static readonly LinearDistance CatEStraightSegmentSiDefault = new LinearDistance(1.3, LinearDistanceUnits.KM);
      public static readonly AirSpeed WindNonSiDefault = new AirSpeed(25.0, AirSpeedUnits.Kt);
      public static readonly LinearDistance CatAStraightSegmentNonSiDefault = new LinearDistance(0.3, LinearDistanceUnits.NM);
      public static readonly LinearDistance CatBStraightSegmentNonSiDefault = new LinearDistance(0.4, LinearDistanceUnits.NM);
      public static readonly LinearDistance CatCStraightSegmentNonSiDefault = new LinearDistance(0.5, LinearDistanceUnits.NM);
      public static readonly LinearDistance CatDStraightSegmentNonSiDefault = new LinearDistance(0.6, LinearDistanceUnits.NM);
      public static readonly LinearDistance CatEStraightSegmentNonSiDefault = new LinearDistance(0.7, LinearDistanceUnits.NM);
    }
  }
}
