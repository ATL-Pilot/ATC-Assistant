// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.GeoCoordinateBasic
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using System;

namespace ArincReader.Geographical
{
    public struct GeoCoordinateBasic : IEquatable<GeoCoordinateBasic>
    {
        private const double kInverseFlattening = 298.257223563665;
        private const double kFlattening = 0.00335281066474;
        private const double kSemiMajorAxis = 6378137.0;
        private const double kSemiMinorAxis = 6356752.31424523;
        private const double kEps = 5E-16;
        private const double kSphereRadius = 6367435.67971622;
        private const double kTol = 1E-09;
        private double _Latitude;
        private double _Longitude;

        public bool WGS84CrsIntersect(
          GeoCoordinateBasic point2,
          CompassBearing az13,
          CompassBearing az23,
          ref GeoCoordinateBasic intersectPoint)
        {
            double num1 = 1E-09;
            double M_PI = Math.PI;
            double M_2PI = 2.0 * Math.PI;
            GeoCoordinateBasic x1 = this;
            GeoCoordinateBasic y = point2;
            GeoAzimuthDistance geoAzimuthDistance1 = x1.WGS84Distance(y);
            double num2 = Math.Abs(SignAzimuthDifference(az13.AsRadians(), geoAzimuthDistance1.AzimuthForward.AsRadians()));
            double num3 = Math.Abs(SignAzimuthDifference(geoAzimuthDistance1.AzimuthReverse.AsRadians(), az23.AsRadians()));
            if (num2 < 0.0 && num3 < 0.0)
            {
                num2 = -num2;
                num3 = -num3;
            }
            if (Math.Sin(num2) == 0.0 && Math.Sin(num3) == 0.0)
                return false;
            double num4 = Math.Cos(num2);
            double num5 = Math.Sin(num2);
            double num6 = Math.Cos(num3);
            double num7 = Math.Sin(num3);
            double num8 = Math.Acos(-num4 * num6 + num5 * num7 * Math.Cos(geoAzimuthDistance1.Distance.Value / 6367435.67971622));
            double num9 = Math.Cos(num8);
            double num10 = Math.Sin(num8);
            double d1 = 6367435.67971622 * Math.Acos((num4 + num6 * num9) / (num7 * num10));
            double d2 = 6367435.67971622 * Math.Acos((num6 + num4 * num9) / (num5 * num10));
            if (double.IsNaN(d1) || double.IsNaN(d2))
                return false;
            GeoCoordinateBasic secondGeoPoint1 = x1.WGS84Destination(az13, new LinearDistance(d2, LinearDistanceUnits.Metres));
            double root = x1.WGS84Distance(secondGeoPoint1).Distance.Value;
            double num11 = -Angle.DegreesToRadians(secondGeoPoint1.Latitude);
            double num12 = Angle.DegreesToRadians(secondGeoPoint1.Longitude) + M_PI - M_2PI;
            GeoAzimuthDistance geoAzimuthDistance2 = x1.WGS84Distance(num11, num12);
            if (root > geoAzimuthDistance2.Distance.Value)
            {
                secondGeoPoint1 = GeoCoordinateBasic.Normalize(Angle.RadiansToDegrees(num11), Angle.RadiansToDegrees(num12));
                root = geoAzimuthDistance2.Distance.Value;
                geoAzimuthDistance2.AzimuthReverse.AsDegrees();
                az13 = new CompassBearing(az13.AsRadians() + M_PI, AngleUnits.Radians);
                az23 = new CompassBearing(az23.AsRadians() + M_PI, AngleUnits.Radians);
            }
            geoAzimuthDistance2 = y.WGS84Distance(secondGeoPoint1);
            double num13 = geoAzimuthDistance2.Distance.Value;
            if (root < NmToMeters(1.0))
            {
                GeoCoordinateBasic geoCoordinateBasic = x1.WGS84Destination(new CompassBearing(az13.AsRadians() + M_PI, AngleUnits.Radians), new LinearDistance(NmToMeters(1.0), LinearDistanceUnits.Metres));
                x1 = new GeoCoordinateBasic(geoCoordinateBasic.Latitude, geoCoordinateBasic.Longitude);
                geoAzimuthDistance2 = x1.WGS84Distance(secondGeoPoint1);
                az13 = geoAzimuthDistance2.AzimuthForward;
            }
            if (num13 < NmToMeters(1.0))
            {
                GeoCoordinateBasic geoCoordinateBasic = y.WGS84Destination(new CompassBearing(az23.AsRadians() + M_PI, AngleUnits.Radians), new LinearDistance(NmToMeters(1.0), LinearDistanceUnits.Metres));
                y = new GeoCoordinateBasic(geoCoordinateBasic.Latitude, geoCoordinateBasic.Longitude);
                geoAzimuthDistance2 = y.WGS84Distance(secondGeoPoint1);
                az23 = geoAzimuthDistance2.AzimuthForward;
            }
            bool flag = false;
            if (num13 < root)
            {
                Swap<GeoCoordinateBasic>(ref x1, ref y);
                Swap<CompassBearing>(ref az13, ref az23);
                root = num13;
                flag = true;
            }
            double[] x2 = new double[2];
            double[] errArray = new double[2];
            x2[0] = root;
            x2[1] = 1.01 * root;
            GeoCoordinateBasic secondGeoPoint2 = x1.WGS84Destination(az13, new LinearDistance(root, LinearDistanceUnits.Metres));
            geoAzimuthDistance2 = y.WGS84Distance(secondGeoPoint2);
            errArray[0] = SignAzimuthDifference(geoAzimuthDistance2.AzimuthForward.AsRadians(), az23.AsRadians());
            GeoCoordinateBasic secondGeoPoint3 = x1.WGS84Destination(az13, new LinearDistance(x2[1], LinearDistanceUnits.Metres));
            geoAzimuthDistance2 = y.WGS84Distance(secondGeoPoint3);
            errArray[1] = SignAzimuthDifference(geoAzimuthDistance2.AzimuthForward.AsRadians(), az23.AsRadians());
            double num14 = 0.0;
            int num15;
            for (num15 = 0; num15 == 0 || num14 > num1 && num15 <= 15; ++num15)
            {
                FindLinearRoot(x2, errArray, ref root);
                if (!double.IsNaN(root))
                {
                    GeoCoordinateBasic secondGeoPoint4 = x1.WGS84Destination(az13, new LinearDistance(root, LinearDistanceUnits.Metres));
                    geoAzimuthDistance2 = y.WGS84Distance(secondGeoPoint4);
                    errArray[0] = errArray[1];
                    SignAzimuthDifference(geoAzimuthDistance2.AzimuthForward.AsRadians(), az23.AsRadians());
                    errArray[1] = SignAzimuthDifference(geoAzimuthDistance2.AzimuthForward.AsRadians(), az23.AsRadians());
                    x2[0] = x2[1];
                    x2[1] = root;
                    geoAzimuthDistance2 = new GeoCoordinateBasic(secondGeoPoint4.Latitude, secondGeoPoint4.Longitude).WGS84Distance(secondGeoPoint3);
                    num14 = geoAzimuthDistance2.Distance.Value;
                    secondGeoPoint3 = secondGeoPoint4;
                }
                else
                    break;
            }
            if (num15 > 15 && num14 > 1E-08)
                return false;
            double num16;
            if (flag)
            {
                Swap<GeoCoordinateBasic>(ref x1, ref y);
                Swap<CompassBearing>(ref az13, ref az23);
                num16 = num13;
            }
            geoAzimuthDistance2 = new GeoCoordinateBasic(secondGeoPoint3.Latitude, secondGeoPoint3.Longitude).WGS84Distance(x1);
            double bearing1 = geoAzimuthDistance2.AzimuthForward.Bearing;
            num16 = geoAzimuthDistance2.Distance.Value;
            geoAzimuthDistance2 = new GeoCoordinateBasic(secondGeoPoint3.Latitude, secondGeoPoint3.Longitude).WGS84Distance(y);
            double bearing2 = geoAzimuthDistance2.AzimuthForward.Bearing;
            double num17 = geoAzimuthDistance2.Distance.Value;
            intersectPoint = secondGeoPoint3;
            return true;

            static bool IsNearZero(double value, double epsilon) => Math.Abs(value) < epsilon;

            static void FindLinearRoot(double[] x, double[] errArray, ref double root)
            {
                if (x[0] == x[1])
                    root = double.NaN;
                else if (errArray[0] == errArray[1])
                {
                    if (IsNearZero(errArray[0] - errArray[1], 1E-15))
                        root = x[0];
                    else
                        root = double.NaN;
                }
                else
                    root = -errArray[0] * (x[1] - x[0]) / (errArray[1] - errArray[0]) + x[0];
            }

            static void Swap<T>(ref T x, ref T y)
            {
                T obj = y;
                y = x;
                x = obj;
            }

            static double NmToMeters(double nm) => new LinearDistance(nm, LinearDistanceUnits.NM).ConvertTo(LinearDistanceUnits.Metres).Value;

            double SignAzimuthDifference(double az1, double az2)
            {
                double num = az1 - az2;
                if (Math.Abs(num) < 1E-13)
                    num = 0.0;
                return Mod(num + M_PI, M_2PI) - M_PI;
            }

            static double Mod(double aMod, double bMod)
            {
                double num = aMod - bMod * (double)(int)(aMod / bMod);
                if (num < 0.0)
                    num += bMod;
                return num;
            }
        }

        public GeoCoordinateBasic WGS84Destination(
          CompassBearing compassBearing,
          LinearDistance distance)
        {
            double num1 = distance.ConvertTo(LinearDistanceUnits.Metres).Value;
            double num2 = compassBearing.AsRadians();
            double num3 = Math.Sin(num2);
            double x = Math.Cos(num2);
            double y = 0.99664718933526 * Math.Tan(Angle.DegreesToRadians(this.Latitude));
            double num4 = 1.0 / Math.Sqrt(1.0 + y * y);
            double num5 = y * num4;
            double num6 = Math.Atan2(y, x);
            double num7 = num4 * num3;
            double num8 = 1.0 - num7 * num7;
            double num9 = num8 * 272331606106.953 / 40408299984662;
            double num10 = 1.0 + num9 / 16384.0 * (4096.0 + num9 * (num9 * (320.0 - 175.0 * num9) - 768.0));
            double num11 = num9 / 1024.0 * (256.0 + num9 * (num9 * (74.0 - 47.0 * num9) - 128.0));
            double num12 = num1 / (6356752.31424523 * num10);
            double num13 = 2.0 * Math.PI;
            double num14 = Math.Sin(num12);
            double num15 = Math.Cos(num12);
            double num16 = Math.Cos(2.0 * num6 + num12);
            double num17;
            for (int index = 0; Math.Abs(num12 - num13) > 5E-16 && ++index < 100; num12 = num1 / (6356752.31424523 * num10) + num17)
            {
                num16 = Math.Cos(2.0 * num6 + num12);
                num14 = Math.Sin(num12);
                num15 = Math.Cos(num12);
                double num18 = num16 * num16;
                num17 = num11 * num14 * (num16 + num11 * 0.25 * (num15 * (2.0 * num18 - 1.0) - num11 / 6.0 * num16 * (4.0 * num14 * num14 - 3.0) * (4.0 * num18 - 3.0)));
                num13 = num12;
            }
            double num19 = num5 * num14 - num4 * num15 * x;
            double radians = Math.Atan2(num5 * num15 + num4 * num14 * x, 0.99664718933526 * Math.Sqrt(num7 * num7 + num19 * num19));
            double num20 = Math.Atan2(num14 * num3, num4 * num15 - num5 * num14 * x);
            double num21 = 0.00020955066654625 * num8 * (4.0 + 0.00335281066474 * (4.0 - 3.0 * num8));
            double num22 = (1.0 - num21) * 0.00335281066474 * num7 * (num12 + num21 * num14 * (num16 + num21 * num15 * (2.0 * num16 * num16 - 1.0)));
            double num23 = num20 - num22;
            return GeoCoordinateBasic.Normalize(Angle.RadiansToDegrees(radians), Angle.RadiansToDegrees(Angle.DegreesToRadians(this.Longitude) + num23));
        }

        private GeoAzimuthDistance WGS84Distance(
          double latitudeRadians,
          double longitudeRadians)
        {
            return this.WGS84Distance(GeoCoordinateBasic.Normalize(Angle.RadiansToDegrees(latitudeRadians), Angle.RadiansToDegrees(longitudeRadians)));
        }

        public GeoAzimuthDistance WGS84Distance(GeoCoordinateBasic secondGeoPoint) => GeoCoordinateBasic.WGS84Distance(this, secondGeoPoint);

        public static GeoAzimuthDistance WGS84Distance(
          GeoCoordinateBasic firstGeoPoint,
          GeoCoordinateBasic secondGeoPoint)
        {
            LinearDistance distance = new LinearDistance(0.0, LinearDistanceUnits.Metres);
            double num1 = Angle.DegreesToRadians(secondGeoPoint.Longitude) - Angle.DegreesToRadians(firstGeoPoint.Longitude);
            double num2 = Math.Atan(0.99664718933526 * Math.Tan(Angle.DegreesToRadians(firstGeoPoint.Latitude)));
            double num3 = Math.Atan(0.99664718933526 * Math.Tan(Angle.DegreesToRadians(secondGeoPoint.Latitude)));
            double num4 = Math.Sin(num2);
            double num5 = Math.Cos(num2);
            double num6 = Math.Sin(num3);
            double num7 = Math.Cos(num3);
            double num8 = num5 * num7;
            double num9 = num5 * num6;
            double num10 = num4 * num6;
            double num11 = num4 * num7;
            double num12 = num1;
            int num13 = 0;
            double num14;
            double num15;
            double y;
            double x;
            double num16;
            double num17;
            double d;
            double num18;
            do
            {
                num14 = Math.Sin(num12);
                num15 = Math.Cos(num12);
                y = Math.Sqrt(num7 * num14 * (num7 * num14) + (num9 - num11 * num15) * (num9 - num11 * num15));
                if (y == 0.0)
                {
                    distance.Value = 0.0;
                    return new GeoAzimuthDistance(distance, new CompassBearing(0.0), new CompassBearing(0.0));
                }
                x = num10 + num8 * num15;
                num16 = Math.Atan2(y, x);
                double num19 = num8 * num14 / y;
                num17 = 1.0 - num19 * num19;
                d = x - 2.0 * num10 / num17;
                if (double.IsNaN(d))
                    d = 0.0;
                double num20 = 0.00020955066654625 * num17 * (4.0 + 0.00335281066474 * (4.0 - 3.0 * num17));
                num18 = num12;
                num12 = num1 + (1.0 - num20) * 0.00335281066474 * num19 * (num16 + num20 * y * (d + num20 * x * (2.0 * d * d - 1.0)));
            }
            while (Math.Abs(num12 - num18) > 5E-16 && ++num13 < 40);
            double num21 = num17 * 272331606106.953 / 40408299984662;
            double num22 = 1.0 + num21 / 16384.0 * (4096.0 + num21 * (num21 * (320.0 - 175.0 * num21) - 768.0));
            double num23 = num21 / 1024.0 * (256.0 + num21 * (num21 * (74.0 - 47.0 * num21) - 128.0));
            double num24 = num23 * y * (d + num23 / 4.0 * (x * (2.0 * d * d - 1.0) - num23 / 6.0 * d * (4.0 * y * y - 3.0) * (4.0 * d * d - 3.0)));
            distance.Value = 6356752.31424523 * num22 * (num16 - num24);
            double radians1 = Math.Atan2(num7 * num14, num9 - num11 * num15);
            double radians2 = Math.PI + Math.Atan2(num5 * num14, -num11 + num9 * num15);
            if (radians2 < 0.0)
                radians2 = 2.0 * Math.PI + radians2;
            if (radians1 < 0.0)
                radians1 = 2.0 * Math.PI + radians1;
            CompassBearing azimuthForward = new CompassBearing(Angle.RadiansToDegrees(radians1));
            CompassBearing azimuthReverse = new CompassBearing(Angle.RadiansToDegrees(radians2));
            return new GeoAzimuthDistance(distance, azimuthForward, azimuthReverse);
        }

        public GeoCoordinateBasic(double latitude, double longitude)
        {
            if (latitude < -90.0 || latitude > 90.0)
                throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be between -90 and 90 degrees inclusive");
            if (longitude < -180.0 || longitude > 180.0)
                throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be between -180 and 180 degrees inclusive.");
            this._Latitude = latitude;
            this._Longitude = longitude;
        }

        public double Latitude
        {
            get => this._Latitude;
            set => this._Latitude = GeoCoordinateBasic.NormalizeLatitude(value);
        }

        public double Longitude
        {
            get => this._Longitude;
            set => this._Longitude = GeoCoordinateBasic.NormalizeLongitude(value);
        }

        public LinearDistance DistanceTo(GeoCoordinateBasic geoCoordinateBasic) => this.WGS84Distance(geoCoordinateBasic).Distance;

        public GeoCoordinate AsGeoCoordinate() => new GeoCoordinate(this._Latitude, this._Longitude);

        public string AsGeography() => GeoCoordinate.AsGeography(this._Latitude, this._Longitude);

        public static GeoCoordinateBasic Normalize(double latitude, double longitude) => new GeoCoordinateBasic(GeoCoordinateBasic.NormalizeLatitude(latitude), GeoCoordinateBasic.NormalizeLongitude(longitude));

        private static double NormalizeLatitude(double latitude)
        {
            while (latitude < -90.0)
                latitude += 180.0;
            while (latitude > 90.0)
                latitude -= 180.0;
            return latitude;
        }

        private static double NormalizeLongitude(double longitude)
        {
            while (longitude < -180.0)
                longitude += 360.0;
            while (longitude > 180.0)
                longitude -= 360.0;
            return longitude;
        }

        //public override int GetHashCode() => (1742751369 * -1521134295 + this._Latitude.GetHashCode()) * -1521134295 + this._Longitude.GetHashCode();

        public override bool Equals(object obj) => obj is GeoCoordinateBasic geoCoordinateBasic && this._Latitude == geoCoordinateBasic._Latitude && this._Longitude == geoCoordinateBasic._Longitude;

        public static bool operator ==(
          GeoCoordinateBasic geoCoordinateBasic1,
          GeoCoordinateBasic geoCoordinateBasic2)
        {
            return geoCoordinateBasic1.Equals(geoCoordinateBasic2);
        }

        public static bool operator !=(
          GeoCoordinateBasic geoCoordinateBasic1,
          GeoCoordinateBasic geoCoordinateBasic2)
        {
            return !(geoCoordinateBasic1 == geoCoordinateBasic2);
        }

        public bool Equals(GeoCoordinateBasic other) => this.Equals((object)other);
    }
}
