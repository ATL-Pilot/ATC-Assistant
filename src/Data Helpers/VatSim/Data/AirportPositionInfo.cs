using System.Collections.Generic;
using System.Drawing;

namespace VatSim.Data
{
    public class AirportPositionInfo
    {
        public List<Atc> Members = new List<Atc>();
        public string AppCircleLabel = "";
        public WorldPoint AirportLoc;
        public Point[] AirportScreenLoc = new Point[3];
        public Point[] AppCircleLabelScreenLoc = new Point[3];
        public AirportOps Operations = new AirportOps();
        public bool IsPseudoAirport;

        public AirportPositionInfo(WorldPoint loc, bool isPseudoAirport = false)
        {
            this.AirportLoc = loc;
            this.IsPseudoAirport = isPseudoAirport;
        }
    }
}
