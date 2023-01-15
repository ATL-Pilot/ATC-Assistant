// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.Line2d
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

namespace FpAssistantCore.General
{
  public class Line2d
  {
    public Line2d(Point2d start, Point2d end)
    {
      this.Start = start;
      this.End = end;
    }

    public Line2d()
      : this(new Point2d(), new Point2d())
    {
    }

    public Point2d Start { get; set; }

    public Point2d End { get; set; }

    public void ExtendBy(double distanceToExtend, Line2dPointType line2DPoints)
    {
      if (line2DPoints != Line2dPointType.Start)
      {
        if (line2DPoints != Line2dPointType.End)
          return;
        Point3d point3d1 = this.End.As3d();
        Point2d point2d = this.Start;
        Point3d point3d2 = point2d.As3d();
        Vector3d vector3d = point3d1 - point3d2;
        point2d = this.End;
        this.End = point2d.As3d().GetTranslated(distanceToExtend, vector3d).As2d();
      }
      else
      {
        Point3d point3d3 = this.Start.As3d();
        Point2d point2d = this.End;
        Point3d point3d4 = point2d.As3d();
        Vector3d vector3d = point3d3 - point3d4;
        point2d = this.Start;
        this.Start = point2d.As3d().GetTranslated(distanceToExtend, vector3d).As2d();
      }
    }

    public Line2d GetOffset(double distanceToOffset)
    {
      Point2d point2d1 = this.Start;
      Point3d point3d1 = point2d1.As3d();
      point2d1 = this.End;
      Point3d point3d2 = point2d1.As3d();
      double magnitude = (point3d1 - point3d2).Magnitude;
      Point2d start = new Point2d();
      Point2d end = new Point2d();
      ref Point2d local1 = ref start;
      Point2d point2d2 = this.Start;
      double x1 = point2d2.X;
      double num1 = distanceToOffset;
      point2d2 = this.End;
      double y1 = point2d2.Y;
      point2d2 = this.Start;
      double y2 = point2d2.Y;
      double num2 = y1 - y2;
      double num3 = num1 * num2 / magnitude;
      double num4 = x1 + num3;
      local1.X = num4;
      ref Point2d local2 = ref end;
      Point2d point2d3 = this.End;
      double x2 = point2d3.X;
      double num5 = distanceToOffset;
      point2d3 = this.End;
      double y3 = point2d3.Y;
      point2d3 = this.Start;
      double y4 = point2d3.Y;
      double num6 = y3 - y4;
      double num7 = num5 * num6 / magnitude;
      double num8 = x2 + num7;
      local2.X = num8;
      ref Point2d local3 = ref start;
      Point2d point2d4 = this.Start;
      double y5 = point2d4.Y;
      double num9 = distanceToOffset;
      point2d4 = this.Start;
      double x3 = point2d4.X;
      point2d4 = this.End;
      double x4 = point2d4.X;
      double num10 = x3 - x4;
      double num11 = num9 * num10 / magnitude;
      double num12 = y5 + num11;
      local3.Y = num12;
      ref Point2d local4 = ref end;
      Point2d point2d5 = this.End;
      double y6 = point2d5.Y;
      double num13 = distanceToOffset;
      point2d5 = this.Start;
      double x5 = point2d5.X;
      point2d5 = this.End;
      double x6 = point2d5.X;
      double num14 = x5 - x6;
      double num15 = num13 * num14 / magnitude;
      double num16 = y6 + num15;
      local4.Y = num16;
      return new Line2d(start, end);
    }
  }
}
