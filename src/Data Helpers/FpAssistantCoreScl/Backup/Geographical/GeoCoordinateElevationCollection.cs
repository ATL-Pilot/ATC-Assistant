// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.GeoCoordinateElevationCollection
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System.Collections.ObjectModel;

namespace FpAssistantCore.Geographical
{
  public class GeoCoordinateElevationCollection : Collection<GeoCoordinateElevation>
  {
    public void SortByDistanceFrom(GeoCoordinateBasic startCoordinate)
    {
      if (this.Count < 1)
        return;
      for (int index1 = 0; index1 < this.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 < this.Count - 1 - index1; ++index2)
        {
          ref GeoCoordinateBasic local1 = ref startCoordinate;
          GeoCoordinateElevation coordinateElevation1 = this[index2];
          GeoCoordinate coordinate = coordinateElevation1.Coordinate;
          GeoCoordinateBasic geoCoordinateBasic1 = coordinate.GeoCoordinateBasic;
          LinearDistance linearDistance1 = local1.DistanceTo(geoCoordinateBasic1);
          ref GeoCoordinateBasic local2 = ref startCoordinate;
          coordinateElevation1 = this[index2 + 1];
          coordinate = coordinateElevation1.Coordinate;
          GeoCoordinateBasic geoCoordinateBasic2 = coordinate.GeoCoordinateBasic;
          LinearDistance linearDistance2 = local2.DistanceTo(geoCoordinateBasic2);
          if (linearDistance1 > linearDistance2)
          {
            GeoCoordinateElevation coordinateElevation2 = this[index2 + 1];
            this[index2 + 1] = this[index2];
            this[index2] = coordinateElevation2;
          }
        }
      }
    }
  }
}
