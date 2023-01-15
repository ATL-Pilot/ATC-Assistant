using Newtonsoft.Json;

namespace VatSim.Data
{
    public class Meta
    {
        [JsonProperty("currentVersionHash")]
        public string CurrentVersionHash { get; set; } = string.Empty;
    }
}
