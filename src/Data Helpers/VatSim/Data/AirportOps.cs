using System.Collections.Generic;

namespace VatSim.Data
{
    public class AirportOps
    {
        public List<Flight> Arrivals = new List<Flight>();
        public List<Flight> Departures = new List<Flight>();
        public List<Flight> Inbounds = new List<Flight>();
        public List<Flight> Outbounds = new List<Flight>();
    }
}
