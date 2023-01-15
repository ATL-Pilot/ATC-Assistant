// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.CommonRecordFields
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public abstract class CommonRecordFields : BaseRecord
  {
    private static readonly List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure(nameof (RecordType), 1, 1),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

    public CommonRecordFields(string record)
      : base(record)
    {
    }

    public Arinc424RecordGroupTypes RecordType => (Arinc424RecordGroupTypes) Enum.Parse(typeof (Arinc424RecordGroupTypes), this.GetFieldContents(CommonRecordFields.Fields, nameof (RecordType)));

    public long FileRecordNumber => long.Parse(this.GetFieldContents(CommonRecordFields.Fields, nameof (FileRecordNumber)));

    public CycleDate CycleDate => new CycleDate(this.GetFieldContents(CommonRecordFields.Fields, nameof (CycleDate)));

    private static class FieldNames
    {
      public const string RecordType = "RecordType";
      public const string FileRecordNumber = "FileRecordNumber";
      public const string CycleDate = "CycleDate";
    }
  }
}
