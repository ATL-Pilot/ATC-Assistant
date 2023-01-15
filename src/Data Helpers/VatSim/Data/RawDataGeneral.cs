using Newtonsoft.Json;
using System;

namespace VatSim.Data
{
    public class RawDataGeneral
    {
        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("reload")]
        public int Reload { get; set; }

        [JsonProperty("update")]
        public string Update { get; set; }

        [JsonProperty("update_timestamp")]
        public DateTime UpdateTimestamp { get; set; }

        [JsonProperty("connected_clients")]
        public int ConnectedClients { get; set; }

        [JsonProperty("unique_users")]
        public int UniqueUsers { get; set; }
    }
}
