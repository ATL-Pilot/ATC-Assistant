// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.HeliportMsa
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public class HeliportMsa : BaseRecord
  {
    public static string SectionCode = "H";
    public static string SubsectionCode = "S";
    public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (HeliportIdentifier), 7, 10),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (MSACenter), 14, 18),
      new FieldStructure(nameof (ICAOCode19), 19, 20),
      new FieldStructure(nameof (SectionCode21), 21, 21),
      new FieldStructure(nameof (SubsectionCode22), 22, 22),
      new FieldStructure(nameof (MultipleCode), 23, 23),
      new FieldStructure(nameof (ContinuationRecordNumber), 39, 39),
      new FieldStructure("SectorBearing1", 43, 48),
      new FieldStructure("SectorAltitude1", 49, 51),
      new FieldStructure("SectorRadius1", 52, 53),
      new FieldStructure("SectorBearing2", 54, 59),
      new FieldStructure("SectorAltitude2", 60, 62),
      new FieldStructure("SectorRadius2", 63, 64),
      new FieldStructure("SectorBearing3", 65, 70),
      new FieldStructure("SectorAltitude3", 71, 73),
      new FieldStructure("SectorRadius3", 74, 75),
      new FieldStructure("SectorBearing4", 76, 81),
      new FieldStructure("SectorAltitude4", 82, 84),
      new FieldStructure("SectorRadius4", 85, 86),
      new FieldStructure("SectorBearing5", 87, 92),
      new FieldStructure("SectorAltitude5", 93, 95),
      new FieldStructure("SectorRadius5", 96, 97),
      new FieldStructure("SectorBearing6", 98, 103),
      new FieldStructure("SectorAltitude6", 104, 106),
      new FieldStructure("SectorRadius6", 107, 108),
      new FieldStructure("SectorBearing7", 109, 114),
      new FieldStructure("SectorAltitude7", 115, 117),
      new FieldStructure("SectorRadius7", 118, 119),
      new FieldStructure(nameof (MagneticTrueIndicator), 120, 120),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

    public HeliportMsa(string record)
      : base(record)
    {
    }

    public string CustomerAreaCode => this.GetFieldContents(HeliportMsa.Fields, nameof (CustomerAreaCode));

    public string HeliportIdentifier => this.GetFieldContents(HeliportMsa.Fields, nameof (HeliportIdentifier));

    public string ICAOCode11 => this.GetFieldContents(HeliportMsa.Fields, nameof (ICAOCode11));

    public string MSACenter => this.GetFieldContents(HeliportMsa.Fields, nameof (MSACenter));

    public string ICAOCode19 => this.GetFieldContents(HeliportMsa.Fields, nameof (ICAOCode19));

    public string SectionCode21 => this.GetFieldContents(HeliportMsa.Fields, nameof (SectionCode21));

    public string SubsectionCode22 => this.GetFieldContents(HeliportMsa.Fields, nameof (SubsectionCode22));

    public string MultipleCode => this.GetFieldContents(HeliportMsa.Fields, nameof (MultipleCode));

    public string ContinuationRecordNumber => this.GetFieldContents(HeliportMsa.Fields, nameof (ContinuationRecordNumber));

    public SectorDataset SectorDataset1 => new SectorDataset()
    {
      Bearing = this.GetFieldContents(HeliportMsa.Fields, "SectorBearing1"),
      Altitude = this.GetFieldContents(HeliportMsa.Fields, "SectorAltitude1"),
      Radius = this.GetFieldContents(HeliportMsa.Fields, "SectorRadius1")
    };

    public SectorDataset SectorDataset2 => new SectorDataset()
    {
      Bearing = this.GetFieldContents(HeliportMsa.Fields, "SectorBearing2"),
      Altitude = this.GetFieldContents(HeliportMsa.Fields, "SectorAltitude2"),
      Radius = this.GetFieldContents(HeliportMsa.Fields, "SectorRadius2")
    };

    public SectorDataset SectorDataset3 => new SectorDataset()
    {
      Bearing = this.GetFieldContents(HeliportMsa.Fields, "SectorBearing3"),
      Altitude = this.GetFieldContents(HeliportMsa.Fields, "SectorAltitude3"),
      Radius = this.GetFieldContents(HeliportMsa.Fields, "SectorRadius3")
    };

    public SectorDataset SectorDataset4 => new SectorDataset()
    {
      Bearing = this.GetFieldContents(HeliportMsa.Fields, "SectorBearing4"),
      Altitude = this.GetFieldContents(HeliportMsa.Fields, "SectorAltitude4"),
      Radius = this.GetFieldContents(HeliportMsa.Fields, "SectorRadius4")
    };

    public SectorDataset SectorDataset5 => new SectorDataset()
    {
      Bearing = this.GetFieldContents(HeliportMsa.Fields, "SectorBearing5"),
      Altitude = this.GetFieldContents(HeliportMsa.Fields, "SectorAltitude5"),
      Radius = this.GetFieldContents(HeliportMsa.Fields, "SectorRadius5")
    };

    public SectorDataset SectorDataset6 => new SectorDataset()
    {
      Bearing = this.GetFieldContents(HeliportMsa.Fields, "SectorBearing6"),
      Altitude = this.GetFieldContents(HeliportMsa.Fields, "SectorAltitude6"),
      Radius = this.GetFieldContents(HeliportMsa.Fields, "SectorRadius6")
    };

    public SectorDataset SectorDataset7 => new SectorDataset()
    {
      Bearing = this.GetFieldContents(HeliportMsa.Fields, "SectorBearing7"),
      Altitude = this.GetFieldContents(HeliportMsa.Fields, "SectorAltitude7"),
      Radius = this.GetFieldContents(HeliportMsa.Fields, "SectorRadius7")
    };

    public string MagneticTrueIndicator => this.GetFieldContents(HeliportMsa.Fields, nameof (MagneticTrueIndicator));

    public string FileRecordNumber => this.GetFieldContents(HeliportMsa.Fields, nameof (FileRecordNumber));

    public string CycleDate => this.GetFieldContents(HeliportMsa.Fields, nameof (CycleDate));

    private static class FieldNames
    {
      public const string RecordType = "RecordType";
      public const string CustomerAreaCode = "CustomerAreaCode";
      public const string HeliportIdentifier = "HeliportIdentifier";
      public const string ICAOCode11 = "ICAOCode11";
      public const string MSACenter = "MSACenter";
      public const string ICAOCode19 = "ICAOCode19";
      public const string SectionCode21 = "SectionCode21";
      public const string SubsectionCode22 = "SubsectionCode22";
      public const string MultipleCode = "MultipleCode";
      public const string ContinuationRecordNumber = "ContinuationRecordNumber";
      public const string SectorBearing1 = "SectorBearing1";
      public const string SectorAltitude1 = "SectorAltitude1";
      public const string SectorRadius1 = "SectorRadius1";
      public const string SectorBearing2 = "SectorBearing2";
      public const string SectorAltitude2 = "SectorAltitude2";
      public const string SectorRadius2 = "SectorRadius2";
      public const string SectorBearing3 = "SectorBearing3";
      public const string SectorAltitude3 = "SectorAltitude3";
      public const string SectorRadius3 = "SectorRadius3";
      public const string SectorBearing4 = "SectorBearing4";
      public const string SectorAltitude4 = "SectorAltitude4";
      public const string SectorRadius4 = "SectorRadius4";
      public const string SectorBearing5 = "SectorBearing5";
      public const string SectorAltitude5 = "SectorAltitude5";
      public const string SectorRadius5 = "SectorRadius5";
      public const string SectorBearing6 = "SectorBearing6";
      public const string SectorAltitude6 = "SectorAltitude6";
      public const string SectorRadius6 = "SectorRadius6";
      public const string SectorBearing7 = "SectorBearing7";
      public const string SectorAltitude7 = "SectorAltitude7";
      public const string SectorRadius7 = "SectorRadius7";
      public const string MagneticTrueIndicator = "MagneticTrueIndicator";
      public const string FileRecordNumber = "FileRecordNumber";
      public const string CycleDate = "CycleDate";
    }
  }
}
