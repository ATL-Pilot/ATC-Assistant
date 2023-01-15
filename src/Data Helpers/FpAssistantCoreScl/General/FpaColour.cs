// Decompiled with JetBrains decompiler
// Type: ArincReader.General.FpaColour
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;
using System.Drawing;

namespace ArincReader.General
{
    public struct FpaColour
    {
        public FpaColour(byte alpha, FpaColour.KnownColours knownColour)
          : this(knownColour)
        {
            this.Alpha = alpha;
        }

        public FpaColour(FpaColour.KnownColours knownColour)
        {
            this.Alpha = this.Red = this.Green = this.Blue = (byte)0;
            switch (knownColour)
            {
                case FpaColour.KnownColours.Red:
                    this.Red = byte.MaxValue;
                    this.Green = (byte)0;
                    this.Blue = (byte)0;
                    break;
                case FpaColour.KnownColours.Green:
                    this.Red = (byte)0;
                    this.Green = byte.MaxValue;
                    this.Blue = (byte)0;
                    break;
                case FpaColour.KnownColours.Blue:
                    this.Red = (byte)0;
                    this.Green = (byte)0;
                    this.Blue = byte.MaxValue;
                    break;
                case FpaColour.KnownColours.White:
                    this.Red = byte.MaxValue;
                    this.Green = byte.MaxValue;
                    this.Blue = byte.MaxValue;
                    break;
                case FpaColour.KnownColours.Black:
                    this.Red = (byte)0;
                    this.Green = (byte)0;
                    this.Blue = (byte)0;
                    break;
                case FpaColour.KnownColours.Cyan:
                    this.Red = (byte)0;
                    this.Green = byte.MaxValue;
                    this.Blue = byte.MaxValue;
                    break;
                case FpaColour.KnownColours.Yellow:
                    this.Red = byte.MaxValue;
                    this.Green = byte.MaxValue;
                    this.Blue = (byte)0;
                    break;
                default:
                    throw new NotImplementedException("KnownColours enum value is not currently supported in FpaColour struct constructor");
            }
        }

        public FpaColour(byte red, byte green, byte blue)
        {
            this.Alpha = (byte)0;
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public FpaColour(byte alpha, byte red, byte green, byte blue)
          : this(red, green, blue)
        {
            this.Alpha = alpha;
        }

        public byte Alpha { get; set; }

        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public Color AsSystemDrawingColor() => Color.FromArgb((int)this.Alpha, (int)this.Red, (int)this.Green, (int)this.Blue);

        public enum KnownColours
        {
            Red,
            Green,
            Blue,
            White,
            Black,
            Cyan,
            Yellow,
        }
    }
}
