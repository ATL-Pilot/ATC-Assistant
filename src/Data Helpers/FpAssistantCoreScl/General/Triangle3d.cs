// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Triangle3d
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;

namespace ArincReader.General
{
    public struct Triangle3d
    {
        public Triangle3d(Point3d point1, Point3d point2, Point3d point3)
        {
            this.Point1 = point1;
            this.Point2 = point2;
            this.Point3 = point3;
        }

        public Triangle3d(Point2d point1, Point2d point2, Point2d point3)
        {
            this.Point1 = new Point3d(point1.X, point1.Y, 0.0);
            this.Point2 = new Point3d(point2.X, point2.Y, 0.0);
            this.Point3 = new Point3d(point3.X, point3.Y, 0.0);
        }

        public Point3d Point1 { get; set; }

        public Point3d Point2 { get; set; }

        public Point3d Point3 { get; set; }

        public double Zmin
        {
            get
            {
                Point3d point3d = this.Point1;
                double z1 = point3d.Z;
                point3d = this.Point2;
                double z2 = point3d.Z;
                point3d = this.Point3;
                double z3 = point3d.Z;
                double val2 = Math.Min(z2, z3);
                return Math.Min(z1, val2);
            }
        }

        public double Zmax
        {
            get
            {
                Point3d point3d = this.Point1;
                double z1 = point3d.Z;
                point3d = this.Point2;
                double z2 = point3d.Z;
                point3d = this.Point3;
                double z3 = point3d.Z;
                double val2 = Math.Max(z2, z3);
                return Math.Max(z1, val2);
            }
        }

        public double Ymin
        {
            get
            {
                Point3d point3d = this.Point1;
                double y1 = point3d.Y;
                point3d = this.Point2;
                double y2 = point3d.Y;
                point3d = this.Point3;
                double y3 = point3d.Y;
                double val2 = Math.Min(y2, y3);
                return Math.Min(y1, val2);
            }
        }

        public double Ymax
        {
            get
            {
                Point3d point3d = this.Point1;
                double y1 = point3d.Y;
                point3d = this.Point2;
                double y2 = point3d.Y;
                point3d = this.Point3;
                double y3 = point3d.Y;
                double val2 = Math.Max(y2, y3);
                return Math.Max(y1, val2);
            }
        }

        public double Xmin
        {
            get
            {
                Point3d point3d = this.Point1;
                double x1 = point3d.X;
                point3d = this.Point2;
                double x2 = point3d.X;
                point3d = this.Point3;
                double x3 = point3d.X;
                double val2 = Math.Min(x2, x3);
                return Math.Min(x1, val2);
            }
        }

        public double Xmax
        {
            get
            {
                Point3d point3d = this.Point1;
                double x1 = point3d.X;
                point3d = this.Point2;
                double x2 = point3d.X;
                point3d = this.Point3;
                double x3 = point3d.X;
                double val2 = Math.Max(x2, x3);
                return Math.Max(x1, val2);
            }
        }

        public Vector3d Normal
        {
            get
            {
                Vector3d normal = new Vector3d(this.Point1, this.Point2) * new Vector3d(this.Point1, this.Point3);
                normal.Normalize();
                return normal;
            }
        }

        public bool IsInsideOn2D(Point2d point)
        {
            Point2d point2d1 = this.Point1.As2d();
            Point2d point2d2 = this.Point2.As2d();
            Point2d point3 = this.Point3.As2d();
            Triangle2d triangle2d = new Triangle2d(point2d1, point2d2, point3);
            double num1 = triangle2d.Area();
            triangle2d = new Triangle2d(point, point2d2, point3);
            double num2 = triangle2d.Area();
            triangle2d = new Triangle2d(point, point2d1, point3);
            double num3 = triangle2d.Area();
            triangle2d = new Triangle2d(point, point2d1, point2d2);
            double num4 = triangle2d.Area();
            double num5 = num2 + num3 + num4;
            return Math.Abs(num1 - num5) < 1E-07;
        }

        public double[] GetPlaneABC()
        {
            Vector3d normal = this.Normal;
            return new double[3]
            {
        -normal.X / normal.Z,
        -normal.Y / normal.Z,
        (normal.X * this.Point1.X + normal.Y * this.Point1.Y + normal.Z * this.Point1.Z) / normal.Z
            };
        }
    }
}
