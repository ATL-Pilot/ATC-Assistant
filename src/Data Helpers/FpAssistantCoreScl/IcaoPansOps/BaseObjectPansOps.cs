// Decompiled with JetBrains decompiler
// Type: ArincReader.IcaoPansOps.BaseObjectPansOps
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.GeneralAviation;
using System;

namespace ArincReader.IcaoPansOps
{
    public abstract class BaseObjectPansOps : BaseObject
    {
        public BaseObjectPansOps(CriteriaUnits pansOpsUnit)
        {
            switch (pansOpsUnit)
            {
                case CriteriaUnits.Si:
                case CriteriaUnits.NonSi:
                    this.PansOpsUnit = pansOpsUnit;
                    if (DeveloperLicense.IsIcaoPansOpsLicensed)
                        break;
                    throw new Exception(ConstantMessages.ForLicensing.IcaoPansOpsModuleNotLicensed);
                default:
                    throw new InvalidOperationException("Unsupported enum value passed to BaseObjectPansOps() instantiation, Value [" + this.PansOpsUnit.ToString() + "]");
            }
        }

        public CriteriaUnits PansOpsUnit { get; private set; }
    }
}
