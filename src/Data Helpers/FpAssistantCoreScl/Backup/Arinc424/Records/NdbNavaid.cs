// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.NdbNavaid
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public class NdbNavaid : BaseRecord
  {
    public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (AirportICAOIdentifier), 7, 10),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (NDBIdentifier), 14, 17),
      new FieldStructure(nameof (ICAOCode20), 20, 21),
      new FieldStructure(nameof (ContinuationRecordNo), 22, 22),
      new FieldStructure(nameof (NDBFrequency), 23, 27),
      new FieldStructure(nameof (NDBClass), 28, 32),
      new FieldStructure(nameof (NDBLatitude), 33, 41),
      new FieldStructure(nameof (NDBLongitude), 42, 51),
      new FieldStructure(nameof (MagneticVariation), 75, 79),
      new FieldStructure(nameof (DatumCode), 91, 93),
      new FieldStructure(nameof (NDBName), 94, 123),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

    public NdbNavaid(string record)
      : base(record)
    {
    }

    public string CustomerAreaCode => this.GetFieldContents(NdbNavaid.Fields, nameof (CustomerAreaCode));

    public string AirportICAOIdentifier => this.GetFieldContents(NdbNavaid.Fields, nameof (AirportICAOIdentifier));

    public string ICAOCode11 => this.GetFieldContents(NdbNavaid.Fields, nameof (ICAOCode11));

    public string NDBIdentifier => this.GetFieldContents(NdbNavaid.Fields, nameof (NDBIdentifier));

    public string ICAOCode20 => this.GetFieldContents(NdbNavaid.Fields, nameof (ICAOCode20));

    public string ContinuationRecordNo => this.GetFieldContents(NdbNavaid.Fields, nameof (ContinuationRecordNo));

    public string NDBFrequency => this.GetFieldContents(NdbNavaid.Fields, nameof (NDBFrequency));

    public string NDBClass => this.GetFieldContents(NdbNavaid.Fields, nameof (NDBClass));

    public string NDBLatitude => this.GetFieldContents(NdbNavaid.Fields, nameof (NDBLatitude));

    public string NDBLongitude => this.GetFieldContents(NdbNavaid.Fields, nameof (NDBLongitude));

    public string MagneticVariation => this.GetFieldContents(NdbNavaid.Fields, nameof (MagneticVariation));

    public string DatumCode => this.GetFieldContents(NdbNavaid.Fields, nameof (DatumCode));

    public string NDBName => this.GetFieldContents(NdbNavaid.Fields, nameof (NDBName));

    public string FileRecordNumber => this.GetFieldContents(NdbNavaid.Fields, nameof (FileRecordNumber));

    public string CycleDate => this.GetFieldContents(NdbNavaid.Fields, nameof (CycleDate));

    private static class FieldNames
    {
      public const string RecordType = "RecordType";
      public const string CustomerAreaCode = "CustomerAreaCode";
      public const string AirportICAOIdentifier = "AirportICAOIdentifier";
      public const string ICAOCode11 = "ICAOCode11";
      public const string NDBIdentifier = "NDBIdentifier";
      public const string ICAOCode20 = "ICAOCode20";
      public const string ContinuationRecordNo = "ContinuationRecordNo";
      public const string NDBFrequency = "NDBFrequency";
      public const string NDBClass = "NDBClass";
      public const string NDBLatitude = "NDBLatitude";
      public const string NDBLongitude = "NDBLongitude";
      public const string MagneticVariation = "MagneticVariation";
      public const string DatumCode = "DatumCode";
      public const string NDBName = "NDBName";
      public const string FileRecordNumber = "FileRecordNumber";
      public const string CycleDate = "CycleDate";
    }
  }
}
