// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.VhfNavaid
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;
using System.Collections.Generic;

namespace ArincReader.Arinc424.Records
{
    public class VhfNavaid : BaseRecord
    {
        public const string SectionCode = "D";
        public const string SubsectionCode = " ";
        public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure(nameof (CustomerAreaCode), 2, 4),
      new FieldStructure(nameof (AirportICAOIdentifier), 7, 10),
      new FieldStructure(nameof (ICAOCode11), 11, 12),
      new FieldStructure(nameof (VORIdentifier), 14, 17),
      new FieldStructure(nameof (ICAOCode20), 20, 21),
      new FieldStructure(nameof (ContinuationRecordNo), 22, 22),
      new FieldStructure(nameof (VORFrequency), 23, 27),
      new FieldStructure(nameof (NAVAIDClass), 28, 32),
      new FieldStructure(nameof (VORLatitude), 33, 41),
      new FieldStructure(nameof (VORLongitude), 42, 51),
      new FieldStructure(nameof (DMEIdentifier), 52, 55),
      new FieldStructure(nameof (DMELatitude), 56, 64),
      new FieldStructure(nameof (DMELongitude), 65, 74),
      new FieldStructure(nameof (StationDeclination), 75, 79),
      new FieldStructure(nameof (DMEElevation), 80, 84),
      new FieldStructure(nameof (FigureOfMerit), 85, 85),
      new FieldStructure(nameof (ILSDMEBias), 86, 87),
      new FieldStructure(nameof (FrequencyProtection), 88, 90),
      new FieldStructure(nameof (DatumCode), 91, 93),
      new FieldStructure(nameof (VORName), 94, 118),
      new FieldStructure(nameof (RouteInappropriateDME), 122, 122),
      new FieldStructure(nameof (DMEOperationalService), 123, 123),
      new FieldStructure(nameof (FileRecordNumber), 124, 128),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

        public VhfNavaid(string record)
          : base(record)
        {
        }

        public VhfNavaid.NavaidTypes NavaidType
        {
            get
            {
                if (this.NAVAIDClass.Substring(0, 1) == "V")
                    return VhfNavaid.NavaidTypes.Vor;
                string str = this.NAVAIDClass.Substring(1, 1);
                if (str == "D")
                    return VhfNavaid.NavaidTypes.Dme;
                if (str == "T")
                    return VhfNavaid.NavaidTypes.Tacan;
                if (str == "M")
                    return VhfNavaid.NavaidTypes.MilTacan;
                if (str == "I")
                    return VhfNavaid.NavaidTypes.IlsDmeTacan;
                if (str == "N")
                    return VhfNavaid.NavaidTypes.MlsDmeN;
                if (str == "P")
                    return VhfNavaid.NavaidTypes.MlsDmeP;
                throw new NotSupportedException(string.Format("Unable to determine Navaid Type from : {0}", (object)this.NAVAIDClass));
            }
        }

        public string CustomerAreaCode => this.GetFieldContents(VhfNavaid.Fields, nameof(CustomerAreaCode));

        public string AirportICAOIdentifier => this.GetFieldContents(VhfNavaid.Fields, nameof(AirportICAOIdentifier));

        public string ICAOCode11 => this.GetFieldContents(VhfNavaid.Fields, nameof(ICAOCode11));

        public string VORIdentifier => this.GetFieldContents(VhfNavaid.Fields, nameof(VORIdentifier));

        public string ICAOCode20 => this.GetFieldContents(VhfNavaid.Fields, nameof(ICAOCode20));

        public string ContinuationRecordNo => this.GetFieldContents(VhfNavaid.Fields, nameof(ContinuationRecordNo));

        public string VORFrequency => this.GetFieldContents(VhfNavaid.Fields, nameof(VORFrequency));

        public string NAVAIDClass => this.GetFieldContents(VhfNavaid.Fields, nameof(NAVAIDClass));

        public string VORLatitude => this.GetFieldContents(VhfNavaid.Fields, nameof(VORLatitude));

        public string VORLongitude => this.GetFieldContents(VhfNavaid.Fields, nameof(VORLongitude));

        public string DMEIdentifier => this.GetFieldContents(VhfNavaid.Fields, nameof(DMEIdentifier));

        public string DMELatitude => this.GetFieldContents(VhfNavaid.Fields, nameof(DMELatitude));

        public string DMELongitude => this.GetFieldContents(VhfNavaid.Fields, nameof(DMELongitude));

        public string StationDeclination => this.GetFieldContents(VhfNavaid.Fields, nameof(StationDeclination));

        public string DMEElevation => this.GetFieldContents(VhfNavaid.Fields, nameof(DMEElevation));

        public string FigureOfMerit => this.GetFieldContents(VhfNavaid.Fields, nameof(FigureOfMerit));

        public string ILSDMEBias => this.GetFieldContents(VhfNavaid.Fields, nameof(ILSDMEBias));

        public string FrequencyProtection => this.GetFieldContents(VhfNavaid.Fields, nameof(FrequencyProtection));

        public string DatumCode => this.GetFieldContents(VhfNavaid.Fields, nameof(DatumCode));

        public string VORName => this.GetFieldContents(VhfNavaid.Fields, nameof(VORName));

        public string RouteInappropriateDME => this.GetFieldContents(VhfNavaid.Fields, nameof(RouteInappropriateDME));

        public string DMEOperationalService => this.GetFieldContents(VhfNavaid.Fields, nameof(DMEOperationalService));

        public string FileRecordNumber => this.GetFieldContents(VhfNavaid.Fields, nameof(FileRecordNumber));

        public string CycleDate => this.GetFieldContents(VhfNavaid.Fields, nameof(CycleDate));

        public enum NavaidTypes
        {
            Vor,
            Dme,
            Tacan,
            MilTacan,
            IlsDmeTacan,
            MlsDmeN,
            MlsDmeP,
        }

        private static class FieldNames
        {
            public const string RecordType = "RecordType";
            public const string CustomerAreaCode = "CustomerAreaCode";
            public const string AirportICAOIdentifier = "AirportICAOIdentifier";
            public const string ICAOCode11 = "ICAOCode11";
            public const string VORIdentifier = "VORIdentifier";
            public const string ICAOCode20 = "ICAOCode20";
            public const string ContinuationRecordNo = "ContinuationRecordNo";
            public const string VORFrequency = "VORFrequency";
            public const string NAVAIDClass = "NAVAIDClass";
            public const string VORLatitude = "VORLatitude";
            public const string VORLongitude = "VORLongitude";
            public const string DMEIdentifier = "DMEIdentifier";
            public const string DMELatitude = "DMELatitude";
            public const string DMELongitude = "DMELongitude";
            public const string StationDeclination = "StationDeclination";
            public const string DMEElevation = "DMEElevation";
            public const string FigureOfMerit = "FigureOfMerit";
            public const string ILSDMEBias = "ILSDMEBias";
            public const string FrequencyProtection = "FrequencyProtection";
            public const string DatumCode = "DatumCode";
            public const string VORName = "VORName";
            public const string RouteInappropriateDME = "RouteInappropriateDME";
            public const string DMEOperationalService = "DMEOperationalService";
            public const string FileRecordNumber = "FileRecordNumber";
            public const string CycleDate = "CycleDate";
        }
    }
}
