// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.WaypointHeliportTerminal
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;

namespace ArincReader.Arinc424.Records
{
    public class WaypointHeliportTerminal : Waypoint
    {
        public static string SectionCode = "H";
        public static string SubsectionCode = "C";
        public new static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure(nameof (Subsection), 13, 13),
      new FieldStructure(nameof (HeliportIdentifier), 7, 10)
    };

        public WaypointHeliportTerminal(string record)
          : base(record)
        {
        }

        public static List<Arinc424RecordObjectTypes> Filter => new List<Arinc424RecordObjectTypes>()
    {
      Arinc424RecordObjectTypes.WaypointHeliportTerminal
    };

        public string Subsection => this.GetFieldContents(WaypointHeliportTerminal.Fields, nameof(Subsection));

        public string HeliportIdentifier => this.GetFieldContents(WaypointHeliportTerminal.Fields, nameof(HeliportIdentifier));

        private new static class FieldNames
        {
            public const string Subsection = "Subsection";
            public const string HeliportIdentifier = "HeliportIdentifier";
        }
    }
}
