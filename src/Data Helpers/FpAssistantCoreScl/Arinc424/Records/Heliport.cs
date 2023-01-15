// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.Heliport
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;

namespace ArincReader.Arinc424.Records
{
    public class Heliport : BaseRecord
    {
        public const string SectionCode = "H";
        public const string SubsectionCode = "A";
        public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (IATADesignator), 14, 16),
      new FieldStructure(nameof (PADIdentifier), 17, 21),
      new FieldStructure(nameof (ContinuationRecordNo), 22, 22),
      new FieldStructure(nameof (SpeedLimitAltitude), 23, 27),
      new FieldStructure(nameof (DatumCode), 28, 30),
      new FieldStructure(nameof (IFRIndicator), 31, 31),
      new FieldStructure(nameof (Latitude), 33, 41),
      new FieldStructure(nameof (Longitude), 42, 51),
      new FieldStructure(nameof (MagneticVariation), 52, 56),
      new FieldStructure(nameof (HeliportElevation), 57, 61),
      new FieldStructure(nameof (SpeedLimit), 62, 64),
      new FieldStructure(nameof (RecommendedVHFNavaid), 65, 68),
      new FieldStructure(nameof (ICAOCode69), 69, 70),
      new FieldStructure(nameof (TransitionAltitude), 71, 75),
      new FieldStructure(nameof (TransitionLevel), 76, 80),
      new FieldStructure(nameof (PublicMilitaryIndicator), 81, 81),
      new FieldStructure(nameof (TimeZone), 82, 84),
      new FieldStructure(nameof (DaylightIndicator), 85, 85),
      new FieldStructure(nameof (PadDimension), 86, 91),
      new FieldStructure(nameof (MagneticTrueIndicator), 92, 92),
      new FieldStructure(nameof (HeliportName), 94, 123),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

        public Heliport(string record)
          : base(record)
        {
        }

        public string CustomerAreaCode => this.GetFieldContents(Heliport.Fields, nameof(CustomerAreaCode));

        public string ICAOCode11 => this.GetFieldContents(Heliport.Fields, nameof(ICAOCode11));

        public string IATADesignator => this.GetFieldContents(Heliport.Fields, nameof(IATADesignator));

        public string PADIdentifier => this.GetFieldContents(Heliport.Fields, nameof(PADIdentifier));

        public string ContinuationRecordNo => this.GetFieldContents(Heliport.Fields, nameof(ContinuationRecordNo));

        public string SpeedLimitAltitude => this.GetFieldContents(Heliport.Fields, nameof(SpeedLimitAltitude));

        public string DatumCode => this.GetFieldContents(Heliport.Fields, nameof(DatumCode));

        public string IFRIndicator => this.GetFieldContents(Heliport.Fields, nameof(IFRIndicator));

        public string Latitude => this.GetFieldContents(Heliport.Fields, nameof(Latitude));

        public string Longitude => this.GetFieldContents(Heliport.Fields, nameof(Longitude));

        public string MagneticVariation => this.GetFieldContents(Heliport.Fields, nameof(MagneticVariation));

        public string HeliportElevation => this.GetFieldContents(Heliport.Fields, nameof(HeliportElevation));

        public string SpeedLimit => this.GetFieldContents(Heliport.Fields, nameof(SpeedLimit));

        public string RecommendedVHFNavaid => this.GetFieldContents(Heliport.Fields, nameof(RecommendedVHFNavaid));

        public string ICAOCode69 => this.GetFieldContents(Heliport.Fields, nameof(ICAOCode69));

        public string TransitionAltitude => this.GetFieldContents(Heliport.Fields, nameof(TransitionAltitude));

        public string TransitionLevel => this.GetFieldContents(Heliport.Fields, nameof(TransitionLevel));

        public string PublicMilitaryIndicator => this.GetFieldContents(Heliport.Fields, nameof(PublicMilitaryIndicator));

        public string TimeZone => this.GetFieldContents(Heliport.Fields, nameof(TimeZone));

        public string DaylightIndicator => this.GetFieldContents(Heliport.Fields, nameof(DaylightIndicator));

        public string PadDimension => this.GetFieldContents(Heliport.Fields, nameof(PadDimension));

        public string MagneticTrueIndicator => this.GetFieldContents(Heliport.Fields, nameof(MagneticTrueIndicator));

        public string HeliportName => this.GetFieldContents(Heliport.Fields, nameof(HeliportName));

        public string FileRecordNumber => this.GetFieldContents(Heliport.Fields, nameof(FileRecordNumber));

        public string CycleDate => this.GetFieldContents(Heliport.Fields, nameof(CycleDate));

        private static class FieldNames
        {
            public const string RecordType = "RecordType";
            public const string CustomerAreaCode = "CustomerAreaCode";
            public const string ICAOCode11 = "ICAOCode11";
            public const string IATADesignator = "IATADesignator";
            public const string PADIdentifier = "PADIdentifier";
            public const string ContinuationRecordNo = "ContinuationRecordNo";
            public const string SpeedLimitAltitude = "SpeedLimitAltitude";
            public const string DatumCode = "DatumCode";
            public const string IFRIndicator = "IFRIndicator";
            public const string Latitude = "Latitude";
            public const string Longitude = "Longitude";
            public const string MagneticVariation = "MagneticVariation";
            public const string HeliportElevation = "HeliportElevation";
            public const string SpeedLimit = "SpeedLimit";
            public const string RecommendedVHFNavaid = "RecommendedVHFNavaid";
            public const string ICAOCode69 = "ICAOCode69";
            public const string TransitionAltitude = "TransitionAltitude";
            public const string TransitionLevel = "TransitionLevel";
            public const string PublicMilitaryIndicator = "PublicMilitaryIndicator";
            public const string TimeZone = "TimeZone";
            public const string DaylightIndicator = "DaylightIndicator";
            public const string PadDimension = "PadDimension";
            public const string MagneticTrueIndicator = "MagneticTrueIndicator";
            public const string HeliportName = "HeliportName";
            public const string FileRecordNumber = "FileRecordNumber";
            public const string CycleDate = "CycleDate";
        }
    }
}
