// Decompiled with JetBrains decompiler
// Type: ArincReader.Pbn.BaseObjectPbn
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.GeneralAviation;

namespace ArincReader.Pbn
{
    public abstract class BaseObjectPbn
    {
        protected Criteria _Criteria;

        public BaseObjectPbn(Criteria criteria)
        {
            //if (!DeveloperLicense.IsIcaoPansOpsLicensed && !DeveloperLicense.IsFaaTerpsLicensed)
            //  throw new Exception(ConstantMessages.ForLicensing.PbnModuleNotLicensed);
            this._Criteria = criteria;
        }

        public bool IsFaa() => this._Criteria == Criteria.FaaTerps;

        public bool IsIcao() => this._Criteria == Criteria.IcaoPansOps;

        public enum PbnPathTypes
        {
            [Description(Text = "Track between two fixes")] TF,
            [Description(Text = "Constant radius to a fix")] RF,
        }
    }
}
