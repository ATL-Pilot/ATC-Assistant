// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.AirportHeliport_LocalizerGlideSlope
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public class AirportHeliport_LocalizerGlideSlope : BaseRecord
  {
    public const string SectionCode = "P";
    public const string SubsectionCode = "I";
    public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (AirportICAOIdentifier), 7, 10),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (LocalizerIdentifier), 14, 17),
      new FieldStructure(nameof (ILSCategory), 18, 18),
      new FieldStructure(nameof (ContinuationRecordNumber), 22, 22),
      new FieldStructure(nameof (LocalizerFrequency), 23, 27),
      new FieldStructure(nameof (RunwayIdentifier), 28, 32),
      new FieldStructure(nameof (LocalizerLatitude), 33, 41),
      new FieldStructure(nameof (LocalizerLongitude), 42, 51),
      new FieldStructure(nameof (LocalizerBearing), 52, 55),
      new FieldStructure(nameof (GlideSlopeLatitude), 56, 64),
      new FieldStructure(nameof (GlideSlopeLongitude), 65, 74),
      new FieldStructure(nameof (LocalizerPosition), 75, 78),
      new FieldStructure(nameof (LocalizerPositionReference), 79, 79),
      new FieldStructure(nameof (GlideSlopePosition), 80, 83),
      new FieldStructure(nameof (LocalizerWidth), 84, 87),
      new FieldStructure(nameof (GlideSlopeAngle), 88, 90),
      new FieldStructure(nameof (StationDeclination), 91, 95),
      new FieldStructure(nameof (GlideSlopeHeightLandingThreshold), 96, 97),
      new FieldStructure(nameof (GlideSlopeElevation), 98, 102),
      new FieldStructure(nameof (SupportingFacilityID), 103, 106),
      new FieldStructure(nameof (SupportingFacilityICAOCode), 107, 108),
      new FieldStructure(nameof (SupportingFacilitySectionCode), 109, 109),
      new FieldStructure(nameof (SupportingFacilitySubsectionCode), 110, 110),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

    public AirportHeliport_LocalizerGlideSlope(string record)
      : base(record)
    {
    }

    public string CustomerAreaCode => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (CustomerAreaCode));

    public string AirportICAOIdentifier => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (AirportICAOIdentifier));

    public string ICAOCode11 => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (ICAOCode11));

    public string LocalizerIdentifier => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (LocalizerIdentifier));

    public string ILSCategory => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (ILSCategory));

    public string ContinuationRecordNumber => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (ContinuationRecordNumber));

    public string LocalizerFrequency => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (LocalizerFrequency));

    public string RunwayIdentifier => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (RunwayIdentifier));

    public string LocalizerLatitude => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (LocalizerLatitude));

    public string LocalizerLongitude => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (LocalizerLongitude));

    public string LocalizerBearing => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (LocalizerBearing));

    public string GlideSlopeLatitude => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (GlideSlopeLatitude));

    public string GlideSlopeLongitude => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (GlideSlopeLongitude));

    public string LocalizerPosition => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (LocalizerPosition));

    public string LocalizerPositionReference => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (LocalizerPositionReference));

    public string GlideSlopePosition => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (GlideSlopePosition));

    public string LocalizerWidth => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (LocalizerWidth));

    public string GlideSlopeAngle => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (GlideSlopeAngle));

    public string StationDeclination => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (StationDeclination));

    public string GlideSlopeHeightLandingThreshold => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (GlideSlopeHeightLandingThreshold));

    public string GlideSlopeElevation => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (GlideSlopeElevation));

    public string SupportingFacilityID => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (SupportingFacilityID));

    public string SupportingFacilityICAOCode => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (SupportingFacilityICAOCode));

    public string SupportingFacilitySectionCode => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (SupportingFacilitySectionCode));

    public string SupportingFacilitySubsectionCode => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (SupportingFacilitySubsectionCode));

    public string FileRecordNumber => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (FileRecordNumber));

    public string CycleDate => this.GetFieldContents(AirportHeliport_LocalizerGlideSlope.Fields, nameof (CycleDate));

    private static class FieldNames
    {
      public const string RecordType = "RecordType";
      public const string CustomerAreaCode = "CustomerAreaCode";
      public const string AirportICAOIdentifier = "AirportICAOIdentifier";
      public const string ICAOCode11 = "ICAOCode11";
      public const string LocalizerIdentifier = "LocalizerIdentifier";
      public const string ILSCategory = "ILSCategory";
      public const string ContinuationRecordNumber = "ContinuationRecordNumber";
      public const string LocalizerFrequency = "LocalizerFrequency";
      public const string RunwayIdentifier = "RunwayIdentifier";
      public const string LocalizerLatitude = "LocalizerLatitude";
      public const string LocalizerLongitude = "LocalizerLongitude";
      public const string LocalizerBearing = "LocalizerBearing";
      public const string GlideSlopeLatitude = "GlideSlopeLatitude";
      public const string GlideSlopeLongitude = "GlideSlopeLongitude";
      public const string LocalizerPosition = "LocalizerPosition";
      public const string LocalizerPositionReference = "LocalizerPositionReference";
      public const string GlideSlopePosition = "GlideSlopePosition";
      public const string LocalizerWidth = "LocalizerWidth";
      public const string GlideSlopeAngle = "GlideSlopeAngle";
      public const string StationDeclination = "StationDeclination";
      public const string GlideSlopeHeightLandingThreshold = "GlideSlopeHeightLandingThreshold";
      public const string GlideSlopeElevation = "GlideSlopeElevation";
      public const string SupportingFacilityID = "SupportingFacilityID";
      public const string SupportingFacilityICAOCode = "SupportingFacilityICAOCode";
      public const string SupportingFacilitySectionCode = "SupportingFacilitySectionCode";
      public const string SupportingFacilitySubsectionCode = "SupportingFacilitySubsectionCode";
      public const string FileRecordNumber = "FileRecordNumber";
      public const string CycleDate = "CycleDate";
    }
  }
}
