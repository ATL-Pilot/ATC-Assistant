// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.SbasProviderIdentifiers
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.GeneralAviation
{
    public enum SbasProviderIdentifiers : byte
    {
        [Description(Text = "0 - Wide Area Augmentation System (WAAS)")] Waas,
        [Description(Text = "1 - European Geostationary Navigation Overlay Service (EGNOS)")] Egnos,
        [Description(Text = "2 - Multifunction Transport Satellite (MTSAT) Satellite-based Augmentation System (MSAS)")] Msas,
        [Description(Text = "3 - GPS-aided Geo-augmented Navigation (GAGAN)")] Gagan,
        [Description(Text = "4 - System of Differential Correction and Monitoring (SDCM)")] Sdcm,
        [Description(Text = "5 - Spare")] Spare5,
        [Description(Text = "6 - Spare")] Spare6,
        [Description(Text = "7 - Spare")] Spare7,
        [Description(Text = "8 - Spare")] Spare8,
        [Description(Text = "9 - Spare")] Spare9,
        [Description(Text = "10 - Spare")] Spare10,
        [Description(Text = "11 - Spare")] Spare11,
        [Description(Text = "12 - Spare")] Spare12,
        [Description(Text = "13 - Spare")] Spare13,
        [Description(Text = "14 - FAS data block is to be used with GBAS only")] GbasOnly,
        [Description(Text = "15 - FAS data block can be used with any SBAS service provider")] AnySbasServiceProvider,
    }
}
