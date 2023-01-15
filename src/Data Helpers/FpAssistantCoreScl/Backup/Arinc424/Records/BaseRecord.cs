// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.BaseRecord
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Collections.Generic;

namespace FpAssistantCore.Arinc424.Records
{
  public class BaseRecord : IBaseRecord
  {
    public BaseRecord(string record)
    {
      this.Record = record;
      this.Id = Guid.NewGuid();
    }

    public string Record { get; private set; }

    public Guid Id { get; private set; }

    public Arinc424RecordObjectTypes Type
    {
      get
      {
        Arinc424RecordObjectTypes type = Arinc424RecordObjectTypes.Unknown;
        if (this.Record.StartsWith("HDR01"))
          type = Arinc424RecordObjectTypes.Header1;
        else if (this.Record.StartsWith("HDR") && this.Record.Substring(2, 2) != "01")
          type = Arinc424RecordObjectTypes.Header2;
        else if (this.SectionCode == "A" && this.SubsectionCode == "S")
          type = Arinc424RecordObjectTypes.GridMora;
        else if (this.SectionCode == "D" && this.SubsectionCode == " ")
          type = Arinc424RecordObjectTypes.VhfNavaid;
        else if (this.SectionCode == NdbNavaidEnroute.SectionCode && this.SubsectionCode == NdbNavaidEnroute.SubsectionCode)
          type = Arinc424RecordObjectTypes.NdbNavaidEnroute;
        else if (this.SectionCode == NdbNavaidTerminal.SectionCode && this.SubsectionCode == NdbNavaidTerminal.SubsectionCode)
          type = Arinc424RecordObjectTypes.NdbNavaidTerminal;
        else if (this.SectionCode == WaypointEnroute.SectionCode && this.SubsectionCode == WaypointEnroute.SubsectionCode)
          type = Arinc424RecordObjectTypes.WaypointEnroute;
        else if (this.SectionCode == WaypointTerminal.SectionCode && this.SubsectionCode == WaypointTerminal.SubsectionCode)
          type = Arinc424RecordObjectTypes.WaypointTerminal;
        else if (this.SectionCode == WaypointHeliportTerminal.SectionCode && this.SubsectionCode == WaypointHeliportTerminal.SubsectionCode)
          type = Arinc424RecordObjectTypes.WaypointHeliportTerminal;
        else if (this.SectionCode == "E" && this.SubsectionCode == "R")
          type = Arinc424RecordObjectTypes.EnrouteAirway;
        else if (this.SectionCode == "P" && this.SubsectionCode == "A")
          type = Arinc424RecordObjectTypes.Airport;
        else if (this.SectionCode == "P" && this.SubsectionCode == "G")
          type = Arinc424RecordObjectTypes.AirportRunway;
        else if (this.SectionCode == "P" && this.SubsectionCode == "D")
          type = Arinc424RecordObjectTypes.AirportSid;
        else if (this.SectionCode == "P" && this.SubsectionCode == "E")
          type = Arinc424RecordObjectTypes.AirportStar;
        else if (this.SectionCode == "P" && this.SubsectionCode == "F")
          type = Arinc424RecordObjectTypes.AirportApproach;
        else if (this.SectionCode == "P" && this.SubsectionCode == "I")
          type = Arinc424RecordObjectTypes.AirportHeliportLocalizerGlideSlope;
        else if (this.SectionCode == "P" && this.SubsectionCode == "S")
          type = Arinc424RecordObjectTypes.AirportMsa;
        else if (this.SectionCode == "P" && this.SubsectionCode == "P")
          type = Arinc424RecordObjectTypes.PathPoint;
        else if (this.SectionCode == "H" && this.SubsectionCode == "A")
          type = Arinc424RecordObjectTypes.Heliport;
        else if (this.SectionCode == HeliportMsa.SectionCode && this.SubsectionCode == HeliportMsa.SubsectionCode)
          type = Arinc424RecordObjectTypes.HeliportMsa;
        else if (this.SectionCode == "U" && this.SubsectionCode == "R")
          type = Arinc424RecordObjectTypes.RestrictiveAirspace;
        else if (this.SectionCode == "U" && this.SubsectionCode == "C")
          type = Arinc424RecordObjectTypes.ControlledAirspace;
        else if (this.SectionCode == "H" && this.SubsectionCode == "D")
          type = Arinc424RecordObjectTypes.HeliportSid;
        else if (this.SectionCode == "H" && this.SubsectionCode == "E")
          type = Arinc424RecordObjectTypes.HeliportStar;
        else if (this.SectionCode == "H" && this.SubsectionCode == "F")
          type = Arinc424RecordObjectTypes.HeliportApproach;
        return type;
      }
    }

    private string SectionCode => this.Record.Substring(4, 1);

    private string SubsectionCode
    {
      get
      {
        int startIndex = 5;
        string sectionCode = this.SectionCode;
        if ((sectionCode == "P" || sectionCode == "H") && this.Record.Substring(startIndex, 1) == " ")
          startIndex = 12;
        return this.Record.Substring(startIndex, 1);
      }
    }

    public bool UpdateRecord(string record)
    {
      this.Record = record.Length == 132 ? record : throw new ArgumentException("Record length must be 132 characters", nameof (record));
      return true;
    }

    public void UpdateField(int position, string newText) => this.UpdateRecord(this.Record.ReplaceAtPosition(position, newText));

    public virtual bool GeoFenceWithin(GeoCoordinateBasic searchCentrePoint, LinearDistance radius) => throw new NotImplementedException();

    protected string GetFieldContents(List<FieldStructure> fields, string propertyName)
    {
      FieldStructure fieldStructure = fields.Find((Predicate<FieldStructure>) (x => string.Equals(x.FieldName, propertyName, StringComparison.InvariantCulture)));
      return this.Record.Substring(fieldStructure.ColumnStart - 1, fieldStructure.FieldLength);
    }

    protected void UpdateThisProperty(
      string propertyName,
      string value,
      List<FieldStructure> Fields)
    {
      FieldStructure fieldStructure = Fields.Find((Predicate<FieldStructure>) (x => string.Equals(x.FieldName, propertyName, StringComparison.InvariantCulture)));
      if (value.Length > fieldStructure.FieldLength)
        value = value.Substring(0, fieldStructure.FieldLength);
      else if (value.Length < fieldStructure.FieldLength)
        value = value.PadRight(fieldStructure.FieldLength);
      this.UpdateField(fieldStructure.ColumnStart - 1, value);
    }
  }
}
