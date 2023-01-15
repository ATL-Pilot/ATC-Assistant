// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.ConstantMessages
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

namespace FpAssistantCore.General
{
  public static class ConstantMessages
  {
    public static class ForLicensing
    {
      public static readonly string IcaoPansOpsModuleNotLicensed = "ICAO PANS-OPS module not licensed!";
      public static readonly string FaaTerpsModuleNotLicensed = "FAA TERPS module not licensed!";
      public static readonly string PbnModuleNotLicensed = "PBN module not licensed!";
      public static readonly string AerodromeSurfacesModuleNotLicensed = "Aerodrome Surfaces module not licensed!";
      public static readonly string FasDataBlockModuleNotLicensed = "FAS Datablock module not licensed!";
      public static readonly string ObstacleEvaluationModuleNotLicensed = "Obstacle Evaluation module not licensed!";
      public static readonly string Arinc424ParserNotLicensed = "ARINC 424 Parser not licensed!";
      public static readonly string GeneralToolsModuleNotLicensed = "General tools module not licensed!";
      public static readonly string FPAssistantLicenseInvalid = "Invalid FPAssistant User License";
    }

    public static class ForExceptions
    {
      public static readonly string Altitude1LessThanAltitude2 = "Altitude1 parameter is less than Altitude2";
      public static readonly string IsNullOrWhiteSpace = "name passed is null or white space";
    }

    public static class PbnExceptions
    {
      public static readonly string FaaPbnSiUnits = "SI Units can't be used for calculations in FAA PBN!";
      public static readonly string UnsupportedSegmentType = "Unsupported segment type!";
    }

    public static class Arinc424Exceptions
    {
      public static readonly string FieldNameNotFound = "Field name {0} not found in field structure for record {1}";
      public static readonly string RecordNameNotInDictionary = "Record name {0} not found in dictionary";
      public static readonly string HeaderRecordVersionNumberInvalid = "Version number must be between 1 and 999";
      public static readonly string CycleDataInvalidYear = "Year for cycle date must be between 1 and 99";
      public static readonly string CycleDataInvalidIdentityUpdateCycle = "Identity of update cycle must be between 1 and 14";
      public static readonly string CycleDataInvalidParameter = "Parameter must be 4 characters in format YYUC";
      public static readonly string CycleDataStringMustContainOnlyDigits = "Parameter must only contain digits";
    }
  }
}
