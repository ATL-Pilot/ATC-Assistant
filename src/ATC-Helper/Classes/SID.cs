using System;
using System.Collections.Generic;
using System.Linq;

namespace ATC_Helper.Classes
{
    public class SID
    {
        private string _AirportIdentifier;
        public string AirportIdentifier { get { return _AirportIdentifier; } set { _AirportIdentifier = value; } }

        private string _SidIdentifier;
        public string SidIdentifier { get { return _SidIdentifier; } set { _SidIdentifier = value; } }

        private List<ArincReader.Arinc424.Records.AirportSid> _SidDetails;
        public List<ArincReader.Arinc424.Records.AirportSid> SidDetails { get { return _SidDetails; } set { _SidDetails = value; } }

        private SidType _SidType;
        public SidType SidType { get { return _SidType; } set { _SidType = value; } }

        private List<String> _strSidTransitions;
        public List<String> strSidTransitions { get { return _strSidTransitions; } set { _strSidTransitions = value; } }

        private bool _IsSidValid;
        public bool IsSidValid { get { return _IsSidValid; } set { _IsSidValid = value; } }

        private List<string> _ValidAirportSIDs;
        public List<string> ValidAirportSIDs { get { return _ValidAirportSIDs; } set { _ValidAirportSIDs = value; } }

        //private List<string> _SelectedSIDTransitions;
        //public List<string> SelectedSIDTransitions { get { return _SelectedSIDTransitions; } set { } }

        public SID()
        { }

        public SID(string sid, string airportIdentifier)
        {
            _SidIdentifier = sid; ;
            _AirportIdentifier = airportIdentifier;

            List<ArincReader.Arinc424.Records.AirportSid> MyAirportsids = Program.NavData.Arinc424Data.AirportSids.FindAll(x => x.AirportIdentifier == _AirportIdentifier);
            _ValidAirportSIDs = MyAirportsids.Select(O => O.ProcedureIdentifier).Distinct().ToList();
            List<ArincReader.Arinc424.Records.AirportSid> MySid = MyAirportsids.FindAll(y => y.ProcedureIdentifier.Trim() == _SidIdentifier);

            if (MySid.Count > 0)
            {
                _SidDetails = MySid;
                _IsSidValid = true;
            }
            _SidType = GetSidType(sid, airportIdentifier);

            _strSidTransitions = new List<string>();
            ArincReader.Arinc424.Records.AirportSid s;

            //DataExport.ExportData.ExportCsv(MyAirportsids, "MyAirportsids");
            //DataExport.ExportData.ExportCsv(_ValidAirportSIDs, "ValidAirportSIDs");
            //DataExport.ExportData.ExportCsv(MySid, "MySid");

            switch (_SidType)
            {
                case SidType.EngineOut:
                    strSidTransitions = MySid.FindAll(y => y.RouteType == "0").Select(o => o.TransitionIdentifier.Trim()).Distinct().ToList();
                    break;

                case SidType.Standard:
                    strSidTransitions = MySid.FindAll(y => y.RouteType == "3").Select(o => o.TransitionIdentifier.Trim()).Distinct().ToList();

                    s = MySid.FindLast(l => l.RouteType == "2");
                    if (s != null)
                    {
                        strSidTransitions.Add(s.FixIdentifier.Trim());
                    }
                    break;

                case SidType.RNAV:
                    strSidTransitions = MySid.FindAll(y => y.RouteType == "6").Select(o => o.TransitionIdentifier.Trim()).Distinct().ToList();
                    s = MySid.FindLast(l => l.RouteType == "5");
                    if (s != null)
                    {
                        strSidTransitions.Add(s.FixIdentifier.Trim());
                    }
                    break;

                case SidType.FMS:
                    strSidTransitions = MySid.FindAll(y => y.RouteType == "S").Select(o => o.TransitionIdentifier.Trim()).Distinct().ToList();
                    s = MySid.FindLast(l => l.RouteType == "M");
                    if (s != null)
                    {
                        strSidTransitions.Add(s.FixIdentifier.Trim());
                    }
                    break;

                case SidType.Vector:
                    strSidTransitions = MySid.FindAll(y => y.RouteType == "V").Select(o => o.TransitionIdentifier.Trim()).Distinct().ToList();
                    s = MySid.FindLast(l => l.RouteType == "v");
                    if (s != null)
                    {
                        strSidTransitions.Add(s.FixIdentifier.Trim());
                    }
                    break;

                case SidType.Unknown:
                    break;
            }

        }

        private SidType GetSidType(string sidName, string airportID)
        {
            SidType result = SidType.Unknown;

            if (_SidDetails is null) return result;

            foreach (ArincReader.Arinc424.Records.AirportSid item in _SidDetails)
            {
                switch (item.RouteType)
                {
                    case "0":
                        result = SidType.EngineOut;
                        break;
                    case "1":
                        result = SidType.Standard;
                        break;
                    case "2":
                        result = SidType.Standard;
                        break;
                    case "3":
                        result = SidType.Standard;
                        break;
                    case "4":
                        result = SidType.RNAV;
                        break;
                    case "5":
                        result = SidType.RNAV;
                        break;
                    case "6":
                        result = SidType.RNAV;
                        break;
                    case "F":
                        result = SidType.FMS;
                        break;
                    case "M":
                        result = SidType.FMS;
                        break;
                    case "S":
                        result = SidType.FMS;
                        break;
                    case "T":
                        result = SidType.Vector;
                        break;
                    case "V":
                        result = SidType.Vector;
                        break;
                    default:
                        result = SidType.Unknown;
                        break;
                }


            }
            return result;
        }


        public bool IsTransitionValid(string Transition)
        {
            if (_strSidTransitions.Contains(Transition.ToUpper()))
            {
                //Transition is good for this SID
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
