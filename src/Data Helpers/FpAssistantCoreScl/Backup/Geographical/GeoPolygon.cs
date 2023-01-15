// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.GeoPolygon
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace FpAssistantCore.Geographical
{
  public class GeoPolygon : GeoMapElement
  {
    public GeoPolygon(GeoCoordinateElevationCollection coordinates)
    {
      if (coordinates == null)
        throw new ArgumentNullException(nameof (coordinates));
      this.Coordinates = coordinates.Count >= 3 ? coordinates : throw new ArgumentOutOfRangeException(nameof (coordinates), "Array must have more 3 or more elements to form the GeoPolygon");
    }

    public GeoPolygon(
      GeoCoordinateElevationCollection coordinates,
      MapObjectProperties mapObjectProperties)
      : this(coordinates)
    {
      if (mapObjectProperties == null)
        return;
      this.AssignProperties(mapObjectProperties);
    }

    public GeoPolygon(
      GeoCoordinateElevation coordinate1,
      GeoCoordinateElevation coordinate2,
      GeoCoordinateElevation coordinate3,
      MapObjectProperties mapObjectProperties)
    {
      this.Coordinates.Add(coordinate1);
      this.Coordinates.Add(coordinate2);
      this.Coordinates.Add(coordinate3);
      if (mapObjectProperties == null)
        return;
      this.AssignProperties(mapObjectProperties);
    }

    public GeoPolygon(
      GeoCoordinateElevation coordinate1,
      GeoCoordinateElevation coordinate2,
      GeoCoordinateElevation coordinate3,
      GeoCoordinateElevation coordinate4,
      MapObjectProperties mapObjectProperties)
      : this(coordinate1, coordinate2, coordinate3, mapObjectProperties)
    {
      this.Coordinates.Add(coordinate4);
    }

    public GeoPolygon(
      GeoCoordinateElevation coordinate1,
      GeoCoordinateElevation coordinate2,
      GeoCoordinateElevation coordinate3,
      GeoCoordinateElevation coordinate4,
      GeoCoordinateElevation coordinate5,
      MapObjectProperties mapObjectProperties)
      : this(coordinate1, coordinate2, coordinate3, coordinate4, mapObjectProperties)
    {
      this.Coordinates.Add(coordinate5);
    }

    public GeoCoordinateElevationCollection Coordinates { get; set; } = new GeoCoordinateElevationCollection();

    public FpaColour FillColour { get; set; }

    public string AsGeography(IFormatProvider provider)
    {
      NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
      string str1 = "POLYGON((";
      foreach (GeoCoordinateElevation coordinate1 in (Collection<GeoCoordinateElevation>) this.Coordinates)
      {
        string[] strArray = new string[5]
        {
          str1,
          null,
          null,
          null,
          null
        };
        GeoCoordinate coordinate2 = coordinate1.Coordinate;
        strArray[1] = coordinate2.Longitude.ToString(provider);
        strArray[2] = " ";
        coordinate2 = coordinate1.Coordinate;
        strArray[3] = coordinate2.Latitude.ToString(provider);
        strArray[4] = instance.NumberGroupSeparator;
        str1 = string.Concat(strArray);
      }
      string str2 = str1;
      GeoCoordinate coordinate = this.Coordinates[0].Coordinate;
      double num = coordinate.Longitude;
      string str3 = num.ToString(provider);
      coordinate = this.Coordinates[0].Coordinate;
      num = coordinate.Latitude;
      string str4 = num.ToString(provider);
      return str2 + str3 + " " + str4 + "))";
    }

    public string AsGmlPosList(GmlDimension gmlDimension, IFormatProvider provider)
    {
      string str1 = "";
      foreach (GeoCoordinateElevation coordinate1 in (Collection<GeoCoordinateElevation>) this.Coordinates)
      {
        string str2 = str1;
        GeoCoordinate coordinate2 = coordinate1.Coordinate;
        double num = coordinate2.Latitude;
        string str3 = num.ToString(provider);
        coordinate2 = coordinate1.Coordinate;
        num = coordinate2.Longitude;
        string str4 = num.ToString(provider);
        str1 = str2 + str3 + " " + str4;
        if (gmlDimension == GmlDimension.Output3D)
        {
          string str5 = str1;
          LinearDistance elevation = coordinate1.Elevation;
          elevation = elevation.ConvertTo(LinearDistanceUnits.Metres);
          num = elevation.Value;
          string str6 = num.ToString("G16", provider);
          str1 = str5 + " " + str6;
        }
        str1 += " ";
      }
      string str7 = str1;
      GeoCoordinateElevation coordinate3 = this.Coordinates[0];
      GeoCoordinate coordinate4 = coordinate3.Coordinate;
      string str8 = coordinate4.Latitude.ToString(provider);
      coordinate3 = this.Coordinates[0];
      coordinate4 = coordinate3.Coordinate;
      string str9 = coordinate4.Longitude.ToString(provider);
      string str10 = str7 + str8 + " " + str9;
      if (gmlDimension == GmlDimension.Output3D)
      {
        string str11 = str10;
        coordinate3 = this.Coordinates[0];
        LinearDistance elevation = coordinate3.Elevation;
        elevation = elevation.ConvertTo(LinearDistanceUnits.Metres);
        string str12 = elevation.Value.ToString("G16", provider);
        str10 = str11 + " " + str12;
      }
      return str10;
    }

    public override void AssignProperties(MapObjectProperties mapObjectProperties)
    {
      if (mapObjectProperties == null)
        throw new ArgumentNullException(nameof (mapObjectProperties));
      base.AssignProperties(mapObjectProperties);
      this.FillColour = mapObjectProperties.FillColour;
    }
  }
}
