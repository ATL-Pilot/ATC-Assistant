using System.Collections.Generic;

namespace VatSim.Data
{
    public class Country
    {
        public string Name;
        public List<string> AirportPrefixes = new List<string>();
        public string CenterName;

        public Country(string name, string centerName)
        {
            this.Name = name;
            this.CenterName = centerName;
        }
    }
}
