// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.Waypoint
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public class Waypoint : CommonRecordFields
  {
    public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure("SectionCode", 5, 5),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (WaypointIdentifier), 14, 18),
      new FieldStructure(nameof (ICAOCode20), 20, 21),
      new FieldStructure(nameof (ContinuationRecordNo), 22, 22),
      new FieldStructure(nameof (WaypointType), 27, 29),
      new FieldStructure(nameof (WaypointUsage), 30, 31),
      new FieldStructure(nameof (WaypointLatitude), 33, 41),
      new FieldStructure(nameof (WaypointLongitude), 42, 51),
      new FieldStructure(nameof (DynamicMagneticVariation), 75, 79),
      new FieldStructure(nameof (DatumCode), 85, 87),
      new FieldStructure(nameof (NameFormatIndicator), 96, 98),
      new FieldStructure(nameof (WaypointName), 99, 123),
      new FieldStructure("FileRecordNumber", 124, 128),
      new FieldStructure("CycleDate", 129, 132)
    };

    public Waypoint(string record)
      : base(record)
    {
    }

    public string CustomerAreaCode => this.GetFieldContents(Waypoint.Fields, nameof (CustomerAreaCode));

    public string Section => this.GetFieldContents(Waypoint.Fields, "SectionCode");

    public string ICAOCode11 => this.GetFieldContents(Waypoint.Fields, nameof (ICAOCode11));

    public string WaypointIdentifier => this.GetFieldContents(Waypoint.Fields, nameof (WaypointIdentifier));

    public string ICAOCode20 => this.GetFieldContents(Waypoint.Fields, nameof (ICAOCode20));

    public string ContinuationRecordNo => this.GetFieldContents(Waypoint.Fields, nameof (ContinuationRecordNo));

    public string WaypointType => this.GetFieldContents(Waypoint.Fields, nameof (WaypointType));

    public string WaypointUsage => this.GetFieldContents(Waypoint.Fields, nameof (WaypointUsage));

    public string WaypointLatitude => this.GetFieldContents(Waypoint.Fields, nameof (WaypointLatitude));

    public string WaypointLongitude => this.GetFieldContents(Waypoint.Fields, nameof (WaypointLongitude));

    public string DynamicMagneticVariation => this.GetFieldContents(Waypoint.Fields, nameof (DynamicMagneticVariation));

    public string DatumCode => this.GetFieldContents(Waypoint.Fields, nameof (DatumCode));

    public string NameFormatIndicator => this.GetFieldContents(Waypoint.Fields, nameof (NameFormatIndicator));

    public string WaypointName => this.GetFieldContents(Waypoint.Fields, "NameFormatIndicator");

    private new static class FieldNames
    {
      public const string RecordType = "RecordType";
      public const string CustomerAreaCode = "CustomerAreaCode";
      public const string SectionCode = "SectionCode";
      public const string ICAOCode11 = "ICAOCode11";
      public const string WaypointIdentifier = "WaypointIdentifier";
      public const string ICAOCode20 = "ICAOCode20";
      public const string ContinuationRecordNo = "ContinuationRecordNo";
      public const string WaypointType = "WaypointType";
      public const string WaypointUsage = "WaypointUsage";
      public const string WaypointLatitude = "WaypointLatitude";
      public const string WaypointLongitude = "WaypointLongitude";
      public const string DynamicMagneticVariation = "DynamicMagneticVariation";
      public const string DatumCode = "DatumCode";
      public const string NameFormatIndicator = "NameFormatIndicator";
      public const string WaypointName = "WaypointName";
      public const string HeliportIdentifier = "HeliportIdentifier";
      public const string RegionCode = "RegionCode";
    }
  }
}
