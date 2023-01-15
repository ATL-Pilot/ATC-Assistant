// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Plane3d
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;

namespace ArincReader.General
{
    public struct Plane3d
    {
        private const double _TOLERANCE = 0.001;
        private readonly double _IndependentTerm;

        private Vector3d Normal { get; }

        public Plane3d(Point3d point1, Point3d point2, Point3d point3)
        {
            this.Normal = new Vector3d(point1, point2) * new Vector3d(point1, point3);
            if (this.Normal.Magnitude < 0.001)
                throw new ArgumentException("Specified points do not define a valid plane");
            this._IndependentTerm = -(this.Normal.X * point1.X + this.Normal.Y * point1.Y + this.Normal.Z * point1.Z);
        }

        public bool Contains(Point3d point3d)
        {
            Vector3d normal = this.Normal;
            double num1 = normal.X * point3d.X;
            normal = this.Normal;
            double num2 = normal.Y * point3d.Y;
            double num3 = num1 + num2;
            normal = this.Normal;
            double num4 = normal.Z * point3d.Z;
            return Math.Abs(num3 + num4 + this._IndependentTerm) < 0.001;
        }
    }
}
