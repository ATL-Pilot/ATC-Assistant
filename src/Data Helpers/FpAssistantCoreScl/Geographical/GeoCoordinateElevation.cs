// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.GeoCoordinateElevation
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.Geographical
{
    public struct GeoCoordinateElevation
    {
        public GeoCoordinateElevation(GeoCoordinate coordinate, LinearDistance elevation)
        {
            this.Coordinate = coordinate;
            this.Elevation = elevation;
        }

        public GeoCoordinateElevation(GeoCoordinateBasic geoCoordinateBasic)
          : this(new GeoCoordinate(geoCoordinateBasic.Latitude, geoCoordinateBasic.Longitude), new LinearDistance(0.0, LinearDistanceUnits.Metres))
        {
        }

        public GeoCoordinateElevation(GeoCoordinateBasic geoCoordinateBasic, LinearDistance elevation)
          : this(new GeoCoordinate(geoCoordinateBasic.Latitude, geoCoordinateBasic.Longitude), elevation)
        {
        }

        public GeoCoordinate Coordinate { get; set; }

        public LinearDistance Elevation { get; set; }
    }
}
