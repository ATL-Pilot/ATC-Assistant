// Decompiled with JetBrains decompiler
// Type: FpAssistantWebApi.Models.LatLongCoordinate
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System.Text.Json.Serialization;

namespace FpAssistantWebApi.Models
{
  public class LatLongCoordinate
  {
    [JsonPropertyName("csmapstatus")]
    public int CsMapStatus { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitute { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("coordinateSystem")]
    public string CoordinateSystem { get; set; }
  }
}
