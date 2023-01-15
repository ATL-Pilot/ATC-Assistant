// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.WaypointTerminal
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;

namespace ArincReader.Arinc424.Records
{
    public class WaypointTerminal : Waypoint
    {
        public static string SectionCode = "P";
        public static string SubsectionCode = "C";
        public new static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure(nameof (Subsection), 13, 13),
      new FieldStructure(nameof (RegionCode), 7, 10)
    };

        public WaypointTerminal(string record)
          : base(record)
        {
        }

        public static List<Arinc424RecordObjectTypes> Filter => new List<Arinc424RecordObjectTypes>()
    {
      Arinc424RecordObjectTypes.WaypointTerminal
    };

        public string Subsection => this.GetFieldContents(WaypointTerminal.Fields, nameof(Subsection));

        public string RegionCode => this.GetFieldContents(WaypointTerminal.Fields, nameof(RegionCode));

        private new static class FieldNames
        {
            public const string Subsection = "Subsection";
            public const string RegionCode = "RegionCode";
        }
    }
}
