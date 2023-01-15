// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.Obstacles.LineObstacleSegment
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;

namespace FpAssistantCore.GeneralAviation.Obstacles
{
  public class LineObstacleSegment
  {
    public LineObstacleSegment(GeoCoordinate startCoordinate, GeoCoordinate endCoordinate)
    {
      this.StartCoordinate = startCoordinate;
      this.EndCoordinate = endCoordinate;
    }

    public GeoCoordinate StartCoordinate { get; } = new GeoCoordinate(0.0, 0.0);

    public GeoCoordinate EndCoordinate { get; } = new GeoCoordinate(0.0, 0.0);

    public LinearDistance HeightMsl { get; set; }
  }
}
