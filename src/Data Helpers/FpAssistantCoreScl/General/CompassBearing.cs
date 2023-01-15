// Decompiled with JetBrains decompiler
// Type: ArincReader.General.CompassBearing
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;
using System.Diagnostics;

namespace ArincReader.General
{
    [DebuggerDisplay("{_Bearing}")]
    public struct CompassBearing : IEquatable<CompassBearing>
    {
        private double _Bearing;

        public CompassBearing(double bearing) => this._Bearing = CompassBearing.Normalize(bearing);

        public CompassBearing(double bearing, AngleUnits angleUnit)
          : this()
        {
            if (angleUnit != AngleUnits.Degrees)
            {
                if (angleUnit != AngleUnits.Radians)
                    return;
                this._Bearing = CompassBearing.Normalize(Angle.RadiansToDegrees(bearing));
            }
            else
                this._Bearing = CompassBearing.Normalize(bearing);
        }

        public double Bearing
        {
            get => this._Bearing;
            set => this._Bearing = CompassBearing.Normalize(value);
        }

        public override string ToString() => string.Format("{0}°", (object)this._Bearing);

        public Angle AsCartesianAngleDegrees() => (Angle)((450.0 - this._Bearing) % 360.0);

        public double AsDegrees() => this._Bearing;

        public double AsRadians() => Angle.DegreesToRadians(this._Bearing);

        public static double Normalize(double degrees)
        {
            degrees %= 360.0;
            while (degrees < 0.0)
                degrees += 360.0;
            return degrees;
        }

        public override bool Equals(object obj) => obj != null && obj is CompassBearing compassBearing && this._Bearing == compassBearing._Bearing;

        public bool Equals(CompassBearing other) => this.Equals((object)other);

        public static bool operator ==(CompassBearing a1, CompassBearing a2) => a1.Equals(a2);

        public static bool operator !=(CompassBearing a1, CompassBearing a2) => !(a1 == a2);

        public static CompassBearing operator +(CompassBearing left, CompassBearing right) => new CompassBearing(left.Bearing + right.Bearing);

        public static CompassBearing operator +(
          CompassBearing compassBearing,
          double angleChange)
        {
            return compassBearing + new CompassBearing(angleChange);
        }

        public static CompassBearing Add(CompassBearing left, CompassBearing right) => left + right;

        public static CompassBearing operator -(CompassBearing left, CompassBearing right) => new CompassBearing(left.Bearing - right.Bearing);

        public static CompassBearing operator -(
          CompassBearing compassBearing,
          double angleChange)
        {
            return compassBearing - new CompassBearing(angleChange);
        }

        public static CompassBearing Subtract(CompassBearing left, CompassBearing right) => left - right;

        public override int GetHashCode() => this._Bearing.GetHashCode();
    }
}
