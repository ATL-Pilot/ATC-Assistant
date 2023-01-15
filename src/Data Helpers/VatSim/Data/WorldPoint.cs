using System;

namespace VatSim.Data
{
    public struct WorldPoint
    {
        public double Lon;
        public double Lat;

        public bool IsNonZero => this.Lon != 0.0 || this.Lat != 0.0;

        public bool IsZero => !this.IsNonZero;

        public static WorldPoint Zero => new WorldPoint();

        public WorldPoint(double lon, double lat)
        {
            this.Lon = lon;
            this.Lat = lat;
        }

        public void Offset(double lonOffset, double latOffset)
        {
            this.Lon += lonOffset;
            this.Lat += latOffset;
        }

        public WorldPoint Clone() => new WorldPoint(this.Lon, this.Lat);

        public WorldPoint CloneWithOffset(double lonOffset, double latOffset) => new WorldPoint(this.Lon + lonOffset, this.Lat + latOffset);

        public override string ToString() => string.Format("{0}, {1}", (object)this.Lat, (object)this.Lon);

        public double DistanceTo(WorldPoint point)
        {
            double d1 = this.Lat * (Math.PI / 180.0);
            double num1 = this.Lon * (Math.PI / 180.0);
            double d2 = point.Lat * (Math.PI / 180.0);
            double num2 = point.Lon * (Math.PI / 180.0) - num1;
            double d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 3437.670013352 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
