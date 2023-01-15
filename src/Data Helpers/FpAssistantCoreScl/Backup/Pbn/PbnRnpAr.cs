// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Pbn.PbnRnpAr
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.GeneralAviation;
using FpAssistantCore.Geographical;
using System;

namespace FpAssistantCore.Pbn
{
  public class PbnRnpAr : BaseObjectPbn
  {
    private GeoCoordinate _LtpFtpCoordinate;
    private CompassBearing _TrueRunwayBearingTrueCourse;
    private GeoCoordinate _FapCoordinate;
    private Angle _Vpa;
    private Angle _VpaMinimum;
    private Angle _VpaMaximum;
    private LinearDistance _Rdh;
    private Altitude _FapAltitude;
    private LinearDistance _LtpElevation;
    private Temperature _Act;
    private LinearDistance _DistanceFapToLtp;
    private Temperature _DeltaIsaLow;
    private Temperature _DeltaIsaHigh;
    private Temperature _NaBelow;
    private Temperature _NaAbove;
    private static readonly LinearDistance _FteIcao = new LinearDistance(23.0, LinearDistanceUnits.Metres);
    private static readonly LinearDistance _AtisIcao = new LinearDistance(6.0, LinearDistanceUnits.Metres);
    private static readonly LinearDistance _FteFaa = new LinearDistance(75.0, LinearDistanceUnits.Feet);
    private static readonly LinearDistance _AtisFaa = new LinearDistance(20.0, LinearDistanceUnits.Feet);
    private static readonly LinearDistance _Rnp = new LinearDistance(0.14, LinearDistanceUnits.NM);

    public PbnRnpAr(Criteria criteria)
      : base(criteria)
    {
      this.CriteriaUnit = CriteriaUnits.Si;
      if (criteria != Criteria.FaaTerps)
        return;
      this.CriteriaUnit = CriteriaUnits.NonSi;
    }

    public LinearDistance FTE => !this.IsIcao() ? PbnRnpAr._FteFaa : PbnRnpAr._FteIcao;

    public LinearDistance ATIS => !this.IsIcao() ? PbnRnpAr._AtisFaa : PbnRnpAr._AtisIcao;

    public LinearDistance RNP => PbnRnpAr._Rnp;

    public CriteriaUnits CriteriaUnit { get; set; }

    public GeoCoordinate LtpFtp
    {
      get => this._LtpFtpCoordinate;
      set => this._LtpFtpCoordinate = value;
    }

    public GeoCoordinate Fap
    {
      get => this._FapCoordinate;
      set => this._FapCoordinate = value;
    }

    public CompassBearing TrueRunwayBearingTrueCourse
    {
      get => this._TrueRunwayBearingTrueCourse;
      set => this._TrueRunwayBearingTrueCourse = value;
    }

    public Angle Vpa
    {
      get => this._Vpa;
      set => this._Vpa = value;
    }

    public Angle VpaMinimum
    {
      get
      {
        this.Calculations();
        return this._VpaMinimum;
      }
      private set => this._VpaMinimum = value;
    }

    public Angle VpaMaximum
    {
      get => this._VpaMaximum;
      set => this._VpaMaximum = value;
    }

    public LinearDistance Rdh
    {
      get => this._Rdh;
      set => this._Rdh = value;
    }

    public Altitude FapAltitude
    {
      get => this._FapAltitude;
      set => this._FapAltitude = value;
    }

    public LinearDistance LtpElevation
    {
      get => this._LtpElevation;
      set => this._LtpElevation = value;
    }

    public Temperature IsaTemperatureLtp
    {
      get
      {
        LinearDistance ltpElevation = this.LtpElevation;
        ltpElevation = ltpElevation.ConvertTo(LinearDistanceUnits.Feet);
        return new Temperature(15.0 - 0.00198 * ltpElevation.Value, TemperatureUnits.Celsius);
      }
    }

    public Temperature Act
    {
      get => this._Act;
      set => this._Act = value;
    }

    public LinearDistance DistanceFapToLtp
    {
      get
      {
        this.Calculations();
        return this._DistanceFapToLtp;
      }
      private set => this._DistanceFapToLtp = value;
    }

    public Temperature DeltaIsaLow
    {
      get
      {
        this.Calculations();
        return this._DeltaIsaLow;
      }
    }

    public Temperature DeltaIsaHigh
    {
      get
      {
        this.Calculations();
        return this._DeltaIsaHigh;
      }
    }

    public Temperature NaBelow
    {
      get
      {
        this.Calculations();
        return this._NaBelow;
      }
    }

    public Temperature NaAbove
    {
      get
      {
        this.Calculations();
        return this._NaAbove;
      }
    }

    private void Calculations()
    {
      bool isSi = this.CriteriaUnit == CriteriaUnits.Si;
      CalculateDistanceFapToLtp();
      GeoCoordinateBasic geoCoordinateBasic = this.LtpFtp.GeoCoordinateBasic.WGS84Destination(new CompassBearing(this.TrueRunwayBearingTrueCourse.Bearing), this._DistanceFapToLtp);
      this._FapCoordinate = new GeoCoordinate(geoCoordinateBasic.Latitude, geoCoordinateBasic.Longitude);
      CalculateVpaTemperatureLimits();

      void CalculateDistanceFapToLtp()
      {
        double num1 = isSi ? Constants.FaaTerpsConstants.MeanRadiusOfEarthInMetres : Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet;
        LinearDistance linearDistance = this._FapAltitude.AsLinearDistance().ConvertTo(this.CriteriaUnit);
        double num2 = linearDistance.Value;
        linearDistance = this._LtpElevation.ConvertTo(this.CriteriaUnit);
        double num3 = linearDistance.Value;
        double num4 = num1;
        double num5 = num1 + num2;
        double num6 = num1 + num3;
        linearDistance = this._Rdh.ConvertTo(this.CriteriaUnit);
        double num7 = linearDistance.Value;
        double num8 = num6 + num7;
        double num9 = Math.Log(num5 / num8);
        this.DistanceFapToLtp = new LinearDistance(num4 * num9 / Math.Tan(this._Vpa.AsRadians()), isSi ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet);
      }

      void CalculateVpaTemperatureLimits()
      {
        double num1 = (this.FapAltitude.AsLinearDistance() - this.LtpElevation).Value;
        double num2 = -(this.IsaTemperatureLtp.AsDegreesCelsius() - this._Act.AsDegreesCelsius());
        double num3 = !isSi ? num2 * (0.19 + 0.0038 * num1) + 0.032 * num1 + 4.9 : num2 * (0.057912 + 0.0038 * num1) + 0.032 * num1 + 1.49352;
        double num4 = num1 / Math.Tan(this._Vpa.AsRadians());
        double degrees = Angle.RadiansToDegrees(Math.Atan((num1 + num3) / num4));
        this._VpaMinimum = new Angle(degrees);
        if (degrees < 2.5)
        {
          double num5 = this._FapAltitude.Value - (num4 * Math.Tan(Angle.DegreesToRadians(2.5)) + this._LtpElevation.Value);
          num2 = !isSi ? (-num5 - 0.032 * num1 - 4.9) / (0.19 + 0.0038 * num1) : (-num5 - 0.032 * num1 - 1.49352) / (0.057912 + 0.0038 * num1);
        }
        this._DeltaIsaLow = new Temperature(num2, TemperatureUnits.Celsius);
        this._NaBelow = new Temperature(this.IsaTemperatureLtp.AsDegreesCelsius() + num2, TemperatureUnits.Celsius);
        double a = this._VpaMaximum.AsRadians();
        double num6 = num4 * Math.Tan(a) + this._LtpElevation.Value - this._FapAltitude.Value;
        double num7 = !isSi ? (num6 - 0.032 * num1 - 4.9) / (0.19 + 0.0038 * num1) : (num6 - 0.032 * num1 - 1.49352) / (0.057912 + 0.0038 * num1);
        this._DeltaIsaHigh = new Temperature(num7, TemperatureUnits.Celsius);
        this._NaAbove = new Temperature(this.IsaTemperatureLtp.AsDegreesCelsius() + num7, TemperatureUnits.Celsius);
      }
    }

    public void SetCriteriaUnit(CriteriaUnits criteriaUnits) => this.CriteriaUnit = !this.IsFaa() || criteriaUnits != CriteriaUnits.Si ? criteriaUnits : throw new Exception(ConstantMessages.PbnExceptions.FaaPbnSiUnits);

    public LinearDistance MocVebCalculation(
      LinearDistance bg,
      LinearDistance isad,
      LinearDistance anpe,
      LinearDistance wpr,
      LinearDistance fte,
      LinearDistance ase,
      LinearDistance vae,
      LinearDistance atis)
    {
      LinearDistanceUnits linearDistanceUnit_ConvertTo = this.CriteriaUnit == CriteriaUnits.Si ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet;
      LinearDistance linearDistance1 = anpe.ConvertTo(linearDistanceUnit_ConvertTo);
      linearDistance1.Value *= linearDistance1.Value;
      LinearDistance linearDistance2 = wpr.ConvertTo(linearDistanceUnit_ConvertTo);
      linearDistance2.Value *= linearDistance2.Value;
      LinearDistance linearDistance3 = fte.ConvertTo(linearDistanceUnit_ConvertTo);
      linearDistance3.Value *= linearDistance3.Value;
      LinearDistance linearDistance4 = ase.ConvertTo(linearDistanceUnit_ConvertTo);
      linearDistance4.Value *= linearDistance4.Value;
      LinearDistance linearDistance5 = vae.ConvertTo(linearDistanceUnit_ConvertTo);
      linearDistance5.Value *= linearDistance5.Value;
      LinearDistance linearDistance6 = atis.ConvertTo(linearDistanceUnit_ConvertTo);
      linearDistance6.Value *= linearDistance6.Value;
      LinearDistance linearDistance7 = linearDistance1 + linearDistance2 + linearDistance3 + linearDistance4 + linearDistance5 + linearDistance6;
      linearDistance7.Value = Math.Sqrt(linearDistance7.Value);
      linearDistance7.Value *= 4.0 / 3.0;
      return bg - isad + linearDistance7;
    }

    public LinearDistance AnpeCalculation(Angle vpa)
    {
      LinearDistanceUnits linearDistanceUnits = this.CriteriaUnit == CriteriaUnits.Si ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet;
      LinearDistance rnp = PbnRnpAr._Rnp;
      rnp = rnp.ConvertTo(linearDistanceUnits);
      return new LinearDistance(1.225 * rnp.Value * Math.Tan(vpa.AsRadians()), linearDistanceUnits);
    }

    public LinearDistance WprCalculation(Angle vpa) => this.CriteriaUnit != CriteriaUnits.Si ? new LinearDistance(60.0 * Math.Tan(vpa.AsRadians()), LinearDistanceUnits.Feet) : new LinearDistance(18.0 * Math.Tan(vpa.AsRadians()), LinearDistanceUnits.Metres);

    public LinearDistance AseCalculation(LinearDistance elevation)
    {
      elevation = elevation.ConvertTo(this.CriteriaUnit == CriteriaUnits.Si ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet);
      double num1 = this.CriteriaUnit == CriteriaUnits.Si ? -2.887E-07 : -8.8E-08;
      double num2 = this.CriteriaUnit == CriteriaUnits.Si ? 15.0 : 50.0;
      double num3 = elevation.Value * elevation.Value;
      return new LinearDistance(num1 * num3 + 0.0065 * elevation.Value + num2, this.CriteriaUnit == CriteriaUnits.Si ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet);
    }

    public LinearDistance VaeCalculation(
      LinearDistance elevation,
      LinearDistance ltpElevation,
      Angle vpa)
    {
      elevation = elevation.ConvertTo(this.CriteriaUnit == CriteriaUnits.Si ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet);
      ltpElevation = ltpElevation.ConvertTo(this.CriteriaUnit == CriteriaUnits.Si ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet);
      double num = Math.Tan(vpa.AsRadians()) - Math.Tan(new Angle(vpa.AsDegrees() - 0.01).AsRadians());
      return new LinearDistance((elevation.Value - ltpElevation.Value) / Math.Tan(vpa.AsRadians()) * num, this.CriteriaUnit == CriteriaUnits.Si ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet);
    }

    public LinearDistance BodyGeometryErrorCalculation(
      BaseObjectPbn.PbnPathTypes pbnPathType,
      Angle bankAngle)
    {
      LinearDistance? nullable = new LinearDistance?();
      if (pbnPathType != BaseObjectPbn.PbnPathTypes.TF)
      {
        if (pbnPathType != BaseObjectPbn.PbnPathTypes.RF)
          throw new Exception(ConstantMessages.PbnExceptions.UnsupportedSegmentType);
        switch (this._Criteria)
        {
          case Criteria.IcaoPansOps:
            nullable = new LinearDistance?(this.CriteriaUnit == CriteriaUnits.Si ? new LinearDistance(40.0 * Math.Sin(bankAngle.AsRadians()), LinearDistanceUnits.Metres) : new LinearDistance(132.0 * Math.Sin(bankAngle.AsRadians()), LinearDistanceUnits.Feet));
            break;
        }
      }
      else
      {
        switch (this._Criteria)
        {
          case Criteria.IcaoPansOps:
            nullable = new LinearDistance?(this.CriteriaUnit == CriteriaUnits.Si ? new LinearDistance(7.6, LinearDistanceUnits.Metres) : new LinearDistance(25.0, LinearDistanceUnits.Feet));
            break;
        }
      }
      return nullable.Value;
    }

    public double OasGradientCalculation(
      Altitude fapAltitude,
      LinearDistance ltpElevation,
      LinearDistance mocFap,
      LinearDistance moc75250,
      Angle vpa)
    {
      LinearDistance linearDistance = this.CriteriaUnit == CriteriaUnits.Si ? new LinearDistance(75.0, LinearDistanceUnits.Metres) : new LinearDistance(250.0, LinearDistanceUnits.Feet);
      double num = 0.0;
      switch (this._Criteria)
      {
        case Criteria.IcaoPansOps:
          num = ((fapAltitude.AsLinearDistance() - ltpElevation - mocFap).Value - (linearDistance - moc75250).Value) / ((fapAltitude.AsLinearDistance() - ltpElevation - linearDistance) / Math.Tan(vpa.AsRadians())).Value;
          break;
        case Criteria.FaaTerps:
          num = ((fapAltitude.AsLinearDistance() - ltpElevation - linearDistance) * Math.Tan(vpa.AsRadians())).Value / (fapAltitude.AsLinearDistance() - ltpElevation - mocFap - linearDistance + moc75250).Value;
          break;
      }
      return num;
    }

    public LinearDistance OasLtpOriginDistanceCalculationIcao(
      LinearDistance rdh,
      LinearDistance moc75250,
      double oasGradient,
      Angle vpa)
    {
      rdh = rdh.ConvertTo(this.CriteriaUnit == CriteriaUnits.Si ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet);
      moc75250 = moc75250.ConvertTo(this.CriteriaUnit == CriteriaUnits.Si ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet);
      LinearDistance linearDistance = this.CriteriaUnit == CriteriaUnits.Si ? new LinearDistance(75.0, LinearDistanceUnits.Metres) : new LinearDistance(250.0, LinearDistanceUnits.Feet);
      return (linearDistance - rdh) / Math.Tan(vpa.AsRadians()) - (linearDistance - moc75250) / oasGradient;
    }
  }
}
