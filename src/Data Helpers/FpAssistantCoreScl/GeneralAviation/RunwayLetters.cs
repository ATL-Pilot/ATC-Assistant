// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.RunwayLetters
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.GeneralAviation
{
    public enum RunwayLetters : byte
    {
        [Description(Text = "0 - No letter")] NoLetter,
        [Description(Text = "1 - R (right)")] Right,
        [Description(Text = "2 - C (centre)")] Centre,
        [Description(Text = "3 - L (left)")] Left,
    }
}
