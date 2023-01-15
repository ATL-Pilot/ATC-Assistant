// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.CoordinateSystems
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FpAssistantCore.Geographical
{
  public static class CoordinateSystems
  {
    private static readonly List<CoordinateSystem> coordinateSystemsList = new List<CoordinateSystem>();

    static CoordinateSystems()
    {
      CoordinateSystems.coordinateSystemsList.Add(new CoordinateSystem(MapProjections.UtmWgs84.GetDescription(), MapProjections.UtmWgs84, CoordinateSystemUnits.Metres, true));
      CoordinateSystems.coordinateSystemsList.Add(new CoordinateSystem(MapProjections.UtmNad83.GetDescription(), MapProjections.UtmNad83, CoordinateSystemUnits.Metres, true));
    }

    public static CoordinateSystem FindByMapProjection(MapProjections mapProjection)
    {
      foreach (CoordinateSystem coordinateSystems in CoordinateSystems.coordinateSystemsList)
      {
        if (coordinateSystems.MapProjection == mapProjection)
          return coordinateSystems;
      }
      throw new ArgumentException("Map projection parameter value not found in enum MapProjections", nameof (mapProjection));
    }

    public static bool IsProjectionZoneIdentifierValid(
      MapProjections mapProjection,
      string projectionZoneIdentifier)
    {
      bool flag = false;
      if (mapProjection != MapProjections.UtmWgs84)
      {
        if (mapProjection != MapProjections.UtmNad83)
          throw new NotImplementedException("MapProjection passed is not supported in CoordinateSystems.IsProjectionZoneIdentifierValid() member function");
        foreach (int enumValue in Enum.GetValues(typeof (MapProjectionUtmNad83)).Cast<MapProjectionUtmNad83>())
        {
          if (((MapProjectionUtmNad83) enumValue).GetDescription() == projectionZoneIdentifier)
          {
            flag = true;
            break;
          }
        }
      }
      else
      {
        foreach (int enumValue in Enum.GetValues(typeof (MapProjectionUtmWgs84)).Cast<MapProjectionUtmWgs84>())
        {
          if (((MapProjectionUtmWgs84) enumValue).GetDescription() == projectionZoneIdentifier)
          {
            flag = true;
            break;
          }
        }
      }
      return flag;
    }
  }
}
