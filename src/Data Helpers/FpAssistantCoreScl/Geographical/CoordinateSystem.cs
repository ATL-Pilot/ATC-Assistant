// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.CoordinateSystem
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;
using System.IO;
using System.Xml;

namespace ArincReader.Geographical
{
    public class CoordinateSystem
    {
        private const string XmlTagGeographicCoordinateSystem = "GeographicCoordinateSystem";
        private readonly ProjectedCoordinateSystem _ProjectedCoordinateSystem;
        private readonly string _Description;
        private readonly CoordinateSystemUnits _CoordinateSystemUnit;

        public CoordinateSystem(
          string description,
          MapProjections mapProjection,
          CoordinateSystemUnits coordinateSystemUnit,
          bool hasZones)
        {
            this._Description = description;
            this._CoordinateSystemUnit = coordinateSystemUnit;
            this.MapProjection = mapProjection;
            this.HasZones = hasZones;
        }

        public CoordinateSystem(string wkt)
        {
            if (string.IsNullOrEmpty(wkt))
                throw new ArgumentException("Well-known text string cannot be null or empty.", nameof(CoordinateSystem));
            if (!wkt.StartsWith("<?xml "))
                return;
            using (StringReader input = new StringReader(wkt))
            {
                using (XmlTextReader xmlTextReader = new XmlTextReader((TextReader)input))
                {
                    xmlTextReader.WhitespaceHandling = WhitespaceHandling.None;
                    int content = (int)xmlTextReader.MoveToContent();
                    xmlTextReader.ReadStartElement();
                    if (xmlTextReader.Name == "ProjectedCoordinateSystem")
                    {
                        this._ProjectedCoordinateSystem = new ProjectedCoordinateSystem(xmlTextReader);
                        this._Description = this._ProjectedCoordinateSystem.Description;
                        this._CoordinateSystemUnit = this._ProjectedCoordinateSystem.Uom;
                    }
                    else
                    {
                        int num = xmlTextReader.Name == "GeographicCoordinateSystem" ? 1 : 0;
                    }
                }
            }
        }

        public string Description => this._Description;

        public MapProjections MapProjection { get; set; }

        public bool HasZones { get; set; }

        public CoordinateSystemUnits CoordinateSystemUnit => this._CoordinateSystemUnit;

        public ProjectedCoordinateSystem Projection => this._ProjectedCoordinateSystem;
    }
}
