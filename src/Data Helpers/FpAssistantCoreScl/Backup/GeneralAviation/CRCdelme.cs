// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.CRCdelme
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FpAssistantCore.GeneralAviation
{
  [Obsolete]
  [ExcludeFromCodeCoverage]
  public class CRCdelme
  {
    private static readonly bool[] CRC32POLY = new bool[32]
    {
      true,
      true,
      false,
      true,
      false,
      true,
      false,
      true,
      true,
      false,
      false,
      false,
      false,
      false,
      true,
      false,
      true,
      false,
      false,
      false,
      false,
      false,
      true,
      false,
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      true
    };
    private static readonly int POLYNOMIALLENGTH = CRCdelme.CRC32POLY.Length;

    public bool CRC32Q(string crcInput, ref string crcOutput)
    {
      bool[] crc = CRCdelme.ComputeCRC(crcInput);
      crcOutput = CRCdelme.BooleanToHex(crc);
      return true;
    }

    public static string CalculateCrc32Q(string crcInput) => CRCdelme.BooleanToHex(CRCdelme.ComputeCRC(crcInput));

    private static bool[] ComputeCRC(string input)
    {
      char[] charArray = input.ToCharArray();
      bool[] flagArray = new bool[CRCdelme.POLYNOMIALLENGTH];
      for (int index = 0; index < input.Length; ++index)
      {
        bool[] boolean = CRCdelme.CharToBoolean(charArray[index]);
        CRCdelme.ProcessChar(flagArray, boolean);
      }
      return CRCdelme.Reverse(flagArray);
    }

    private static void ProcessChar(bool[] remainder, bool[] characterAsBoolean)
    {
      for (int index1 = 0; index1 < 8; ++index1)
      {
        int index2 = CRCdelme.POLYNOMIALLENGTH - 1;
        bool flag = remainder[index2] ^ characterAsBoolean[index1];
        for (; index2 > 0; --index2)
          remainder[index2] = !CRCdelme.CRC32POLY[index2] ? remainder[index2 - 1] : remainder[index2 - 1] ^ flag;
        remainder[index2] = flag;
      }
    }

    public static string ComputeCRCHex(string input) => CRCdelme.BooleanToHex(CRCdelme.ComputeCRC(input));

    private static bool[] Reverse(bool[] toProcess)
    {
      bool[] flagArray = new bool[toProcess.Length];
      for (int index = toProcess.Length - 1; index > -1; --index)
        flagArray[toProcess.Length - 1 - index] = toProcess[index];
      return flagArray;
    }

    private static bool[] CharToBoolean(char val)
    {
      bool[] boolean = new bool[8];
      for (int i = 0; i < 8; ++i)
      {
        if (CRCdelme.BitIsSet(val, i))
          boolean[7 - i] = true;
      }
      return boolean;
    }

    private static bool BitIsSet(char val, int i) => ((int) val & (int) Math.Pow(2.0, (double) i)) > 0;

    private static string BooleanToHex(bool[] array)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int offset = 0; offset < array.Length; offset += 4)
        stringBuilder.Append(CRCdelme.DecodeBoolean(offset, array));
      return stringBuilder.ToString().ToUpper();
    }

    private static string DecodeBoolean(int offset, bool[] array)
    {
      char minValue = char.MinValue;
      for (int y = 0; y < 4; ++y)
      {
        if (array[offset + (3 - y)])
          minValue += (char) Math.Pow(2.0, (double) y);
      }
      return Convert.ToString((int) minValue, 16);
    }
  }
}
