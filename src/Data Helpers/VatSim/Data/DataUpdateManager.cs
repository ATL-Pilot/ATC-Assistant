using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VatSim.Core;

namespace VatSim.Data
{
    public class DataUpdateManager : IDataUpdateManager
    {
        private const int LATEST_VERSION_INFO_DOWNLOAD_TIMEOUT = 10000;
        private const string LATEST_DATA_VERSION_INFO_URL = "https://api.vatsim.net/api/map_data/";
        private const string META_DATA_FILENAME = "Meta.json";

        public event EventHandler MainDataDownloadStarted;

        public event EventHandler FirBoundaryDataDownloadStarted;

        public async Task CheckForNewDataFiles()
        {
            string metaPath = ".\\VatSim_Data\\Meta.json";
            Meta meta = new Meta();
            if (System.IO.File.Exists(metaPath))
                meta = JsonConvert.DeserializeObject<Meta>(System.IO.File.ReadAllText(metaPath));
            using (ConfigurableWebClient webClient = new ConfigurableWebClient(10000))
            {
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers.Add("user-agent", Application.ProductName + "/" + Application.ProductVersion);
                DataVersionInfo latestDataVersionInfo = JsonConvert.DeserializeObject<DataVersionInfo>(await webClient.DownloadStringTaskAsync("https://api.vatsim.net/api/map_data/"));
                if (latestDataVersionInfo.CommitHash != meta.CurrentVersionHash)
                {
                    await this.UpdateDatafiles((WebClient)webClient, latestDataVersionInfo);
                    meta.CurrentVersionHash = latestDataVersionInfo.CommitHash;
                    System.IO.File.WriteAllText(metaPath, JsonConvert.SerializeObject((object)meta, Formatting.Indented, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }));
                }
                latestDataVersionInfo = (DataVersionInfo)null;
            }
            metaPath = (string)null;
            meta = (Meta)null;
        }

        private async Task UpdateDatafiles(
          WebClient webClient,
          DataVersionInfo latestDataVersionInfo)
        {
            DataUpdateManager sender = this;
            EventHandler dataDownloadStarted1 = sender.MainDataDownloadStarted;
            if (dataDownloadStarted1 != null)
                dataDownloadStarted1((object)sender, EventArgs.Empty);
            await webClient.DownloadFileTaskAsync(latestDataVersionInfo.VatspyDataUrl, ".\\VatSim_Data\\VatSim.dat");
            EventHandler dataDownloadStarted2 = sender.FirBoundaryDataDownloadStarted;
            if (dataDownloadStarted2 != null)
                dataDownloadStarted2((object)sender, EventArgs.Empty);
            await webClient.DownloadFileTaskAsync(latestDataVersionInfo.FirBoundaryDataUrl, ".\\VatSim_Data\\FIRBoundaries.dat");
        }
    }
}
