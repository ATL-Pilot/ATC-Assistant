using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VatSim.Data
{
    public class RawDataController
    {
        [JsonProperty("cid")]
        public int Cid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("callsign")]
        public string Callsign { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("facility")]
        public int Facility { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("visual_range")]
        public int VisualRange { get; set; }

        [JsonProperty("text_atis")]
        public List<string> TextAtis { get; set; } = new List<string>();

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("logon_time")]
        public DateTime LogonTime { get; set; } = DateTime.MinValue;
    }
}
