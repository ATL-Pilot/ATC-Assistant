using Newtonsoft.Json;

namespace VatSim.Data
{
    public class RawDataServer
    {
        [JsonProperty("ident")]
        public string Ident { get; set; }

        [JsonProperty("hostname_or_ip")]
        public string HostnameOrIp { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("clients_connection_allowed")]
        public int ClientsConnectionAllowed { get; set; }
    }
}
