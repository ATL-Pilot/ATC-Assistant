// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.Obstacles.Obstacle
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.Geographical;
using System;

namespace FpAssistantCore.GeneralAviation.Obstacles
{
  public abstract class Obstacle
  {
    public abstract void AssignGridCoordinate(
      CoordinateSystem coordinateSystem,
      string projectionZoneIdentifier);

    public abstract void AssignGridCoordinate(MapProjections mapProjection);

    public abstract GeoMapElement AsGeoMapElement(
      ObstacleGeographyMappings obstacleGeographyMappings);

    public string Description { get; set; } = string.Empty;

    public string Id { get; set; } = string.Empty;

    public Guid InternalId { get; set; } = Guid.Empty;
  }
}
