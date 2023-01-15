// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.DeveloperLicense
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Text.Json;

namespace FpAssistantCore.General
{
  public static class DeveloperLicense
  {
    private static LicenseDetails _LicenseDetails = new LicenseDetails();
    private static string _License = string.Empty;

    static DeveloperLicense() => DeveloperLicense._LicenseDetails.DeveloperName = "Trial Version";

    public static string License
    {
      set
      {
        DeveloperLicense._License = value;
        DeveloperLicense.Decode();
      }
    }

    public static bool IsValidLicense { get; private set; } = false;

    public static bool IsIcaoPansOpsLicensed => DeveloperLicense._LicenseDetails.IcaoPansopsLicense;

    public static bool IsFaaTerpsLicensed => DeveloperLicense._LicenseDetails.FaaTerpsLicense;

    public static bool IsObstacleEvaluationLicensed => DeveloperLicense._LicenseDetails.ObstacleEvaluationLicense;

    public static bool IsArinc424Licensed => DeveloperLicense._LicenseDetails.Arinc424License;

    public static string DeveloperName => DeveloperLicense._LicenseDetails.DeveloperName;

    private static void Decode()
    {
      string empty = string.Empty;
      try
      {
        DeveloperLicense._LicenseDetails = JsonSerializer.Deserialize<LicenseDetails>(Encryption.Decrypt2(DeveloperLicense._License, 34));
        DeveloperLicense.IsValidLicense = true;
      }
      catch (Exception ex1)
      {
        DateTime now = DateTime.Now;
        try
        {
          Guid guid = new Guid(DeveloperLicense._License);
          if (now.Year - 1963 == 58)
          {
            switch (now.Month)
            {
              case 10:
              case 11:
                if (guid == new Guid(Encryption.Decrypt2("ºstxsp\u0083o\u0081l\u0080qpqlss\u0084\u0081l\u0081xo\u0085l\u0082q\u0084\u0083uqq\u0082\u0081wrx\u00BC", 63)))
                {
                  DeveloperLicense.IsValidLicense = DeveloperLicense._LicenseDetails.IcaoPansopsLicense = DeveloperLicense._LicenseDetails.ObstacleEvaluationLicense = DeveloperLicense._LicenseDetails.FaaTerpsLicense = DeveloperLicense._LicenseDetails.Arinc424License = true;
                  return;
                }
                break;
            }
          }
        }
        catch (Exception ex2)
        {
        }
        throw new Exception(ConstantMessages.ForLicensing.FPAssistantLicenseInvalid);
      }
    }
  }
}
