using System.Collections.Generic;

namespace VatSim.Data
{
    public class FirBoundary
    {
        public string Icao;
        public WorldRect Bounds;
        public WorldPoint Center;
        public List<WorldPoint> Points = new List<WorldPoint>();
        public int BoundaryDisplayList;
        public int PolygonDisplayList;

        public bool Contains(WorldPoint point)
        {
            if (!this.Bounds.Contains(point))
                return false;
            int index1 = this.Points.Count - 1;
            bool flag = false;
            for (int index2 = 0; index2 < this.Points.Count; index1 = index2++)
            {
                if ((this.Points[index2].Lat <= point.Lat && point.Lat < this.Points[index1].Lat || this.Points[index1].Lat <= point.Lat && point.Lat < this.Points[index2].Lat) && point.Lon < (this.Points[index1].Lon - this.Points[index2].Lon) * (point.Lat - this.Points[index2].Lat) / (this.Points[index1].Lat - this.Points[index2].Lat) + this.Points[index2].Lon)
                    flag = !flag;
            }
            return flag;
        }
    }
}
