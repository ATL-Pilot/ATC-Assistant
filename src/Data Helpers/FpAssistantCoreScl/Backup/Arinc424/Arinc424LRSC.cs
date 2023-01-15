// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Arinc424LRSC
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;

namespace FpAssistantCore.Arinc424
{
  public enum Arinc424LRSC
  {
    [Description(Text = "Hard Surface, for example, asphalt or concrete")] H,
    [Description(Text = "Soft Surface, for example, gravel, grass or soil")] S,
    [Description(Text = "Water Runway")] W,
    [Description(Text = "Undefined, surface material not provided in source")] U,
  }
}
