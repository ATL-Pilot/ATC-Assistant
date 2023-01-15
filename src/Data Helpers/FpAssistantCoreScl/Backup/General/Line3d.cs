// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.Line3d
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

namespace FpAssistantCore.General
{
  public class Line3d
  {
    public Line3d(Point3d start, Point3d end)
    {
      this.Start = start;
      this.End = end;
    }

    public Point3d Start { get; set; }

    public Point3d End { get; set; }

    public void ExtendBy(double distanceToExtend, Line3dPointType line3DPoints)
    {
      if (line3DPoints != Line3dPointType.Start)
      {
        if (line3DPoints != Line3dPointType.End)
          return;
        Vector3d vector3d = this.End - this.Start;
        this.End = this.End.GetTranslated(distanceToExtend, vector3d);
      }
      else
      {
        Vector3d vector3d = this.Start - this.End;
        this.Start = this.Start.GetTranslated(distanceToExtend, vector3d);
      }
    }
  }
}
