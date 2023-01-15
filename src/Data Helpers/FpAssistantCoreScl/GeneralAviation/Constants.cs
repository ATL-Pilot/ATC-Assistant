// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.Constants
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;

namespace ArincReader.GeneralAviation
{
    public static class Constants
    {
        private const double _MetresInKM = 1000.0;
        private const double _FeetInNauticalMile = 6076.1154855643;

        public static double MetresInKilometres => 1000.0;

        public static double FeetInNauticalMile => 6076.1154855643;

        public static double PI => Math.PI;

        public static class IcaoAnnex5
        {
            private const double _MetresInFeet = 0.3048;
            private const double _MetresInNauticalMile = 1852.0;

            public static double MetresInFeet => 0.3048;

            public static double MetresInNauticalMile => 1852.0;
        }

        public static class FaaTerpsConstants
        {
            public static double MeanRadiusOfEarthInFeet => 20890537.0;

            public static double MeanRadiusOfEarthInMetres => 6367435.67964;

            public static double E => Math.E;
        }
    }
}
