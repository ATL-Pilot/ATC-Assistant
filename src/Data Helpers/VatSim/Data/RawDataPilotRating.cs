using Newtonsoft.Json;

namespace VatSim.Data
{
    public class RawDataPilotRating
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("long_name")]
        public string LongName { get; set; }
    }
}
