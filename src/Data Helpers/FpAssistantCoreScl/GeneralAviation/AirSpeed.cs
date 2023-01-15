// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.AirSpeed
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using System;
using System.Globalization;

namespace ArincReader.GeneralAviation
{
    public struct AirSpeed : IEquatable<AirSpeed>
    {
        private double _AirSpeedValue;
        private readonly AirSpeedUnits _AirSpeedUnits;

        public AirSpeed(double airSpeedValue, AirSpeedUnits airSpeedUnit)
        {
            this._AirSpeedValue = airSpeedValue;
            this._AirSpeedUnits = airSpeedUnit;
        }

        public double Value
        {
            get => this._AirSpeedValue;
            set => this._AirSpeedValue = value >= 0.0 ? value : throw new ArgumentOutOfRangeException(nameof(Value), "AirSpeed value should not be less than 0.0");
        }

        public AirSpeedUnits ValueUnit => this._AirSpeedUnits;

        public override string ToString() => AirSpeed.ToString((IFormatProvider)CultureInfo.CurrentCulture, this._AirSpeedValue.ToString((IFormatProvider)CultureInfo.CurrentCulture), this._AirSpeedUnits);

        public string ToString(string format) => AirSpeed.ToString((IFormatProvider)CultureInfo.CurrentCulture, this._AirSpeedValue.ToString(format), this._AirSpeedUnits);

        private static string ToString(
          IFormatProvider iFormatProvider,
          string airSpeedValue,
          AirSpeedUnits airSpeedUnits)
        {
            return string.Format(iFormatProvider, "{0} {1}", (object)airSpeedValue, (object)airSpeedUnits.GetDescription());
        }

        public LinearDistance RadiusOfTurn(Angle angleOfBank) => this.RadiusOfTurn(this.RateOfTurn(angleOfBank, false));

        public LinearDistance RadiusOfTurn(Angle angleOfBank, bool overide3DegreesLimit) => this.RadiusOfTurn(this.RateOfTurn(angleOfBank, overide3DegreesLimit));

        public LinearDistance RadiusOfTurn(double rateOfTurn) => AirSpeed.RadiusOfTurn(this, rateOfTurn);

        public static LinearDistance RadiusOfTurn(AirSpeed airspeed, double rateOfTurn)
        {
            if (rateOfTurn < 0.0)
                throw new ArgumentOutOfRangeException(nameof(rateOfTurn), "Rate of turn value should not be less than 0.0");
            double num = airspeed.Value / (20.0 * Math.PI * rateOfTurn);
            LinearDistance linearDistance = new LinearDistance(num, LinearDistanceUnits.KM);
            if (airspeed.ValueUnit == AirSpeedUnits.Kt)
                linearDistance = new LinearDistance(num, LinearDistanceUnits.NM);
            return linearDistance;
        }

        public double RateOfTurn(Angle angleOfBank, bool overide3DegreesLimit) => AirSpeed.RateOfTurn(this, angleOfBank, overide3DegreesLimit);

        public static double RateOfTurn(AirSpeed speed, Angle angleOfBank, bool overide3DegreesLimit)
        {
            double num1 = 0.0;
            switch (speed.ValueUnit)
            {
                case AirSpeedUnits.Kt:
                    num1 = 3431.0;
                    break;
                case AirSpeedUnits.Kph:
                    num1 = 6355.0;
                    break;
            }
            double num2 = num1 * Math.Tan(angleOfBank.AsRadians()) / (Math.PI * speed.Value);
            if (num2 > 3.0 && !overide3DegreesLimit)
                num2 = 3.0;
            return num2;
        }

        public bool Equals(AirSpeed other) => this._AirSpeedValue == other._AirSpeedValue && this._AirSpeedUnits == other._AirSpeedUnits;

        public override bool Equals(object obj) => obj is AirSpeed other && this.Equals(other);

        public override int GetHashCode() => (int)((AirSpeedUnits)this._AirSpeedValue.GetHashCode() ^ this._AirSpeedUnits);

        public static bool operator ==(AirSpeed left, AirSpeed right) => left.Equals(right);

        public static bool operator !=(AirSpeed left, AirSpeed right) => !(left == right);

        public static class Constants
        {
            public const double rateOfTurnKph = 6355.0;
            public const double rateOfTurnKts = 3431.0;
            public const double radiusOfTurn = 20.0;
        }
    }
}
