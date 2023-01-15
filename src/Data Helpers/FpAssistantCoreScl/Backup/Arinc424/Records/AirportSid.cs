// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.AirportSid
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public class AirportSid : AirportSidStarApproach
  {
    public const string SubsectionCode = "D";

    public AirportSid(string record)
      : base(record)
    {
    }

    public static List<Arinc424RecordObjectTypes> Filter => new List<Arinc424RecordObjectTypes>()
    {
      Arinc424RecordObjectTypes.AirportSid
    };
  }
}
