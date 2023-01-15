using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCHelper_CommonClasses
{
    internal class ATC_Airport
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; } 
            set { _Name = value; }
        }

        private string _IATA_ID;
        public string IATA_ID
        {
            get { return _IATA_ID; }
            set { _IATA_ID = value; }
        }

        private string _ICAO_ID;
        public string ICAO_ID
        {
            get { return _ICAO_ID; }
            set { _ICAO_ID = value; }
        }

        private string _Location;

        public string Location
        {
            get { return _Location; } 
            set { _Location = value; }
        }

        private string _Country;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        private bool _SidRequired;

        public bool SsidRequired
        {
            get { return _SidRequired; } 
            set { _SidRequired = value; }
        }

        private bool _HasDeparturePlan;

        public bool HasDeparturePlan
        {
            get { return _HasDeparturePlan; }
            set { _HasDeparturePlan = value; }
        }

        private bool _IsConfigured;

        public bool IsConfigured
        {
            get { return _IsConfigured; }
            set { _IsConfigured = value; }
        }
    }
}
