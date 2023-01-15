using System;

namespace VatSim.Data
{
    public class Flight
    {
        public bool Prefile;
        public string Callsign;
        public string Cid;
        public string RealName;
        public WorldPoint Loc;
        public int Alt;
        public int Speed;
        public string Equipment;
        public int PlannedSpeed;
        public string PlannedDep;
        public string PlannedAlt;
        public string PlannedDest;
        public string NetworkServer;
        public Rating Rating;
        public string Squawk;
        public FlightRules FlightRules;
        public string PlannedAlternate;
        public string Remarks;
        public string Route;
        public WorldPoint PlannedDepLoc;
        public WorldPoint PlannedDestLoc;
        public TimeSpan TimeOnline;
        public int Heading;
        public string DepAirportName;
        public string DestAirportName;
        public string DepCountryName;
        public string DestCountryName;
        public string DepFirIcao;
        public string DestFirIcao;
        public string WithinFirIcao;
        public string WithinCountry;
        public DateTime Eta;
        public double DistanceFromDep;
        public double DistanceToDest;
        public FlightStatus Status;
        public int PilotRating;

        public bool HasFlightPlan => !string.IsNullOrEmpty(this.PlannedDep) && !string.IsNullOrEmpty(this.PlannedDest);
    }
}
