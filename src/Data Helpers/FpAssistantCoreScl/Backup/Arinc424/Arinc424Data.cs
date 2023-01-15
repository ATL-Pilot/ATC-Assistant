// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Arinc424Data
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.Arinc424.Records;
using FpAssistantCore.Geographical;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FpAssistantCore.Arinc424
{
  public class Arinc424Data : BaseObjectArinc424
  {
    private readonly RecordCollection _RecordCollection = new RecordCollection();

    public void Clear() => this._RecordCollection.Clear();

    public bool FindByGuid(Guid guidToFind, ref BaseRecord userBaseRecord)
    {
      bool byGuid = false;
      foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
      {
        if (record.Id == guidToFind)
        {
          userBaseRecord = record;
          byGuid = true;
          break;
        }
      }
      return byGuid;
    }

    public List<BaseRecord> Filter(
      List<Arinc424RecordObjectTypes> arinc424RecordObjectTypes)
    {
      if (arinc424RecordObjectTypes == null)
        throw new ArgumentNullException(nameof (arinc424RecordObjectTypes));
      if (arinc424RecordObjectTypes.Count == 0)
        throw new ArgumentException("List should not be 0 length!", nameof (arinc424RecordObjectTypes));
      if (!arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.EnrouteAirway) && !arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.Airport) && !arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.WaypointEnroute) && !arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.WaypointHeliportTerminal) && !arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.WaypointTerminal) && !arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.AirportApproach) && !arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.AirportSid) && !arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.AirportStar))
        throw new NotImplementedException("One of the Arinc424RecordObjectTypes is currently not supported, please contact developer!");
      List<BaseRecord> baseRecordList = new List<BaseRecord>();
      foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
      {
        switch (record)
        {
          case EnrouteAirway enrouteAirway when arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.EnrouteAirway):
            baseRecordList.Add((BaseRecord) enrouteAirway);
            continue;
          case Airport airport when arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.Airport):
            baseRecordList.Add((BaseRecord) airport);
            continue;
          case WaypointEnroute waypointEnroute when arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.WaypointEnroute):
            baseRecordList.Add((BaseRecord) waypointEnroute);
            continue;
          case WaypointHeliportTerminal heliportTerminal when arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.WaypointHeliportTerminal):
            baseRecordList.Add((BaseRecord) heliportTerminal);
            continue;
          case WaypointTerminal waypointTerminal when arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.WaypointTerminal):
            baseRecordList.Add((BaseRecord) waypointTerminal);
            continue;
          case AirportApproach airportApproach when arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.AirportApproach):
            baseRecordList.Add((BaseRecord) airportApproach);
            continue;
          case AirportSid airportSid when arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.AirportSid):
            baseRecordList.Add((BaseRecord) airportSid);
            continue;
          case AirportStar airportStar when arinc424RecordObjectTypes.Contains(Arinc424RecordObjectTypes.AirportStar):
            baseRecordList.Add((BaseRecord) airportStar);
            continue;
          default:
            continue;
        }
      }
      return baseRecordList;
    }

    public Header1 Header01
    {
      get
      {
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is Header1 header01)
            return header01;
        }
        return (Header1) null;
      }
    }

    public List<Header2> Header02s
    {
      get
      {
        List<Header2> header02s = new List<Header2>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is Header2 header2)
            header02s.Add(header2);
        }
        return header02s;
      }
    }

    public List<GridMora> GridMoras
    {
      get
      {
        List<GridMora> gridMoras = new List<GridMora>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is GridMora gridMora)
            gridMoras.Add(gridMora);
        }
        return gridMoras;
      }
    }

    public List<VhfNavaid> VhfNavaids
    {
      get
      {
        List<VhfNavaid> vhfNavaids = new List<VhfNavaid>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is VhfNavaid vhfNavaid)
            vhfNavaids.Add(vhfNavaid);
        }
        return vhfNavaids;
      }
    }

    public List<NdbNavaid> NdbNavaids
    {
      get
      {
        List<NdbNavaid> ndbNavaids = new List<NdbNavaid>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is NdbNavaid ndbNavaid)
            ndbNavaids.Add(ndbNavaid);
        }
        return ndbNavaids;
      }
    }

    public List<NdbNavaidEnroute> NdbNavaidEnroutes
    {
      get
      {
        List<NdbNavaidEnroute> ndbNavaidEnroutes = new List<NdbNavaidEnroute>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is NdbNavaidEnroute ndbNavaidEnroute)
            ndbNavaidEnroutes.Add(ndbNavaidEnroute);
        }
        return ndbNavaidEnroutes;
      }
    }

    public List<NdbNavaidTerminal> NdbNavaidTerminals
    {
      get
      {
        List<NdbNavaidTerminal> ndbNavaidTerminals = new List<NdbNavaidTerminal>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is NdbNavaidTerminal ndbNavaidTerminal)
            ndbNavaidTerminals.Add(ndbNavaidTerminal);
        }
        return ndbNavaidTerminals;
      }
    }

    public List<WaypointEnroute> WaypointEnroutes
    {
      get
      {
        List<BaseRecord> baseRecordList = this.Filter(WaypointEnroute.Filter);
        List<WaypointEnroute> waypointEnroutes = new List<WaypointEnroute>();
        foreach (BaseRecord baseRecord in baseRecordList)
        {
          if (baseRecord is WaypointEnroute waypointEnroute)
            waypointEnroutes.Add(waypointEnroute);
        }
        return waypointEnroutes;
      }
    }

    public List<WaypointTerminal> WaypointTerminals
    {
      get
      {
        List<BaseRecord> baseRecordList = this.Filter(WaypointTerminal.Filter);
        List<WaypointTerminal> waypointTerminals = new List<WaypointTerminal>();
        foreach (BaseRecord baseRecord in baseRecordList)
        {
          if (baseRecord is WaypointTerminal waypointTerminal)
            waypointTerminals.Add(waypointTerminal);
        }
        return waypointTerminals;
      }
    }

    public List<WaypointHeliportTerminal> WaypointHeliportTerminals
    {
      get
      {
        List<BaseRecord> baseRecordList = this.Filter(WaypointHeliportTerminal.Filter);
        List<WaypointHeliportTerminal> heliportTerminals = new List<WaypointHeliportTerminal>();
        foreach (BaseRecord baseRecord in baseRecordList)
        {
          if (baseRecord is WaypointHeliportTerminal heliportTerminal)
            heliportTerminals.Add(heliportTerminal);
        }
        return heliportTerminals;
      }
    }

    public Arinc424Collection<Airport> Airports
    {
      get
      {
        List<BaseRecord> baseRecordList = this.Filter(Airport.Filter);
        Arinc424Collection<Airport> airports = new Arinc424Collection<Airport>();
        foreach (BaseRecord baseRecord in baseRecordList)
        {
          if (baseRecord is Airport airport)
            airports.Add(airport);
        }
        return airports;
      }
    }

    public List<AirportStar> AirportStars
    {
      get
      {
        List<BaseRecord> baseRecordList = this.Filter(AirportStar.Filter);
        List<AirportStar> airportStars = new List<AirportStar>();
        foreach (BaseRecord baseRecord in baseRecordList)
        {
          if (baseRecord is AirportStar airportStar)
            airportStars.Add(airportStar);
        }
        return airportStars;
      }
    }

    public List<AirportApproach> AirportApproachs
    {
      get
      {
        List<BaseRecord> baseRecordList = this.Filter(AirportApproach.Filter);
        List<AirportApproach> airportApproachs = new List<AirportApproach>();
        foreach (BaseRecord baseRecord in baseRecordList)
        {
          if (baseRecord is AirportApproach airportApproach)
            airportApproachs.Add(airportApproach);
        }
        return airportApproachs;
      }
    }

    public List<Heliport> Heliports
    {
      get
      {
        List<Heliport> heliports = new List<Heliport>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is Heliport heliport)
            heliports.Add(heliport);
        }
        return heliports;
      }
    }

    public List<AirportRunway> AirportRunways
    {
      get
      {
        List<AirportRunway> airportRunways = new List<AirportRunway>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is AirportRunway airportRunway)
            airportRunways.Add(airportRunway);
        }
        return airportRunways;
      }
    }

    public List<AirportMsa> AirportMsas
    {
      get
      {
        List<AirportMsa> airportMsas = new List<AirportMsa>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is AirportMsa airportMsa)
            airportMsas.Add(airportMsa);
        }
        return airportMsas;
      }
    }

    public List<RestrictiveAirspace> RestrictiveAirspaces
    {
      get
      {
        List<RestrictiveAirspace> restrictiveAirspaces = new List<RestrictiveAirspace>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is RestrictiveAirspace restrictiveAirspace)
            restrictiveAirspaces.Add(restrictiveAirspace);
        }
        return restrictiveAirspaces;
      }
    }

    public List<ControlledAirspace> ControlledAirspaces
    {
      get
      {
        List<ControlledAirspace> controlledAirspaces = new List<ControlledAirspace>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is ControlledAirspace controlledAirspace)
            controlledAirspaces.Add(controlledAirspace);
        }
        return controlledAirspaces;
      }
    }

    public List<PathPoint> PathPoints
    {
      get
      {
        List<PathPoint> pathPoints = new List<PathPoint>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is PathPoint pathPoint)
            pathPoints.Add(pathPoint);
        }
        return pathPoints;
      }
    }

    public List<AirportHeliport_LocalizerGlideSlope> AirportHeliportLocalizerGlideSlopes
    {
      get
      {
        List<AirportHeliport_LocalizerGlideSlope> localizerGlideSlopes = new List<AirportHeliport_LocalizerGlideSlope>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is AirportHeliport_LocalizerGlideSlope localizerGlideSlope)
            localizerGlideSlopes.Add(localizerGlideSlope);
        }
        return localizerGlideSlopes;
      }
    }

    public List<HeliportApproach> HeliportApproachs
    {
      get
      {
        List<HeliportApproach> heliportApproachs = new List<HeliportApproach>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is HeliportApproach heliportApproach)
            heliportApproachs.Add(heliportApproach);
        }
        return heliportApproachs;
      }
    }

    public List<HeliportSid> HeliportSids
    {
      get
      {
        List<HeliportSid> heliportSids = new List<HeliportSid>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is HeliportSid heliportSid)
            heliportSids.Add(heliportSid);
        }
        return heliportSids;
      }
    }

    public List<HeliportStar> HeliportStars
    {
      get
      {
        List<HeliportStar> heliportStars = new List<HeliportStar>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is HeliportStar heliportStar)
            heliportStars.Add(heliportStar);
        }
        return heliportStars;
      }
    }

    public List<HeliportMsa> HeliportMsas
    {
      get
      {
        List<HeliportMsa> heliportMsas = new List<HeliportMsa>();
        foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
        {
          if (record is HeliportMsa heliportMsa)
            heliportMsas.Add(heliportMsa);
        }
        return heliportMsas;
      }
    }

    public void AddRecord(BaseRecord baseRecord) => this._RecordCollection.Add((IBaseRecord) baseRecord);

    public void InsertRecord(int rowNumber, BaseRecord baseRecord) => this._RecordCollection.Insert(rowNumber, (IBaseRecord) baseRecord);

    public Airway AirwayByRouteIdentifier(string routeIdentifier) => new Airway(routeIdentifier, this);

    public (bool, GeoCoordinateBasic) FindFix(string indentifier)
    {
      indentifier = indentifier != null ? indentifier.Trim() : throw new ArgumentNullException(nameof (indentifier));
      foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
      {
        switch (record)
        {
          case Waypoint waypoint:
            if (string.Equals(waypoint.WaypointIdentifier, indentifier, StringComparison.OrdinalIgnoreCase))
              return (true, new GeoCoordinate(waypoint.WaypointLatitude, waypoint.WaypointLongitude).GeoCoordinateBasic);
            continue;
          case VhfNavaid vhfNavaid:
            if (string.Equals(vhfNavaid.VORIdentifier.Trim(), indentifier, StringComparison.OrdinalIgnoreCase))
            {
              switch (vhfNavaid.NavaidType)
              {
                case VhfNavaid.NavaidTypes.Vor:
                  return (true, new GeoCoordinate(vhfNavaid.VORLatitude, vhfNavaid.VORLongitude).GeoCoordinateBasic);
                case VhfNavaid.NavaidTypes.Dme:
                  return (true, new GeoCoordinate(vhfNavaid.DMELatitude, vhfNavaid.DMELongitude).GeoCoordinateBasic);
                default:
                  continue;
              }
            }
            else
              continue;
          case NdbNavaid ndbNavaid:
            if (string.Equals(ndbNavaid.NDBIdentifier.Trim(), indentifier, StringComparison.OrdinalIgnoreCase))
              return (true, new GeoCoordinate(ndbNavaid.NDBLatitude, ndbNavaid.NDBLongitude).GeoCoordinateBasic);
            continue;
          case Airport airport:
            if (string.Equals(airport.AirportICAOIdentifier.Trim(), indentifier, StringComparison.OrdinalIgnoreCase))
              return (true, new GeoCoordinate(airport.ArpLatitude, airport.ArpLongitude).GeoCoordinateBasic);
            continue;
          default:
            continue;
        }
      }
      return (false, new GeoCoordinate(0.0, 0.0).GeoCoordinateBasic);
    }

    public List<AirportSid> AirportSids
    {
      get
      {
        List<BaseRecord> baseRecordList = this.Filter(AirportSid.Filter);
        List<AirportSid> airportSids = new List<AirportSid>();
        foreach (BaseRecord baseRecord in baseRecordList)
        {
          if (baseRecord is AirportSid airportSid)
            airportSids.Add(airportSid);
        }
        return airportSids;
      }
    }

    public List<AirportSid> AirportSidByProcedureIdentifier(string procedureIdentifier)
    {
      List<AirportSid> airportSidList = new List<AirportSid>();
      foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
      {
        if (record is AirportSid airportSid && string.Equals(airportSid.ProcedureIdentifier.Trim(), procedureIdentifier.Trim(), StringComparison.OrdinalIgnoreCase))
          airportSidList.Add((AirportSid) record);
      }
      return airportSidList;
    }

    public List<string> AirportSidProcedureIdentifiers()
    {
      List<string> stringList = new List<string>();
      foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
      {
        if (record is AirportSid airportSid && !stringList.Contains(airportSid.ProcedureIdentifier))
          stringList.Add(airportSid.ProcedureIdentifier);
      }
      return stringList;
    }

    public List<EnrouteAirway> EnrouteAirways
    {
      get
      {
        List<BaseRecord> baseRecordList = this.Filter(EnrouteAirway.Filter);
        List<EnrouteAirway> enrouteAirways = new List<EnrouteAirway>();
        foreach (BaseRecord baseRecord in baseRecordList)
        {
          if (baseRecord is EnrouteAirway)
            enrouteAirways.Add((EnrouteAirway) baseRecord);
        }
        return enrouteAirways;
      }
    }

    public List<EnrouteAirway> EnrouteAirwaysByRouteIdentifier(
      string routeIdentifier)
    {
      List<EnrouteAirway> enrouteAirwayList = new List<EnrouteAirway>();
      foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
      {
        if (record is EnrouteAirway enrouteAirway && string.Equals(enrouteAirway.RouteIdentifier.Trim(), routeIdentifier.Trim(), StringComparison.OrdinalIgnoreCase))
          enrouteAirwayList.Add((EnrouteAirway) record);
      }
      return enrouteAirwayList;
    }

    public List<string> EnrouteAirwaysRouteIdentifiers()
    {
      List<string> stringList = new List<string>();
      foreach (BaseRecord record in (Collection<IBaseRecord>) this._RecordCollection)
      {
        if (record is EnrouteAirway enrouteAirway && !stringList.Contains(enrouteAirway.RouteIdentifier))
          stringList.Add(enrouteAirway.RouteIdentifier);
      }
      return stringList;
    }
  }
}
