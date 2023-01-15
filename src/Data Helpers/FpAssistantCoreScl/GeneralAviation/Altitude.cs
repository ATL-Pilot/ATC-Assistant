// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.Altitude
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using System;

namespace ArincReader.GeneralAviation
{
    public struct Altitude : IEquatable<Altitude>
    {
        private double _AltitudeValue;
        private readonly AltitudeUnits _AltitudeUnits;

        public Altitude(double altitudeValue, AltitudeUnits altitudeUnit)
        {
            this._AltitudeValue = altitudeValue;
            this._AltitudeUnits = altitudeUnit;
        }

        public double Value
        {
            get => this._AltitudeValue;
            set => this._AltitudeValue = value;
        }

        public AltitudeUnits ValueUnit => this._AltitudeUnits;

        public double AsMetres() => new LinearDistance(this._AltitudeValue, this.AsLinearDistanceUnits()).ConvertTo(LinearDistanceUnits.Metres).Value;

        public double AsFeet() => new LinearDistance(this._AltitudeValue, this.AsLinearDistanceUnits()).ConvertTo(LinearDistanceUnits.Feet).Value;

        public LinearDistance AsLinearDistance() => new LinearDistance(this._AltitudeValue, this.AsLinearDistanceUnits());

        private LinearDistanceUnits AsLinearDistanceUnits() => this._AltitudeUnits == AltitudeUnits.Metres ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet;

        public static LinearDistanceUnits AsLinearDistanceUnits(
          AltitudeUnits altitudeUnit)
        {
            if (altitudeUnit != AltitudeUnits.Feet && altitudeUnit != AltitudeUnits.Metres)
                throw new NotImplementedException("AltitudeUnits enum value is not currently supported in Altitude");
            return altitudeUnit == AltitudeUnits.Metres ? LinearDistanceUnits.Metres : LinearDistanceUnits.Feet;
        }

        public Altitude ConvertTo(AltitudeUnits altitudeUnitConvertTo)
        {
            Altitude altitude = new Altitude(0.0, altitudeUnitConvertTo);
            if (altitudeUnitConvertTo != AltitudeUnits.Feet)
            {
                if (altitudeUnitConvertTo != AltitudeUnits.Metres)
                    throw new NotImplementedException("AltitudeUnits enum value is not currently supported in Altitude");
                altitude.Value = this.AsMetres();
            }
            else
                altitude.Value = this.AsFeet();
            return altitude;
        }

        public static bool operator >(Altitude altitude1, Altitude altitude2)
        {
            Altitude altitude = new Altitude(altitude2.ConvertTo(altitude1.ValueUnit).Value, altitude1.ValueUnit);
            return altitude1.Value > altitude.Value;
        }

        public static bool operator <(Altitude altitude1, Altitude altitude2)
        {
            Altitude altitude = new Altitude(altitude2.ConvertTo(altitude1.ValueUnit).Value, altitude1.ValueUnit);
            return altitude1.Value < altitude.Value;
        }

        public static Altitude operator -(Altitude altitude1, Altitude altitude2)
        {
            Altitude altitude = new Altitude(altitude2.ConvertTo(altitude1.ValueUnit).Value, altitude1.ValueUnit);
            return new Altitude(altitude1.Value - altitude.Value, altitude1.ValueUnit);
        }

        public static Altitude Subtract(Altitude altitude1, Altitude altitude2) => altitude1 - altitude2;

        public static Altitude operator +(Altitude altitude1, Altitude altitude2)
        {
            Altitude altitude = new Altitude(altitude2.ConvertTo(altitude1.ValueUnit).Value, altitude1.ValueUnit);
            return new Altitude(altitude1.Value + altitude.Value, altitude1.ValueUnit);
        }

        public static Altitude Add(Altitude altitude1, Altitude altitude2) => altitude1 + altitude2;

        public override bool Equals(object obj) => obj != null && obj is Altitude altitude && this._AltitudeValue == altitude.Value && this._AltitudeUnits == altitude.ValueUnit;

        public override int GetHashCode() => (int)((AltitudeUnits)this._AltitudeValue.GetHashCode() ^ this._AltitudeUnits);

        public bool Equals(Altitude other) => this.Equals((object)other);

        public static bool operator ==(Altitude left, Altitude right) => left.Equals(right);

        public static bool operator !=(Altitude left, Altitude right) => !(left == right);
    }
}
