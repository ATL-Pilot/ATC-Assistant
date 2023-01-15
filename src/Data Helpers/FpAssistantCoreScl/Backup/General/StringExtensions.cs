// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.StringExtensions
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Text;

namespace FpAssistantCore.General
{
  public static class StringExtensions
  {
    public static byte ToIA5Byte(this char character) => (byte) ((uint) Encoding.UTF8.GetBytes(new char[1]
    {
      character
    })[0] & 63U);

    public static string ReplaceAtPosition(this string self, int position, string newValue)
    {
      if (self == null)
        throw new NullReferenceException(nameof (self));
      if (newValue == null)
        throw new NullReferenceException(nameof (newValue));
      return self.Remove(position, newValue.Length).Insert(position, newValue);
    }
  }
}
