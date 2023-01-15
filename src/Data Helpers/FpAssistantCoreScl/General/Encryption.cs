// Decompiled with JetBrains decompiler
// Type: ArincReader.General.Encryption
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System;
using System.Security.Cryptography;
using System.Text;

namespace ArincReader.General
{
    public static class Encryption
    {
        public const string key = "cEvu4MHkqz7mQgeqmB6mQEXi";
        public const string iv = "jvz8bUAx";

        public static string Encrypt(string encrypt)
        {
            string empty = string.Empty;
            return Encryption.Crypto(encrypt, "cEvu4MHkqz7mQgeqmB6mQEXi", "jvz8bUAx", EncryptionMode.Encrypt);
        }

        public static string Encrypt2(string encrypt, int CCaesarCipherKey) => Encryption.CaesarCipher(encrypt, CCaesarCipherKey);

        public static string Decrypt(string decrypt)
        {
            string empty = string.Empty;
            return Encryption.Crypto(decrypt, "cEvu4MHkqz7mQgeqmB6mQEXi", "jvz8bUAx", EncryptionMode.Decrypt);
        }

        public static string Decrypt2(string decrypt, int CCaesarCipherKey) => Encryption.CaesarCipher(decrypt, -CCaesarCipherKey);

        public static string CaesarCipher(string inputString, int shiftOrUnshift)
        {
            if (inputString == null)
                throw new ArgumentException("Must not be null.", nameof(inputString));
            if (shiftOrUnshift == 0)
                throw new ArgumentException("Must not be zero.", nameof(shiftOrUnshift));
            if (shiftOrUnshift <= -65536 || shiftOrUnshift >= 65536)
                throw new ArgumentException("Out of range.", nameof(shiftOrUnshift));
            char[] chArray = new char[inputString.Length];
            for (int index = 0; index < inputString.Length; ++index)
                chArray[index] = Convert.ToChar((Convert.ToInt32(inputString[index]) + shiftOrUnshift + 65536) % 65536);
            return new string(chArray);
        }

        private static string Crypto(
          string json,
          string key,
          string iv,
          EncryptionMode encryptionMode)
        {
            UTF8Encoding utF8Encoding = new UTF8Encoding();
            MD5CryptoServiceProvider cryptoServiceProvider1 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider cryptoServiceProvider2 = new TripleDESCryptoServiceProvider();
            byte[] hash = cryptoServiceProvider1.ComputeHash(Encoding.UTF8.GetBytes(key));
            cryptoServiceProvider2.Key = hash;
            cryptoServiceProvider2.IV = utF8Encoding.GetBytes(iv);
            cryptoServiceProvider2.Mode = CipherMode.CBC;
            cryptoServiceProvider2.Padding = PaddingMode.Zeros;
            byte[] inputBuffer = (byte[])null;
            ICryptoTransform cryptoTransform = (ICryptoTransform)null;
            if (encryptionMode != EncryptionMode.Encrypt)
            {
                if (encryptionMode == EncryptionMode.Decrypt)
                {
                    cryptoTransform = cryptoServiceProvider2.CreateDecryptor();
                    inputBuffer = Convert.FromBase64String(json);
                }
            }
            else
            {
                cryptoTransform = cryptoServiceProvider2.CreateEncryptor();
                inputBuffer = utF8Encoding.GetBytes(json);
            }
            byte[] numArray;
            try
            {
                numArray = cryptoTransform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            }
            finally
            {
                cryptoServiceProvider2.Clear();
                cryptoServiceProvider1.Clear();
            }
            return encryptionMode == EncryptionMode.Decrypt ? utF8Encoding.GetString(numArray) : Convert.ToBase64String(numArray);
        }
    }
}
