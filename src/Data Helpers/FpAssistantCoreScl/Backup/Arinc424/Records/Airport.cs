// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.Airport
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public class Airport : CommonRecordFields
  {
    public const string SectionCode = "P";
    public const string SubsectionCode = "A";
    public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (SectionCode), 5, 5),
      new FieldStructure(nameof (AirportICAOIdentifier), 7, 10),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (SubsectionCode), 13, 13),
      new FieldStructure(nameof (IATADesignator), 14, 16),
      new FieldStructure(nameof (ContinuationRecordNo), 22, 22),
      new FieldStructure(nameof (SpeedLimitAltitude), 23, 27),
      new FieldStructure(nameof (LongestRunway), 28, 30),
      new FieldStructure(nameof (IFRCapability), 31, 31),
      new FieldStructure(nameof (LongestRunwaySurfaceCode), 32, 32),
      new FieldStructure(nameof (ArpLatitude), 33, 41),
      new FieldStructure(nameof (ArpLongitude), 42, 51),
      new FieldStructure(nameof (MagneticVariation), 52, 56),
      new FieldStructure(nameof (AirportElevation), 57, 61),
      new FieldStructure(nameof (SpeedLimit), 62, 64),
      new FieldStructure(nameof (RecommendedNavaid), 65, 68),
      new FieldStructure(nameof (ICAOCode69), 69, 70),
      new FieldStructure(nameof (TransitionAltitude), 71, 75),
      new FieldStructure(nameof (TransitionLevel), 76, 80),
      new FieldStructure(nameof (PublicMilitaryIndicator), 81, 81),
      new FieldStructure(nameof (TimeZone), 82, 84),
      new FieldStructure(nameof (DaylightIndicator), 85, 85),
      new FieldStructure(nameof (MagneticTrueIndicator), 86, 86),
      new FieldStructure(nameof (DatumCode), 87, 89),
      new FieldStructure(nameof (AirportName), 94, 123),
      new FieldStructure("FileRecordNumber", 124, 128),
      new FieldStructure("CycleDate", 129, 132)
    };

    public Airport(string record)
      : base(record)
    {
    }

    public static List<Arinc424RecordObjectTypes> Filter => new List<Arinc424RecordObjectTypes>()
    {
      Arinc424RecordObjectTypes.Airport
    };

    public string CustomerAreaCode
    {
      set => this.UpdateThisProperty(nameof (CustomerAreaCode), value, Airport.Fields);
      get => this.GetFieldContents(Airport.Fields, nameof (CustomerAreaCode));
    }

    public string Section => this.GetFieldContents(Airport.Fields, "SectionCode");

    public string Subsection => this.GetFieldContents(Airport.Fields, "SubsectionCode");

    public string AirportICAOIdentifier
    {
      set => this.UpdateThisProperty(nameof (AirportICAOIdentifier), value, Airport.Fields);
      get => this.GetFieldContents(Airport.Fields, nameof (AirportICAOIdentifier));
    }

    public string ICAOCode11 => this.GetFieldContents(Airport.Fields, nameof (ICAOCode11));

    public string IATADesignator => this.GetFieldContents(Airport.Fields, nameof (IATADesignator));

    public int ContinuationRecordNo => int.Parse(this.GetFieldContents(Airport.Fields, nameof (ContinuationRecordNo)));

    public string SpeedLimitAltitude => this.GetFieldContents(Airport.Fields, nameof (SpeedLimitAltitude));

    public string LongestRunway => this.GetFieldContents(Airport.Fields, nameof (LongestRunway));

    public bool IFRCapability => this.GetFieldContents(Airport.Fields, nameof (IFRCapability)) == "Y";

    public Arinc424LRSC LongestRunwaySurfaceCode => (Arinc424LRSC) Enum.Parse(typeof (Arinc424LRSC), this.GetFieldContents(Airport.Fields, nameof (LongestRunwaySurfaceCode)));

    public string ArpLatitude => this.GetFieldContents(Airport.Fields, nameof (ArpLatitude));

    public string ArpLongitude => this.GetFieldContents(Airport.Fields, nameof (ArpLongitude));

    public GeoCoordinateBasic ArpCoordinate => new GeoCoordinate(this.ArpLatitude, this.ArpLongitude).GeoCoordinateBasic;

    public string MagneticVariation => this.GetFieldContents(Airport.Fields, nameof (MagneticVariation));

    public LinearDistance AirportElevation => new LinearDistance(Utilities.ConvertStringToDouble(this.GetFieldContents(Airport.Fields, nameof (AirportElevation))).value, LinearDistanceUnits.Feet);

    public string SpeedLimit => this.GetFieldContents(Airport.Fields, nameof (SpeedLimit));

    public string RecommendedNavaid => this.GetFieldContents(Airport.Fields, nameof (RecommendedNavaid));

    public string ICAOCode69 => this.GetFieldContents(Airport.Fields, nameof (ICAOCode69));

    public string TransitionAltitude => this.GetFieldContents(Airport.Fields, nameof (TransitionAltitude));

    public string TransitionLevel => this.GetFieldContents(Airport.Fields, nameof (TransitionLevel));

    public Arinc424PublicMilitaryIndicator PublicMilitaryIndicator => (Arinc424PublicMilitaryIndicator) Enum.Parse(typeof (Arinc424PublicMilitaryIndicator), this.GetFieldContents(Airport.Fields, nameof (PublicMilitaryIndicator)));

    public string TimeZone => this.GetFieldContents(Airport.Fields, nameof (TimeZone));

    public string DaylightIndicator => this.GetFieldContents(Airport.Fields, nameof (DaylightIndicator));

    public string MagneticTrueIndicator => this.GetFieldContents(Airport.Fields, nameof (MagneticTrueIndicator));

    public string DatumCode => this.GetFieldContents(Airport.Fields, nameof (DatumCode));

    public string AirportName => this.GetFieldContents(Airport.Fields, nameof (AirportName));

    public override bool GeoFenceWithin(GeoCoordinateBasic searchCentrePoint, LinearDistance radius) => GeoCoordinateBasic.WGS84Distance(this.ArpCoordinate, searchCentrePoint).Distance < radius;

    private new static class FieldNames
    {
      public const string RecordType = "RecordType";
      public const string CustomerAreaCode = "CustomerAreaCode";
      public const string SectionCode = "SectionCode";
      public const string SubsectionCode = "SubsectionCode";
      public const string AirportICAOIdentifier = "AirportICAOIdentifier";
      public const string ICAOCode11 = "ICAOCode11";
      public const string IATADesignator = "IATADesignator";
      public const string ContinuationRecordNo = "ContinuationRecordNo";
      public const string SpeedLimitAltitude = "SpeedLimitAltitude";
      public const string LongestRunway = "LongestRunway";
      public const string IFRCapability = "IFRCapability";
      public const string LongestRunwaySurfaceCode = "LongestRunwaySurfaceCode";
      public const string ArpLatitude = "ArpLatitude";
      public const string ArpLongitude = "ArpLongitude";
      public const string MagneticVariation = "MagneticVariation";
      public const string AirportElevation = "AirportElevation";
      public const string SpeedLimit = "SpeedLimit";
      public const string RecommendedNavaid = "RecommendedNavaid";
      public const string ICAOCode69 = "ICAOCode69";
      public const string TransitionAltitude = "TransitionAltitude";
      public const string TransitionLevel = "TransitionLevel";
      public const string PublicMilitaryIndicator = "PublicMilitaryIndicator";
      public const string TimeZone = "TimeZone";
      public const string DaylightIndicator = "DaylightIndicator";
      public const string MagneticTrueIndicator = "MagneticTrueIndicator";
      public const string DatumCode = "DatumCode";
      public const string AirportName = "AirportName";
      public const string FileRecordNumber = "FileRecordNumber";
      public const string CycleDate = "CycleDate";
    }
  }
}
