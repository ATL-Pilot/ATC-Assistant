// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.AirportApproach
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;

namespace ArincReader.Arinc424.Records
{
    public class AirportApproach : AirportSidStarApproach
    {
        public const string SubsectionCode = "F";

        public AirportApproach(string record)
          : base(record)
        {
        }

        public static List<Arinc424RecordObjectTypes> Filter => new List<Arinc424RecordObjectTypes>()
    {
      Arinc424RecordObjectTypes.AirportApproach
    };
    }
}
