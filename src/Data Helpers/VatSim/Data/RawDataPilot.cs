using Newtonsoft.Json;
using System;

namespace VatSim.Data
{
    public class RawDataPilot
    {
        [JsonProperty("cid")]
        public int Cid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("callsign")]
        public string Callsign { get; set; }

        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("pilot_rating")]
        public int PilotRating { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("altitude")]
        public int Altitude { get; set; }

        [JsonProperty("groundspeed")]
        public int GroundSpeed { get; set; }

        [JsonProperty("transponder")]
        public string Transponder { get; set; }

        [JsonProperty("heading")]
        public int Heading { get; set; }

        [JsonProperty("qnh_i_hg")]
        public float QnhInHg { get; set; }

        [JsonProperty("qnh_mb")]
        public int QnhMb { get; set; }

        [JsonProperty("flight_plan")]
        public RawDataFlightPlan FlightPlan { get; set; }

        [JsonProperty("logon_time")]
        public DateTime LogonTime { get; set; } = DateTime.MinValue;

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
