// Decompiled with JetBrains decompiler
// Type: ArincReader.General.MathExtension
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;

namespace ArincReader.General
{
    public static class MathExtension
    {
        public static Vector3d PerpendicularVector2D(this Vector3d v) => new Vector3d(-v.Y, v.X);

        public static double AngleTo(this Vector3d v1, Vector3d v)
        {
            if (v1.Magnitude < 1E-18 || v.Magnitude < 1E-18)
                return 0.0;
            double d = v1.DotProduct(v) / v1.Magnitude / v.Magnitude;
            if (Math.Abs(d) < 1.0)
                return Math.Acos(d);
            return d <= 0.0 ? Math.PI : 0.0;
        }

        public static double[] GetExtents(Point3d[] p3c)
        {
            if (p3c == null)
                throw new NullReferenceException(nameof(p3c));
            if (p3c.Length == 0)
                throw new Exception("Empty Point3dCollection in GetExtents() call.");
            double[] extents = new double[6];
            extents[0] = extents[1] = p3c[0].X;
            extents[2] = extents[3] = p3c[0].Y;
            extents[4] = extents[5] = p3c[0].Z;
            foreach (Point3d point3d in p3c)
            {
                if (extents[0] > point3d.X)
                    extents[0] = point3d.X;
                else if (extents[1] < point3d.X)
                    extents[1] = point3d.X;
                if (extents[2] > point3d.Y)
                    extents[2] = point3d.Y;
                else if (extents[3] < point3d.Y)
                    extents[3] = point3d.Y;
                if (extents[4] > point3d.Z)
                    extents[4] = point3d.Z;
                else if (extents[5] < point3d.Z)
                    extents[5] = point3d.Z;
            }
            return extents;
        }

        public static double[] FitToRectangle(Point3d[] p3c, double width, double height)
        {
            double[] rectangle = new double[4]
            {
        0.0,
        0.0,
        1.0,
        1.0
            };
            try
            {
                double[] extents = MathExtension.GetExtents(p3c);
                double num1 = extents[1] - extents[0];
                double num2 = extents[3] - extents[2];
                double num3 = Math.Min(width / num1, height / num2) * 0.95;
                rectangle[2] = num3;
                rectangle[3] = num3;
                rectangle[0] = extents[0] - (width / num3 - num1) / 2.0;
                rectangle[1] = extents[2] - (height / num3 - num2) / 2.0;
            }
            catch
            {
                throw;
            }
            return rectangle;
        }

        public static Point3d IntersectLine2D(
          Point3d origin1,
          Vector3d vector1,
          Point3d origin2,
          Vector3d v2,
          double[] dt)
        {
            if (dt == null)
                throw new NullReferenceException(nameof(dt));
            double num1;
            double num2 = num1 = 0.0;
            double num3 = num1;
            double num4 = num1;
            double[] numArray1 = new double[2]
            {
        origin2.X - origin1.X,
        origin2.Y - origin1.Y
            };
            double[] numArray2 = new double[2]
            {
        vector1.X / vector1.Magnitude,
        vector1.Y / vector1.Magnitude
            };
            double[] numArray3 = new double[2]
            {
        v2.X / v2.Magnitude,
        v2.Y / v2.Magnitude
            };
            for (long index = 0; index < 2L; ++index)
            {
                num4 += numArray1[index] * numArray3[index];
                num3 += numArray1[index] * numArray2[index];
                num2 += numArray3[index] * numArray2[index];
            }
            double num5 = 1.0 - num2 * num2;
            long num6;
            if (num5 < 1E-06)
            {
                dt[0] = 0.0;
                dt[1] = -num4;
                num6 = 0L;
            }
            else
            {
                dt[1] = (num3 * num2 - num4) / num5;
                dt[0] = (num3 - num4 * num2) / num5;
                num6 = 1L;
            }
            Point3d point3d = new Point3d(origin2.X + numArray3[0] * dt[1], origin2.Y + numArray3[1] * dt[1], 0.0);
            double num7 = point3d.X - (origin1.X + numArray2[0] * dt[0]);
            double num8 = num7 * num7;
            double num9 = point3d.Y - (origin1.Y + numArray2[1] * dt[0]);
            if (num8 + num9 * num9 > 1E-06)
                num6 = 0L;
            dt[2] = (double)num6;
            return point3d;
        }
    }
}
