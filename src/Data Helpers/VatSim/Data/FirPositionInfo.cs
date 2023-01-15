using System.Collections.Generic;
using System.Drawing;

namespace VatSim.Data
{
    public class FirPositionInfo
    {
        public List<Atc> Members = new List<Atc>();
        public WorldPoint FirCenterLoc;
        public Point[] FirLabelScreenLoc = new Point[3];
    }
}
