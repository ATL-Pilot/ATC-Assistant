// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.LinearDistance
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.GeneralAviation;
using FpAssistantCore.Geographical;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace FpAssistantCore.General
{
  public struct LinearDistance : IEquatable<LinearDistance>
  {
    private double _LinearDistanceValue;
    private readonly LinearDistanceUnits _LinearDistanceUnit;
    private int _PrecisionFeet;
    private int _PrecisionKilometres;
    private int _PrecisionMetres;
    private int _PrecisionNauticalMiles;

    [JsonConstructor]
    public LinearDistance(double value, LinearDistanceUnits valueUnit)
    {
      this._LinearDistanceValue = value;
      this._LinearDistanceUnit = valueUnit;
      this._PrecisionFeet = 2;
      this._PrecisionKilometres = 5;
      this._PrecisionMetres = 2;
      this._PrecisionNauticalMiles = 5;
    }

    public LinearDistance(double linearDistanceValue, AltitudeUnits altitudeUnit)
      : this(linearDistanceValue, Altitude.AsLinearDistanceUnits(altitudeUnit))
    {
    }

    public LinearDistance(double linearDistanceValue, CoordinateSystemUnits coordinateSystemUnits)
    {
      LinearDistanceUnits linearDistanceUnits = LinearDistanceUnits.Feet;
      if (coordinateSystemUnits != CoordinateSystemUnits.Metres)
      {
        if (coordinateSystemUnits != CoordinateSystemUnits.Feet)
          throw new NotImplementedException("CoordinateSystemUnits enum value is not currently supported in LinearDistance struct constructor");
      }
      else
        linearDistanceUnits = LinearDistanceUnits.Metres;
      this._LinearDistanceValue = linearDistanceValue;
      this._LinearDistanceUnit = linearDistanceUnits;
      this._PrecisionFeet = 2;
      this._PrecisionKilometres = 5;
      this._PrecisionMetres = 2;
      this._PrecisionNauticalMiles = 5;
    }

    public LinearDistance(string linearDistanceValue)
      : this()
    {
      this._PrecisionFeet = 2;
      this._PrecisionKilometres = 5;
      this._PrecisionMetres = 2;
      this._PrecisionNauticalMiles = 5;
      string str1 = linearDistanceValue;
      if (string.IsNullOrEmpty(str1))
        return;
      string s = str1.Trim().ToLower().Replace(" ", "");
      Dictionary<string, LinearDistanceUnits> dictionary = new Dictionary<string, LinearDistanceUnits>();
      dictionary.Add("km", LinearDistanceUnits.KM);
      dictionary.Add("k", LinearDistanceUnits.KM);
      dictionary.Add("kilometres", LinearDistanceUnits.KM);
      dictionary.Add("kilometre", LinearDistanceUnits.KM);
      dictionary.Add("kilometers", LinearDistanceUnits.KM);
      dictionary.Add("kilometer", LinearDistanceUnits.KM);
      dictionary.Add("m", LinearDistanceUnits.Metres);
      dictionary.Add("metres", LinearDistanceUnits.Metres);
      dictionary.Add("meters", LinearDistanceUnits.Metres);
      dictionary.Add("meter", LinearDistanceUnits.Metres);
      dictionary.Add("metre", LinearDistanceUnits.Metres);
      dictionary.Add("mt", LinearDistanceUnits.Metres);
      dictionary.Add("f", LinearDistanceUnits.Feet);
      dictionary.Add("feet", LinearDistanceUnits.Feet);
      dictionary.Add("ft", LinearDistanceUnits.Feet);
      dictionary.Add("nm", LinearDistanceUnits.NM);
      dictionary.Add("n", LinearDistanceUnits.NM);
      dictionary.Add("naut", LinearDistanceUnits.NM);
      dictionary.Add("nautical", LinearDistanceUnits.NM);
      LinearDistanceUnits? nullable = new LinearDistanceUnits?();
      foreach (KeyValuePair<string, LinearDistanceUnits> keyValuePair in dictionary)
      {
        string oldValue = s.Substring(Math.Max(0, s.Length - keyValuePair.Key.Length));
        string str2 = s.Substring(0, Math.Max(0, s.Length - keyValuePair.Key.Length));
        char c = (double) str2.Length > 0.0 ? str2[str2.Length - 1] : char.MinValue;
        if (oldValue == keyValuePair.Key && char.IsDigit(c))
        {
          nullable = new LinearDistanceUnits?(keyValuePair.Value);
          s = s.Replace(oldValue, "");
          break;
        }
      }
      if (!nullable.HasValue)
        throw new FormatException("Invalid argument:" + linearDistanceValue);
      double result;
      if (!double.TryParse(s, NumberStyles.Any, (IFormatProvider) CultureInfo.CurrentCulture, out result))
        throw new FormatException("Invalid argument:" + linearDistanceValue);
      this._LinearDistanceValue = result;
      this._LinearDistanceUnit = nullable.Value;
    }

    public double Value
    {
      get => this._LinearDistanceValue;
      set => this._LinearDistanceValue = value;
    }

    public LinearDistanceUnits ValueUnit => this._LinearDistanceUnit;

    public void PrecisionNauticalMiles(int value) => this._PrecisionNauticalMiles = value;

    public void PrecisionKilometres(int value) => this._PrecisionKilometres = value;

    public void PrecisionFeet(int value) => this._PrecisionFeet = value;

    public void PrecisionMetres(int value) => this._PrecisionMetres = value;

    public LinearDistance ConvertTo(
      CoordinateSystemUnits CoordinateSystemUnitConvertTo)
    {
      LinearDistanceUnits linearDistanceUnit_ConvertTo = LinearDistanceUnits.Metres;
      if (CoordinateSystemUnitConvertTo != CoordinateSystemUnits.Metres)
      {
        if (CoordinateSystemUnitConvertTo != CoordinateSystemUnits.Feet)
          throw new NotImplementedException("CoordinateSystemUnits enum value is not currently supported in ConvertTo() in LinearDistance struct");
        linearDistanceUnit_ConvertTo = LinearDistanceUnits.Feet;
      }
      return this.ConvertTo(linearDistanceUnit_ConvertTo);
    }

    public LinearDistance ConvertTo(CriteriaUnits criteriaUnit)
    {
      switch (this._LinearDistanceUnit)
      {
        case LinearDistanceUnits.KM:
          return criteriaUnit != CriteriaUnits.Si ? this.ConvertTo(LinearDistanceUnits.NM) : this;
        case LinearDistanceUnits.Metres:
          return criteriaUnit != CriteriaUnits.Si ? this.ConvertTo(LinearDistanceUnits.Feet) : this;
        case LinearDistanceUnits.NM:
          return criteriaUnit != CriteriaUnits.NonSi ? this.ConvertTo(LinearDistanceUnits.KM) : this;
        case LinearDistanceUnits.Feet:
          return criteriaUnit != CriteriaUnits.NonSi ? this.ConvertTo(LinearDistanceUnits.Metres) : this;
        default:
          throw new NotImplementedException("LinearDistanceUnit enum value is not currently supported in ConvertTo() in LinearDistance struct");
      }
    }

    public LinearDistance ConvertTo(LinearDistanceUnits linearDistanceUnit_ConvertTo)
    {
      LinearDistance linearDistance = new LinearDistance(0.0, linearDistanceUnit_ConvertTo);
      switch (linearDistanceUnit_ConvertTo)
      {
        case LinearDistanceUnits.KM:
          switch (this._LinearDistanceUnit)
          {
            case LinearDistanceUnits.KM:
              linearDistance.Value = this._LinearDistanceValue;
              break;
            case LinearDistanceUnits.Metres:
              linearDistance.Value = this._LinearDistanceValue / Constants.MetresInKilometres;
              break;
            case LinearDistanceUnits.NM:
              linearDistance.Value = this._LinearDistanceValue * Constants.IcaoAnnex5.MetresInNauticalMile / Constants.MetresInKilometres;
              break;
            case LinearDistanceUnits.Feet:
              linearDistance.Value = this._LinearDistanceValue * Constants.IcaoAnnex5.MetresInFeet / Constants.MetresInKilometres;
              break;
          }
          break;
        case LinearDistanceUnits.Metres:
          switch (this._LinearDistanceUnit)
          {
            case LinearDistanceUnits.KM:
              linearDistance.Value = this._LinearDistanceValue * Constants.MetresInKilometres;
              break;
            case LinearDistanceUnits.Metres:
              linearDistance.Value = this._LinearDistanceValue;
              break;
            case LinearDistanceUnits.NM:
              linearDistance.Value = this._LinearDistanceValue * Constants.IcaoAnnex5.MetresInNauticalMile;
              break;
            case LinearDistanceUnits.Feet:
              linearDistance.Value = this._LinearDistanceValue * Constants.IcaoAnnex5.MetresInFeet;
              break;
          }
          break;
        case LinearDistanceUnits.NM:
          switch (this._LinearDistanceUnit)
          {
            case LinearDistanceUnits.KM:
              linearDistance.Value = this._LinearDistanceValue * Constants.MetresInKilometres / Constants.IcaoAnnex5.MetresInNauticalMile;
              break;
            case LinearDistanceUnits.Metres:
              linearDistance.Value = this._LinearDistanceValue * (1.0 / Constants.IcaoAnnex5.MetresInNauticalMile);
              break;
            case LinearDistanceUnits.NM:
              linearDistance.Value = this._LinearDistanceValue;
              break;
            case LinearDistanceUnits.Feet:
              linearDistance.Value = this._LinearDistanceValue * Constants.IcaoAnnex5.MetresInFeet / Constants.IcaoAnnex5.MetresInNauticalMile;
              break;
          }
          break;
        case LinearDistanceUnits.Feet:
          switch (this._LinearDistanceUnit)
          {
            case LinearDistanceUnits.KM:
              linearDistance.Value = this._LinearDistanceValue * Constants.MetresInKilometres / Constants.IcaoAnnex5.MetresInFeet;
              break;
            case LinearDistanceUnits.Metres:
              linearDistance.Value = this._LinearDistanceValue * (1.0 / Constants.IcaoAnnex5.MetresInFeet);
              break;
            case LinearDistanceUnits.NM:
              linearDistance.Value = this._LinearDistanceValue * Constants.FeetInNauticalMile;
              break;
            case LinearDistanceUnits.Feet:
              linearDistance.Value = this._LinearDistanceValue;
              break;
          }
          break;
      }
      return linearDistance;
    }

    public Altitude AsAltitude()
    {
      LinearDistance linearDistance = new LinearDistance(this.Value, this.ValueUnit);
      switch (this.ValueUnit)
      {
        case LinearDistanceUnits.KM:
          return new Altitude(linearDistance.ConvertTo(LinearDistanceUnits.Metres).Value, AltitudeUnits.Metres);
        case LinearDistanceUnits.Metres:
          return new Altitude(linearDistance.Value, AltitudeUnits.Metres);
        case LinearDistanceUnits.NM:
          return new Altitude(linearDistance.ConvertTo(LinearDistanceUnits.Feet).Value, AltitudeUnits.Feet);
        case LinearDistanceUnits.Feet:
          return new Altitude(linearDistance.Value, AltitudeUnits.Feet);
        default:
          throw new NotImplementedException("LinearDistanceUnit enum value is not currently supported in AsAltitude() in LinearDistance struct");
      }
    }

    public override int GetHashCode() => (int) ((LinearDistanceUnits) this._LinearDistanceValue.GetHashCode() ^ this._LinearDistanceUnit);

    public override bool Equals(object obj) => obj is LinearDistance linearDistance && this == linearDistance;

    public bool Equals(LinearDistance other) => this.Equals((object) other);

    public static bool operator ==(LinearDistance linearDistance1, LinearDistance linearDistance2)
    {
      int digits = 8;
      return Math.Round(linearDistance1.Value, digits) == Math.Round(linearDistance2.Value, digits) && linearDistance1._LinearDistanceUnit == linearDistance2._LinearDistanceUnit;
    }

    public static bool operator !=(LinearDistance linearDistance1, LinearDistance linearDistance2) => !(linearDistance1 == linearDistance2);

    public static LinearDistance operator /(
      LinearDistance linearDistance1,
      LinearDistance linearDistance2)
    {
      LinearDistance linearDistance = new LinearDistance(linearDistance2.ConvertTo(linearDistance1.ValueUnit).Value, linearDistance1.ValueUnit);
      return new LinearDistance(linearDistance1.Value / linearDistance.Value, linearDistance1.ValueUnit);
    }

    public static LinearDistance operator /(
      LinearDistance linearDistance,
      int distance)
    {
      return new LinearDistance(linearDistance.Value / (double) distance, linearDistance.ValueUnit);
    }

    public static LinearDistance operator /(
      LinearDistance linearDistance,
      double distance)
    {
      return new LinearDistance(linearDistance.Value / distance, linearDistance.ValueUnit);
    }

    public static LinearDistance Divide(
      LinearDistance linearDistance1,
      LinearDistance linearDistance2)
    {
      return linearDistance1 / linearDistance2;
    }

    public static LinearDistance operator *(
      LinearDistance linearDistance1,
      LinearDistance linearDistance2)
    {
      LinearDistance linearDistance = new LinearDistance(linearDistance2.ConvertTo(linearDistance1.ValueUnit).Value, linearDistance1.ValueUnit);
      return new LinearDistance(linearDistance1.Value * linearDistance.Value, linearDistance1.ValueUnit);
    }

    public static LinearDistance operator *(
      LinearDistance linearDistance,
      double distance)
    {
      return new LinearDistance(linearDistance.Value * distance, linearDistance.ValueUnit);
    }

    public static LinearDistance Multiply(
      LinearDistance linearDistance1,
      LinearDistance linearDistance2)
    {
      return linearDistance1 * linearDistance2;
    }

    public static LinearDistance operator -(
      LinearDistance linearDistance1,
      LinearDistance linearDistance2)
    {
      LinearDistance linearDistance = new LinearDistance(linearDistance2.ConvertTo(linearDistance1.ValueUnit).Value, linearDistance1.ValueUnit);
      return new LinearDistance(linearDistance1.Value - linearDistance.Value, linearDistance1.ValueUnit);
    }

    public static LinearDistance Subtract(
      LinearDistance linearDistance1,
      LinearDistance linearDistance2)
    {
      return linearDistance1 - linearDistance2;
    }

    public static LinearDistance operator +(
      LinearDistance linearDistance1,
      LinearDistance linearDistance2)
    {
      LinearDistance linearDistance = new LinearDistance(linearDistance2.ConvertTo(linearDistance1.ValueUnit).Value, linearDistance1.ValueUnit);
      return new LinearDistance(linearDistance1.Value + linearDistance.Value, linearDistance1.ValueUnit);
    }

    public static LinearDistance Add(LinearDistance left, LinearDistance right) => left + right;

    public static LinearDistance operator +(
      LinearDistance linearDistance,
      int distance)
    {
      return new LinearDistance(linearDistance.Value + (double) distance, linearDistance.ValueUnit);
    }

    public static LinearDistance operator +(
      LinearDistance linearDistance,
      double distance)
    {
      return new LinearDistance(linearDistance.Value + distance, linearDistance.ValueUnit);
    }

    public static bool operator >(LinearDistance linearDistance1, LinearDistance linearDistance2)
    {
      LinearDistance linearDistance = new LinearDistance(linearDistance2.ConvertTo(linearDistance1.ValueUnit).Value, linearDistance1.ValueUnit);
      return linearDistance1.Value > linearDistance.Value;
    }

    public static bool operator <(LinearDistance linearDistance1, LinearDistance linearDistance2)
    {
      LinearDistance linearDistance = new LinearDistance(linearDistance2.ConvertTo(linearDistance1.ValueUnit).Value, linearDistance1.ValueUnit);
      return linearDistance1.Value < linearDistance.Value;
    }

    public static explicit operator LinearDistance(Altitude altitude)
    {
      LinearDistance linearDistance = new LinearDistance();
      switch (altitude.ValueUnit)
      {
        case AltitudeUnits.Feet:
          linearDistance = new LinearDistance(altitude.Value, LinearDistanceUnits.Feet);
          break;
        case AltitudeUnits.Metres:
          linearDistance = new LinearDistance(altitude.Value, LinearDistanceUnits.Metres);
          break;
      }
      return linearDistance;
    }

    public static double FeetToMetres(double feet)
    {
      LinearDistance linearDistance = new LinearDistance(feet, LinearDistanceUnits.Feet);
      linearDistance = linearDistance.ConvertTo(LinearDistanceUnits.Metres);
      return linearDistance.Value;
    }

    public static double MetresToFeet(double metres)
    {
      LinearDistance linearDistance = new LinearDistance(metres, LinearDistanceUnits.Metres);
      linearDistance = linearDistance.ConvertTo(LinearDistanceUnits.Feet);
      return linearDistance.Value;
    }

    public static double FeetToNM(double feet)
    {
      LinearDistance linearDistance = new LinearDistance(feet, LinearDistanceUnits.Feet);
      linearDistance = linearDistance.ConvertTo(LinearDistanceUnits.NM);
      return linearDistance.Value;
    }

    public static double NMToFeet(double nm)
    {
      LinearDistance linearDistance = new LinearDistance(nm, LinearDistanceUnits.NM);
      linearDistance = linearDistance.ConvertTo(LinearDistanceUnits.Feet);
      return linearDistance.Value;
    }

    public static double NMToMetres(double nm)
    {
      LinearDistance linearDistance = new LinearDistance(nm, LinearDistanceUnits.NM);
      linearDistance = linearDistance.ConvertTo(LinearDistanceUnits.Metres);
      return linearDistance.Value;
    }

    public static double MetresToNM(double metres)
    {
      LinearDistance linearDistance = new LinearDistance(metres, LinearDistanceUnits.Metres);
      linearDistance = linearDistance.ConvertTo(LinearDistanceUnits.NM);
      return linearDistance.Value;
    }

    public static LinearDistance ZeroMetres() => new LinearDistance(0.0, LinearDistanceUnits.Metres);

    [JsonIgnore]
    public bool IsSi => this._LinearDistanceUnit == LinearDistanceUnits.KM || this._LinearDistanceUnit == LinearDistanceUnits.Metres;

    public override string ToString() => this.ToString(LinearDistanceFormat.NoneWithUnitPostfix);

    public string ToString(LinearDistanceFormat linearDistanceFormat) => this.ToString((IFormatProvider) CultureInfo.CurrentCulture, linearDistanceFormat);

    public string ToString(IFormatProvider provider, LinearDistanceFormat linearDistanceFormat)
    {
      string str = string.Empty;
      switch (linearDistanceFormat)
      {
        case LinearDistanceFormat.None:
        case LinearDistanceFormat.NoneWithUnitPostfix:
          str = this._LinearDistanceValue.ToString(provider);
          if (linearDistanceFormat == LinearDistanceFormat.NoneWithUnitPostfix)
          {
            str = this.AppendUnitType(str);
            break;
          }
          break;
        case LinearDistanceFormat.InternalPrecision:
        case LinearDistanceFormat.InternalPrecisionWithUnitPostfix:
          switch (this._LinearDistanceUnit)
          {
            case LinearDistanceUnits.KM:
              str = this.FormatString(this._PrecisionKilometres);
              break;
            case LinearDistanceUnits.Metres:
              str = this.FormatString(this._PrecisionMetres);
              break;
            case LinearDistanceUnits.NM:
              str = this.FormatString(this._PrecisionNauticalMiles);
              break;
            case LinearDistanceUnits.Feet:
              str = this.FormatString(this._PrecisionFeet);
              break;
          }
          if (linearDistanceFormat == LinearDistanceFormat.InternalPrecisionWithUnitPostfix)
          {
            str = this.AppendUnitType(str);
            break;
          }
          break;
      }
      return str;
    }

    private string AppendUnitType(string value)
    {
      string str = string.Empty;
      switch (this._LinearDistanceUnit)
      {
        case LinearDistanceUnits.KM:
          str = " km";
          break;
        case LinearDistanceUnits.Metres:
          str = " m";
          break;
        case LinearDistanceUnits.NM:
          str = " NM";
          break;
        case LinearDistanceUnits.Feet:
          str = " ft";
          break;
      }
      return value + str;
    }

    private string FormatString(int decimalPlaces) => string.Format("{0:f" + decimalPlaces.ToString() + "}", (object) Math.Round(this._LinearDistanceValue, decimalPlaces));
  }
}
