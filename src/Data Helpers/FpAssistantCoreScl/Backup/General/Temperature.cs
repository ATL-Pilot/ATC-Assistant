// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.Temperature
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;

namespace FpAssistantCore.General
{
  public struct Temperature
  {
    private double _Value;
    private readonly TemperatureUnits _TemperatureUnit;

    public Temperature(double value, TemperatureUnits temperatureUnit)
    {
      if (temperatureUnit != TemperatureUnits.Celsius && temperatureUnit != TemperatureUnits.Fahrenheit)
        throw new NotImplementedException("TemperatureUnits enum value is not currently supported in constructor");
      this._Value = value;
      this._TemperatureUnit = temperatureUnit;
    }

    public double Value
    {
      get => this._Value;
      set => this._Value = value;
    }

    public TemperatureUnits Unit => this._TemperatureUnit;

    public double AsDegreesCelsius()
    {
      double num = 0.0;
      switch (this._TemperatureUnit)
      {
        case TemperatureUnits.Celsius:
          num = this._Value;
          break;
        case TemperatureUnits.Fahrenheit:
          num = Temperature.ConvertDegreesFahrenheitToDegreesCelsius(this._Value);
          break;
      }
      return num;
    }

    public double AsDegreesFahrenheit()
    {
      double num = 0.0;
      switch (this._TemperatureUnit)
      {
        case TemperatureUnits.Celsius:
          num = Temperature.ConvertDegreesCelsiusToDegreesFahrenheit(this._Value);
          break;
        case TemperatureUnits.Fahrenheit:
          num = this._Value;
          break;
      }
      return num;
    }

    public static double ConvertDegreesCelsiusToDegreesFahrenheit(double celsius) => celsius * 9.0 / 5.0 + 32.0;

    public static double ConvertDegreesFahrenheitToDegreesCelsius(double Fahrenheit) => (Fahrenheit - 32.0) * 5.0 / 9.0;
  }
}
