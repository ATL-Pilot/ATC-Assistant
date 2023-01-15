﻿// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.MapProjections
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.Geographical
{
    public enum MapProjections
    {
        [Description(Text = "Universal Transverse Mercator coordinate system - WGS84 Datum")] UtmWgs84,
        [Description(Text = "Universal Transverse Mercator coordinate system - NAD83 Datum")] UtmNad83,
    }
}
