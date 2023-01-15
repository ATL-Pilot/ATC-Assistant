// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Pbn.PbnCalculations
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.FaaTerps;
using FpAssistantCore.General;
using FpAssistantCore.GeneralAviation;
using System;

namespace FpAssistantCore.Pbn
{
  public class PbnCalculations : BaseObjectPbn
  {
    public PbnCalculations(Criteria criteria)
      : base(criteria)
    {
    }

    public Altitude ProjectedAltitude(
      Altitude segmentStartingMSLElevation,
      LinearDistance d500,
      LinearDistance d350,
      Altitude? publishedMaximumMSLAltitude)
    {
      Altitude altitude1 = new Altitude(0.0, AltitudeUnits.Feet);
      Altitude segmentStartingMSLElevationCopy = segmentStartingMSLElevation.ConvertTo(AltitudeUnits.Feet);
      d500 = d500.ConvertTo(LinearDistanceUnits.NM);
      d500.Value = MathFaa.Round(d500.Value, 0);
      d350 = d350.ConvertTo(LinearDistanceUnits.NM);
      d350.Value = MathFaa.Round(d350.Value, 0);
      if (segmentStartingMSLElevationCopy.Value >= 10000.0)
        altitude1.Value = EquationPart1(d350.Value * 350.0);
      else if (segmentStartingMSLElevationCopy.Value < 10000.0)
      {
        double num1 = EquationPart1(d500.Value * 500.0);
        double num2 = Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet + 10000.0;
        double num3 = Math.Exp(350.0 * d350.Value / Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet);
        altitude1.Value = num1 + num2 * num3 - num2;
      }
      if (publishedMaximumMSLAltitude.HasValue)
      {
        Altitude altitude2 = altitude1;
        Altitude? nullable = publishedMaximumMSLAltitude;
        if ((nullable.HasValue ? (altitude2 > nullable.GetValueOrDefault() ? 1 : 0) : 0) != 0)
          altitude1 = publishedMaximumMSLAltitude.Value.ConvertTo(AltitudeUnits.Feet);
      }
      return altitude1;

      double EquationPart1(double distance) => (Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet + segmentStartingMSLElevationCopy.Value) * Math.Exp(distance / Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet) - Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet;
    }

    public Tuple<double, double, Altitude> RocCgClimbGradientTerminationAltitude(
      LinearDistance dObstacle,
      Altitude obstacleElevation,
      Altitude startMslElevation,
      LinearDistance dSobstacle)
    {
      dObstacle = dObstacle.ConvertTo(LinearDistanceUnits.NM);
      obstacleElevation = obstacleElevation.ConvertTo(AltitudeUnits.Feet);
      startMslElevation = startMslElevation.ConvertTo(AltitudeUnits.Feet);
      dSobstacle = dSobstacle.ConvertTo(LinearDistanceUnits.Feet);
      Altitude h = obstacleElevation - startMslElevation;
      return Tuple.Create<double, double, Altitude>(CalclateRoc(), CalclateCg(), CalclateCgTerminationAltitude());

      double CalclateRoc()
      {
        double a = h.Value / 0.76 - h.Value;
        if (dSobstacle.Value > 0.0)
          a -= dSobstacle.Value / 12.0;
        return Math.Ceiling(a);
      }

      double CalclateCg()
      {
        double radiusOfEarthInFeet = Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet;
        double num1 = radiusOfEarthInFeet + obstacleElevation.Value + CalclateRoc();
        double num2 = radiusOfEarthInFeet + startMslElevation.Value;
        return Math.Ceiling(radiusOfEarthInFeet / dObstacle.Value * Math.Log(num1 / num2));
      }

      Altitude CalclateCgTerminationAltitude() => new Altitude(100.0 * Math.Ceiling((obstacleElevation.Value + CalclateRoc()) / 100.0), AltitudeUnits.Feet);
    }

    public LinearDistance VaSegmentDistance(
      Altitude derElevation,
      Altitude turningAltitude,
      double? specifiedClimbGradient)
    {
      LinearDistance linearDistance = new LinearDistance(0.0, LinearDistanceUnits.Feet);
      derElevation = derElevation.ConvertTo(AltitudeUnits.Feet);
      turningAltitude = turningAltitude.ConvertTo(AltitudeUnits.Feet);
      double num1 = 200.0;
      if (specifiedClimbGradient.HasValue)
        num1 = specifiedClimbGradient.Value;
      double radiusOfEarthInFeet = Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet;
      double num2 = new LinearDistance(1.0, LinearDistanceUnits.NM).ConvertTo(LinearDistanceUnits.Feet).Value;
      double d = (radiusOfEarthInFeet + turningAltitude.Value) / (radiusOfEarthInFeet + derElevation.Value);
      linearDistance.Value = radiusOfEarthInFeet * num2 * Math.Log(d) / num1;
      return linearDistance;
    }

    public Altitude VaTerminationAltitude(
      Altitude derElevation,
      double climbGradient,
      LinearDistance vaSegmentDistance)
    {
      Altitude altitude = new Altitude(0.0, AltitudeUnits.Feet);
      derElevation = derElevation.ConvertTo(AltitudeUnits.Feet);
      vaSegmentDistance = vaSegmentDistance.ConvertTo(LinearDistanceUnits.NM);
      double a = ((Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet + derElevation.Value) * Math.Exp(climbGradient * vaSegmentDistance.Value / Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet) - Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet) / 100.0;
      altitude.Value = Math.Ceiling(a) * 100.0;
      return altitude;
    }

    public LinearDistance RnpArDta(Angle beta, LinearDistance radiusOfTurn)
    {
      radiusOfTurn = radiusOfTurn.ConvertTo(LinearDistanceUnits.NM);
      return new LinearDistance(MathFaa.Round(radiusOfTurn.Value * Math.Tan(Angle.DegreesToRadians(beta.AsDegrees() / 2.0)), 2), LinearDistanceUnits.NM);
    }
  }
}
