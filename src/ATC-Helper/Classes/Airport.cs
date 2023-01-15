namespace ATC_Helper.Classes
{
    internal class Airport
    {
        private string _IATA;
        public string IATA { get { return _IATA; } set { _IATA = value; } }

        private string _ICAO;
        public string ICAO { get { return _ICAO; } set { _ICAO = value; } }

        private string _Location;
        public string Location { get { return _Location; } set { _Location = value; } }

        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }

        private string _Country;
        public string Country { get { return _Country; } set { _Country = value; } }

        private bool _SidRequired;
        public bool SidRequired { get { return _SidRequired; } set { _SidRequired = value; } }

        private bool _HasDeparturePlan;
        public bool HasDeparturePlan { get { return _HasDeparturePlan; } set { _HasDeparturePlan = value; } }

    }
}
