// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.CsMapStatus
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

namespace ArincReader.Geographical
{
    public enum CsMapStatus
    {
        ErrorHttpClientFailure = -9, // 0xFFFFFFF7
        ErrorDictionaryNotFound = -3, // 0xFFFFFFFD
        ErrorConversionOfCoordinate = -2, // 0xFFFFFFFE
        ErrorInvalidProjectionName = -1, // 0xFFFFFFFF
        Ok = 0,
    }
}
