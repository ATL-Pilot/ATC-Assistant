// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.GeoLine
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;

namespace FpAssistantCore.Geographical
{
  public class GeoLine : GeoMapElement
  {
    private GeoCoordinate _StartCoordinate = new GeoCoordinate(0.0, 0.0);
    private GeoCoordinate _EndCoordinate = new GeoCoordinate(0.0, 0.0);
    private CompassBearing _ForwardAzimuth = new CompassBearing(0.0);
    private CompassBearing _ReverseAzimuth = new CompassBearing(0.0);
    private LinearDistance _StartElevation = new LinearDistance(0.0, LinearDistanceUnits.Metres);
    private LinearDistance _EndElevation = new LinearDistance(0.0, LinearDistanceUnits.Metres);
    private LinearDistance _Distance = new LinearDistance(0.0, LinearDistanceUnits.Metres);

    public GeoCoordinate StartCoordinate
    {
      get => this._StartCoordinate;
      set
      {
        this._StartCoordinate = value;
        this.CalculateProperties();
      }
    }

    public LinearDistance StartElevation
    {
      get => this._StartElevation;
      set => this._StartElevation = value;
    }

    public GeoCoordinate EndCoordinate
    {
      get => this._EndCoordinate;
      set
      {
        this._EndCoordinate = value;
        this.CalculateProperties();
      }
    }

    public LinearDistance EndElevation
    {
      get => this._EndElevation;
      set => this._EndElevation = value;
    }

    public LinearDistance Distance => this._Distance;

    public CompassBearing ForwardAzimuth => this._ForwardAzimuth;

    public CompassBearing ReverseAzimuth => this._ReverseAzimuth;

    public GeoLine(GeoCoordinateElevation startCoordinate, GeoCoordinateElevation endCoordinate)
    {
      this._StartCoordinate = startCoordinate.Coordinate;
      this._EndCoordinate = endCoordinate.Coordinate;
      this._StartElevation = startCoordinate.Elevation;
      this._EndElevation = endCoordinate.Elevation;
      this.CalculateProperties();
    }

    public GeoLine(GeoCoordinate startCoordinate, GeoCoordinate endCoordinate)
    {
      this._StartCoordinate = startCoordinate;
      this._EndCoordinate = endCoordinate;
      this.CalculateProperties();
    }

    public GeoLine(
      GeoCoordinate startCoordinate,
      GeoCoordinate endCoordinate,
      MapObjectProperties mapObjectProperties)
      : this(startCoordinate, endCoordinate)
    {
      if (mapObjectProperties == null)
        return;
      this.AssignProperties(mapObjectProperties);
    }

    public GeoLine(
      GeoCoordinate startCoordinate,
      GeoCoordinate endCoordinate,
      LinearDistance startElevation,
      LinearDistance endElevation,
      MapObjectProperties mapObjectProperties)
      : this(startCoordinate, endCoordinate, mapObjectProperties)
    {
      this._StartElevation = startElevation;
      this._EndElevation = endElevation;
    }

    private void CalculateProperties()
    {
      GeoAzimuthDistance geoAzimuthDistance = this._StartCoordinate.GeoCoordinateBasic.WGS84Distance(this._EndCoordinate.GeoCoordinateBasic);
      this._ForwardAzimuth = geoAzimuthDistance.AzimuthForward;
      this._ReverseAzimuth = geoAzimuthDistance.AzimuthReverse;
      this._Distance = geoAzimuthDistance.Distance;
    }

    public string AsGeography(IFormatProvider provider)
    {
      LinearDistance startElevation = this.StartElevation;
      startElevation = startElevation.ConvertTo(LinearDistanceUnits.Metres);
      string str1 = startElevation.Value.ToString("G16", provider);
      LinearDistance endElevation = this.EndElevation;
      endElevation = endElevation.ConvertTo(LinearDistanceUnits.Metres);
      string str2 = endElevation.Value.ToString("G16", provider);
      return "LINESTRING(" + this.StartCoordinate.Longitude.ToString(provider) + " " + this.StartCoordinate.Latitude.ToString(provider) + " " + str1 + " 0," + this.EndCoordinate.Longitude.ToString(provider) + " " + this.EndCoordinate.Latitude.ToString(provider) + " " + str2 + " 0)";
    }

    public string AsGmlPosList(GmlDimension gmlDimension, IFormatProvider provider)
    {
      LinearDistance startElevation = this.StartElevation;
      startElevation = startElevation.ConvertTo(LinearDistanceUnits.Metres);
      string str1 = startElevation.Value.ToString("G16", provider);
      LinearDistance endElevation = this.EndElevation;
      endElevation = endElevation.ConvertTo(LinearDistanceUnits.Metres);
      string str2 = endElevation.Value.ToString("G16", provider);
      double num = this.StartCoordinate.Latitude;
      string str3 = num.ToString(provider);
      num = this.StartCoordinate.Longitude;
      string str4 = num.ToString(provider);
      string str5 = str3 + " " + str4;
      if (gmlDimension == GmlDimension.Output3D)
        str5 = str5 + " " + str1;
      string str6 = str5 + " " + this.EndCoordinate.Latitude.ToString(provider) + " " + this.EndCoordinate.Longitude.ToString(provider);
      if (gmlDimension == GmlDimension.Output3D)
        str6 = str6 + " " + str2;
      return str6;
    }

    public bool Intersection(GeoLine geoLine2, ref GeoCoordinate intersectionCoordinate)
    {
      if (geoLine2 == null)
        throw new ArgumentNullException(nameof (geoLine2));
      GeoCoordinateBasic geoCoordinateBasic1 = new GeoCoordinateBasic();
      GeoCoordinateBasic geoCoordinateBasic2 = this.StartCoordinate.GeoCoordinateBasic;
      ref GeoCoordinateBasic local1 = ref geoCoordinateBasic2;
      GeoCoordinate geoCoordinate = this.EndCoordinate;
      GeoCoordinateBasic geoCoordinateBasic3 = geoCoordinate.GeoCoordinateBasic;
      GeoAzimuthDistance geoAzimuthDistance1 = local1.WGS84Distance(geoCoordinateBasic3);
      geoCoordinate = geoLine2.StartCoordinate;
      GeoCoordinateBasic geoCoordinateBasic4 = geoCoordinate.GeoCoordinateBasic;
      ref GeoCoordinateBasic local2 = ref geoCoordinateBasic4;
      geoCoordinate = geoLine2.EndCoordinate;
      GeoCoordinateBasic geoCoordinateBasic5 = geoCoordinate.GeoCoordinateBasic;
      GeoAzimuthDistance geoAzimuthDistance2 = local2.WGS84Distance(geoCoordinateBasic5);
      geoCoordinate = this.StartCoordinate;
      GeoCoordinateBasic geoCoordinateBasic6 = geoCoordinate.GeoCoordinateBasic;
      ref GeoCoordinateBasic local3 = ref geoCoordinateBasic6;
      geoCoordinate = geoLine2.StartCoordinate;
      GeoCoordinateBasic geoCoordinateBasic7 = geoCoordinate.GeoCoordinateBasic;
      CompassBearing az13_1 = new CompassBearing(geoAzimuthDistance1.AzimuthForward.Bearing);
      CompassBearing az23_1 = new CompassBearing(geoAzimuthDistance2.AzimuthForward.Bearing);
      ref GeoCoordinateBasic local4 = ref geoCoordinateBasic1;
      bool flag;
      if (!(flag = local3.WGS84CrsIntersect(geoCoordinateBasic7, az13_1, az23_1, ref local4)))
      {
        geoCoordinate = this.EndCoordinate;
        GeoCoordinateBasic geoCoordinateBasic8 = geoCoordinate.GeoCoordinateBasic;
        ref GeoCoordinateBasic local5 = ref geoCoordinateBasic8;
        geoCoordinate = geoLine2.StartCoordinate;
        GeoCoordinateBasic geoCoordinateBasic9 = geoCoordinate.GeoCoordinateBasic;
        CompassBearing az13_2 = new CompassBearing(geoAzimuthDistance1.AzimuthReverse.Bearing);
        CompassBearing az23_2 = new CompassBearing(geoAzimuthDistance2.AzimuthForward.Bearing);
        ref GeoCoordinateBasic local6 = ref geoCoordinateBasic1;
        if (!(flag = local5.WGS84CrsIntersect(geoCoordinateBasic9, az13_2, az23_2, ref local6)))
        {
          geoCoordinate = this.StartCoordinate;
          geoCoordinateBasic8 = geoCoordinate.GeoCoordinateBasic;
          ref GeoCoordinateBasic local7 = ref geoCoordinateBasic8;
          geoCoordinate = geoLine2.EndCoordinate;
          GeoCoordinateBasic geoCoordinateBasic10 = geoCoordinate.GeoCoordinateBasic;
          CompassBearing az13_3 = new CompassBearing(geoAzimuthDistance1.AzimuthForward.Bearing);
          CompassBearing az23_3 = new CompassBearing(geoAzimuthDistance2.AzimuthReverse.Bearing);
          ref GeoCoordinateBasic local8 = ref geoCoordinateBasic1;
          if (!(flag = local7.WGS84CrsIntersect(geoCoordinateBasic10, az13_3, az23_3, ref local8)))
          {
            geoCoordinate = this.EndCoordinate;
            geoCoordinateBasic8 = geoCoordinate.GeoCoordinateBasic;
            ref GeoCoordinateBasic local9 = ref geoCoordinateBasic8;
            geoCoordinate = geoLine2.EndCoordinate;
            GeoCoordinateBasic geoCoordinateBasic11 = geoCoordinate.GeoCoordinateBasic;
            CompassBearing az13_4 = new CompassBearing(geoAzimuthDistance1.AzimuthReverse.Bearing);
            CompassBearing az23_4 = new CompassBearing(geoAzimuthDistance2.AzimuthReverse.Bearing);
            ref GeoCoordinateBasic local10 = ref geoCoordinateBasic1;
            flag = local9.WGS84CrsIntersect(geoCoordinateBasic11, az13_4, az23_4, ref local10);
          }
        }
      }
      if (flag)
        intersectionCoordinate = new GeoCoordinate(geoCoordinateBasic1.Latitude, geoCoordinateBasic1.Longitude);
      return flag;
    }
  }
}
