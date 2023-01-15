// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.GbasOperationTypes
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;

namespace FpAssistantCore.GeneralAviation
{
  public enum GbasOperationTypes : byte
  {
    [Description(Text = "0 - Straight-in approach procedure including offset procedures")] StraightInOffsetProcedure,
    [Description(Text = "1 - Terminal Area Path")] TerminalAreaPath,
    [Description(Text = "2 - Missed approach procedure")] MissedApproach,
    [Description(Text = "3 - Code reserved for future definition")] FutureDefinition3,
    [Description(Text = "4 - Code reserved for future definition")] FutureDefinition4,
    [Description(Text = "5 - Code reserved for future definition")] FutureDefinition5,
    [Description(Text = "6 - Code reserved for future definition")] FutureDefinition6,
    [Description(Text = "7 - Code reserved for future definition")] FutureDefinition7,
    [Description(Text = "8 - Code reserved for future definition")] FutureDefinition8,
    [Description(Text = "9 - Code reserved for future definition")] FutureDefinition9,
    [Description(Text = "10 - Code reserved for future definition")] FutureDefinition10,
    [Description(Text = "11 - Code reserved for future definition")] FutureDefinition11,
    [Description(Text = "12 - Code reserved for future definition")] FutureDefinition12,
    [Description(Text = "13 - Code reserved for future definition")] FutureDefinition13,
    [Description(Text = "14 - Code reserved for future definition")] FutureDefinition14,
    [Description(Text = "15 - Code reserved for future definition")] FutureDefinition15,
  }
}
