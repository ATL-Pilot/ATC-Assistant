// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Facet
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;

namespace ArincReader.General
{
    public class Facet
    {
        public Facet(Point3d vertex1, Point3d vertex2, Point3d vertex3)
        {
            this.Vertex1 = vertex1;
            this.Vertex2 = vertex2;
            this.Vertex3 = vertex3;
            this.Vertex4 = vertex3;
            this.FacetType = FacetType.Triangle;
        }

        public Facet(Point3d vertex1, Point3d vertex2, Point3d vertex3, Point3d vertex4)
          : this(vertex1, vertex2, vertex3)
        {
            this.Vertex4 = vertex4;
            this.FacetType = this.IndentifyFacetType();
        }

        public Point3d Vertex1 { get; private set; }

        public Point3d Vertex2 { get; private set; }

        public Point3d Vertex3 { get; private set; }

        public Point3d Vertex4 { get; private set; }

        public string Description { get; set; } = string.Empty;

        public FacetType FacetType { get; private set; }

        public Triangle2d[] AsTriangles2d()
        {
            List<Triangle2d> triangle2dList = new List<Triangle2d>()
      {
        new Triangle2d(this.Vertex1, this.Vertex2, this.Vertex3)
      };
            if (this.FacetType != FacetType.Triangle)
                triangle2dList.Add(new Triangle2d(this.Vertex1, this.Vertex3, this.Vertex4));
            return triangle2dList.ToArray();
        }

        public Triangle3d[] AsTriangles3d() => this.FacetType == FacetType.Triangle ? new Triangle3d[1]
        {
      new Triangle3d(this.Vertex1, this.Vertex2, this.Vertex3)
        } : new Triangle3d[2]
        {
      new Triangle3d(this.Vertex1, this.Vertex2, this.Vertex3),
      new Triangle3d(this.Vertex1, this.Vertex3, this.Vertex4)
        };

        private FacetType IndentifyFacetType() => Facet.IsCoplanar(this.Vertex1, this.Vertex2, this.Vertex3, this.Vertex4) ? FacetType.Planar : FacetType.NonPlanar;

        public static bool IsCoplanar(
          Point3d point3d_1,
          Point3d point3d_2,
          Point3d point3d_3,
          Point3d point3d_4)
        {
            return Facet.IsCoplanar(point3d_1.X, point3d_1.Y, point3d_1.Z, point3d_2.X, point3d_2.Y, point3d_2.Z, point3d_3.X, point3d_3.Y, point3d_3.Z, point3d_4.X, point3d_4.Y, point3d_4.Z);
        }

        public static bool IsCoplanar(
          double x1,
          double y1,
          double z1,
          double x2,
          double y2,
          double z2,
          double x3,
          double y3,
          double z3,
          double x,
          double y,
          double z)
        {
            double num1 = x2 - x1;
            double num2 = y2 - y1;
            double num3 = z2 - z1;
            double num4 = x3 - x1;
            double num5 = y3 - y1;
            double num6 = z3 - z1;
            double num7 = num2 * num6 - num5 * num3;
            double num8 = num4 * num3 - num1 * num6;
            double num9 = num1 * num5 - num2 * num4;
            double num10 = -num7 * x1 - num8 * y1 - num9 * z1;
            return num7 * x + num8 * y + num9 * z + num10 == 0.0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Facet facet = obj as Facet;
            return (object)facet != null && this.Vertex1 == facet.Vertex1 && this.Vertex2 == facet.Vertex2 && this.Vertex3 == facet.Vertex3 && this.Vertex4 == facet.Vertex4;
        }

        public static bool operator ==(Facet a1, Facet a2) => a1.Equals((object)a2);

        public static bool operator !=(Facet a1, Facet a2) => !(a1 == a2);

        public override int GetHashCode()
        {
            Point3d point3d = this.Vertex1;
            int hashCode1 = point3d.GetHashCode();
            point3d = this.Vertex2;
            int hashCode2 = point3d.GetHashCode();
            int num1 = hashCode1 ^ hashCode2;
            point3d = this.Vertex3;
            int hashCode3 = point3d.GetHashCode();
            int num2 = num1 ^ hashCode3;
            point3d = this.Vertex4;
            int hashCode4 = point3d.GetHashCode();
            return num2 ^ hashCode4;
        }
    }
}
