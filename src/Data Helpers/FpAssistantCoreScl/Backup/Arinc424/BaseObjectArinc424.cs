﻿// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.BaseObjectArinc424
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;

namespace FpAssistantCore.Arinc424
{
  public abstract class BaseObjectArinc424
  {
    public BaseObjectArinc424()
    {
      if (!DeveloperLicense.IsArinc424Licensed)
        throw new Exception(ConstantMessages.ForLicensing.Arinc424ParserNotLicensed);
    }
  }
}
