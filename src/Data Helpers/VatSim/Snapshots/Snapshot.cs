using System;
using System.Collections.Generic;
using VatSim.Data;

namespace VatSim.Snapshots
{
    public class Snapshot
    {
        public DateTime LastUpdated { get; set; }

        public Dictionary<string, Flight> Flights { get; set; } = new Dictionary<string, Flight>();

        public Dictionary<string, VatSim.Data.Atc> Atc { get; set; } = new Dictionary<string, VatSim.Data.Atc>();

        public Dictionary<string, NetworkServer> NetworkServers { get; set; } = new Dictionary<string, NetworkServer>();

        public Dictionary<string, AirportPositionInfo> AirportPositionInfos { get; set; } = new Dictionary<string, AirportPositionInfo>();

        public Dictionary<string, FirPositionInfo> FirPositionInfos { get; set; } = new Dictionary<string, FirPositionInfo>();

        public Dictionary<string, UirPositionInfo> UirPositionInfos { get; set; } = new Dictionary<string, UirPositionInfo>();

        public Dictionary<string, WorldPoint> InactiveAirports { get; set; } = new Dictionary<string, WorldPoint>();

        public Dictionary<int, PilotRating> PilotRatings { get; set; } = new Dictionary<int, PilotRating>();

        public string GetPilotRatingShortName(int id) => id == 0 || !this.PilotRatings.ContainsKey(id) ? string.Empty : this.PilotRatings[id].ShortName;

        public string GetPilotRatingLongName(int id) => id == 0 || !this.PilotRatings.ContainsKey(id) ? string.Empty : this.PilotRatings[id].LongName;
    }
}
