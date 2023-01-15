// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Arinc424PublicMilitaryIndicator
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;

namespace FpAssistantCore.Arinc424
{
  public enum Arinc424PublicMilitaryIndicator
  {
    [Description(Text = "Airport/Heliport is open to the public (civil)")] C,
    [Description(Text = "Airport/Heliport is military airport")] M,
    [Description(Text = "Airport/Heliport is not open to the public(private)")] P,
    [Description(Text = "Airport is joint Civil and Military")] J,
  }
}
