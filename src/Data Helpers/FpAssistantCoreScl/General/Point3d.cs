// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Point3d
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;

namespace ArincReader.General
{
    public struct Point3d
    {
        private double _X;
        private double _Y;
        private double _Z;

        public Point3d(double pointX, double pointY, double pointZ)
        {
            this._X = pointX;
            this._Y = pointY;
            this._Z = pointZ;
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

        public Point2d As2d() => new Point2d(this.X, this.Y);

        public static bool operator ==(Point3d point3d1, Point3d point3d2) => point3d1.X == point3d2.X && point3d1.Y == point3d2.Y && point3d1.Z == point3d2.Z;

        public static bool operator !=(Point3d point3d1, Point3d point3d2) => !(point3d1 == point3d2);

        public static bool Equals(Point3d point1, Point3d point2) => point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y) && point1.Z.Equals(point2.Z);

        public override bool Equals(object obj) => obj != null && obj is Point3d point2 && Point3d.Equals(this, point2);

        public bool Equals(Point3d point3d) => Point3d.Equals(this, point3d);

        public override int GetHashCode() => this._X.GetHashCode() ^ this._Y.GetHashCode() ^ this._Z.GetHashCode();

        public void Offset(double offsetX, double offsetY, double offsetZ)
        {
            this._X += offsetX;
            this._Y += offsetY;
            this._Z += offsetZ;
        }

        public double DistanceTo(Point3d point) => Point3d.DistanceBetween(this, point);

        public static double DistanceBetween(Point3d point1, Point3d point2) => Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y) + (point1.Z - point2.Z) * (point1.Z - point2.Z));

        public double Distance2dTo(Point3d point) => Point3d.Distance2dBetween(this, point);

        public static double Distance2dBetween(Point3d point1, Point3d point2) => Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));

        public static Point3d operator +(Point3d point, Vector3d vector) => new Point3d(point._X + vector.X, point._Y + vector.Y, point._Z + vector.Z);

        public static Point3d operator +(Point3d point1, Point3d point2) => new Point3d(point1._X + point2.X, point1._Y + point2.Y, point1._Z + point2.Z);

        public static Point3d operator -(Point3d point, Vector3d vector) => Point3d.Subtract(point, vector);

        public static Point3d Subtract(Point3d point, Vector3d vector) => new Point3d(point._X - vector.X, point._Y - vector.Y, point._Z - vector.Z);

        public static Point3d operator -(Vector3d vector, Point3d point) => Point3d.Subtract(vector, point);

        public static Point3d Subtract(Vector3d vector, Point3d point) => new Point3d(vector.X - point._X, vector.Y - point._Y, vector.Z - point._Z);

        public static Vector3d operator -(Point3d point1, Point3d point2) => Point3d.Subtract(point1, point2);

        public static Vector3d Subtract(Point3d point1, Point3d point2) => new Vector3d(point1._X - point2._X, point1._Y - point2._Y, point1._Z - point2._Z);

        public Point3d Rotate2DByDegrees(double degrees) => this.Rotate2DRadians(Angle.DegreesToRadians(degrees));

        public Point3d Rotate2DByRadians(double radians) => this.Rotate2DRadians(radians);

        public Point3d Rotate2DByAngle(Angle angle) => this.Rotate2DRadians(angle.AsRadians());

        private Point3d Rotate2DRadians(double radians) => new Point3d(this._X * Math.Cos(radians) - this._Y * Math.Sin(radians), this._X * Math.Sin(radians) + this._Y * Math.Cos(radians), this._Z);

        public Point3d GetMirror(Axes axis)
        {
            Point3d mirror = this;
            switch (axis)
            {
                case Axes.XAxis:
                    mirror.Y *= -1.0;
                    break;
                case Axes.YAxis:
                    mirror.X *= -1.0;
                    break;
                case Axes.ZAxis:
                    throw new ArgumentException("Unable to mirror point around Z-Axis", nameof(axis));
                default:
                    throw new ArgumentException("Invalid enum value", nameof(axis));
            }
            return mirror;
        }

        public Point3d GetTranslated(double deltaX, double deltaY)
        {
            Point3d translated = this;
            translated.Translate(deltaX, deltaY);
            return translated;
        }

        public void Translate(double deltaX, double deltaY)
        {
            this._X += deltaX;
            this._Y += deltaY;
        }

        public Point3d GetTranslated(double offset, Vector3d vector3d)
        {
            Point3d translated = this;
            translated.Translate(offset, vector3d);
            return translated;
        }

        public void Translate(double offset, Vector3d vector3d)
        {
            vector3d.Normalize();
            Vector3d offset1 = offset / vector3d.Magnitude * vector3d;
            Matrix3d matrix3d = new Matrix3d();
            matrix3d.Translate(offset1);
            Point3d point3d = matrix3d.Transform(this);
            this._X = point3d.X;
            this._Y = point3d.Y;
            this._Z = point3d.Z;
        }

        public void Translate(double offset, Angle cartesianAngle)
        {
            this._X += Math.Cos(cartesianAngle.AsRadians()) * offset;
            this._Y += Math.Sin(cartesianAngle.AsRadians()) * offset;
        }

        public Point3d GetTranslated(double offset, Angle cartesianAngle)
        {
            Point3d translated = this;
            translated.Translate(offset, cartesianAngle);
            return translated;
        }

        public void Translate(double offset, CompassBearing compassBearing) => this.Translate(offset, compassBearing.AsCartesianAngleDegrees());

        public Point3d GetTranslated(double offset, CompassBearing compassBearing)
        {
            Point3d translated = this;
            translated.Translate(offset, compassBearing.AsCartesianAngleDegrees());
            return translated;
        }

        public Point3d PointBetween(Point3d point2, double t01) => new Point3d(this.X + t01 * (point2.X - this.X), this.Y + t01 * (point2.Y - this.Y), this.Z + t01 * (point2.Z - this.Z));
    }
}
