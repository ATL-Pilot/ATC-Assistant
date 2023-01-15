// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.PathPoint
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;

namespace ArincReader.Arinc424.Records
{
    public class PathPoint : BaseRecord
    {
        public const string SectionCode = "P";
        public const string SubsectionCode = "P";
        public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (AirportICAOIdentifier), 7, 10),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (ApproachProcedureIdentifier), 14, 19),
      new FieldStructure(nameof (RunwayHelipadIdentifier), 20, 24),
      new FieldStructure(nameof (OperationType), 25, 26),
      new FieldStructure(nameof (ContinuationRecordNumber), 27, 27),
      new FieldStructure(nameof (RouteIndicator), 28, 28),
      new FieldStructure(nameof (SBASServiceProviderIdentifier), 29, 30),
      new FieldStructure(nameof (ReferencePathDataSelector), 31, 32),
      new FieldStructure(nameof (ReferencePathIdentifier), 33, 36),
      new FieldStructure(nameof (ApproachPerformanceDesignator), 37, 37),
      new FieldStructure(nameof (LandingThresholdPointLatitude), 38, 48),
      new FieldStructure(nameof (LandingThresholdPointLongitude), 49, 60),
      new FieldStructure(nameof (LTP_EllipsoidHeight), 61, 66),
      new FieldStructure(nameof (GlidePathAngle), 67, 70),
      new FieldStructure(nameof (FlightPathAlignmentPointLatitude), 71, 81),
      new FieldStructure(nameof (FlightPathAlignmentPointLongitude), 82, 93),
      new FieldStructure(nameof (CourseWidthThreshold), 94, 98),
      new FieldStructure(nameof (LengthOffset), 99, 102),
      new FieldStructure(nameof (PathPointTCH), 103, 108),
      new FieldStructure(nameof (TCHUnitsIndicator), 109, 109),
      new FieldStructure(nameof (HAL), 110, 112),
      new FieldStructure(nameof (VAL), 113, 115),
      new FieldStructure(nameof (SBAS_FASDataCRCRemainder), 116, 123),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

        public PathPoint(string record)
          : base(record)
        {
        }

        public string CustomerAreaCode => this.GetFieldContents(PathPoint.Fields, nameof(CustomerAreaCode));

        public string AirportICAOIdentifier => this.GetFieldContents(PathPoint.Fields, nameof(AirportICAOIdentifier));

        public string ICAOCode11 => this.GetFieldContents(PathPoint.Fields, nameof(ICAOCode11));

        public string ApproachProcedureIdentifier => this.GetFieldContents(PathPoint.Fields, nameof(ApproachProcedureIdentifier));

        public string RunwayHelipadIdentifier => this.GetFieldContents(PathPoint.Fields, nameof(RunwayHelipadIdentifier));

        public string OperationType => this.GetFieldContents(PathPoint.Fields, nameof(OperationType));

        public string ContinuationRecordNumber => this.GetFieldContents(PathPoint.Fields, nameof(ContinuationRecordNumber));

        public string RouteIndicator => this.GetFieldContents(PathPoint.Fields, nameof(RouteIndicator));

        public string SBASServiceProviderIdentifier => this.GetFieldContents(PathPoint.Fields, nameof(SBASServiceProviderIdentifier));

        public string ReferencePathDataSelector => this.GetFieldContents(PathPoint.Fields, nameof(ReferencePathDataSelector));

        public string ReferencePathIdentifier => this.GetFieldContents(PathPoint.Fields, nameof(ReferencePathIdentifier));

        public string ApproachPerformanceDesignator => this.GetFieldContents(PathPoint.Fields, nameof(ApproachPerformanceDesignator));

        public string LandingThresholdPointLatitude => this.GetFieldContents(PathPoint.Fields, nameof(LandingThresholdPointLatitude));

        public string LandingThresholdPointLongitude => this.GetFieldContents(PathPoint.Fields, nameof(LandingThresholdPointLongitude));

        public string LTP_EllipsoidHeight => this.GetFieldContents(PathPoint.Fields, nameof(LTP_EllipsoidHeight));

        public string GlidePathAngle => this.GetFieldContents(PathPoint.Fields, nameof(GlidePathAngle));

        public string FlightPathAlignmentPointLatitude => this.GetFieldContents(PathPoint.Fields, nameof(FlightPathAlignmentPointLatitude));

        public string FlightPathAlignmentPointLongitude => this.GetFieldContents(PathPoint.Fields, nameof(FlightPathAlignmentPointLongitude));

        public string CourseWidthThreshold => this.GetFieldContents(PathPoint.Fields, nameof(CourseWidthThreshold));

        public string LengthOffset => this.GetFieldContents(PathPoint.Fields, nameof(LengthOffset));

        public string PathPointTCH => this.GetFieldContents(PathPoint.Fields, nameof(PathPointTCH));

        public string TCHUnitsIndicator => this.GetFieldContents(PathPoint.Fields, nameof(TCHUnitsIndicator));

        public string HAL => this.GetFieldContents(PathPoint.Fields, nameof(HAL));

        public string VAL => this.GetFieldContents(PathPoint.Fields, nameof(VAL));

        public string SBAS_FASDataCRCRemainder => this.GetFieldContents(PathPoint.Fields, nameof(SBAS_FASDataCRCRemainder));

        public string FileRecordNumber => this.GetFieldContents(PathPoint.Fields, nameof(FileRecordNumber));

        public string CycleDate => this.GetFieldContents(PathPoint.Fields, nameof(CycleDate));

        private static class FieldNames
        {
            public const string RecordType = "RecordType";
            public const string CustomerAreaCode = "CustomerAreaCode";
            public const string AirportICAOIdentifier = "AirportICAOIdentifier";
            public const string ICAOCode11 = "ICAOCode11";
            public const string ApproachProcedureIdentifier = "ApproachProcedureIdentifier";
            public const string RunwayHelipadIdentifier = "RunwayHelipadIdentifier";
            public const string OperationType = "OperationType";
            public const string ContinuationRecordNumber = "ContinuationRecordNumber";
            public const string RouteIndicator = "RouteIndicator";
            public const string SBASServiceProviderIdentifier = "SBASServiceProviderIdentifier";
            public const string ReferencePathDataSelector = "ReferencePathDataSelector";
            public const string ReferencePathIdentifier = "ReferencePathIdentifier";
            public const string ApproachPerformanceDesignator = "ApproachPerformanceDesignator";
            public const string LandingThresholdPointLatitude = "LandingThresholdPointLatitude";
            public const string LandingThresholdPointLongitude = "LandingThresholdPointLongitude";
            public const string LTP_EllipsoidHeight = "LTP_EllipsoidHeight";
            public const string GlidePathAngle = "GlidePathAngle";
            public const string FlightPathAlignmentPointLatitude = "FlightPathAlignmentPointLatitude";
            public const string FlightPathAlignmentPointLongitude = "FlightPathAlignmentPointLongitude";
            public const string CourseWidthThreshold = "CourseWidthThreshold";
            public const string LengthOffset = "LengthOffset";
            public const string PathPointTCH = "PathPointTCH";
            public const string TCHUnitsIndicator = "TCHUnitsIndicator";
            public const string HAL = "HAL";
            public const string VAL = "VAL";
            public const string SBAS_FASDataCRCRemainder = "SBAS_FASDataCRCRemainder";
            public const string FileRecordNumber = "FileRecordNumber";
            public const string CycleDate = "CycleDate";
        }
    }
}
