// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.GbasApproachPerformanceDesignators
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.GeneralAviation
{
    public enum GbasApproachPerformanceDesignators : byte
    {
        [Description(Text = "0 - GSL A/GSL B")] GslAGslB,
        [Description(Text = "1 - GSL C")] GslC,
        [Description(Text = "2 - GSL D")] GslD,
        [Description(Text = "3 - GSL E")] GslE,
        [Description(Text = "4 - GSL F")] GslF,
        [Description(Text = "5 - Spare")] Spare5,
        [Description(Text = "6 - Spare")] Spare6,
        [Description(Text = "7 - Spare")] Spare7,
    }
}
