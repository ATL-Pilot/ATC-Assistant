namespace ATC_Helper.Classes
{
    public enum WaypointTypes
    {
        Airport,
        AirportApproach,
        AirportRunway,
        AirportSid,
        AirportStar,
        EnrouteAirway,
        NDBNavAidEnroute,
        NDBNavAidTerminal,
        NDBNavAid,
        VhfNavAid,
        Waypoint,
        WaypointEnroute,
        WaypointHeliportTerminal,
        WaypointTerminal,
        HeliportApproach,
        HeliportMSA,
        HeliportSid,
        HeliportStar,
        Heliport,
        Transition
    }

    public class Waypoint
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private WaypointTypes _type;
        public WaypointTypes Type { get { return _type; } set { _type = value; } }

        private WaypointTypes _TransitionType;
        public WaypointTypes TransitionType { get { return _TransitionType; } set { _TransitionType = value; } }

        private ArincReader.Arinc424.Records.BaseRecord _record;
        public ArincReader.Arinc424.Records.BaseRecord Record { get { return _record; } set { _record = value; } }
    }
}
