// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.AircraftFlightData
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.Geographical;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ArincReader.GeneralAviation
{
    [ExcludeFromCodeCoverage]
    public class AircraftFlightData : BaseObjectGeneral
    {
        public AircraftFlightData(
          Guid guidId,
          int id,
          string callsign,
          double latitude,
          double longitude,
          int altitude,
          double trackDegrees,
          string from,
          string to,
          string airline,
          string aircraftModel)
        {
            this.GuidId = guidId;
            this.Id = id;
            this.Callsign = callsign;
            this.Coordinate = new GeoCoordinate(latitude, longitude).GeoCoordinateBasic;
            this.Altitude = new LinearDistance((double)altitude, this.Altitude.ValueUnit);
            this.Track = new CompassBearing(trackDegrees);
            this.To = to;
            this.From = from;
            this.Airline = airline;
            this.AircraftModel = aircraftModel;
        }

        public Guid GuidId { get; private set; } = Guid.Empty;

        public int Id { get; private set; }

        public string Callsign { get; private set; } = string.Empty;

        public GeoCoordinateBasic Coordinate { get; private set; }

        public LinearDistance Altitude { get; private set; } = new LinearDistance(0.0, LinearDistanceUnits.Feet);

        public CompassBearing Track { get; private set; } = new CompassBearing(0.0);

        public string To { get; private set; }

        public string From { get; private set; }

        public string Airline { get; private set; }

        public string AircraftModel { get; private set; }
    }
}
