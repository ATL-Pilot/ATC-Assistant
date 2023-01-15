// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Serialization.Arinc424AsciiDeserializer
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.Arinc424.Records;
using System.IO;

namespace FpAssistantCore.Arinc424.Serialization
{
  public class Arinc424AsciiDeserializer
  {
    public Arinc424Data Deserialize(
      StreamReader streamReader,
      ref Arinc424Data arinc424Data)
    {
      string record;
      while ((record = streamReader.ReadLine()) != null)
      {
        BaseRecord baseRecord = new BaseRecord(record);
        switch (baseRecord.Type)
        {
          case Arinc424RecordObjectTypes.Header1:
            arinc424Data.AddRecord((BaseRecord) new Header1(record));
            continue;
          case Arinc424RecordObjectTypes.Header2:
            arinc424Data.AddRecord((BaseRecord) new Header2(record));
            continue;
          case Arinc424RecordObjectTypes.GridMora:
            arinc424Data.AddRecord((BaseRecord) new GridMora(record));
            continue;
          case Arinc424RecordObjectTypes.VhfNavaid:
            arinc424Data.AddRecord((BaseRecord) new VhfNavaid(record));
            continue;
          case Arinc424RecordObjectTypes.NdbNavaidEnroute:
            arinc424Data.AddRecord((BaseRecord) new NdbNavaidEnroute(record));
            continue;
          case Arinc424RecordObjectTypes.NdbNavaidTerminal:
            arinc424Data.AddRecord((BaseRecord) new NdbNavaidTerminal(record));
            continue;
          case Arinc424RecordObjectTypes.WaypointEnroute:
            arinc424Data.AddRecord((BaseRecord) new WaypointEnroute(record));
            continue;
          case Arinc424RecordObjectTypes.WaypointTerminal:
            arinc424Data.AddRecord((BaseRecord) new WaypointTerminal(record));
            continue;
          case Arinc424RecordObjectTypes.WaypointHeliportTerminal:
            arinc424Data.AddRecord((BaseRecord) new WaypointHeliportTerminal(record));
            continue;
          case Arinc424RecordObjectTypes.EnrouteAirway:
            arinc424Data.AddRecord((BaseRecord) new EnrouteAirway(record));
            continue;
          case Arinc424RecordObjectTypes.Airport:
            arinc424Data.AddRecord((BaseRecord) new Airport(record));
            continue;
          case Arinc424RecordObjectTypes.Heliport:
            arinc424Data.AddRecord((BaseRecord) new Heliport(record));
            continue;
          case Arinc424RecordObjectTypes.AirportRunway:
            arinc424Data.AddRecord((BaseRecord) new AirportRunway(record));
            continue;
          case Arinc424RecordObjectTypes.RestrictiveAirspace:
            arinc424Data.AddRecord((BaseRecord) new RestrictiveAirspace(record));
            continue;
          case Arinc424RecordObjectTypes.ControlledAirspace:
            arinc424Data.AddRecord((BaseRecord) new ControlledAirspace(record));
            continue;
          case Arinc424RecordObjectTypes.AirportSid:
            arinc424Data.AddRecord((BaseRecord) new AirportSid(record));
            continue;
          case Arinc424RecordObjectTypes.AirportStar:
            arinc424Data.AddRecord((BaseRecord) new AirportStar(record));
            continue;
          case Arinc424RecordObjectTypes.AirportApproach:
            arinc424Data.AddRecord((BaseRecord) new AirportApproach(record));
            continue;
          case Arinc424RecordObjectTypes.AirportMsa:
            arinc424Data.AddRecord((BaseRecord) new AirportMsa(record));
            continue;
          case Arinc424RecordObjectTypes.HeliportMsa:
            arinc424Data.AddRecord((BaseRecord) new HeliportMsa(record));
            continue;
          case Arinc424RecordObjectTypes.PathPoint:
            arinc424Data.AddRecord((BaseRecord) new PathPoint(record));
            continue;
          case Arinc424RecordObjectTypes.AirportHeliportLocalizerGlideSlope:
            arinc424Data.AddRecord((BaseRecord) new AirportHeliport_LocalizerGlideSlope(record));
            continue;
          case Arinc424RecordObjectTypes.HeliportSid:
            arinc424Data.AddRecord((BaseRecord) new HeliportSid(record));
            continue;
          case Arinc424RecordObjectTypes.HeliportStar:
            arinc424Data.AddRecord((BaseRecord) new HeliportStar(record));
            continue;
          case Arinc424RecordObjectTypes.HeliportApproach:
            arinc424Data.AddRecord((BaseRecord) new HeliportApproach(record));
            continue;
          case Arinc424RecordObjectTypes.Unknown:
            arinc424Data.AddRecord(baseRecord);
            continue;
          default:
            continue;
        }
      }
      return arinc424Data;
    }
  }
}
