using Newtonsoft.Json;
using System.Collections.Generic;

namespace VatSim.Data
{
    public class RawData
    {
        [JsonProperty("general")]
        public RawDataGeneral General { get; set; }

        [JsonProperty("pilots")]
        public List<RawDataPilot> Pilots { get; set; } = new List<RawDataPilot>();

        [JsonProperty("controllers")]
        public List<RawDataController> Controllers { get; set; } = new List<RawDataController>();

        [JsonProperty("atis")]
        public List<RawDataController> Atises { get; set; } = new List<RawDataController>();

        [JsonProperty("servers")]
        public List<RawDataServer> Servers { get; set; } = new List<RawDataServer>();

        [JsonProperty("prefiles")]
        public List<RawDataPilot> Prefiles { get; set; } = new List<RawDataPilot>();

        [JsonProperty("pilot_ratings")]
        public List<RawDataPilotRating> PilotRatings { get; set; } = new List<RawDataPilotRating>();
    }
}
