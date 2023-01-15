// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.Crc
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Collections;

namespace FpAssistantCore.GeneralAviation
{
  public static class Crc
  {
    private static readonly BitArray Polynomial = new BitArray(new int[1]
    {
      -2126429781
    });
    private const int PolynomialLength = 32;

    public static byte[] GenerateBytes(string value)
    {
      byte[] input = new byte[value.Length];
      for (int index = 0; index < value.Length; ++index)
        input[index] = Convert.ToByte(value[index]);
      return Crc.GenerateChecksumBytes(input);
    }

    public static string Reverse(string x)
    {
      string str = "";
      for (int index = x.Length - 1; index >= 0; --index)
        str += x[index].ToString();
      return str;
    }

    public static byte[] GenerateChecksumBytes(byte[] input)
    {
      BitArray remainder = new BitArray(32);
      for (int index = 0; index < input.Length; ++index)
        Crc.ProcessByte(input[index], remainder);
      return Crc.GetReversedBytes(remainder);
    }

    private static void ProcessByte(byte inputByte, BitArray remainder)
    {
      for (int index1 = 0; index1 < 8; ++index1)
      {
        int index2 = 31;
        bool boolean = Convert.ToBoolean((int) inputByte >> index1 & 1);
        bool flag = remainder[index2] ^ boolean;
        for (; index2 > 0; --index2)
          remainder[index2] = !Crc.Polynomial[index2] ? remainder[index2 - 1] : remainder[index2 - 1] ^ flag;
        remainder[0] = flag;
      }
    }

    private static byte[] GetReversedBytes(BitArray remainder)
    {
      int length = remainder.Length;
      BitArray bitArray = new BitArray(length);
      for (int index = 0; index < remainder.Length; ++index)
        bitArray[--length] = remainder[index];
      byte[] reversedBytes = new byte[remainder.Length / 8];
      bitArray.CopyTo((Array) reversedBytes, 0);
      return reversedBytes;
    }
  }
}
