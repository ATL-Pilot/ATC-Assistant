// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.Gradient
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using System;
using System.Globalization;

namespace ArincReader.GeneralAviation
{
    public struct Gradient
    {
        private GradientUnitTypes _SeedGradientUnit;
        private double _Percentage;
        private double _FtNm;
        private double _FtKm;
        private double _MNm;
        private double _MKm;
        private double _SlopeDegrees;

        public Gradient(GradientUnitTypes gradientUnitType, double value)
        {
            this._SeedGradientUnit = gradientUnitType;
            this._Percentage = this._FtNm = this._FtKm = this._MNm = this._MKm = this._SlopeDegrees = 0.0;
            if (gradientUnitType == GradientUnitTypes.Percentage)
                this.CheckPercentageValue(value);
            this.CalculateWithSeedValue(gradientUnitType, value);
        }

        public GradientUnitTypes SeedGradientUnit => this._SeedGradientUnit;

        public double Percentage
        {
            set
            {
                this.CheckPercentageValue(value);
                this.CalculateWithSeedValue(GradientUnitTypes.Percentage, value);
            }
            get => this._Percentage;
        }

        public double FeetPerNM
        {
            set => this.CalculateWithSeedValue(GradientUnitTypes.FeetPerNauticalMile, value);
            get => this._FtNm;
        }

        public double FeetPerKm
        {
            set => this.CalculateWithSeedValue(GradientUnitTypes.FeetPerKilometre, value);
            get => this._FtKm;
        }

        public double MetresPerKm
        {
            set => this.CalculateWithSeedValue(GradientUnitTypes.MetresPerKilometre, value);
            get => this._MKm;
        }

        public double MetresPerNM
        {
            set
            {
                this.CalculateWithSeedValue(GradientUnitTypes.MetresPerNauticalMile, value);
                this._MNm = value;
            }
            get => this._MNm;
        }

        public double SlopeDegrees
        {
            set => this.CalculateWithSeedValue(GradientUnitTypes.SlopeDegrees, value);
            get => this._SlopeDegrees;
        }

        private void CheckPercentageValue(double percentage)
        {
            if (percentage < 0.0)
                throw new ArgumentOutOfRangeException(string.Format("{0} Percentage can't be less than zero", (object)percentage));
        }

        private void CalculateWithSeedValue(GradientUnitTypes gradientUnitType, double value)
        {
            this._SeedGradientUnit = gradientUnitType;
            switch (gradientUnitType)
            {
                case GradientUnitTypes.SlopeDegrees:
                    this._SlopeDegrees = value;
                    break;
                case GradientUnitTypes.Percentage:
                    this._Percentage = value;
                    break;
                case GradientUnitTypes.FeetPerNauticalMile:
                    this._FtNm = value;
                    break;
                case GradientUnitTypes.FeetPerKilometre:
                    this._FtKm = value;
                    break;
                case GradientUnitTypes.MetresPerNauticalMile:
                    this._MNm = value;
                    break;
                case GradientUnitTypes.MetresPerKilometre:
                    this._MKm = value;
                    break;
            }
            this.Calculate(gradientUnitType);
        }

        private void Calculate(GradientUnitTypes gradientUnitType)
        {
            LinearDistance linearDistance1 = new LinearDistance(1.0, LinearDistanceUnits.KM);
            linearDistance1 = linearDistance1.ConvertTo(LinearDistanceUnits.Feet);
            double num1 = linearDistance1.Value;
            LinearDistance linearDistance2 = new LinearDistance(1.0, LinearDistanceUnits.NM);
            linearDistance2 = linearDistance2.ConvertTo(LinearDistanceUnits.Metres);
            double num2 = linearDistance2.Value;
            LinearDistance linearDistance3 = new LinearDistance(1.0, LinearDistanceUnits.KM);
            linearDistance3 = linearDistance3.ConvertTo(LinearDistanceUnits.Metres);
            double num3 = linearDistance3.Value;
            double metresInFeet = Constants.IcaoAnnex5.MetresInFeet;
            switch (gradientUnitType)
            {
                case GradientUnitTypes.SlopeDegrees:
                    this._MKm = Math.Tan(this._SlopeDegrees * (Math.PI / 180.0)) * num3;
                    Gradient gradient = new Gradient(GradientUnitTypes.MetresPerKilometre, this._MKm);
                    this._Percentage = gradient.Percentage;
                    this._MNm = gradient.MetresPerNM;
                    this._FtNm = gradient.FeetPerNM;
                    this._FtKm = gradient.FeetPerKm;
                    break;
                case GradientUnitTypes.Percentage:
                    this._FtNm = this._Percentage / 100.0 * Constants.FeetInNauticalMile;
                    this._FtKm = this._Percentage / 100.0 * num1;
                    this._MNm = this._Percentage / 100.0 * num2;
                    this._MKm = this._Percentage / 100.0 * num3;
                    this._SlopeDegrees = this.ComputeSlopeFromMPerKm(this._Percentage / 100.0 * num3);
                    break;
                case GradientUnitTypes.FeetPerNauticalMile:
                    this._Percentage = this._FtNm * 100.0 / Constants.FeetInNauticalMile;
                    this._FtKm = this._FtNm / (num2 / num3);
                    this._MKm = this._FtNm * metresInFeet / (num2 / num3);
                    this._MNm = this._FtNm * metresInFeet;
                    this._SlopeDegrees = this.ComputeSlopeFromMPerKm(this._FtNm * metresInFeet / (num2 / num3));
                    break;
                case GradientUnitTypes.FeetPerKilometre:
                    this._Percentage = this._FtKm * 100.0 / num1;
                    this._FtNm = this._FtKm * (num2 / num3);
                    this._MKm = this._FtKm * metresInFeet;
                    this._MNm = this._FtKm * (num2 / num3) * metresInFeet;
                    this._SlopeDegrees = this.ComputeSlopeFromMPerKm(this._FtKm * metresInFeet);
                    break;
                case GradientUnitTypes.MetresPerNauticalMile:
                    this._Percentage = this._MNm * 100.0 / num2;
                    this._FtNm = this._MNm / metresInFeet;
                    this._FtKm = this._MNm / metresInFeet / (num2 / num3);
                    this._MKm = this._MNm / (num2 / num3);
                    this._SlopeDegrees = this.ComputeSlopeFromMPerKm(this._MNm / (num2 / num3));
                    break;
                case GradientUnitTypes.MetresPerKilometre:
                    this._Percentage = this._MKm * 100.0 / num3;
                    this._FtNm = this._MKm / metresInFeet * (num2 / num3);
                    this._FtKm = this._MKm / metresInFeet;
                    this._MNm = this._MKm * (num2 / num3);
                    this._SlopeDegrees = this.ComputeSlopeFromMPerKm(this._MKm);
                    break;
            }
        }

        private double ComputeSlopeFromMPerKm(double metresPerKm) => Math.Atan(metresPerKm / 1000.0) * (180.0 / Math.PI);

        public override string ToString() => this.ToString((IFormatProvider)CultureInfo.CurrentCulture, this._SeedGradientUnit);

        public string ToString(GradientUnitTypes gradientUnitType) => this.ToString((IFormatProvider)CultureInfo.CurrentCulture, gradientUnitType);

        public string ToString(IFormatProvider provider, GradientUnitTypes gradientUnitType)
        {
            int digits = 2;
            string str = string.Empty;
            switch (gradientUnitType)
            {
                case GradientUnitTypes.SlopeDegrees:
                    str = string.Format(provider, "{0:f" + digits.ToString() + "}°", (object)Math.Round(this._SlopeDegrees, digits));
                    break;
                case GradientUnitTypes.Percentage:
                    str = string.Format(provider, "{0:f" + digits.ToString() + "}%", (object)Math.Round(this._Percentage, digits));
                    break;
                case GradientUnitTypes.FeetPerNauticalMile:
                    str = string.Format(provider, "{0:f" + digits.ToString() + "}Ft/NM", (object)Math.Round(this._FtNm, digits));
                    break;
                case GradientUnitTypes.FeetPerKilometre:
                    str = string.Format(provider, "{0:f" + digits.ToString() + "}Ft/km", (object)Math.Round(this._FtKm, digits));
                    break;
                case GradientUnitTypes.MetresPerNauticalMile:
                    str = string.Format(provider, "{0:f" + digits.ToString() + "}m/NM", (object)Math.Round(this._MNm, digits));
                    break;
                case GradientUnitTypes.MetresPerKilometre:
                    str = string.Format(provider, "{0:f" + digits.ToString() + "}m/km", (object)Math.Round(this._MKm, digits));
                    break;
            }
            return str;
        }
    }
}
