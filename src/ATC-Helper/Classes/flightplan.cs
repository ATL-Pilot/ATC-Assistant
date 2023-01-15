using System;
using System.Collections.Generic;
using System.Linq;
using VatSim.Data;

namespace ATC_Helper.Classes
{
    public class flightplan
    {

        #region Properties

        private DataManager _dataManager = null;

        public flightplan(DataManager dm)
        {
            _dataManager = dm;
        }

        private string _Callsign;
        public string Callsign { get { return _Callsign; } set { _Callsign = value; } }

        private string _AcType;
        public string AcType { get { return _AcType; } set { _AcType = value; } }

        private string _FlightRules;
        public string FlightRules { get { return _FlightRules; } set { _FlightRules = value; } }

        private string _Departure;
        public string Departure
        {
            get { return _Departure; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;


                _Departure = value;

                ArincReader.Arinc424.Records.Airport dep;
                GetAirport(value, out dep);

                if (dep != null)
                    _DepartureRecord = dep;


                VatSim.Data.Airport va = _dataManager.Airports[value];

                if (va != null)
                {
                    _VatSim_DepartureAirport = va;
                }

                WebService.Airport DepCustom;
                GetCustomAirport(value, out DepCustom);

                if (DepCustom != null)
                    _DepartureCustomRecord = DepCustom;


            }
        }

        private bool GetCustomAirport(string value, out WebService.Airport depCustom)
        {

            var ap = Program.AtcHelper_AirportDetails.First(a => a.ICAO_ID == value);

            if (ap != null)
            {
                depCustom = ap;
                return true;
            }
            else
            {
                depCustom = null;
                return false;
            }
        }

        private ArincReader.Arinc424.Records.Airport _DepartureRecord;
        public ArincReader.Arinc424.Records.Airport DepartureRecord { get { return _DepartureRecord; } set { _DepartureRecord = value; } }

        private VatSim.Data.Airport _VatSim_DepartureAirport;
        public VatSim.Data.Airport VatSim_DepartureAirport { get { return _VatSim_DepartureAirport; } set { _VatSim_DepartureAirport = value; } }

        private string _Destination;
        public string Destination
        {
            get { return _Destination; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    return;

                _Destination = value;

                ArincReader.Arinc424.Records.Airport dep;
                GetAirport(value, out dep);

                if (dep != null)
                    _DestinationRecord = dep;

                VatSim.Data.Airport va = _dataManager.Airports[value];

                if (va != null)
                    _VatSim_DestinationAirport = va;

                WebService.Airport AriveCustom;
                GetCustomAirport(value, out AriveCustom);

                if (AriveCustom != null)
                    _DepartureCustomRecord = AriveCustom;
            }
        }

        private ArincReader.Arinc424.Records.Airport _DestinationRecord;
        public ArincReader.Arinc424.Records.Airport DestinationRecord { get { return _DestinationRecord; } set { _DestinationRecord = value; } }

        private VatSim.Data.Airport _VatSim_DestinationAirport;
        public VatSim.Data.Airport VatSim_DestinationAirport { get { return _VatSim_DestinationAirport; } set { _VatSim_DestinationAirport = value; } }

        private string _Alternate;
        public string Alternate { get { return _Alternate; } set { _Alternate = value; } }

        private int _CruiseAlt;
        public int CruiseAlt
        {
            get { return _CruiseAlt; }
            set
            {
                _CruiseAlt = value;

                if (_FlightRules.ToLower() == "vfr")
                {
                    if (_EngineType == "Jet")
                    {
                        _IntAlt = 7500;
                    }
                    else
                    {
                        _IntAlt = 3500;
                    }
                }
                else
                {
                    if (_EngineType == "Jet")
                    {
                        if (value > 8000)
                        {
                            _IntAlt = 8000;
                        }
                        else
                        {
                            _IntAlt = value;
                        }
                    }
                    else
                    {
                        if (value > 4000)
                        {
                            _IntAlt = 4000;
                        }
                        else
                        {
                            _IntAlt = value;
                        }
                    }
                }
            }
        }

        private string _Squawk;
        public string Squawk { get { return _Squawk; } set { _Squawk = value; } }

        private EquiptmentSuffix _EquiptmentSuffix;
        public EquiptmentSuffix EquiptmentSuffix { get { return _EquiptmentSuffix; } set { _EquiptmentSuffix = value; } }

        private string _EngineType;
        public string EngineType { get { return _EngineType; } set { _EngineType = value; } }

        private bool _IsHeavy;
        public bool IsHeavy { get { return _IsHeavy; } set { _IsHeavy = value; } }

        private string _RouteString;
        public string RouteString
        {
            get
            {
                return _RouteString;
            }
            set
            {
                _RouteString = value;
                if (ParseRouteString(value))
                {


                }
                else
                {

                }

            }
        }

        private Route _route;
        public Route Route
        {
            get
            {
                if (_route == null)
                    _route = new Route();

                return _route;
            }
            set
            {
                if (_route == null)
                    _route = new Route();

                _route = value;
            }
        }

        private string _ACTypeDesignator;
        public string ACTypeDesignator { get { return _ACTypeDesignator; } set { _ACTypeDesignator = value; } }

        private int _IntAlt;
        public int IntAlt
        {
            get { return _IntAlt; }
        }

        private string _DirectionOfFlight;
        public string DirectionOfFlight { get { return _DirectionOfFlight; } set { _DirectionOfFlight = value; } }

        private Classes.SID _sid;
        public Classes.SID SID { get { return _sid; } set { _sid = value; } }

        private string _Transition;
        public string Transition
        {
            get { return _Transition; }
            set
            {
                _Transition = value;



            }
        }

        private bool _IsTransitionCommon;
        public bool IsTransitionCommon { get { return _IsTransitionCommon; } set { _IsTransitionCommon = value; } }

        private WebService.Aircraft _Aircraft;
        public WebService.Aircraft Aircraft { get { return _Aircraft; } set { _Aircraft = value; } }

        private WebService.Airport _DestinationCustomRecord;
        public WebService.Airport DesinationCustomRecord { get { return _DestinationCustomRecord; } set { _DestinationCustomRecord = value; } }

        private WebService.Airport _DepartureCustomRecord;
        public WebService.Airport DepartureCustomRecord { get { return _DepartureCustomRecord; } set { _DepartureCustomRecord = value; } }

        private string _DepartureRW;
        public string DepartureRW { get { return _DepartureRW; } set { _DepartureRW = value; } }

        private string _PreferedRunway;
        public string PreferedRunway { get { return _PreferedRunway; } set { _PreferedRunway = value; } }

        #endregion Properties





        private bool ParseRouteString(string routeString)
        {
            int counter = 0;
            string[] TempWayPoints = routeString.Split(' ');

            foreach (string TempWayPoint in TempWayPoints)
            {
                counter += 1;
                bool skip = false;

                //Determine Waypoint Type
                Waypoint wp = new Waypoint();
                ArincReader.Arinc424.Records.BaseRecord record;
                ArincReader.Arinc424.Records.Airport Airport;
                ArincReader.Arinc424.Records.AirportSid SID;
                ArincReader.Arinc424.Records.AirportApproach AirportApproach;
                ArincReader.Arinc424.Records.AirportRunway AirportRunway;
                ArincReader.Arinc424.Records.AirportStar AirportStar;
                ArincReader.Arinc424.Records.NdbNavaid NdbNavAid;
                ArincReader.Arinc424.Records.NdbNavaidEnroute NdbNavAidEnroute;
                ArincReader.Arinc424.Records.EnrouteAirway EnrouteAirway;
                ArincReader.Arinc424.Records.Heliport Heliport;
                ArincReader.Arinc424.Records.HeliportApproach HeliportApproach;
                ArincReader.Arinc424.Records.HeliportMsa HeleportMsa;
                ArincReader.Arinc424.Records.HeliportSid heliportSid;
                ArincReader.Arinc424.Records.HeliportStar HeliportStar;
                ArincReader.Arinc424.Records.NdbNavaidTerminal NdbNavaidTerminal;
                ArincReader.Arinc424.Records.VhfNavaid vhfNavaid;
                ArincReader.Arinc424.Records.WaypointEnroute waypointEnroute;
                ArincReader.Arinc424.Records.WaypointHeliportTerminal waypointHeliportTerminal;
                ArincReader.Arinc424.Records.WaypointTerminal waypointTerminal;

                if (!skip && GetAirport(TempWayPoint, out Airport))
                {
                    wp.Record = Airport;
                    //wp.AirportObject = Airport;
                    wp.Type = WaypointTypes.Airport;
                    wp.TransitionType = WaypointTypes.Airport;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetNDBNavAid(TempWayPoint, out NdbNavAid))
                {
                    wp.Record = NdbNavAid;
                    //wp.NdbNavaid = NdbNavAid;
                    wp.Type = WaypointTypes.NDBNavAid;
                    wp.TransitionType = WaypointTypes.NDBNavAid;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetNDBNavAidEnroute(TempWayPoint, out NdbNavAidEnroute))
                {
                    wp.Record = NdbNavAidEnroute;
                    //wp.NdbNavAidEnroute = NdbNavAidEnroute;
                    wp.Type = WaypointTypes.NDBNavAidEnroute;
                    wp.TransitionType = WaypointTypes.NDBNavAidEnroute;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetEnrouteAirway(TempWayPoint, out EnrouteAirway))
                {
                    wp.Record = EnrouteAirway;
                    wp.Type = WaypointTypes.EnrouteAirway;
                    wp.TransitionType = WaypointTypes.EnrouteAirway;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetNdbTerminal(TempWayPoint, out NdbNavaidTerminal))
                {
                    wp.Record = NdbNavaidTerminal;
                    wp.Type = WaypointTypes.NDBNavAidTerminal;
                    wp.TransitionType = WaypointTypes.NDBNavAidTerminal;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetVhfNadAid(TempWayPoint, out vhfNavaid))
                {
                    wp.Record = vhfNavaid;
                    wp.Type = WaypointTypes.VhfNavAid;
                    wp.TransitionType = WaypointTypes.VhfNavAid;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetWaypointEnroute(TempWayPoint, out waypointEnroute))
                {
                    wp.Record = waypointEnroute;
                    wp.Type = WaypointTypes.WaypointEnroute;
                    wp.TransitionType = WaypointTypes.WaypointEnroute;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetAirportSid(TempWayPoint, out SID))
                {
                    wp.Record = SID;
                    //wp.AirportSid = SID;
                    wp.Type = WaypointTypes.AirportSid;
                    wp.TransitionType = WaypointTypes.AirportSid;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetAirportStar(TempWayPoint, out AirportStar))
                {
                    wp.Record = AirportStar;
                    //wp.AirportStar = AirportStar;
                    wp.Type = WaypointTypes.AirportStar;
                    wp.TransitionType = WaypointTypes.AirportStar;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetHeliport(TempWayPoint, out Heliport))
                {
                    wp.Record = Heliport;
                    wp.Type = WaypointTypes.Heliport;
                    wp.TransitionType = WaypointTypes.Heliport;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetHeliportApproach(TempWayPoint, out HeliportApproach))
                {
                    wp.Record = HeliportApproach;
                    wp.Type = WaypointTypes.HeliportApproach;
                    wp.TransitionType = WaypointTypes.HeliportApproach;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetHeliportSID(TempWayPoint, out heliportSid))
                {
                    wp.Record = heliportSid;
                    wp.Type = WaypointTypes.HeliportMSA;
                    wp.TransitionType = WaypointTypes.HeliportMSA;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetHeliportStar(TempWayPoint, out HeliportStar))
                {
                    wp.Record = HeliportStar;
                    wp.Type = WaypointTypes.HeliportStar;
                    wp.TransitionType = WaypointTypes.HeliportStar;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetWaypointHeliportTerminal(TempWayPoint, out waypointHeliportTerminal))
                {
                    wp.Record = waypointHeliportTerminal;
                    wp.Type = WaypointTypes.WaypointHeliportTerminal;
                    wp.TransitionType = WaypointTypes.WaypointHeliportTerminal;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetWaypointTerminal(TempWayPoint, out waypointTerminal))
                {
                    wp.Record = waypointTerminal;
                    wp.Type = WaypointTypes.WaypointTerminal;
                    wp.TransitionType = WaypointTypes.WaypointTerminal;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetAirportApproach(TempWayPoint, out AirportApproach))
                {
                    wp.Record = AirportApproach;
                    // wp.AirportApproach = AirportApproach;
                    wp.Type = WaypointTypes.AirportApproach;
                    wp.TransitionType = WaypointTypes.AirportApproach;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                if (!skip && GetAirportRunway(TempWayPoint, out AirportRunway))
                {
                    wp.Record = AirportRunway;
                    //wp.AirportRunway = AirportRunway;
                    wp.Type = WaypointTypes.AirportRunway;
                    wp.TransitionType = WaypointTypes.AirportRunway;
                    wp.Name = TempWayPoint;
                    skip = true;
                }

                //Check if this is a transition and if so update it accordingly
                if (counter == 2 && _sid != null)
                {
                    //TODO:  Exception _sid.strSidTransions is null
                    if (_sid.strSidTransitions.Contains(TempWayPoint))
                    {
                        wp.Type = WaypointTypes.Transition;
                    }
                }

                if (wp != null)
                {
                    Route.Waypoints.Add(wp);
                }
            }

            return true;
        }

        private bool GetAirport(string ICAO_ID, out ArincReader.Arinc424.Records.Airport Object)
        {
            foreach (var item in Program.NavData.Arinc424Data.Airports)
            {
                if (item.AirportICAOIdentifier.Trim() == ICAO_ID.Trim())
                {
                    Object = item;
                    return true;
                }
            }

            Object = null;
            return false;
        }

        private bool GetAirportSid(string ICAO_ID, out ArincReader.Arinc424.Records.AirportSid Object)
        {
            List<ArincReader.Arinc424.Records.AirportSid> sidTransitions = Program.NavData.Arinc424Data.AirportSids.FindAll(y => y.ProcedureIdentifier.Trim() == ICAO_ID.Trim());

            foreach (var item in sidTransitions)
            {
                if (item.ProcedureIdentifier.Trim() == ICAO_ID.Trim())
                {
                    Object = item;
                    return true;
                }
            }

            Object = null;
            return false;
        }

        private bool GetAirportApproach(string ICAO_ID, out ArincReader.Arinc424.Records.AirportApproach Object)
        {
            List<ArincReader.Arinc424.Records.AirportApproach> sidTransitions = Program.NavData.Arinc424Data.AirportApproachs.FindAll(y => y.ProcedureIdentifier.Trim() == ICAO_ID.Trim());

            foreach (var item in sidTransitions)
            {
                if (item.ProcedureIdentifier.Trim() == ICAO_ID.Trim())
                {
                    Object = item;
                    return true;
                }
            }

            Object = null;
            return false;
        }

        private bool GetAirportRunway(string ICAO_ID, out ArincReader.Arinc424.Records.AirportRunway Object)
        {
            //RunwayIdentifier
            List<ArincReader.Arinc424.Records.AirportRunway> sidTransitions = Program.NavData.Arinc424Data.AirportRunways.FindAll(y => y.RunwayIdentifier.Trim() == ICAO_ID.Trim());

            foreach (var item in sidTransitions)
            {
                if (item.RunwayIdentifier.Trim() == ICAO_ID.Trim())
                {
                    Object = item;
                    return true;
                }
            }

            Object = null;
            return false;
        }

        private bool GetAirportStar(string ICAO_ID, out ArincReader.Arinc424.Records.AirportStar Object)
        {
            //ProcedureIdentifier
            List<ArincReader.Arinc424.Records.AirportStar> sidTransitions = Program.NavData.Arinc424Data.AirportStars.FindAll(y => y.ProcedureIdentifier.Trim() == ICAO_ID.Trim());

            foreach (var item in sidTransitions)
            {
                if (item.ProcedureIdentifier.Trim() == ICAO_ID.Trim())
                {
                    Object = item;
                    return true;
                }
            }

            Object = null;
            return false;
        }

        private bool GetNDBNavAid(string ICAO_ID, out ArincReader.Arinc424.Records.NdbNavaid Object)
        {
            //NDBIdentifier or NDBName
            foreach (var item in Program.NavData.Arinc424Data.NdbNavaids.FindAll(x => x.NDBIdentifier.Trim() == ICAO_ID.Trim() || x.NDBName.Trim() == ICAO_ID.Trim()))
            {
                if (item.NDBIdentifier.Trim() == ICAO_ID.Trim())
                {
                    Object = item;
                    return true;
                }
            }

            Object = null;
            return false;
        }

        private bool GetNDBNavAidEnroute(string ICAO_ID, out ArincReader.Arinc424.Records.NdbNavaidEnroute Object)
        {
            //NDBIdentifier or NDBName
            foreach (var item in Program.NavData.Arinc424Data.NdbNavaidEnroutes.FindAll(x => x.NDBName.Trim() == ICAO_ID.Trim() || x.NDBIdentifier.Trim() == ICAO_ID.Trim()))
            {
                if (item.NDBIdentifier.Trim() == ICAO_ID.Trim())
                {
                    Object = item;
                    return true;
                }
            }

            Object = null;
            return false;
        }

        private bool GetEnrouteAirway(string ICAO_ID, out ArincReader.Arinc424.Records.EnrouteAirway Object)
        {
            //RouteIdentifier
            List<ArincReader.Arinc424.Records.EnrouteAirway> temp = Program.NavData.Arinc424Data.EnrouteAirways.FindAll(X => X.RouteIdentifier.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }

        private bool GetHeliport(string ICAO_ID, out ArincReader.Arinc424.Records.Heliport Object)
        {

            //HeliportName??
            List<ArincReader.Arinc424.Records.Heliport> temp = Program.NavData.Arinc424Data.Heliports.FindAll(X => X.HeliportName.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }

        private bool GetHeliportApproach(string ICAO_ID, out ArincReader.Arinc424.Records.HeliportApproach Object)
        {
            //ProcedureIdentifier
            List<ArincReader.Arinc424.Records.HeliportApproach> temp = Program.NavData.Arinc424Data.HeliportApproachs.FindAll(X => X.ProcedureIdentifier.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }

        private bool GetHeliportSID(string ICAO_ID, out ArincReader.Arinc424.Records.HeliportSid Object)
        {
            //ProcedureIdentifier
            List<ArincReader.Arinc424.Records.HeliportSid> temp = Program.NavData.Arinc424Data.HeliportSids.FindAll(X => X.ProcedureIdentifier.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }

        private bool GetHeliportStar(string ICAO_ID, out ArincReader.Arinc424.Records.HeliportStar Object)
        {
            //ProcedureIdentifier
            List<ArincReader.Arinc424.Records.HeliportStar> temp = Program.NavData.Arinc424Data.HeliportStars.FindAll(X => X.ProcedureIdentifier.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }

        private bool GetNdbTerminal(string ICAO_ID, out ArincReader.Arinc424.Records.NdbNavaidTerminal Object)
        {
            //NDBName
            List<ArincReader.Arinc424.Records.NdbNavaidTerminal> temp = Program.NavData.Arinc424Data.NdbNavaidTerminals.FindAll(X => X.NDBIdentifier == ICAO_ID.Trim() || X.NDBName.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }

        private bool GetVhfNadAid(string ICAO_ID, out ArincReader.Arinc424.Records.VhfNavaid Object)
        {
            //VORIdentifier
            List<ArincReader.Arinc424.Records.VhfNavaid> temp = Program.NavData.Arinc424Data.VhfNavaids.FindAll(X => X.VORIdentifier.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }

        private bool GetWaypointEnroute(string ICAO_ID, out ArincReader.Arinc424.Records.WaypointEnroute Object)
        {
            //WaypointIdentifier
            List<ArincReader.Arinc424.Records.WaypointEnroute> temp = Program.NavData.Arinc424Data.WaypointEnroutes.FindAll(X => X.WaypointIdentifier.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }

        private bool GetWaypointHeliportTerminal(string ICAO_ID, out ArincReader.Arinc424.Records.WaypointHeliportTerminal Object)
        {
            //WaypointIdentifier
            List<ArincReader.Arinc424.Records.WaypointHeliportTerminal> temp = Program.NavData.Arinc424Data.WaypointHeliportTerminals.FindAll(X => X.WaypointIdentifier.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }

        private bool GetWaypointTerminal(string ICAO_ID, out ArincReader.Arinc424.Records.WaypointTerminal Object)
        {
            //WaypointIdentifier
            List<ArincReader.Arinc424.Records.WaypointTerminal> temp = Program.NavData.Arinc424Data.WaypointTerminals.FindAll(X => X.WaypointIdentifier.Trim() == ICAO_ID.Trim());
            if (temp.Count > 0)
            {
                Object = temp[0];
                return true;
            }

            Object = null;
            return false;
        }



    }
}
