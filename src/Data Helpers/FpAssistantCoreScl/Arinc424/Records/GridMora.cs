// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.GridMora
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;

namespace ArincReader.Arinc424.Records
{
    public class GridMora : BaseRecord
    {
        public const string SectionCode = "A";
        public const string SubsectionCode = "S";
        public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure("RecordType", 1, 1),
      new FieldStructure("Blank", 2, 4),
      new FieldStructure(nameof (SectionCode), 5, 5),
      new FieldStructure(nameof (SubsectionCode), 6, 6),
      new FieldStructure(nameof (StartingLatitude), 14, 16),
      new FieldStructure(nameof (StartingLongitude), 17, 20),
      new FieldStructure(nameof (CycleDate), 129, 132)
    };

        public GridMora(string record)
          : base(record)
        {
        }

        public string StartingLatitude => this.GetFieldContents(GridMora.Fields, nameof(StartingLatitude));

        public string StartingLongitude => this.GetFieldContents(GridMora.Fields, nameof(StartingLongitude));

        public string CycleDate => this.GetFieldContents(GridMora.Fields, nameof(CycleDate));

        private static class FieldNames
        {
            public const string RecordType = "RecordType";
            public const string Blank = "Blank";
            public const string SectionCode = "SectionCode";
            public const string SubsectionCode = "SubsectionCode";
            public const string StartingLatitude = "StartingLatitude";
            public const string StartingLongitude = "StartingLongitude";
            public const string CycleDate = "CycleDate";
        }
    }
}
