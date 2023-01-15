// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Triangle2d
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;

namespace ArincReader.General
{
    public struct Triangle2d
    {
        public Triangle2d(Point2d point1, Point2d point2, Point2d point3)
        {
            this.Point1 = point1;
            this.Point2 = point2;
            this.Point3 = point3;
        }

        public Triangle2d(Point3d point1, Point3d point2, Point3d point3)
        {
            this.Point1 = new Point2d(point1.X, point1.Y);
            this.Point2 = new Point2d(point2.X, point2.Y);
            this.Point3 = new Point2d(point3.X, point3.Y);
        }

        public Point2d Point1 { get; set; }

        public Point2d Point2 { get; set; }

        public Point2d Point3 { get; set; }

        public bool IsInside(Point2d point) => Math.Abs(this.Area() - (new Triangle2d(point, this.Point2, this.Point3).Area() + new Triangle2d(point, this.Point1, this.Point3).Area() + new Triangle2d(point, this.Point1, this.Point2).Area())) < 1E-07;

        public bool IsInside(Point3d point) => this.IsInside(new Point2d(point.X, point.Y));

        public double Area()
        {
            double num1 = this.Point1.DistanceTo(this.Point2);
            double num2 = this.Point2.DistanceTo(this.Point3);
            double num3 = this.Point3.DistanceTo(this.Point1);
            double num4 = (num1 + num2 + num3) / 2.0;
            return Math.Sqrt(num4 * (num4 - num1) * (num4 - num2) * (num4 - num3));
        }
    }
}
