// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Point2d
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;

namespace ArincReader.General
{
    public struct Point2d
    {
        public Point2d(double pointX, double pointY)
        {
            this.X = pointX;
            this.Y = pointY;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public Point3d As3d() => new Point3d(this.X, this.Y, 0.0);

        public Point3d As3d(double z) => new Point3d(this.X, this.Y, z);

        public double DistanceTo(Point2d point) => Point2d.DistanceBetween(this, point);

        public double AngleTo(Point2d point) => Angle.RadiansToDegrees(Math.Atan2(point.Y - this.Y, point.X - this.X));

        public static double DistanceBetween(Point2d point1, Point2d point2) => Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));

        public static bool operator ==(Point2d point1, Point2d point2) => point1.X == point2.X && point1.Y == point2.Y;

        public static bool operator !=(Point2d point1, Point2d point2) => !(point1 == point2);

        public static bool Equals(Point2d point1, Point2d point2) => point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y);

        public override bool Equals(object obj) => obj != null && obj is Point2d point2 && Point2d.Equals(this, point2);

        public bool Equals(Point2d point2d) => object.Equals((object)this, (object)point2d);

        public override int GetHashCode()
        {
            double num = this.X;
            int hashCode1 = num.GetHashCode();
            num = this.Y;
            int hashCode2 = num.GetHashCode();
            return hashCode1 ^ hashCode2;
        }
    }
}
