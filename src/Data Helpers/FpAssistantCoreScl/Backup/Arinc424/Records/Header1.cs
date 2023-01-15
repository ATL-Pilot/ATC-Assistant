// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.Header1
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace FpAssistantCore.Arinc424.Records
{
  public class Header1 : BaseRecord
  {
    public const string HdrIdent = "HDR";
    public const string HdrNumber = "01";
    public static List<FieldStructure> Fields = new List<FieldStructure>()
    {
      new FieldStructure(nameof (HeaderIdent), 1, 3),
      new FieldStructure(nameof (HeaderNumber), 4, 5),
      new FieldStructure(nameof (FileName), 6, 20),
      new FieldStructure(nameof (VersionNumber), 21, 23),
      new FieldStructure(nameof (ProductionTestFlag), 24, 24),
      new FieldStructure(nameof (RecordLength), 25, 28),
      new FieldStructure(nameof (RecordCount), 29, 35),
      new FieldStructure(nameof (CycleDate), 36, 39),
      new FieldStructure(nameof (Blank40), 40, 41),
      new FieldStructure(nameof (CreationDate), 42, 52),
      new FieldStructure(nameof (CreationTime), 53, 60),
      new FieldStructure(nameof (Blank61), 61, 61),
      new FieldStructure(nameof (DataSupplierIdent), 62, 77),
      new FieldStructure(nameof (TargetCustomerIdent), 78, 93),
      new FieldStructure(nameof (DatabasePartNumber), 94, 113),
      new FieldStructure(nameof (Reserved), 114, 124),
      new FieldStructure(nameof (FileCRC), 125, 132)
    };

    public Header1(string record)
      : base(record)
    {
    }

    public Header1()
      : base(new string(' ', 132))
    {
      this.UpdateThisProperty(nameof (HeaderIdent), Header1.HeaderIdent, Header1.Fields);
      this.UpdateThisProperty(nameof (HeaderNumber), Header1.HeaderNumber, Header1.Fields);
      this.FileName = "FileName.424";
      this.VersionNumber = "001";
      this.ProductionTestFlagEnum = Arinc424ProductTestFlag.P;
      this.RecordLength = "0132";
      this.RecordCount = 1L;
      this.CycleDate = new CycleDate(DateTime.Now.Year - 2000, 1);
      this.CreationDate2 = this.CreationTime2 = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
      this.DataSupplierIdent = "CADology";
    }

    public static string HeaderIdent => "HDR";

    public static string HeaderNumber => "01";

    public string FileName
    {
      set => this.UpdateThisProperty(nameof (FileName), value, Header1.Fields);
      get => this.GetFieldContents(Header1.Fields, nameof (FileName));
    }

    public string VersionNumber
    {
      private set => this.UpdateThisProperty(nameof (VersionNumber), value, Header1.Fields);
      get => this.GetFieldContents(Header1.Fields, nameof (VersionNumber));
    }

    public string ProductionTestFlag => this.ProductionTestFlagEnum.ToString();

    public Arinc424ProductTestFlag ProductionTestFlagEnum
    {
      set => this.UpdateThisProperty("ProductionTestFlag", value.ToString(), Header1.Fields);
      get => (Arinc424ProductTestFlag) Enum.Parse(typeof (Arinc424ProductTestFlag), this.GetFieldContents(Header1.Fields, "ProductionTestFlag"));
    }

    public string RecordLength
    {
      private set => this.UpdateThisProperty(nameof (RecordLength), value, Header1.Fields);
      get => this.GetFieldContents(Header1.Fields, nameof (RecordLength));
    }

    public long RecordCount
    {
      private set
      {
        FieldStructure fieldStructure = Header1.Fields.Find((Predicate<FieldStructure>) (x => string.Equals(x.FieldName, nameof (RecordCount), StringComparison.InvariantCulture)));
        this.UpdateThisProperty(nameof (RecordCount), value.ToString("D" + fieldStructure.FieldLength.ToString()), Header1.Fields);
      }
      get => long.Parse(this.GetFieldContents(Header1.Fields, nameof (RecordCount)));
    }

    public CycleDate CycleDate
    {
      set => this.UpdateThisProperty(nameof (CycleDate), value.ToString(), Header1.Fields);
      get => new CycleDate(this.GetFieldContents(Header1.Fields, nameof (CycleDate)));
    }

    public string Blank40 => this.GetFieldContents(Header1.Fields, nameof (Blank40));

    public string CreationDate => this.GetFieldContents(Header1.Fields, nameof (CreationDate));

    public DateTime CreationDate2
    {
      set => this.UpdateThisProperty("CreationDate", value.ToString("dd-MMM-yyyy", (IFormatProvider) CultureInfo.InvariantCulture).ToUpper(), Header1.Fields);
      get => Convert.ToDateTime(DateTime.Parse(this.GetFieldContents(Header1.Fields, "CreationDate")).ToString("dd-MMM-yyyy", (IFormatProvider) CultureInfo.InvariantCulture));
    }

    public string CreationTime => this.GetFieldContents(Header1.Fields, nameof (CreationTime));

    public DateTime CreationTime2
    {
      set => this.UpdateThisProperty("CreationTime", value.ToString("HH:mm:ss", (IFormatProvider) CultureInfo.InvariantCulture), Header1.Fields);
      get => Convert.ToDateTime(DateTime.Parse(this.GetFieldContents(Header1.Fields, "CreationTime")).ToString("HH:mm:ss", (IFormatProvider) CultureInfo.InvariantCulture));
    }

    public string Blank61 => this.GetFieldContents(Header1.Fields, nameof (Blank61));

    public string DataSupplierIdent
    {
      set => this.UpdateThisProperty(nameof (DataSupplierIdent), value, Header1.Fields);
      get => this.GetFieldContents(Header1.Fields, nameof (DataSupplierIdent));
    }

    public string TargetCustomerIdent
    {
      set => this.UpdateThisProperty(nameof (TargetCustomerIdent), value, Header1.Fields);
      get => this.GetFieldContents(Header1.Fields, nameof (TargetCustomerIdent));
    }

    public string DatabasePartNumber
    {
      set => this.UpdateThisProperty(nameof (DatabasePartNumber), value, Header1.Fields);
      get => this.GetFieldContents(Header1.Fields, nameof (DatabasePartNumber));
    }

    public string Reserved => this.GetFieldContents(Header1.Fields, nameof (Reserved));

    public string FileCRC
    {
      set => this.UpdateThisProperty(nameof (FileCRC), value, Header1.Fields);
      get => this.GetFieldContents(Header1.Fields, nameof (FileCRC));
    }

    public void VersionNumberUpdate(int versionNumber)
    {
      if (versionNumber < 1 || versionNumber > 999)
        throw new ArgumentException(ConstantMessages.Arinc424Exceptions.HeaderRecordVersionNumberInvalid, nameof (versionNumber));
      FieldStructure fieldStructure = Header1.Fields.Find((Predicate<FieldStructure>) (x => string.Equals(x.FieldName, "VersionNumber", StringComparison.InvariantCulture)));
      this.VersionNumber = versionNumber.ToString("D" + fieldStructure.FieldLength.ToString());
    }

    private static class FieldNames
    {
      public const string HeaderIdent = "HeaderIdent";
      public const string HeaderNumber = "HeaderNumber";
      public const string FileName = "FileName";
      public const string VersionNumber = "VersionNumber";
      public const string ProductionTestFlag = "ProductionTestFlag";
      public const string RecordLength = "RecordLength";
      public const string RecordCount = "RecordCount";
      public const string CycleDate = "CycleDate";
      public const string CreationDate = "CreationDate";
      public const string CreationTime = "CreationTime";
      public const string DataSupplierIdent = "DataSupplierIdent";
      public const string TargetCustomerIdent = "TargetCustomerIdent";
      public const string DatabasePartNumber = "DatabasePartNumber";
      public const string FileCRC = "FileCRC";
    }
  }
}
