// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Airway
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.Arinc424.Records;
using ArincReader.Geographical;
using System;
using System.Collections.Generic;

namespace ArincReader.Arinc424
{
    public class Airway
    {
        private string _AirwayIdentifier = string.Empty;
        private List<EnrouteAirway> _EnrouteAirways = new List<EnrouteAirway>();
        private readonly List<GeoCoordinateBasic> _FixCoordinates = new List<GeoCoordinateBasic>();

        public Airway(string routeIdentifier, Arinc424Data arinc424Data)
        {
            if (arinc424Data == null)
                throw new ArgumentNullException(nameof(arinc424Data), "NULL not allowed for EnrouteAirways list");
            this.AirwayIdentifier = routeIdentifier;
            this.EnrouteAirways = arinc424Data.EnrouteAirwaysByRouteIdentifier(this.AirwayIdentifier);
            foreach (EnrouteAirway enrouteAirway in this.EnrouteAirways)
            {
                (bool flag, GeoCoordinateBasic geoCoordinateBasic) = arinc424Data.FindFix(enrouteAirway.FixIdentifier);
                if (!flag)
                    throw new Exception(string.Format("Fix coordinate not found for EnrouteAirway identifier {0}", (object)enrouteAirway.FixIdentifier));
                this._FixCoordinates.Add(geoCoordinateBasic);
            }
        }

        public List<EnrouteAirway> EnrouteAirways
        {
            get => this._EnrouteAirways;
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("AirwayIdentifier", "NULL not allowed for EnrouteAirways list");
                foreach (EnrouteAirway enrouteAirway in value)
                {
                    if (!string.Equals(enrouteAirway.RouteIdentifier.Trim(), this._AirwayIdentifier, StringComparison.OrdinalIgnoreCase))
                        throw new ArgumentException("Invalid route identifier in record collection", nameof(EnrouteAirways));
                }
                this._EnrouteAirways = value;
            }
        }

        public string AirwayIdentifier
        {
            get => this._AirwayIdentifier;
            private set => this._AirwayIdentifier = value != null ? value.Trim() : throw new ArgumentNullException(nameof(AirwayIdentifier), "NULL not allowed for Airway Identifier");
        }

        public string AsGeography()
        {
            string str = "MULTILINESTRING((";
            foreach (GeoCoordinateBasic fixCoordinate in this._FixCoordinates)
                str = str + fixCoordinate.Longitude.ToString() + " " + fixCoordinate.Latitude.ToString() + ",";
            return str.Remove(str.Length - 1) + "))";
        }

        public GeoMapElement AsGeoMapElement()
        {
            GeoLineString geoLineString = new GeoLineString(this._FixCoordinates);
            geoLineString.Name = nameof(Airway);
            geoLineString.Description = this._AirwayIdentifier;
            return (GeoMapElement)geoLineString;
        }
    }
}
