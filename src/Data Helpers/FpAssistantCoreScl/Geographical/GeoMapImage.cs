// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.GeoMapImage
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.Geographical
{
    public class GeoMapImage : GeoMapElement
    {
        public string ImageFilename { get; set; } = string.Empty;

        public GeoCoordinate Coordinate { get; set; } = new GeoCoordinate(0.0, 0.0);

        public CompassBearing Angle { get; set; } = new CompassBearing(0.0);
    }
}
