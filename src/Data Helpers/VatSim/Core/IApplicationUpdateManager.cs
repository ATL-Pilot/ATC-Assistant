// Decompiled with JetBrains decompiler
// Type: RossCarlson.Vatsim.VatSpy.Core.IApplicationUpdateManager
// Assembly: VATSpy, Version=1.3.3.19, Culture=neutral, PublicKeyToken=null
// MVID: 191BE92D-D460-48E2-AF38-70BEFDB1F90E
// Assembly location: D:\Flight Sim\VATSpy\VATSpy.exe

using System.Threading.Tasks;

namespace Vatsim.Core
{
  public interface IApplicationUpdateManager
  {
    Task<VersionInfo> CheckForNewVersion();

    Task<string> DownloadNewVersion(string url);
  }
}
