﻿// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.FaaTerps.BaseObjectTerps
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.GeneralAviation;
using System;

namespace FpAssistantCore.FaaTerps
{
  public abstract class BaseObjectTerps
  {
    private readonly CriteriaUnits _TerpsUnit;

    public BaseObjectTerps(CriteriaUnits terpsUnit)
    {
      switch (terpsUnit)
      {
        case CriteriaUnits.Si:
        case CriteriaUnits.NonSi:
          this._TerpsUnit = terpsUnit;
          if (DeveloperLicense.IsFaaTerpsLicensed)
            break;
          throw new Exception(ConstantMessages.ForLicensing.FaaTerpsModuleNotLicensed);
        default:
          throw new InvalidOperationException("Unsupported enum value passed to BaseObjectTerps() instantiation, Value [" + this.TerpsUnit.ToString() + "]");
      }
    }

    public CriteriaUnits TerpsUnit => this._TerpsUnit;
  }
}
