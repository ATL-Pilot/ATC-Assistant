// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.GradientSlopeCalculator
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;

namespace FpAssistantCore.GeneralAviation
{
  public struct GradientSlopeCalculator
  {
    private LinearDistance _VerticalDistance;
    private LinearDistance _HorizontalDistance;
    private double _PercentageGradient;
    private double _SlopeDegrees;

    public GradientSlopeCalculator(
      LinearDistanceUnits horizontalDistanceUnit,
      LinearDistanceUnits verticalDistanceUnit)
      : this()
    {
      this._VerticalDistance = new LinearDistance(0.0, verticalDistanceUnit);
      this._HorizontalDistance = new LinearDistance(0.0, horizontalDistanceUnit);
    }

    public double GradientPercentage
    {
      get => this._PercentageGradient;
      set => this._PercentageGradient = value;
    }

    public LinearDistance HorizontalDistance
    {
      get => this._HorizontalDistance;
      set => this._HorizontalDistance = value;
    }

    public LinearDistance VerticalDistance
    {
      get => this._VerticalDistance;
      set => this._VerticalDistance = value;
    }

    public double SlopeDegrees => this._SlopeDegrees;

    public void CalculateGradient()
    {
      if (this._HorizontalDistance.Value <= 0.0)
        throw new ArgumentOutOfRangeException("Distance value must be greater than 0.0");
      this._PercentageGradient = (this._VerticalDistance / this._HorizontalDistance).Value * 100.0;
      this._SlopeDegrees = Math.Atan((this._VerticalDistance / this._HorizontalDistance).Value) * (180.0 / Math.PI);
    }

    public void CalculateElevationChange()
    {
      if (this._PercentageGradient <= 0.0)
        throw new ArgumentOutOfRangeException("Gradient percentage must be greater than 0.0");
      if (this._HorizontalDistance.Value <= 0.0)
        throw new ArgumentOutOfRangeException("Distance value must be greater than 0.0");
      this._VerticalDistance.Value = this._HorizontalDistance.ConvertTo(this._VerticalDistance.ValueUnit).Value / 100.0 * this._PercentageGradient;
      this._SlopeDegrees = Math.Atan((this._VerticalDistance / this._HorizontalDistance).Value) * (180.0 / Math.PI);
    }

    public void CalculateDistance()
    {
      this._HorizontalDistance.Value = this._VerticalDistance.ConvertTo(this._HorizontalDistance.ValueUnit).Value / this._PercentageGradient * 100.0;
      this._SlopeDegrees = Math.Atan((this._VerticalDistance / this._HorizontalDistance).Value) * (180.0 / Math.PI);
    }

    public static double PercentageDistance(double distance, double percentage)
    {
      if (percentage < 0.0 || percentage > 100.0)
        throw new ArgumentOutOfRangeException(nameof (percentage), "Percentage must be greater than 0 and not greater than 100");
      return percentage / 100.0 * distance;
    }

    public static double DistanceFromHeightAndPercentage(double height, double percentage)
    {
      GradientSlopeCalculator gradientSlopeCalculator = percentage >= 0.0 && percentage <= 100.0 ? new GradientSlopeCalculator(LinearDistanceUnits.Metres, LinearDistanceUnits.Metres)
      {
        GradientPercentage = percentage,
        VerticalDistance = new LinearDistance(height, LinearDistanceUnits.Metres)
      } : throw new ArgumentOutOfRangeException(nameof (percentage), "Percentage must be greater than 0 and not greater than 100");
      gradientSlopeCalculator.CalculateDistance();
      return gradientSlopeCalculator.HorizontalDistance.Value;
    }
  }
}
