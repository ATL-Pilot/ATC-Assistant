// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.Header2
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Collections.Generic;
using System.Globalization;

namespace FpAssistantCore.Arinc424.Records
{
  public class Header2 : BaseRecord
  {
    public const string HeaderIdent = "HDR";
    public const string HeaderNumber = "02";
    public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure(nameof (HeaderIdent), 1, 3),
      new FieldStructure(nameof (HeaderNumber), 4, 5),
      new FieldStructure(nameof (EffectiveDate), 6, 16),
      new FieldStructure(nameof (ExpirationDate), 17, 27),
      new FieldStructure("Blank28", 28, 28),
      new FieldStructure(nameof (SupplierTextField), 29, 58),
      new FieldStructure(nameof (DescriptiveText), 59, 88),
      new FieldStructure("Reserved", 89, 132)
    };

    public Header2(string record)
      : base(record)
    {
    }

    public Header2()
      : base(new string(' ', 132))
    {
      this.UpdateThisProperty(nameof (HeaderIdent), "HDR", Header2.Fields);
      this.UpdateThisProperty(nameof (HeaderNumber), "02", Header2.Fields);
    }

    public DateTime EffectiveDate
    {
      set => this.UpdateThisProperty(nameof (EffectiveDate), value.ToString("dd-MMM-yyyy", (IFormatProvider) CultureInfo.InvariantCulture).ToUpper(), Header2.Fields);
      get => Convert.ToDateTime(DateTime.Parse(this.GetFieldContents(Header2.Fields, nameof (EffectiveDate))).ToString("dd-MMM-yyyy", (IFormatProvider) CultureInfo.InvariantCulture));
    }

    public DateTime ExpirationDate
    {
      set => this.UpdateThisProperty(nameof (ExpirationDate), value.ToString("dd-MMM-yyyy", (IFormatProvider) CultureInfo.InvariantCulture).ToUpper(), Header2.Fields);
      get => Convert.ToDateTime(DateTime.Parse(this.GetFieldContents(Header2.Fields, nameof (ExpirationDate))).ToString("dd-MMM-yyyy", (IFormatProvider) CultureInfo.InvariantCulture));
    }

    public string SupplierTextField
    {
      set => this.UpdateThisProperty(nameof (SupplierTextField), value, Header2.Fields);
      get => this.GetFieldContents(Header2.Fields, nameof (SupplierTextField));
    }

    public string DescriptiveText
    {
      set => this.UpdateThisProperty(nameof (DescriptiveText), value, Header2.Fields);
      get => this.GetFieldContents(Header2.Fields, nameof (DescriptiveText));
    }

    private static class FieldNames
    {
      public const string HeaderIdent = "HeaderIdent";
      public const string HeaderNumber = "HeaderNumber";
      public const string EffectiveDate = "EffectiveDate";
      public const string ExpirationDate = "ExpirationDate";
      public const string SupplierTextField = "SupplierTextField";
      public const string DescriptiveText = "DescriptiveText";
    }
  }
}
