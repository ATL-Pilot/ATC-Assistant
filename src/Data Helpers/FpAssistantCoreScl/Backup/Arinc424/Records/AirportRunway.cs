// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.AirportRunway
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public class AirportRunway : BaseRecord
  {
    public const string SectionCode = "P";
    public const string SubsectionCode = "G";
    public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (AirportICAOIdentifier), 7, 10),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (RunwayIdentifier), 14, 18),
      new FieldStructure(nameof (ContinuationRecordNo), 22, 22),
      new FieldStructure(nameof (RunwayLength), 23, 27),
      new FieldStructure(nameof (RunwayMagneticBearing), 28, 31),
      new FieldStructure(nameof (RunwayLatitude), 33, 41),
      new FieldStructure(nameof (RunwayLongitude), 42, 51),
      new FieldStructure(nameof (RunwayGradient), 52, 56),
      new FieldStructure(nameof (LTPEllipsoidHeight), 61, 66),
      new FieldStructure(nameof (LandingThreasholdElevation), 67, 71),
      new FieldStructure(nameof (DisplacedThreasholdDistance), 72, 75),
      new FieldStructure(nameof (ThreasholdCrossingHeight), 76, 77),
      new FieldStructure(nameof (RunwayWidth), 78, 80),
      new FieldStructure(nameof (TCHValueIndicator), 81, 81),
      new FieldStructure(nameof (LocalizerMLSGLSRefPathIdentifier), 82, 85),
      new FieldStructure(nameof (LocalizerMLSGLSCategoryClass), 86, 86),
      new FieldStructure(nameof (Stopway), 78, 90),
      new FieldStructure(nameof (SecondLocalizerMLSGLSRefPathIdentifier), 91, 94),
      new FieldStructure(nameof (SecondLocalizerMLSGLSCategoryClass), 95, 95),
      new FieldStructure(nameof (RunwayDescription), 102, 123),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

    public AirportRunway(string record)
      : base(record)
    {
    }

    public string CustomerAreaCode => this.GetFieldContents(AirportRunway.Fields, nameof (CustomerAreaCode));

    public string AirportICAOIdentifier => this.GetFieldContents(AirportRunway.Fields, nameof (AirportICAOIdentifier));

    public string ICAOCode11 => this.GetFieldContents(AirportRunway.Fields, nameof (ICAOCode11));

    public string RunwayIdentifier => this.GetFieldContents(AirportRunway.Fields, nameof (RunwayIdentifier));

    public string ContinuationRecordNo => this.GetFieldContents(AirportRunway.Fields, nameof (ContinuationRecordNo));

    public string RunwayLength => this.GetFieldContents(AirportRunway.Fields, nameof (RunwayLength));

    public string RunwayMagneticBearing => this.GetFieldContents(AirportRunway.Fields, nameof (RunwayMagneticBearing));

    public string RunwayLatitude => this.GetFieldContents(AirportRunway.Fields, nameof (RunwayLatitude));

    public string RunwayLongitude => this.GetFieldContents(AirportRunway.Fields, nameof (RunwayLongitude));

    public string RunwayGradient => this.GetFieldContents(AirportRunway.Fields, nameof (RunwayGradient));

    public string LTPEllipsoidHeight => this.GetFieldContents(AirportRunway.Fields, nameof (LTPEllipsoidHeight));

    public string LandingThreasholdElevation => this.GetFieldContents(AirportRunway.Fields, nameof (LandingThreasholdElevation));

    public string DisplacedThreasholdDistance => this.GetFieldContents(AirportRunway.Fields, nameof (DisplacedThreasholdDistance));

    public string ThreasholdCrossingHeight => this.GetFieldContents(AirportRunway.Fields, nameof (ThreasholdCrossingHeight));

    public string RunwayWidth => this.GetFieldContents(AirportRunway.Fields, nameof (RunwayWidth));

    public string TCHValueIndicator => this.GetFieldContents(AirportRunway.Fields, nameof (TCHValueIndicator));

    public string LocalizerMLSGLSRefPathIdentifier => this.GetFieldContents(AirportRunway.Fields, nameof (LocalizerMLSGLSRefPathIdentifier));

    public string LocalizerMLSGLSCategoryClass => this.GetFieldContents(AirportRunway.Fields, nameof (LocalizerMLSGLSCategoryClass));

    public string Stopway => this.GetFieldContents(AirportRunway.Fields, nameof (Stopway));

    public string SecondLocalizerMLSGLSRefPathIdentifier => this.GetFieldContents(AirportRunway.Fields, nameof (SecondLocalizerMLSGLSRefPathIdentifier));

    public string SecondLocalizerMLSGLSCategoryClass => this.GetFieldContents(AirportRunway.Fields, nameof (SecondLocalizerMLSGLSCategoryClass));

    public string RunwayDescription => this.GetFieldContents(AirportRunway.Fields, nameof (RunwayDescription));

    public string FileRecordNumber => this.GetFieldContents(AirportRunway.Fields, nameof (FileRecordNumber));

    public string CycleDate => this.GetFieldContents(AirportRunway.Fields, nameof (CycleDate));

    private static class FieldNames
    {
      public const string RecordType = "RecordType";
      public const string CustomerAreaCode = "CustomerAreaCode";
      public const string AirportICAOIdentifier = "AirportICAOIdentifier";
      public const string ICAOCode11 = "ICAOCode11";
      public const string RunwayIdentifier = "RunwayIdentifier";
      public const string ContinuationRecordNo = "ContinuationRecordNo";
      public const string RunwayLength = "RunwayLength";
      public const string RunwayMagneticBearing = "RunwayMagneticBearing";
      public const string RunwayLatitude = "RunwayLatitude";
      public const string RunwayLongitude = "RunwayLongitude";
      public const string RunwayGradient = "RunwayGradient";
      public const string LTPEllipsoidHeight = "LTPEllipsoidHeight";
      public const string LandingThreasholdElevation = "LandingThreasholdElevation";
      public const string DisplacedThreasholdDistance = "DisplacedThreasholdDistance";
      public const string ThreasholdCrossingHeight = "ThreasholdCrossingHeight";
      public const string RunwayWidth = "RunwayWidth";
      public const string TCHValueIndicator = "TCHValueIndicator";
      public const string LocalizerMLSGLSRefPathIdentifier = "LocalizerMLSGLSRefPathIdentifier";
      public const string LocalizerMLSGLSCategoryClass = "LocalizerMLSGLSCategoryClass";
      public const string Stopway = "Stopway";
      public const string SecondLocalizerMLSGLSRefPathIdentifier = "SecondLocalizerMLSGLSRefPathIdentifier";
      public const string SecondLocalizerMLSGLSCategoryClass = "SecondLocalizerMLSGLSCategoryClass";
      public const string RunwayDescription = "RunwayDescription";
      public const string FileRecordNumber = "FileRecordNumber";
      public const string CycleDate = "CycleDate";
    }
  }
}
