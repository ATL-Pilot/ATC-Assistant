// Decompiled with JetBrains decompiler
// Type: ArincReader.Aerodromes.Aerodrome
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.Geographical;

namespace ArincReader.Aerodromes
{
    public class Aerodrome
    {
        public Aerodrome()
        {
        }

        public Aerodrome(
          string iataCode,
          string description,
          GeoCoordinate arp,
          LinearDistance height)
        {
            this.IATACode = iataCode;
            this.Description = description;
            this.Arp = arp;
            this.Height = height;
        }

        public GeoCoordinate Arp { get; private set; }

        public double Latitude => this.Arp.Latitude;

        public double Longitude => this.Arp.Longitude;

        public string IATACode { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public LinearDistance Height { get; private set; } = new LinearDistance(0.0, LinearDistanceUnits.Metres);
    }
}
