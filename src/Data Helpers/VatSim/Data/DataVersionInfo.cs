using Newtonsoft.Json;

namespace VatSim.Data
{
    public class DataVersionInfo
    {
        [JsonProperty("current_commit_hash")]
        public string CommitHash { get; set; }

        [JsonProperty("fir_boundaries_dat_url")]
        public string FirBoundaryDataUrl { get; set; }

        [JsonProperty("vatspy_dat_url")]
        public string VatspyDataUrl { get; set; }
    }
}
