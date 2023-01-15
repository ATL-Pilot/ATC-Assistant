// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.FieldStructure
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

namespace FpAssistantCore.Arinc424.Records
{
  public class FieldStructure
  {
    public FieldStructure(string fieldName, int columnStart, int columnEnd)
    {
      this.FieldName = fieldName;
      this.ColumnStart = columnStart;
      this.ColumnEnd = columnEnd;
    }

    public string FieldName { get; set; }

    public int ColumnStart { get; set; }

    public int ColumnEnd { get; set; }

    public int FieldLength => this.ColumnEnd - this.ColumnStart + 1;
  }
}
