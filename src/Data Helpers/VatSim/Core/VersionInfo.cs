// Decompiled with JetBrains decompiler
// Type: RossCarlson.VatSim.VatSpy.Core.VersionInfo
// Assembly: VATSpy, Version=1.3.3.19, Culture=neutral, PublicKeyToken=null
// MVID: 191BE92D-D460-48E2-AF38-70BEFDB1F90E
// Assembly location: D:\Flight Sim\VATSpy\VATSpy.exe

namespace VatSim.Core
{
    public class VersionInfo
    {
        internal string LatestVersion { get; }

        internal string DownloadUrl { get; }

        internal VersionInfo(string latestVersion, string downloadUrl)
        {
            this.LatestVersion = latestVersion;
            this.DownloadUrl = downloadUrl;
        }
    }
}
