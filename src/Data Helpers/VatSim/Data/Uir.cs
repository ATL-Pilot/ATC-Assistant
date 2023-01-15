using System.Collections.Generic;

namespace VatSim.Data
{
    public class Uir
    {
        public string Id;
        public string Name;
        public List<string> MemberFirs = new List<string>();

        public Uir(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
