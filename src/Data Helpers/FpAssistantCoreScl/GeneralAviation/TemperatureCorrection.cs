// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.TemperatureCorrection
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using System;

namespace ArincReader.GeneralAviation
{
    public struct TemperatureCorrection
    {
        private Temperature _AerodromeTemperature;
        private LinearDistance _ThresholdElevation;
        private LinearDistance _Fap;
        private LinearDistance _DeltaHMetres;
        private const double _L0Si = -0.0065;
        private const double _T0 = 288.15;

        public TemperatureCorrection(
          Temperature aerodromeTemperature,
          LinearDistance thresholdElevation,
          LinearDistance fapHeight,
          TemperatureCorrectionFormulaTypes temperatureCorrectionFormulaType)
        {
            this._ThresholdElevation = thresholdElevation.ConvertTo(LinearDistanceUnits.Metres);
            this._Fap = fapHeight.ConvertTo(LinearDistanceUnits.Metres);
            this._AerodromeTemperature = aerodromeTemperature;
            this._DeltaHMetres = new LinearDistance(0.0, LinearDistanceUnits.Metres);
            this.Calculate(temperatureCorrectionFormulaType);
        }

        public double L0 => -0.0065;

        public double T0 => 288.15;

        public LinearDistance DeltaH(LinearDistanceUnits linearDistanceUnits) => this._DeltaHMetres.ConvertTo(linearDistanceUnits);

        private void Calculate(
          TemperatureCorrectionFormulaTypes temperatureCorrectionFormulaType)
        {
            if (temperatureCorrectionFormulaType != TemperatureCorrectionFormulaTypes.IcaoTabulatedCorrections)
                throw new Exception("Unsupported formula in TemperatureCorrection!");
            double num = this.T0 - 6.5 * this._ThresholdElevation.Value / 1000.0;
            this._DeltaHMetres = new LinearDistance(-(this._AerodromeTemperature.AsDegreesCelsius() + 273.15 - num) / this.L0 * Math.Log(1.0 + this.L0 * this._Fap.Value / (this.T0 + this.L0 * this._ThresholdElevation.Value)), LinearDistanceUnits.Metres);
        }
    }
}
