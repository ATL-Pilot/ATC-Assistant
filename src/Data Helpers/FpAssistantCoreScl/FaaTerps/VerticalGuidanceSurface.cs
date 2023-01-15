// Decompiled with JetBrains decompiler
// Type: ArincReader.FaaTerps.VerticalGuidanceSurface
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.GeneralAviation;
using System;

namespace ArincReader.FaaTerps
{
    public class VerticalGuidanceSurface : BaseObjectTerps
    {
        private LinearDistance _RunwayWidth = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _k = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _E = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _LtpToDaVdpDistance = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _HalfAreaWidthAtSpecifiedDistance = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _SpecifiedDistanceFromLtp = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _Constant_100ft = new LinearDistance(100.0, LinearDistanceUnits.Feet);

        public VerticalGuidanceSurface(CriteriaUnits terpsUnit)
          : base(terpsUnit)
        {
        }

        public LinearDistance RunwayWidth
        {
            set
            {
                this._RunwayWidth = value.Value > 0.0 ? value : throw new ArgumentException("Runway width must not be zero or less", nameof(RunwayWidth));
                this.HalfAreaWidthAtOrigin();
            }
            get => this._RunwayWidth;
        }

        public LinearDistance LtpToDaVdpDistance
        {
            set
            {
                this._LtpToDaVdpDistance = value.Value > 0.0 ? value : throw new ArgumentException("Distance from LTP to DA or VDP point must not be zero or less", "RunwayWidth");
                this.HalfAreaWidthAtDaVdpPoint();
            }
            get => this._LtpToDaVdpDistance;
        }

        public LinearDistance SpecifiedDistanceFromLtp
        {
            set
            {
                if (value.Value <= 0.0)
                    throw new ArgumentException("Distance from LTP to a point along the RCL must not be zero or less", nameof(SpecifiedDistanceFromLtp));
            }
            get => this._SpecifiedDistanceFromLtp;
        }

        public LinearDistance HalfAreaWidthAtSpecifiedDistance => this._HalfAreaWidthAtSpecifiedDistance;

        private void HalfAreaWidthAtOrigin() => this._k = this._RunwayWidth / 2.0 + this._Constant_100ft;

        private void HalfAreaWidthAtDaVdpPoint() => this._E = this._LtpToDaVdpDistance * 0.036 + 392.8;

        private void HalfAreaWidthAtDistance()
        {
        }
    }
}
