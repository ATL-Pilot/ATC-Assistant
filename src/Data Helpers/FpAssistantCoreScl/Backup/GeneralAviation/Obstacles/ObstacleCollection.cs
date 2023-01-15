// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.Obstacles.ObstacleCollection
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.Geographical;
using System.Collections.ObjectModel;

namespace FpAssistantCore.GeneralAviation.Obstacles
{
  public class ObstacleCollection : Collection<Obstacle>
  {
    public void AssignGridCoordinate(
      CoordinateSystem coordinateSystem,
      string projectionZoneIdentifier)
    {
      foreach (Obstacle obstacle in (Collection<Obstacle>) this)
        obstacle.AssignGridCoordinate(coordinateSystem, projectionZoneIdentifier);
    }

    public GeoMapElementCollection AsGeoMapElements(
      ObstacleGeographyMappings obstacleGeographyMappings)
    {
      GeoMapElementCollection elementCollection = new GeoMapElementCollection();
      foreach (Obstacle obstacle in (Collection<Obstacle>) this)
        elementCollection.Add((IGeoMapElement) obstacle.AsGeoMapElement(obstacleGeographyMappings));
      return elementCollection;
    }
  }
}
