// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.HeliportSidStarApproach
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;

namespace ArincReader.Arinc424.Records
{
    public abstract class HeliportSidStarApproach : BaseRecord
    {
        public const string SectionCode = "H";
        public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (HeliportIdentifier), 7, 10),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (ProcedureIdentifier), 14, 19),
      new FieldStructure(nameof (RouteType), 20, 20),
      new FieldStructure(nameof (TransitionIdentifier), 21, 25),
      new FieldStructure(nameof (MultipleIndicator), 26, 26),
      new FieldStructure(nameof (SequenceNumber), 27, 29),
      new FieldStructure(nameof (FixIdentifier), 30, 34),
      new FieldStructure(nameof (ICAOCode35), 35, 36),
      new FieldStructure(nameof (SectionCode37), 37, 37),
      new FieldStructure(nameof (SubsectionCode38), 38, 38),
      new FieldStructure(nameof (ContinuationRecordNumber), 39, 39),
      new FieldStructure(nameof (WaypointDescriptionCode), 40, 43),
      new FieldStructure(nameof (TurnDirection), 44, 44),
      new FieldStructure(nameof (RNP), 45, 47),
      new FieldStructure(nameof (PathAndTermination), 48, 49),
      new FieldStructure(nameof (TurnDirecionValid), 50, 50),
      new FieldStructure(nameof (RecommendedNavaid), 51, 54),
      new FieldStructure(nameof (ICAOCode55), 55, 56),
      new FieldStructure(nameof (ArcRadius), 57, 62),
      new FieldStructure(nameof (Theta), 63, 66),
      new FieldStructure(nameof (Rho), 67, 70),
      new FieldStructure(nameof (MagneticCourse), 71, 74),
      new FieldStructure(nameof (RouteDistanceHoldingDistanceTime), 75, 78),
      new FieldStructure(nameof (RecommendedNavaidSection), 79, 79),
      new FieldStructure(nameof (RecommendedNavaidSubsection), 80, 80),
      new FieldStructure(nameof (AltitudeDescription), 83, 83),
      new FieldStructure(nameof (ATC_Indicator), 84, 84),
      new FieldStructure(nameof (Altitude1), 85, 89),
      new FieldStructure(nameof (Altitude2), 90, 94),
      new FieldStructure(nameof (TransitionAltitude), 95, 99),
      new FieldStructure(nameof (SpeedLimit), 100, 102),
      new FieldStructure(nameof (VerticalAngle), 103, 106),
      new FieldStructure(nameof (CenterFix), 107, 111),
      new FieldStructure(nameof (MultipleCode), 112, 112),
      new FieldStructure(nameof (ICAOCode113), 113, 114),
      new FieldStructure(nameof (SectionCode115), 115, 115),
      new FieldStructure(nameof (SubsectionCode116), 116, 116),
      new FieldStructure(nameof (GPSFMSIndication), 117, 117),
      new FieldStructure(nameof (SpeedLimitDescription), 118, 118),
      new FieldStructure(nameof (ApchRouteQualifier1), 119, 119),
      new FieldStructure(nameof (ApchRouteQualifier2), 120, 120),
      new FieldStructure(nameof (ApchRouteQualifier2), 121, 123),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

        public HeliportSidStarApproach(string record)
          : base(record)
        {
        }

        public string CustomerAreaCode => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(CustomerAreaCode));

        public string HeliportIdentifier => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(HeliportIdentifier));

        public string ICAOCode11 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ICAOCode11));

        public string ProcedureIdentifier => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ProcedureIdentifier));

        public string RouteType => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(RouteType));

        public string TransitionIdentifier => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(TransitionIdentifier));

        public string MultipleIndicator => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(MultipleIndicator));

        public string SequenceNumber => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(SequenceNumber));

        public string FixIdentifier => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(FixIdentifier));

        public string ICAOCode35 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ICAOCode35));

        public string SectionCode37 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(SectionCode37));

        public string SubsectionCode38 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(SubsectionCode38));

        public string ContinuationRecordNumber => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ContinuationRecordNumber));

        public string WaypointDescriptionCode => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(WaypointDescriptionCode));

        public string TurnDirection => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(TurnDirection));

        public string RNP => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(RNP));

        public string PathAndTermination => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(PathAndTermination));

        public string TurnDirecionValid => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(TurnDirecionValid));

        public string RecommendedNavaid => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(RecommendedNavaid));

        public string ICAOCode55 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ICAOCode55));

        public string ArcRadius => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ArcRadius));

        public string Theta => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(Theta));

        public string Rho => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(Rho));

        public string MagneticCourse => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(MagneticCourse));

        public string RouteDistanceHoldingDistanceTime => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(RouteDistanceHoldingDistanceTime));

        public string RecommendedNavaidSection => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(RecommendedNavaidSection));

        public string RecommendedNavaidSubsection => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(RecommendedNavaidSubsection));

        public string AltitudeDescription => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(AltitudeDescription));

        public string ATC_Indicator => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ATC_Indicator));

        public string Altitude1 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(Altitude1));

        public string Altitude2 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(Altitude2));

        public string TransitionAltitude => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(TransitionAltitude));

        public string SpeedLimit => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(SpeedLimit));

        public string VerticalAngle => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(VerticalAngle));

        public string CenterFix => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(CenterFix));

        public string MultipleCode => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(MultipleCode));

        public string ICAOCode113 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ICAOCode113));

        public string SectionCode115 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(SectionCode115));

        public string SubsectionCode116 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(SubsectionCode116));

        public string GPSFMSIndication => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(GPSFMSIndication));

        public string SpeedLimitDescription => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(SpeedLimitDescription));

        public string ApchRouteQualifier1 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ApchRouteQualifier1));

        public string ApchRouteQualifier2 => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(ApchRouteQualifier2));

        public string VerticalScaleFactor => this.GetFieldContents(HeliportSidStarApproach.Fields, "ApchRouteQualifier2");

        public string FileRecordNumber => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(FileRecordNumber));

        public string CycleDate => this.GetFieldContents(HeliportSidStarApproach.Fields, nameof(CycleDate));

        private static class FieldNames
        {
            public const string RecordType = "RecordType";
            public const string CustomerAreaCode = "CustomerAreaCode";
            public const string HeliportIdentifier = "HeliportIdentifier";
            public const string ICAOCode11 = "ICAOCode11";
            public const string ProcedureIdentifier = "ProcedureIdentifier";
            public const string RouteType = "RouteType";
            public const string TransitionIdentifier = "TransitionIdentifier";
            public const string MultipleIndicator = "MultipleIndicator";
            public const string SequenceNumber = "SequenceNumber";
            public const string FixIdentifier = "FixIdentifier";
            public const string ICAOCode35 = "ICAOCode35";
            public const string SectionCode37 = "SectionCode37";
            public const string SubsectionCode38 = "SubsectionCode38";
            public const string ContinuationRecordNumber = "ContinuationRecordNumber";
            public const string WaypointDescriptionCode = "WaypointDescriptionCode";
            public const string TurnDirection = "TurnDirection";
            public const string RNP = "RNP";
            public const string PathAndTermination = "PathAndTermination";
            public const string TurnDirecionValid = "TurnDirecionValid";
            public const string RecommendedNavaid = "RecommendedNavaid";
            public const string ICAOCode55 = "ICAOCode55";
            public const string ArcRadius = "ArcRadius";
            public const string Theta = "Theta";
            public const string Rho = "Rho";
            public const string MagneticCourse = "MagneticCourse";
            public const string RouteDistanceHoldingDistanceTime = "RouteDistanceHoldingDistanceTime";
            public const string RecommendedNavaidSection = "RecommendedNavaidSection";
            public const string RecommendedNavaidSubsection = "RecommendedNavaidSubsection";
            public const string AltitudeDescription = "AltitudeDescription";
            public const string ATC_Indicator = "ATC_Indicator";
            public const string Altitude1 = "Altitude1";
            public const string Altitude2 = "Altitude2";
            public const string TransitionAltitude = "TransitionAltitude";
            public const string SpeedLimit = "SpeedLimit";
            public const string VerticalAngle = "VerticalAngle";
            public const string CenterFix = "CenterFix";
            public const string MultipleCode = "MultipleCode";
            public const string ICAOCode113 = "ICAOCode113";
            public const string SectionCode115 = "SectionCode115";
            public const string SubsectionCode116 = "SubsectionCode116";
            public const string GPSFMSIndication = "GPSFMSIndication";
            public const string SpeedLimitDescription = "SpeedLimitDescription";
            public const string ApchRouteQualifier1 = "ApchRouteQualifier1";
            public const string ApchRouteQualifier2 = "ApchRouteQualifier2";
            public const string VerticalScaleFactor = "ApchRouteQualifier2";
            public const string FileRecordNumber = "FileRecordNumber";
            public const string CycleDate = "CycleDate";
        }
    }
}
