﻿// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.NdbNavaidEnroute
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

namespace FpAssistantCore.Arinc424.Records
{
  public class NdbNavaidEnroute : NdbNavaid
  {
    public static string SectionCode = "D";
    public static string SubsectionCode = "B";

    public NdbNavaidEnroute(string record)
      : base(record)
    {
    }
  }
}
