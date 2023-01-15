// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.GeoLineString
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FpAssistantCore.Geographical
{
  public class GeoLineString : GeoMapElement
  {
    private readonly GeoCoordinateElevationCollection _Coordinates = new GeoCoordinateElevationCollection();

    public GeoLineString(GeoCoordinateElevationCollection coordinates)
    {
      if (coordinates == null)
        throw new NullReferenceException("coordinates parameter is null");
      if (coordinates.Count < 2)
        throw new ArgumentOutOfRangeException(nameof (coordinates), "Array must have more 2 or more elements to form the GeoLineString");
      foreach (GeoCoordinateElevation coordinate in (Collection<GeoCoordinateElevation>) coordinates)
        this._Coordinates.Add(new GeoCoordinateElevation(coordinate.Coordinate, coordinate.Elevation));
    }

    public GeoLineString(List<GeoCoordinateBasic> coordinates)
    {
      if (coordinates == null)
        throw new NullReferenceException("coordinates parameter is null");
      if (coordinates.Count < 2)
        throw new ArgumentOutOfRangeException(nameof (coordinates), "Array must have more 2 or more elements to form the GeoLineString");
      foreach (GeoCoordinateBasic coordinate in coordinates)
        this._Coordinates.Add(new GeoCoordinateElevation(coordinate));
    }

    public GeoCoordinateElevationCollection Coordinates => this._Coordinates;

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
      return str1;
    }
  }
}
