// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Percentage
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;
using System.Diagnostics;

namespace ArincReader.General
{
    [DebuggerDisplay("{_Percentage}")]
    public struct Percentage : IEquatable<Percentage>
    {
        private double _Percentage;

        public Percentage(double percentage)
        {
            this._Percentage = 0.0;
            this.Value = percentage;
        }

        public double Value
        {
            get => this._Percentage;
            set => this._Percentage = value >= 0.0 && value <= 100.0 ? value : throw new ArgumentOutOfRangeException(nameof(Value), "Percentage must be between 0% and 100%");
        }

        public double PercentageOf(double value) => value * this._Percentage / 100.0;

        public static double operator *(Percentage percentage, double value) => percentage.Value * value;

        public static double operator /(Percentage percentage, double value) => percentage.Value / value;

        public override bool Equals(object obj) => obj != null && obj is Percentage percentage && this._Percentage == percentage._Percentage;

        public bool Equals(Percentage percentage) => this.Equals((object)percentage);

        public static bool operator ==(Percentage a1, Percentage a2) => a1.Equals(a2);

        public static bool operator !=(Percentage a1, Percentage a2) => !(a1 == a2);

        public override int GetHashCode() => this._Percentage.GetHashCode();
    }
}
