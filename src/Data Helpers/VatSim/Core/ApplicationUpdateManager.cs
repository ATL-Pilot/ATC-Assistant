// Decompiled with JetBrains decompiler
// Type: RossCarlson.Vatsim.VatSpy.Core.ApplicationUpdateManager
// Assembly: VATSpy, Version=1.3.3.19, Culture=neutral, PublicKeyToken=null
// MVID: 191BE92D-D460-48E2-AF38-70BEFDB1F90E
// Assembly location: D:\Flight Sim\VATSpy\VATSpy.exe

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vatsim.Core
{
  public class ApplicationUpdateManager : IApplicationUpdateManager
  {
    private const string LATEST_APP_VERSION_INFO_URL = "https://vatspy.rosscarlson.dev/LatestVersion.json";
    private const int LATEST_VERSION_INFO_DOWNLOAD_TIMEOUT = 10000;
    private const int LATEST_VERSION_DOWNLOAD_TIMEOUT = 10000;

    public async Task<VersionInfo> CheckForNewVersion()
    {
      VersionInfo versionInfo;
      using (ConfigurableWebClient webClient = new ConfigurableWebClient(10000))
      {
        webClient.Encoding = Encoding.UTF8;
        webClient.Headers.Add("user-agent", Application.ProductName + "/" + Application.ProductVersion);
        string str = await webClient.DownloadStringTaskAsync("https://vatspy.rosscarlson.dev/LatestVersion.json");
        Version version1 = Assembly.GetExecutingAssembly().GetName().Version;
        Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(str);
        Version version2 = new Version(dictionary["latestVersion"]);
        string latestVersion = dictionary["latestVersionInformational"];
        string downloadUrl = dictionary["downloadUrl"];
        versionInfo = !(version1 < version2) ? (VersionInfo) null : new VersionInfo(latestVersion, downloadUrl);
      }
      return versionInfo;
    }

    public async Task<string> DownloadNewVersion(string url)
    {
      string tempFilePath = Path.Combine(Path.GetTempPath(), Application.ProductName + "-Installer.exe");
      using (ConfigurableWebClient webClient = new ConfigurableWebClient(10000))
      {
        webClient.Encoding = Encoding.UTF8;
        webClient.Headers.Add("user-agent", Application.ProductName + "/" + Application.ProductVersion);
        await webClient.DownloadFileTaskAsync(url, tempFilePath);
      }
      string str = tempFilePath;
      tempFilePath = (string) null;
      return str;
    }
  }
}
