using System.Collections.Generic;
using System.Drawing;

namespace VatSim.Data
{
    public class UirPositionInfo
    {
        public string Uir;
        public List<Atc> Members = new List<Atc>();
        public List<string> FirIcaos = new List<string>();
        public List<WorldPoint> FirCenterLocs = new List<WorldPoint>();
        public Point[] FirLabelScreenLocs;
    }
}
