// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.EnrouteAirway
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public class EnrouteAirway : CommonRecordFields
  {
    public const string SectionCode = "E";
    public const string SubsectionCode = "R";
    public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (RouteIdentifier), 14, 18),
      new FieldStructure(nameof (SequenceNumber), 26, 29),
      new FieldStructure(nameof (FixIdentifier), 30, 34),
      new FieldStructure(nameof (ICAOCode35), 35, 36),
      new FieldStructure(nameof (ContinuationRecordNo), 39, 39),
      new FieldStructure(nameof (WaypointDescriptionCode), 40, 43),
      new FieldStructure(nameof (BoundaryCode), 44, 44),
      new FieldStructure(nameof (RouteType), 45, 45),
      new FieldStructure(nameof (Level), 46, 46),
      new FieldStructure(nameof (DirectionRestriction), 47, 47),
      new FieldStructure(nameof (CruiseTableIndicator), 48, 49),
      new FieldStructure(nameof (EUIndicator), 50, 50),
      new FieldStructure(nameof (RecommendedNavaid), 51, 54),
      new FieldStructure(nameof (ICAOCode55), 55, 56),
      new FieldStructure(nameof (RNP), 57, 59),
      new FieldStructure(nameof (Theta), 63, 66),
      new FieldStructure(nameof (Rho), 67, 70),
      new FieldStructure(nameof (OutboundMagneticCourse), 71, 74),
      new FieldStructure(nameof (RouteDistanceFrom), 75, 78),
      new FieldStructure(nameof (InboundMagneticCourse), 79, 82),
      new FieldStructure(nameof (MinimumAltitude1), 84, 88),
      new FieldStructure(nameof (MinimumAltitude2), 89, 93),
      new FieldStructure(nameof (MinimumAltitude3), 94, 98),
      new FieldStructure(nameof (FixRadiusTransitionIndicator), 99, 101),
      new FieldStructure(nameof (VerticalScaleFactor), 102, 104),
      new FieldStructure(nameof (RVSMMinimumLevel), 105, 107),
      new FieldStructure(nameof (VSFRVSMMaximumLevel), 108, 110),
      new FieldStructure(nameof (ICAOCode115), 115, 116),
      new FieldStructure("FileRecordNumber", 124, 128),
      new FieldStructure("CycleDate", 129, 132)
    };

    public EnrouteAirway(string record)
      : base(record)
    {
    }

    public static List<Arinc424RecordObjectTypes> Filter => new List<Arinc424RecordObjectTypes>()
    {
      Arinc424RecordObjectTypes.EnrouteAirway
    };

    public string CustomerAreaCode => this.GetFieldContents(EnrouteAirway.Fields, nameof (CustomerAreaCode));

    public string RouteIdentifier => this.GetFieldContents(EnrouteAirway.Fields, nameof (RouteIdentifier));

    public int SequenceNumber => int.Parse(this.GetFieldContents(EnrouteAirway.Fields, nameof (SequenceNumber)));

    public string FixIdentifier => this.GetFieldContents(EnrouteAirway.Fields, nameof (FixIdentifier));

    public string ICAOCode35 => this.GetFieldContents(EnrouteAirway.Fields, nameof (ICAOCode35));

    public int ContinuationRecordNo => int.Parse(this.GetFieldContents(EnrouteAirway.Fields, nameof (ContinuationRecordNo)));

    public string WaypointDescriptionCode => this.GetFieldContents(EnrouteAirway.Fields, nameof (WaypointDescriptionCode));

    public string BoundaryCode => this.GetFieldContents(EnrouteAirway.Fields, nameof (BoundaryCode));

    public EnrouteAirway.RouteTypes RouteType => (EnrouteAirway.RouteTypes) Enum.Parse(typeof (EnrouteAirway.RouteTypes), this.GetFieldContents(EnrouteAirway.Fields, nameof (RouteType)));

    public string Level => this.GetFieldContents(EnrouteAirway.Fields, nameof (Level));

    public string DirectionRestriction => this.GetFieldContents(EnrouteAirway.Fields, nameof (DirectionRestriction));

    public string CruiseTableIndicator => this.GetFieldContents(EnrouteAirway.Fields, nameof (CruiseTableIndicator));

    public string EUIndicator => this.GetFieldContents(EnrouteAirway.Fields, nameof (EUIndicator));

    public string RecommendedNavaid => this.GetFieldContents(EnrouteAirway.Fields, nameof (RecommendedNavaid));

    public string ICAOCode55 => this.GetFieldContents(EnrouteAirway.Fields, nameof (ICAOCode55));

    public string RNP => this.GetFieldContents(EnrouteAirway.Fields, nameof (RNP));

    public string Theta => this.GetFieldContents(EnrouteAirway.Fields, nameof (Theta));

    public string Rho => this.GetFieldContents(EnrouteAirway.Fields, nameof (Rho));

    public string OutboundMagneticCourse => this.GetFieldContents(EnrouteAirway.Fields, nameof (OutboundMagneticCourse));

    public string RouteDistanceFrom => this.GetFieldContents(EnrouteAirway.Fields, nameof (RouteDistanceFrom));

    public string InboundMagneticCourse => this.GetFieldContents(EnrouteAirway.Fields, nameof (InboundMagneticCourse));

    public string MinimumAltitude1 => this.GetFieldContents(EnrouteAirway.Fields, nameof (MinimumAltitude1));

    public string MinimumAltitude2 => this.GetFieldContents(EnrouteAirway.Fields, nameof (MinimumAltitude2));

    public string MinimumAltitude3 => this.GetFieldContents(EnrouteAirway.Fields, nameof (MinimumAltitude3));

    public string FixRadiusTransitionIndicator => this.GetFieldContents(EnrouteAirway.Fields, nameof (FixRadiusTransitionIndicator));

    public string VerticalScaleFactor => this.GetFieldContents(EnrouteAirway.Fields, nameof (VerticalScaleFactor));

    public string RVSMMinimumLevel => this.GetFieldContents(EnrouteAirway.Fields, nameof (RVSMMinimumLevel));

    public string VSFRVSMMaximumLevel => this.GetFieldContents(EnrouteAirway.Fields, nameof (VSFRVSMMaximumLevel));

    public string ICAOCode115 => this.GetFieldContents(EnrouteAirway.Fields, nameof (ICAOCode115));

    private new static class FieldNames
    {
      public const string RecordType = "RecordType";
      public const string CustomerAreaCode = "CustomerAreaCode";
      public const string RouteIdentifier = "RouteIdentifier";
      public const string SequenceNumber = "SequenceNumber";
      public const string FixIdentifier = "FixIdentifier";
      public const string ICAOCode35 = "ICAOCode35";
      public const string WaypointDescriptionCode = "WaypointDescriptionCode";
      public const string BoundaryCode = "BoundaryCode";
      public const string RouteType = "RouteType";
      public const string Level = "Level";
      public const string DirectionRestriction = "DirectionRestriction";
      public const string CruiseTableIndicator = "CruiseTableIndicator";
      public const string EUIndicator = "EUIndicator";
      public const string RecommendedNavaid = "RecommendedNavaid";
      public const string ICAOCode55 = "ICAOCode55";
      public const string ContinuationRecordNo = "ContinuationRecordNo";
      public const string RNP = "RNP";
      public const string Theta = "Theta";
      public const string Rho = "Rho";
      public const string OutboundMagneticCourse = "OutboundMagneticCourse";
      public const string RouteDistanceFrom = "RouteDistanceFrom";
      public const string InboundMagneticCourse = "InboundMagneticCourse";
      public const string MinimumAltitude1 = "MinimumAltitude1";
      public const string MinimumAltitude2 = "MinimumAltitude2";
      public const string MinimumAltitude3 = "MinimumAltitude3";
      public const string FixRadiusTransitionIndicator = "FixRadiusTransitionIndicator";
      public const string VerticalScaleFactor = "VerticalScaleFactor";
      public const string RVSMMinimumLevel = "RVSMMinimumLevel";
      public const string VSFRVSMMaximumLevel = "VSFRVSMMaximumLevel";
      public const string ICAOCode115 = "ICAOCode115";
    }

    public enum RouteTypes
    {
      A,
      C,
      D,
      H,
      O,
      R,
      S,
      T,
    }
  }
}
