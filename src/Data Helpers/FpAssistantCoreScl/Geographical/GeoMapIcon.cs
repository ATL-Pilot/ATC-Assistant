// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.GeoMapIcon
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

namespace ArincReader.Geographical
{
    public class GeoMapIcon : GeoMapElement
    {
        private GeoCoordinate _GeoCoordinate = new GeoCoordinate(0.0, 0.0);
        private string _Title = string.Empty;

        public GeoMapIcon(GeoCoordinate geoCoordinate, string title)
        {
            this._GeoCoordinate = geoCoordinate;
            this._Title = title;
        }

        public GeoCoordinate Coordinate
        {
            get => this._GeoCoordinate;
            set => this._GeoCoordinate = value;
        }

        public string Title
        {
            get => this._Title;
            set => this._Title = value;
        }
    }
}
