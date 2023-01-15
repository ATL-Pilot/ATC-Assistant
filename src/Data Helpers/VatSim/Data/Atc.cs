using System;
using System.Collections.Generic;

namespace VatSim.Data
{
    public class Atc
    {
        public string Callsign;
        public string Cid;
        public string RealName;
        public string Frequency;
        public string NetworkServer;
        public Rating Rating;
        public Facility Facility;
        public int VisualRange;
        public string Atis;
        public TimeSpan TimeOnline;
        public string CountryName;
        public List<string> UirCountryNames;
        public string AirportCode;
        public string AirportName;
        public string FirIcao;
        public List<string> UirFirIcaos;
        public string FirName;
        public string PositionName;
        public string Prefix;
        public bool IsOceanic;
        public bool IsUir;
        public string UirCode;
        public string UirName;
    }
}
