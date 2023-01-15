// Decompiled with JetBrains decompiler
// Type: FpAssistantWebApi.Models.AzimuthDistance
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using System.Text.Json.Serialization;

namespace FpAssistantWebApi.Models
{
    public class AzimuthDistance
    {
        public AzimuthDistance(
          int csMapStatus,
          double azimuth,
          double distance,
          LinearDistanceUnits distanceUnits)
        {
            this.CsMapStatus = csMapStatus;
            this.Azimuth = azimuth;
            this.Distance = distance;
            this.DistanceUnits = distanceUnits;
        }

        [JsonPropertyName("csmapstatus")]
        public int CsMapStatus { get; set; }

        [JsonPropertyName("azimuth")]
        public double Azimuth { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("distanceunits")]
        public LinearDistanceUnits DistanceUnits { get; set; }
    }
}
