using System.Drawing;

namespace VatSim.Data
{
    public class MapPopupInfo
    {
        public MapPopupType Type;
        public string AirportName;
        public string Icao;
        public Rectangle Bounds = new Rectangle(0, 0, 0, 0);
        public object InfoObject;
        public string UnstaffedFIRName;

        public MapPopupInfo(
          MapPopupType type,
          string icao,
          string airportName,
          int x,
          int y,
          int width,
          int height,
          object info)
        {
            this.Type = type;
            this.Icao = icao;
            this.AirportName = airportName;
            this.Bounds = new Rectangle(x, y, width, height);
            this.InfoObject = info;
        }
    }
}
