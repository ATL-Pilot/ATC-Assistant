// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.SbasApproachPerformanceDesignators
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;

namespace FpAssistantCore.GeneralAviation
{
  public enum SbasApproachPerformanceDesignators : byte
  {
    [Description(Text = "0 - APV")] Apv,
    [Description(Text = "1 - Category I")] CatI,
    [Description(Text = "2 - Reserved for Category II")] CatII,
    [Description(Text = "3 - Reserved Category III")] CatIII,
    [Description(Text = "4 - Spare")] Spare4,
    [Description(Text = "5 - Spare")] Spare5,
    [Description(Text = "6 - Spare")] Spare6,
    [Description(Text = "7 - Spare")] Spare7,
  }
}
