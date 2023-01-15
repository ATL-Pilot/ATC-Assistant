// Decompiled with JetBrains decompiler
// Type: ArincReader.FaaTerps.LtpFtpToPfaf
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.GeneralAviation;
using System;

namespace ArincReader.FaaTerps
{
    public class LtpFtpToPfaf : BaseObjectTerps
    {
        private LinearDistance _PfafAltitude;
        private LinearDistance _LtpElevation;
        private LinearDistance _Tch;
        private Angle _Gpa;
        private readonly double _r = Constants.FaaTerpsConstants.MeanRadiusOfEarthInFeet;
        private LinearDistance _DistancePfaf = new LinearDistance(0.0, LinearDistanceUnits.Feet);

        public LtpFtpToPfaf(
          LinearDistance PfafAltitude,
          LinearDistance LtpElevation,
          LinearDistance Tch,
          Angle GlidePathAngle,
          CriteriaUnits terpsUnit)
          : base(terpsUnit)
        {
            this._PfafAltitude = PfafAltitude;
            this._LtpElevation = LtpElevation;
            this._Tch = Tch;
            this._Gpa = GlidePathAngle;
            this.Calcuate();
        }

        public LinearDistance PfafAltitude
        {
            set => this._PfafAltitude = value;
        }

        public LinearDistance LtpElevation
        {
            set => this._LtpElevation = value;
        }

        public LinearDistance Tch
        {
            set => this._Tch = value;
        }

        public double Gpa
        {
            set => this._Gpa = new Angle(value);
        }

        public LinearDistance DistancePfaf => this._DistancePfaf;

        private void Calcuate() => this._DistancePfaf = new LinearDistance(this._r * Math.Log((this._r + this._PfafAltitude.ConvertTo(LinearDistanceUnits.Feet).Value) / (this._r + this._LtpElevation.ConvertTo(LinearDistanceUnits.Feet).Value + this._Tch.ConvertTo(LinearDistanceUnits.Feet).Value)) / Math.Tan(this._Gpa.AsRadians()), LinearDistanceUnits.Feet);
    }
}
