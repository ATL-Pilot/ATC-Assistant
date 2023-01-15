// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.AngleOfBank
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.GeneralAviation
{
    public struct AngleOfBank
    {
        private Angle _Angle;

        public AngleOfBank(double angleOfBank) => this._Angle = new Angle(angleOfBank);

        public double Value
        {
            get => this.AsDegrees();
            set => this._Angle = new Angle(value);
        }

        public double AsDegrees() => this._Angle.AsDegrees();

        public Angle AsAngle() => this._Angle;
    }
}
