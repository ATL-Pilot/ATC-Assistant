// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.Obstacles.LineObstacle
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.Geographical;
using System;
using System.Collections.Generic;

namespace FpAssistantCore.GeneralAviation.Obstacles
{
  public class LineObstacle : Obstacle
  {
    public List<LineObstacleSegment> LineSegments { get; set; } = new List<LineObstacleSegment>();

    public override void AssignGridCoordinate(
      CoordinateSystem coordinateSystem,
      string projectionZoneIdentifier)
    {
      throw new NotImplementedException();
    }

    public override void AssignGridCoordinate(MapProjections mapProjection) => throw new NotImplementedException();

    public override GeoMapElement AsGeoMapElement(
      ObstacleGeographyMappings obstacleGeographyMappings)
    {
      throw new NotImplementedException();
    }
  }
}
