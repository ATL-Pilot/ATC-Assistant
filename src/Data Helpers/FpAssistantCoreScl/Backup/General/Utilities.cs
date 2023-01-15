// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.Utilities
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace FpAssistantCore.General
{
  public static class Utilities
  {
    public static (bool status, double value) ConvertStringToDouble(string textualNumber)
    {
      bool flag = false;
      double result;
      if (double.TryParse(textualNumber, NumberStyles.Any, (IFormatProvider) CultureInfo.CurrentCulture, out result))
        flag = true;
      return (flag, result);
    }

    public static string GetResource(string resourceName) => new ResourceManager("FpAssistantCore.ResourcesFpa", typeof (Utilities).GetTypeInfo().Assembly).GetString(resourceName);

    public static string GetFPAssistantSDKFileVersion()
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      return executingAssembly != (Assembly) null ? FileVersionInfo.GetVersionInfo(executingAssembly.Location).FileVersion : "0.0.0.0";
    }
  }
}
