// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.BaseObjectGeneral
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;

namespace ArincReader.GeneralAviation
{
    public abstract class BaseObjectGeneral : BaseObject
    {
        public BaseObjectGeneral()
        {
            //if (!DeveloperLicense.IsIcaoPansOpsLicensed && !DeveloperLicense.IsFaaTerpsLicensed)
            //  throw new Exception(ConstantMessages.ForLicensing.GeneralToolsModuleNotLicensed);
        }
    }
}
