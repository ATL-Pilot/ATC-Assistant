// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.LicenseDetails
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Text.Json.Serialization;

namespace FpAssistantCore.General
{
  public class LicenseDetails
  {
    [JsonPropertyName("icaopansops")]
    public bool IcaoPansopsLicense { get; set; }

    [JsonPropertyName("faaterps")]
    public bool FaaTerpsLicense { get; set; }

    [JsonPropertyName("obstacleevaluation")]
    public bool ObstacleEvaluationLicense { get; set; }

    [JsonPropertyName("arinc424")]
    public bool Arinc424License { get; set; }

    [JsonPropertyName("developername")]
    public string DeveloperName { get; set; }

    [JsonPropertyName("developerkey")]
    public Guid DeveloperKey { get; set; }
  }
}
