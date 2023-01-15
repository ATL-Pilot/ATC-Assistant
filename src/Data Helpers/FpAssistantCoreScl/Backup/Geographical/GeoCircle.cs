// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.GeoCircle
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;

namespace FpAssistantCore.Geographical
{
  public class GeoCircle : GeoMapElement
  {
    private GeoCoordinate _CentreCoordinate = new GeoCoordinate(0.0, 0.0);
    private LinearDistance _Radius;
    private LinearDistance _ElevationMsl = new LinearDistance(0.0, LinearDistanceUnits.Metres);
    public const int ResolutionMinimum = 3;
    public const int ResolutionMaximum = 18;

    public GeoCircle(GeoCoordinate centreCoordinate, LinearDistance radius)
    {
      this._CentreCoordinate = centreCoordinate;
      this.Radius = radius;
    }

    public GeoCircle(
      GeoCoordinate centreCoordinate,
      LinearDistance radius,
      LinearDistance elevation)
      : this(centreCoordinate, radius)
    {
      this.Elevation = elevation;
    }

    public GeoCoordinate CentreCoordinate
    {
      get => this._CentreCoordinate;
      set => this._CentreCoordinate = value;
    }

    public LinearDistance Radius
    {
      get => this._Radius;
      set => this._Radius = value.Value >= 0.0 ? value : throw new ArgumentException("Radius must be 0 or greater", nameof (Radius));
    }

    public LinearDistance Elevation
    {
      get => this._ElevationMsl;
      set => this._ElevationMsl = value;
    }

    public string AsGeography(int resolution)
    {
      if (this._Radius.Value == 0.0)
        throw new NotImplementedException("AsGeography() with radius 0 is not currently supported GeoCircle");
      if (resolution < 3)
        resolution = 3;
      else if (resolution > 18)
        resolution = 18;
      string str1 = "LINESTRING(";
      int num1 = 360 / resolution;
      for (int bearing = 360; bearing >= 0; bearing -= num1)
      {
        if (bearing != 360)
          str1 += ",";
        GeoCoordinateBasic geoCoordinateBasic = this.CentreCoordinate.GeoCoordinateBasic.WGS84Destination(new CompassBearing((double) bearing), this.Radius);
        string str2 = str1;
        double num2 = geoCoordinateBasic.Longitude;
        string str3 = num2.ToString(GeoCoordinate.GeoCoordinateFormatDouble);
        num2 = geoCoordinateBasic.Latitude;
        string str4 = num2.ToString(GeoCoordinate.GeoCoordinateFormatDouble);
        str1 = str2 + str3 + " " + str4;
        if (this.Elevation.Value > 0.0)
          str1 = str1 + " " + this.Elevation.ConvertTo(LinearDistanceUnits.Metres).ToString(LinearDistanceFormat.None) + " NULL";
      }
      return str1 + ")";
    }

    public string AsGmlPos(GmlDimension gmlDimension)
    {
      double num = this.CentreCoordinate.Latitude;
      string str1 = num.ToString();
      num = this.CentreCoordinate.Longitude;
      string str2 = num.ToString();
      string str3 = string.Format("{0} {1}", (object) str1, (object) str2);
      if (gmlDimension == GmlDimension.Output3D)
        str3 += " 0";
      return str3;
    }

    public string AsGmlRadius(LinearDistanceUnits linearDistanceUnits)
    {
      LinearDistance radius = this.Radius;
      radius = radius.ConvertTo(linearDistanceUnits);
      return string.Format("{0}", (object) radius.Value.ToString());
    }
  }
}
