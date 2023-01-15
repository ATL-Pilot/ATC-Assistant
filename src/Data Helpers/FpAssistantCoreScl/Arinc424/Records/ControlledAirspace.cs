// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.ControlledAirspace
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;

namespace ArincReader.Arinc424.Records
{
    public class ControlledAirspace : BaseRecord
    {
        public const string SectionCode = "U";
        public const string SubsectionCode = "C";
        public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (ICAOCode), 7, 8),
      new FieldStructure(nameof (AirspaceType), 9, 9),
      new FieldStructure(nameof (AirspaceCenter), 10, 14),
      new FieldStructure(nameof (AirspaceClassification), 17, 17),
      new FieldStructure(nameof (MultipleCode), 20, 20),
      new FieldStructure(nameof (SequenceNumber), 21, 24),
      new FieldStructure(nameof (ContinuationRecordNo), 25, 25),
      new FieldStructure(nameof (Level), 26, 26),
      new FieldStructure(nameof (TimeCode), 27, 27),
      new FieldStructure(nameof (NOTAM), 28, 28),
      new FieldStructure(nameof (BoundaryVia), 31, 32),
      new FieldStructure(nameof (Latitude), 33, 41),
      new FieldStructure(nameof (Longitude), 42, 51),
      new FieldStructure(nameof (ArcOriginLatitude), 52, 60),
      new FieldStructure(nameof (ArcOriginLongitude), 61, 70),
      new FieldStructure(nameof (ArcDistance), 71, 74),
      new FieldStructure(nameof (ArcBearing), 75, 78),
      new FieldStructure(nameof (RNP), 79, 81),
      new FieldStructure(nameof (LowerLimit), 82, 86),
      new FieldStructure(nameof (UnitIndicatorLower), 87, 87),
      new FieldStructure(nameof (UpperLimit), 88, 92),
      new FieldStructure("UnitIndicatortUpper", 93, 93),
      new FieldStructure(nameof (ControlledAirspaceName), 94, 123),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

        public ControlledAirspace(string record)
          : base(record)
        {
        }

        public string CustomerAreaCode => this.GetFieldContents(ControlledAirspace.Fields, nameof(CustomerAreaCode));

        public string ICAOCode => this.GetFieldContents(ControlledAirspace.Fields, nameof(ICAOCode));

        public string AirspaceType => this.GetFieldContents(ControlledAirspace.Fields, nameof(AirspaceType));

        public string AirspaceCenter => this.GetFieldContents(ControlledAirspace.Fields, nameof(AirspaceCenter));

        public string AirspaceClassification => this.GetFieldContents(ControlledAirspace.Fields, nameof(AirspaceClassification));

        public string MultipleCode => this.GetFieldContents(ControlledAirspace.Fields, nameof(MultipleCode));

        public string SequenceNumber => this.GetFieldContents(ControlledAirspace.Fields, nameof(SequenceNumber));

        public string ContinuationRecordNo => this.GetFieldContents(ControlledAirspace.Fields, nameof(ContinuationRecordNo));

        public string Level => this.GetFieldContents(ControlledAirspace.Fields, nameof(Level));

        public string TimeCode => this.GetFieldContents(ControlledAirspace.Fields, nameof(TimeCode));

        public string NOTAM => this.GetFieldContents(ControlledAirspace.Fields, nameof(NOTAM));

        public string BoundaryVia => this.GetFieldContents(ControlledAirspace.Fields, nameof(BoundaryVia));

        public string Latitude => this.GetFieldContents(ControlledAirspace.Fields, nameof(Latitude));

        public string Longitude => this.GetFieldContents(ControlledAirspace.Fields, nameof(Longitude));

        public string ArcOriginLatitude => this.GetFieldContents(ControlledAirspace.Fields, nameof(ArcOriginLatitude));

        public string ArcOriginLongitude => this.GetFieldContents(ControlledAirspace.Fields, nameof(ArcOriginLongitude));

        public string ArcDistance => this.GetFieldContents(ControlledAirspace.Fields, nameof(ArcDistance));

        public string ArcBearing => this.GetFieldContents(ControlledAirspace.Fields, nameof(ArcBearing));

        public string RNP => this.GetFieldContents(ControlledAirspace.Fields, nameof(RNP));

        public string LowerLimit => this.GetFieldContents(ControlledAirspace.Fields, nameof(LowerLimit));

        public string UnitIndicatorLower => this.GetFieldContents(ControlledAirspace.Fields, nameof(UnitIndicatorLower));

        public string UpperLimit => this.GetFieldContents(ControlledAirspace.Fields, nameof(UpperLimit));

        public string UnitIndicatorUpper => this.GetFieldContents(ControlledAirspace.Fields, "UnitIndicatortUpper");

        public string ControlledAirspaceName => this.GetFieldContents(ControlledAirspace.Fields, nameof(ControlledAirspaceName));

        public string FileRecordNumber => this.GetFieldContents(ControlledAirspace.Fields, nameof(FileRecordNumber));

        public string CycleDate => this.GetFieldContents(ControlledAirspace.Fields, nameof(CycleDate));

        private static class FieldNames
        {
            public const string RecordType = "RecordType";
            public const string CustomerAreaCode = "CustomerAreaCode";
            public const string ICAOCode = "ICAOCode";
            public const string AirspaceType = "AirspaceType";
            public const string AirspaceCenter = "AirspaceCenter";
            public const string AirspaceClassification = "AirspaceClassification";
            public const string MultipleCode = "MultipleCode";
            public const string SequenceNumber = "SequenceNumber";
            public const string ContinuationRecordNo = "ContinuationRecordNo";
            public const string Level = "Level";
            public const string TimeCode = "TimeCode";
            public const string NOTAM = "NOTAM";
            public const string BoundaryVia = "BoundaryVia";
            public const string Latitude = "Latitude";
            public const string Longitude = "Longitude";
            public const string ArcOriginLatitude = "ArcOriginLatitude";
            public const string ArcOriginLongitude = "ArcOriginLongitude";
            public const string ArcDistance = "ArcDistance";
            public const string ArcBearing = "ArcBearing";
            public const string RNP = "RNP";
            public const string LowerLimit = "LowerLimit";
            public const string UnitIndicatorLower = "UnitIndicatorLower";
            public const string UpperLimit = "UpperLimit";
            public const string UnitIndicatortUpper = "UnitIndicatortUpper";
            public const string ControlledAirspaceName = "ControlledAirspaceName";
            public const string FileRecordNumber = "FileRecordNumber";
            public const string CycleDate = "CycleDate";
        }
    }
}
