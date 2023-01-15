// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Angle
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;
using System.Diagnostics;

namespace ArincReader.General
{
    [DebuggerDisplay("{_Degrees}")]
    public struct Angle : IEquatable<Angle>
    {
        private readonly double _Degrees;

        public Angle(double degrees)
          : this()
        {
            this._Degrees = Angle.Normalize(degrees);
        }

        public Angle(double angleValue, AngleUnits angleUnit)
          : this()
        {
            if (angleUnit != AngleUnits.Degrees)
            {
                if (angleUnit != AngleUnits.Radians)
                    return;
                this._Degrees = Angle.Normalize(Angle.RadiansToDegrees(angleValue));
            }
            else
                this._Degrees = Angle.Normalize(angleValue);
        }

        public Angle(int degrees, int minutes, double seconds) => this._Degrees = Angle.Normalize((double)degrees + (double)minutes / 60.0 + seconds / 3600.0);

        public double AsDegrees() => this._Degrees;

        public double AsRadians() => Angle.DegreesToRadians(this._Degrees);

        public CompassBearing AsCompassBearing() => new CompassBearing((450.0 - this._Degrees) % 360.0);

        public double TotalSeconds => this._Degrees * 3600.0;

        public override bool Equals(object obj) => obj != null && obj is Angle angle && this._Degrees == angle._Degrees;

        public bool Equals(Angle other) => this.Equals((object)other);

        public static bool operator ==(Angle a1, Angle a2) => a1.Equals(a2);

        public override int GetHashCode() => this._Degrees.GetHashCode();

        public static bool operator !=(Angle a1, Angle a2) => !(a1 == a2);

        public static double DegreesToRadians(double degrees) => degrees * Math.PI / 180.0;

        public static double RadiansToDegrees(double radians) => radians * 180.0 / Math.PI;

        public static Angle FromDegrees(double degrees) => new Angle(Angle.Normalize(degrees));

        public static Angle FromRadians(double radians) => new Angle(Angle.RadiansToDegrees(radians));

        public static double Normalize(double degrees)
        {
            degrees %= 360.0;
            return degrees;
        }

        public static implicit operator Angle(double degrees) => new Angle(degrees);

        public static implicit operator double(Angle angle) => angle._Degrees;

        public static double CompassToCartesianDegrees(double angleDegrees) => Angle.RadiansToDegrees(Angle.CompassToCartesianRadians(Angle.DegreesToRadians(angleDegrees)));

        public static double CartesianToCompassDegrees(double angleDegrees) => Angle.RadiansToDegrees(Angle.CartesianToCompassRadians(Angle.DegreesToRadians(angleDegrees)));

        public static double CompassToCartesianRadians(double angleRadians) => Angle.CartesianToCompassRadians(angleRadians) % (2.0 * Math.PI);

        public static double CartesianToCompassRadians(double angleRadians)
        {
            double compassRadians = 5.0 * Math.PI / 2.0 - angleRadians;
            if (compassRadians >= 2.0 * Math.PI)
                compassRadians %= 2.0 * Math.PI;
            return compassRadians;
        }
    }
}
