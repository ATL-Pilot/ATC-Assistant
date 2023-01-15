namespace VatSim.Data
{
    public struct WorldRect
    {
        public double MinLon;
        public double MaxLon;
        public double MinLat;
        public double MaxLat;

        public WorldRect(double minLon, double maxLon, double minLat, double maxLat)
        {
            this.MinLon = minLon;
            this.MaxLon = maxLon;
            this.MinLat = minLat;
            this.MaxLat = maxLat;
        }

        public bool Contains(double lon, double lat) => lon >= this.MinLon && lon <= this.MaxLon && lat >= this.MinLat && lat <= this.MaxLat;

        public bool Contains(WorldPoint point) => this.Contains(point.Lon, point.Lat);
    }
}
