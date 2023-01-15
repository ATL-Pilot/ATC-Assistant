// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Vector3d
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;

namespace ArincReader.General
{
    public struct Vector3d : IEquatable<Vector3d>
    {
        private double _X;
        private double _Y;
        private double _Z;

        public Vector3d(double vectorX = 0.0, double vectorY = 0.0, double vectorZ = 0.0)
        {
            this._X = vectorX;
            this._Y = vectorY;
            this._Z = vectorZ;
        }

        public Vector3d(Point3d point1, Point3d point2)
          : this(point2.X - point1.X, point2.Y - point1.Y, point2.Z - point1.Z)
        {
        }

        public double X
        {
            get => this._X;
            set => this._X = value;
        }

        public double Y
        {
            get => this._Y;
            set => this._Y = value;
        }

        public double Z
        {
            get => this._Z;
            set => this._Z = value;
        }

        public double Magnitude => Math.Sqrt(this._X * this._X + this._Y * this._Y + this._Z * this._Z);

        public static Vector3d UnitVectorXAxis => new Vector3d(1.0);

        public static Vector3d UnitVectorYAxis => new Vector3d(vectorY: 1.0);

        public static Vector3d UnitVectorZAxis => new Vector3d(vectorZ: 1.0);

        public void Normalize()
        {
            double num1 = Math.Abs(this._X);
            double num2 = Math.Abs(this._Y);
            double num3 = Math.Abs(this._Z);
            if (num2 > num1)
                num1 = num2;
            if (num3 > num1)
                num1 = num3;
            this._X /= num1;
            this._Y /= num1;
            this._Z /= num1;
            double num4 = Math.Sqrt(this._X * this._X + this._Y * this._Y + this._Z * this._Z);
            this._X /= num4;
            this._Y /= num4;
            this._Z /= num4;
        }

        public Vector3d NormalizedCopy()
        {
            Vector3d vector3d = new Vector3d(this._X, this._Y, this._Z);
            vector3d.Normalize();
            return vector3d;
        }

        public double Gamma() => Vector3d.Gamma(this);

        public static double Gamma(Vector3d vector3d)
        {
            vector3d._Z = 0.0;
            return Vector3d.AngleBetween(vector3d, Vector3d.UnitVectorXAxis);
        }

        public static double AngleBetween(Vector3d vector1, Vector3d vector2)
        {
            vector1.Normalize();
            vector2.Normalize();
            return Vector3d.DotProduct(vector1, vector2) >= 0.0 ? 2.0 * Math.Asin((vector1 - vector2).Magnitude / 2.0) : Math.PI - 2.0 * Math.Asin((-vector1 - vector2).Magnitude / 2.0);
        }

        public static Vector3d operator -(Vector3d vector3d) => new Vector3d(-vector3d._X, -vector3d._Y, -vector3d._Z);

        public static Vector3d Negate(Vector3d vector3d) => -vector3d;

        public static Vector3d operator -(Vector3d vector1, Vector3d vector2) => new Vector3d(vector1._X - vector2._X, vector1._Y - vector2._Y, vector1._Z - vector2._Z);

        public static Vector3d Subtract(Vector3d vector1, Vector3d vector2) => vector1 - vector2;

        public static Vector3d operator +(Vector3d vector1, Vector3d vector2) => new Vector3d(vector1._X + vector2._X, vector1._Y + vector2._Y, vector1._Z + vector2._Z);

        public static Vector3d Add(Vector3d vector1, Vector3d vector2) => vector1 + vector2;

        public static Vector3d operator *(Vector3d vector1, Vector3d vector2) => new Vector3d(vector1.Y * vector2.Z - vector1.Z * vector2.Y, vector1.Z * vector2.X - vector1.X * vector2.Z, vector1.X * vector2.Y - vector1.Y * vector2.X);

        public static Vector3d Multiply(Vector3d left, Vector3d right) => left * right;

        public static Vector3d operator *(double scalar, Vector3d vector) => new Vector3d(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);

        public double DotProduct(Vector3d vector3d) => Vector3d.DotProduct(this, vector3d);

        public static double DotProduct(Vector3d vector3d1, Vector3d vector3d2) => Vector3d.DotProduct(ref vector3d1, ref vector3d2);

        internal static double DotProduct(ref Vector3d vector3d1, ref Vector3d vector3d2) => vector3d1._X * vector3d2._X + vector3d1._Y * vector3d2._Y + vector3d1._Z * vector3d2._Z;

        public bool Equals(Vector3d other) => this.X == other.X && this.Y == other.Y && this.Z == other.Z;

        public override bool Equals(object obj) => obj is Vector3d other && this.Equals(other);

        public override int GetHashCode() => this._X.GetHashCode() ^ this._Y.GetHashCode() ^ this._Z.GetHashCode();

        public static bool operator ==(Vector3d left, Vector3d right) => left.Equals(right);

        public static bool operator !=(Vector3d left, Vector3d right) => !(left == right);
    }
}
