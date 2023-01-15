// Decompiled with JetBrains decompiler
// Type: ArincReader.Arinc424.Records.CycleDate
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using System;
using System.Globalization;
using System.Linq;

namespace ArincReader.Arinc424.Records
{
    public struct CycleDate : IEquatable<CycleDate>
    {
        private int _Year;
        private int _IdentityUpdateCycle;

        public CycleDate(int year, int updateCycle)
        {
            this._Year = year;
            this._IdentityUpdateCycle = updateCycle;
        }

        public CycleDate(string yearUpdateCycle)
        {
            if (yearUpdateCycle == null)
                throw new ArgumentNullException(nameof(yearUpdateCycle));
            this._Year = DateTime.Now.Year - 2000;
            this._IdentityUpdateCycle = 0;
            if (yearUpdateCycle.Length != 4)
                throw new ArgumentException(ConstantMessages.Arinc424Exceptions.CycleDataInvalidParameter, nameof(yearUpdateCycle));
            if (!yearUpdateCycle.All<char>(new Func<char, bool>(char.IsDigit)))
                throw new ArgumentException(ConstantMessages.Arinc424Exceptions.CycleDataStringMustContainOnlyDigits, nameof(yearUpdateCycle));
            int result1;
            int.TryParse(yearUpdateCycle.Substring(0, 2), NumberStyles.Any, (IFormatProvider)CultureInfo.CurrentCulture, out result1);
            this.Year = result1;
            int result2;
            int.TryParse(yearUpdateCycle.Substring(2, 2), NumberStyles.Any, (IFormatProvider)CultureInfo.CurrentCulture, out result2);
            this.IdentityUpdateCycle = result2;
        }

        public int Year
        {
            get => this._Year;
            set => this._Year = value >= 0 && value <= 99 ? value : throw new ArgumentOutOfRangeException(ConstantMessages.Arinc424Exceptions.CycleDataInvalidYear);
        }

        public int IdentityUpdateCycle
        {
            get => this._IdentityUpdateCycle;
            set => this._IdentityUpdateCycle = value >= 0 && value <= 14 ? value : throw new ArgumentOutOfRangeException(ConstantMessages.Arinc424Exceptions.CycleDataInvalidIdentityUpdateCycle);
        }

        public override string ToString() => string.Format((IFormatProvider)CultureInfo.GetCultureInfo("en-US"), "{0:00}{1:00}", (object)this._Year, (object)this._IdentityUpdateCycle);

        public override bool Equals(object obj) => obj != null && obj is CycleDate cycleDate && this._Year == cycleDate.Year && this._IdentityUpdateCycle == cycleDate.IdentityUpdateCycle;

        public override int GetHashCode() => this._Year.GetHashCode() ^ this._IdentityUpdateCycle.GetHashCode();

        public static bool operator ==(CycleDate left, CycleDate right) => left.Equals(right);

        public static bool operator !=(CycleDate left, CycleDate right) => !(left == right);

        public bool Equals(CycleDate other) => this.Equals((object)other);
    }
}
