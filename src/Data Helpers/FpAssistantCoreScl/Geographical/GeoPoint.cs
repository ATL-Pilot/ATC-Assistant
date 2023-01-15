// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.GeoPoint
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

namespace ArincReader.Geographical
{
    public class GeoPoint : GeoMapElement
    {
        private GeoCoordinate _GeoCoordinate = new GeoCoordinate(0.0, 0.0);

        public GeoCoordinate Coordinate
        {
            get => this._GeoCoordinate;
            set => this._GeoCoordinate = value;
        }

        public GeoPoint(GeoCoordinate geoCoordinate) => this._GeoCoordinate = geoCoordinate;

        public string AsGeography()
        {
            double num = this.Coordinate.Longitude;
            string str1 = num.ToString();
            num = this.Coordinate.Latitude;
            string str2 = num.ToString();
            return string.Format("POINT({0} {1})", (object)str1, (object)str2);
        }

        public string AsGmlPos(GmlDimension gmlDimension)
        {
            double num = this.Coordinate.Latitude;
            string str1 = num.ToString();
            num = this.Coordinate.Longitude;
            string str2 = num.ToString();
            string str3 = string.Format("{0} {1}", (object)str1, (object)str2);
            if (gmlDimension == GmlDimension.Output3D)
                str3 += " 0";
            return str3;
        }
    }
}
