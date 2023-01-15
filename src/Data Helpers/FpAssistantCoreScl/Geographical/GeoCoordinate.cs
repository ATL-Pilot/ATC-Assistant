// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.GeoCoordinate
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using FpAssistantWebApi.Models;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArincReader.Geographical
{
    public struct GeoCoordinate
    {
        private GeoCoordinateBasic _GeoCoordinateBasic;
        private const int _CoordinateSecondsRounding = 9;
        private const int _CoordinateEqualCompareDecimalPlaces = 5;
        private static GeoCoordinate.ModesOfOperation _ModeOfOperation = GeoCoordinate.ModesOfOperation.CsMapLocalFiles;
        public static readonly string GeoCoordinateFormatDouble = "0.#############";

        public static GeoCoordinate.ModesOfOperation ModeOfOperation
        {
            get => GeoCoordinate._ModeOfOperation;
            set => GeoCoordinate._ModeOfOperation = value;
        }

        public double Latitude => this._GeoCoordinateBasic.Latitude;

        public double Longitude => this._GeoCoordinateBasic.Longitude;

        [JsonIgnore]
        public Tuple<int, int, double> LatitudeToDMS => Tuple.Create<int, int, double>(this.LatitudeDegrees, this.LatitudeMinutes, this.LatitudeSeconds);

        [JsonIgnore]
        public int LatitudeDegrees => Convert.ToInt32(Math.Truncate(this._GeoCoordinateBasic.Latitude));

        [JsonIgnore]
        public int LatitudeMinutes => Convert.ToInt32(Math.Truncate(Math.Abs(this._GeoCoordinateBasic.Latitude) * 60.0) % 60.0);

        [JsonIgnore]
        public double LatitudeSeconds => Math.Round(Convert.ToDouble(Math.Abs(this._GeoCoordinateBasic.Latitude) * 3600.0 % 60.0), 9, MidpointRounding.AwayFromZero);

        [JsonIgnore]
        public Tuple<int, int, double> LongitudeToDMS => Tuple.Create<int, int, double>(this.LongitudeDegrees, this.LongitudeMinutes, this.LongitudeSeconds);

        [JsonIgnore]
        public int LongitudeDegrees => Convert.ToInt32(Math.Truncate(this._GeoCoordinateBasic.Longitude));

        [JsonIgnore]
        public int LongitudeMinutes => Convert.ToInt32(Math.Truncate(Math.Abs(this._GeoCoordinateBasic.Longitude) * 60.0) % 60.0);

        [JsonIgnore]
        public double LongitudeSeconds => Math.Round(Convert.ToDouble(Math.Abs(this._GeoCoordinateBasic.Longitude) * 3600.0 % 60.0), 9, MidpointRounding.AwayFromZero);

        [JsonIgnore]
        public LatitudeCardinalDirection LatitudeCardinalDirection => this._GeoCoordinateBasic.Latitude < 0.0 ? LatitudeCardinalDirection.S : LatitudeCardinalDirection.N;

        [JsonIgnore]
        public LongitudeCardinalDirection LongitudeCardinalDirection => this._GeoCoordinateBasic.Longitude < 0.0 ? LongitudeCardinalDirection.W : LongitudeCardinalDirection.E;

        [JsonIgnore]
        public bool IsEmpty => this._GeoCoordinateBasic.Latitude == 0.0 & this._GeoCoordinateBasic.Longitude == 0.0;

        [JsonIgnore]
        public GeoCoordinateBasic GeoCoordinateBasic => this._GeoCoordinateBasic;

        public int UTMGridZone()
        {
            double num = Math.Floor((this.Longitude + 180.0) / 6.0) + 1.0;
            if ((double)this.LatitudeDegrees >= 56.0 && (double)this.LatitudeDegrees < 64.0 && (double)this.LongitudeDegrees >= 3.0 && (double)this.LongitudeDegrees < 12.0)
                num = 32.0;
            if ((double)this.LatitudeDegrees > 72.0 && (double)this.LatitudeDegrees < 84.0)
            {
                if ((double)this.LongitudeDegrees >= 0.0 && (double)this.LongitudeDegrees < 9.0)
                    num = 31.0;
                else if ((double)this.LongitudeDegrees >= 9.0 && (double)this.LongitudeDegrees < 21.0)
                    num = 33.0;
                else if ((double)this.LongitudeDegrees >= 21.0 && (double)this.LongitudeDegrees < 33.0)
                    num = 35.0;
                else if ((double)this.LongitudeDegrees >= 33.0 && (double)this.LongitudeDegrees < 42.0)
                    num = 37.0;
            }
            return (int)num;
        }

        public MapProjectionUtmWgs84 UTMWGS84ProjectionZone()
        {
            int num = this.UTMGridZone();
            if (this.LatitudeCardinalDirection == LatitudeCardinalDirection.S)
                num += 100;
            return (MapProjectionUtmWgs84)num;
        }

        public MapProjectionUtmNad83 UTMNAD83ProjectionZone()
        {
            int num = this.UTMGridZone();
            return num >= 3 && num <= 22 && this.LatitudeCardinalDirection != LatitudeCardinalDirection.S ? (MapProjectionUtmNad83)num : throw new ArithmeticException("Coordinate not located in NAD83 Zones, found in Zone" + num.ToString());
        }

        public string ProjectionZoneDescription(MapProjections mapProjection)
        {
            if (mapProjection == MapProjections.UtmWgs84)
                return this.UTMWGS84ProjectionZone().GetDescription();
            if (mapProjection == MapProjections.UtmNad83)
                return this.UTMNAD83ProjectionZone().GetDescription();
            throw new ArgumentException("MapProjection not supported", nameof(mapProjection));
        }

        public GeoCoordinate(
          double gridCoordinateX,
          double gridCoordinateY,
          string projectionOfCartesianCoordinates)
          : this(0.0, 0.0)
        {
            switch (this.ConvertCartesianToGeoCoordinate(gridCoordinateX, gridCoordinateY, projectionOfCartesianCoordinates))
            {
                case -2:
                    throw new ArgumentException("Unable to convert from cartesian to geo, check valid X & Y or projection/zone name");
                case -1:
                    throw new ArgumentException("Invalid projection/zone name", nameof(projectionOfCartesianCoordinates));
                case 0:
                    break;
                default:
                    throw new ArgumentException("Unhandled error in constructor");
            }
        }

        [JsonConstructor]
        public GeoCoordinate(double latitude, double longitude)
        {
            if (latitude > 90.0 || latitude < -90.0)
                throw new ArgumentOutOfRangeException(nameof(latitude), (object)latitude, "Latitude must be between +90.0 and -90.0 degrees.");
            this._GeoCoordinateBasic = longitude < 360.0 && longitude > -360.0 ? GeoCoordinateBasic.Normalize(latitude, longitude) : throw new ArgumentOutOfRangeException(nameof(longitude), (object)longitude, "Longitude must be less than +360.0 and greater than -360.0 degrees.");
        }

        public GeoCoordinate(
          LatitudeCardinalDirection latitudeCardinalDirection,
          double latitudeDegrees,
          double latitudeMinutes,
          double latitudeSeconds,
          LongitudeCardinalDirection longitudeCardinalDirection,
          double longitudeDegrees,
          double longitudeMinutes,
          double longitudeSeconds)
        {
            if (latitudeDegrees > 90.0 || latitudeDegrees < -90.0)
                throw new ArgumentOutOfRangeException(nameof(latitudeDegrees), (object)latitudeDegrees, "Latitude degrees must be between 90.0 and -90.0 degrees.");
            if (latitudeMinutes < 0.0 || latitudeMinutes >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(latitudeMinutes), (object)latitudeMinutes, "Latitude minutes must be between 0.0 and < 60.0 minutes.");
            if (latitudeSeconds < 0.0 || latitudeSeconds >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(latitudeSeconds), (object)latitudeSeconds, "Latitude seconds must be between 0.0 and < 60.0 seconds.");
            if (longitudeDegrees >= 360.0 || longitudeDegrees < -360.0)
                throw new ArgumentOutOfRangeException(nameof(longitudeDegrees), (object)longitudeDegrees, "Longitude degrees must be less than 360.0 and greater than -360.0 degrees.");
            if (longitudeMinutes < 0.0 || longitudeMinutes >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(longitudeMinutes), (object)longitudeMinutes, "Longitude minutes must be between 0.0 and < 60.0 minutes.");
            if (longitudeSeconds < 0.0 || longitudeSeconds >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(longitudeSeconds), (object)longitudeSeconds, "Longitude seconds must be between 0.0 and < 60.0 seconds.");
            this._GeoCoordinateBasic = GeoCoordinateBasic.Normalize(GeoCoordinate.DmsToDecimalDms(Math.Abs(latitudeDegrees), latitudeMinutes, latitudeSeconds) * (latitudeCardinalDirection == LatitudeCardinalDirection.S ? -1.0 : 1.0), GeoCoordinate.DmsToDecimalDms(Math.Abs(longitudeDegrees), longitudeMinutes, longitudeSeconds) * (longitudeCardinalDirection == LongitudeCardinalDirection.W ? -1.0 : 1.0));
        }

        public GeoCoordinate(string latitude, string longitude)
        {
            this._GeoCoordinateBasic = new GeoCoordinateBasic(0.0, 0.0);
            double decimalDms1 = 0.0;
            double decimalDms2 = 0.0;
            if (!GeoCoordinate.DecimalDMSFromString(latitude, ref decimalDms1))
                throw new ArgumentException("Invalid latitude string format", nameof(latitude));
            if (!GeoCoordinate.DecimalDMSFromString(longitude, ref decimalDms2))
                throw new ArgumentException("Invalid Longitude string format", nameof(longitude));
            this._GeoCoordinateBasic.Latitude = decimalDms1;
            this._GeoCoordinateBasic.Longitude = decimalDms2;
        }

        public GeoCoordinate(string latitudeLongitude)
        {
            string[] strArray = Regex.Split(latitudeLongitude, "\\s+");
            if (strArray.Length != 2)
                throw new ArgumentException("Invalid latitude/longitude string format", nameof(latitudeLongitude));
            this._GeoCoordinateBasic = new GeoCoordinateBasic(0.0, 0.0);
            double decimalDms1 = 0.0;
            double decimalDms2 = 0.0;
            if (!GeoCoordinate.DecimalDMSFromString(strArray[0], ref decimalDms1))
                throw new ArgumentException("Invalid latitude string format", nameof(latitudeLongitude));
            if (!GeoCoordinate.DecimalDMSFromString(strArray[1], ref decimalDms2))
                throw new ArgumentException("Invalid Longitude string format", nameof(latitudeLongitude));
            this._GeoCoordinateBasic.Latitude = decimalDms1;
            this._GeoCoordinateBasic.Longitude = decimalDms2;
        }

        public static double DmsToDecimalDms(double degrees, double minutes, double seconds) => Convert.ToDouble(degrees + minutes / 60.0 + seconds / 3600.0);

        public static bool operator ==(GeoCoordinate geoCoordinateA, GeoCoordinate geoCoordinateB) => (ValueType)geoCoordinateA == (ValueType)geoCoordinateB || geoCoordinateA.Equals((object)geoCoordinateB);

        public static bool operator !=(GeoCoordinate geoCoordinateA, GeoCoordinate geoCoordinateB) => !(geoCoordinateA == geoCoordinateB);

        public static string AsGeography(double latitude, double longitude) => GeoCoordinate.AsGeography(latitude, longitude, LinearDistance.ZeroMetres());

        public static string AsGeography(double latitude, double longitude, LinearDistance height) => string.Format("POINT({0} {1} {2})", (object)longitude.ToString(), (object)latitude.ToString(), (object)height.ConvertTo(LinearDistanceUnits.Metres).Value.ToString());

        public string AsGeography() => this._GeoCoordinateBasic.AsGeography();

        public override string ToString() => this.ToString((IFormatProvider)CultureInfo.CurrentCulture, GeoCoordinateFormat.DecimalDms);

        public string ToString(IFormatProvider iFormatProvider, GeoCoordinateFormat geoCoordinateFormat) => this.ToString(iFormatProvider, geoCoordinateFormat, 15);

        public string ToString(
          IFormatProvider iFormatProvider,
          GeoCoordinateFormat geoCoordinateFormat,
          int decimalPlaces)
        {
            string str = string.Empty;
            switch (geoCoordinateFormat)
            {
                case GeoCoordinateFormat.DecimalDms:
                    str = string.Format(iFormatProvider, "{0:f" + decimalPlaces.ToString() + "} {1:f" + decimalPlaces.ToString() + "}", (object)Math.Round(this._GeoCoordinateBasic.Latitude, decimalPlaces), (object)Math.Round(this._GeoCoordinateBasic.Longitude, decimalPlaces));
                    break;
                case GeoCoordinateFormat.DegreesMinutesSecondsWithSymbols:
                    Tuple<int, int, double> latitudeToDms1 = this.LatitudeToDMS;
                    Tuple<int, int, double> longitudeToDms1 = this.LongitudeToDMS;
                    str = string.Format(iFormatProvider, "{0:00}° {1:00}' {2:f" + decimalPlaces.ToString() + "}\" ", (object)Math.Abs(latitudeToDms1.Item1), (object)latitudeToDms1.Item2, (object)Math.Round(latitudeToDms1.Item3, decimalPlaces)) + (this._GeoCoordinateBasic.Latitude >= 0.0 ? "N" : "S") + " " + string.Format(iFormatProvider, "{0:000}° {1:00}' {2:f" + decimalPlaces.ToString() + "}\" ", (object)Math.Abs(longitudeToDms1.Item1), (object)longitudeToDms1.Item2, (object)Math.Round(longitudeToDms1.Item3, decimalPlaces)) + (this._GeoCoordinateBasic.Longitude >= 0.0 ? "E" : "W");
                    break;
                case GeoCoordinateFormat.DegreesMinutesSecondsNoSymbols:
                    Tuple<int, int, double> latitudeToDms2 = this.LatitudeToDMS;
                    Tuple<int, int, double> longitudeToDms2 = this.LongitudeToDMS;
                    str = string.Format(iFormatProvider, "{0:00} {1:00} {2:f" + decimalPlaces.ToString() + "}", (object)Math.Abs(latitudeToDms2.Item1), (object)latitudeToDms2.Item2, (object)Math.Round(latitudeToDms2.Item3, decimalPlaces)) + (this._GeoCoordinateBasic.Latitude >= 0.0 ? " N" : " S") + " " + string.Format(iFormatProvider, "{0:000} {1:00} {2:f" + decimalPlaces.ToString() + "}", (object)Math.Abs(longitudeToDms2.Item1), (object)longitudeToDms2.Item2, (object)Math.Round(longitudeToDms2.Item3, decimalPlaces)) + (this._GeoCoordinateBasic.Longitude >= 0.0 ? " E" : " W");
                    break;
            }
            return str;
        }

        public override int GetHashCode()
        {
            double num = this.Latitude;
            int hashCode1 = num.GetHashCode();
            num = this.Longitude;
            int hashCode2 = num.GetHashCode();
            return hashCode1 ^ hashCode2;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            if ((ValueType)this == other)
                return true;
            return !(other.GetType() != this.GetType()) && this.IsEqual((GeoCoordinate)other, 5);
        }

        public bool Equals(GeoCoordinate geoCoordinate, int decimalPlaces) => (ValueType)this == (ValueType)geoCoordinate || this.IsEqual(geoCoordinate, decimalPlaces);

        private bool IsEqual(GeoCoordinate other, int decimalPlaces)
        {
            GeoCoordinate geoCoordinate1 = new GeoCoordinate(this._GeoCoordinateBasic.Latitude, this._GeoCoordinateBasic.Longitude).RoundSeconds(decimalPlaces);
            GeoCoordinate geoCoordinate2 = new GeoCoordinate(other._GeoCoordinateBasic.Latitude, other._GeoCoordinateBasic.Longitude).RoundSeconds(decimalPlaces);
            return geoCoordinate1.LatitudeCardinalDirection == geoCoordinate2.LatitudeCardinalDirection && geoCoordinate1.LatitudeDegrees == geoCoordinate2.LatitudeDegrees && geoCoordinate1.LatitudeMinutes == geoCoordinate2.LatitudeMinutes && Math.Round(geoCoordinate1.LatitudeSeconds, decimalPlaces) == Math.Round(geoCoordinate2.LatitudeSeconds, decimalPlaces) && geoCoordinate1.LongitudeCardinalDirection == geoCoordinate2.LongitudeCardinalDirection && geoCoordinate1.LongitudeDegrees == geoCoordinate2.LongitudeDegrees && geoCoordinate1.LongitudeMinutes == geoCoordinate2.LongitudeMinutes && Math.Round(geoCoordinate1.LongitudeSeconds, decimalPlaces) == Math.Round(geoCoordinate2.LongitudeSeconds, decimalPlaces);
        }

        private GeoCoordinate RoundSeconds(int roundingDecimalPlaces)
        {
            double latitudeSeconds = Math.Round(this.LatitudeSeconds, roundingDecimalPlaces);
            int latitudeMinutes = this.LatitudeMinutes;
            int latitudeDegrees = Math.Abs(this.LatitudeDegrees);
            if (latitudeSeconds >= 60.0)
            {
                ++latitudeMinutes;
                latitudeSeconds -= 60.0;
            }
            if (latitudeMinutes >= 60)
            {
                ++latitudeDegrees;
                latitudeMinutes -= 60;
            }
            if (latitudeDegrees >= 90)
                latitudeDegrees -= 90;
            double longitudeSeconds = Math.Round(this.LongitudeSeconds, roundingDecimalPlaces);
            int longitudeMinutes = this.LongitudeMinutes;
            int longitudeDegrees = Math.Abs(this.LongitudeDegrees);
            if (longitudeSeconds >= 60.0)
            {
                ++longitudeMinutes;
                longitudeSeconds -= 60.0;
            }
            if (longitudeMinutes >= 60)
            {
                ++longitudeDegrees;
                longitudeMinutes -= 60;
            }
            if (longitudeDegrees >= 360)
                longitudeDegrees -= 360;
            return new GeoCoordinate(this.LatitudeCardinalDirection, (double)latitudeDegrees, (double)latitudeMinutes, latitudeSeconds, this.LongitudeCardinalDirection, (double)longitudeDegrees, (double)longitudeMinutes, longitudeSeconds);
        }

        public static LinearDistance DistanceBetweenSpherical(
          double latitude1,
          double longitude1,
          double latitude2,
          double longitude2)
        {
            double radians1 = Angle.DegreesToRadians(latitude1);
            double radians2 = Angle.DegreesToRadians(latitude2);
            double radians3 = Angle.DegreesToRadians(longitude1);
            double radians4 = Angle.DegreesToRadians(longitude2);
            return new LinearDistance(Angle.RadiansToDegrees(Math.Acos(Math.Sin(radians1) * Math.Sin(radians2) + Math.Cos(radians1) * Math.Cos(radians2) * Math.Cos(radians3 - radians4)) * 60.0), LinearDistanceUnits.NM);
        }

        private static bool DecimalDMSFromString(string coordinate, ref double decimalDms)
        {
            string[] strArray = new string[6]
            {
        "^(?<latD>[0-8]{1}?[0-9]{1})(?<latM>\\d{2})(?<latS>[0-9]+(?:\\.[0-9]+)?)(?<NorS>[NS])",
        "^(?<longD>\\d{2,3})(?<longM>\\d{2})(?<longS>[0-9]+(?:\\.[0-9]+)?)(?<EorW>[EW])",
        "^(?<NorS>[NS])(?<latD>[0-8]\\d)(?<latM>[0-5]\\d)(?<latS>[0-5]\\d)(?<latDec>\\d*)",
        "^(?<EorW>[EW])(?<longD>\\d{3})(?<longM>[0-5]\\d)(?<longS>[0-5]\\d)(?<longDec>\\d*)",
        "^(?<latD>[0-8]{1}?[0-9]{1}):(?<latM>\\d{2}):(?<latS>[0-9]+(?:\\.[0-9]+)?)(?<NorS>[NS])",
        "^(?<longD>\\d{2,3}):(?<longM>\\d{2}):(?<longS>[0-9]+(?:\\.[0-9]+)?)(?<EorW>[EW])"
            };
            foreach (string pattern in strArray)
            {
                Match match = new Regex(pattern).Match(coordinate);
                if (match.Success)
                {
                    string str1 = match.Groups["latD"].Value;
                    string str2 = match.Groups["latM"].Value;
                    string str3 = match.Groups["latS"].Value;
                    string str4 = match.Groups["latDec"].Value;
                    if (str4.Length > 0 && !str3.Contains("."))
                        str3 = str3 + "." + str4;
                    string str5 = match.Groups["NorS"].Value;
                    if ((str5 == "N" || str5 == "S") && str1.Length == 2 && str2.Length == 2 && str3.Length > 0)
                    {
                        double decimalDms1 = GeoCoordinate.DmsToDecimalDms(Convert.ToDouble(str1, (IFormatProvider)CultureInfo.InvariantCulture), Convert.ToDouble(str2, (IFormatProvider)CultureInfo.InvariantCulture), Convert.ToDouble(str3, (IFormatProvider)CultureInfo.InvariantCulture));
                        decimalDms = decimalDms1 * (str5 == "S" ? -1.0 : 1.0);
                        return true;
                    }
                    string str6 = match.Groups["longD"].Value;
                    string str7 = match.Groups["longM"].Value;
                    string str8 = match.Groups["longS"].Value;
                    string str9 = match.Groups["longDec"].Value;
                    if (str9.Length > 0 && !str8.Contains("."))
                        str8 = str8 + "." + str9;
                    string str10 = match.Groups["EorW"].Value;
                    if ((str10 == "E" || str10 == "W") && (str6.Length == 2 || str6.Length == 3) && str7.Length == 2 && str8.Length > 0)
                    {
                        double decimalDms2 = GeoCoordinate.DmsToDecimalDms(Convert.ToDouble(str6, (IFormatProvider)CultureInfo.InvariantCulture), Convert.ToDouble(str7, (IFormatProvider)CultureInfo.InvariantCulture), Convert.ToDouble(str8, (IFormatProvider)CultureInfo.InvariantCulture));
                        decimalDms = decimalDms2 * (str10 == "W" ? -1.0 : 1.0);
                        return true;
                    }
                }
            }
            return false;
        }

        private async Task CalculateDistanceAndAzimuthAsync(
          double firstLatitude,
          double firstLongitude,
          double secondLatitude,
          double secondLongitude,
          GeoCoordinate.Ref<int> csMapStatusCalculated,
          GeoCoordinate.Ref<double> distanceCalculated,
          GeoCoordinate.Ref<double> azimuthCalculated)
        {
            AzimuthDistance azimuthDistance = new AzimuthDistance(-9, 0.0, 0.0, LinearDistanceUnits.Metres);
            StringContent content = new StringContent(string.Format("{{ \"latitude1\": {0}, \"longitude1\": {1}, \"latitude2\": {2}, \"longitude2\": {3} }}", (object)firstLatitude.ToString("R"), (object)firstLongitude.ToString("R"), (object)secondLatitude.ToString("R"), (object)secondLongitude.ToString("R")), Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://fpassistantwa.azurewebsites.net/api/CalculateDistanceAndAzimuth", (HttpContent)content);
                azimuthDistance.CsMapStatus = (int)httpResponseMessage.StatusCode;
                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                    azimuthDistance = JsonSerializer.Deserialize<AzimuthDistance>(await httpResponseMessage.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
            }
            csMapStatusCalculated.Value = azimuthDistance.CsMapStatus;
            distanceCalculated.Value = azimuthDistance.Distance;
            azimuthCalculated.Value = azimuthDistance.Azimuth;
            azimuthDistance = (AzimuthDistance)null;
        }

        public int CalculateDistanceAndAzimuth(
          GeoCoordinate secondGeoCoordinate,
          ref CompassBearing azimuth,
          ref LinearDistance distance)
        {
            GeoCoordinate.Ref<double> distanceCalculated = new GeoCoordinate.Ref<double>();
            GeoCoordinate.Ref<double> azimuthCalculated = new GeoCoordinate.Ref<double>();
            GeoCoordinate.Ref<int> csMapStatusCalculated = new GeoCoordinate.Ref<int>();
            this.CalculateDistanceAndAzimuthAsync(this._GeoCoordinateBasic.Latitude, this._GeoCoordinateBasic.Longitude, secondGeoCoordinate._GeoCoordinateBasic.Latitude, secondGeoCoordinate._GeoCoordinateBasic.Longitude, csMapStatusCalculated, distanceCalculated, azimuthCalculated).Wait();
            int distanceAndAzimuth = csMapStatusCalculated.Value;
            if (distanceAndAzimuth != 0)
                return distanceAndAzimuth;
            azimuth = new CompassBearing(azimuthCalculated.Value);
            distance = new LinearDistance(distanceCalculated.Value, LinearDistanceUnits.Metres).ConvertTo(distance.ValueUnit);
            return distanceAndAzimuth;
        }

        private async Task TranslatedByAzimuthAndDistanceAsync(
          double latitude,
          double longitude,
          Angle azimuth,
          LinearDistance distance,
          GeoCoordinate.Ref<int> csMapStatusCalculated,
          GeoCoordinate.Ref<double> translatedLatitudeCalculated,
          GeoCoordinate.Ref<double> translatedLongitudeCalculated)
        {
            LatLongCoordinate latLongCoordinate = new LatLongCoordinate();
            StringContent content = new StringContent(string.Format("{{ \"latitude1\": {0}, \"longitude1\": {1}, \"azimuth\": {2}, \"distance\": {3} }}", (object)latitude.ToString(), (object)longitude.ToString(), (object)azimuth.AsDegrees(), (object)distance.ConvertTo(LinearDistanceUnits.Metres).Value), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await client.PostAsync("http://fpassistantwa.azurewebsites.net/api/TranslatedByAzimuthAndDistance", (HttpContent)content);
                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                        latLongCoordinate = JsonSerializer.Deserialize<LatLongCoordinate>(await httpResponseMessage.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                }
                csMapStatusCalculated.Value = latLongCoordinate.CsMapStatus;
                translatedLatitudeCalculated.Value = latLongCoordinate.Latitute;
                translatedLongitudeCalculated.Value = latLongCoordinate.Longitude;
            }
            latLongCoordinate = (LatLongCoordinate)null;
        }

        public int TranslatedByAzimuthAndDistance(
          CompassBearing azimuth,
          LinearDistance distance,
          ref GeoCoordinate translatedGeoCoordinate)
        {
            GeoCoordinate.Ref<double> translatedLatitudeCalculated = new GeoCoordinate.Ref<double>();
            GeoCoordinate.Ref<double> translatedLongitudeCalculated = new GeoCoordinate.Ref<double>();
            GeoCoordinate.Ref<int> csMapStatusCalculated = new GeoCoordinate.Ref<int>();
            this.TranslatedByAzimuthAndDistanceAsync(this._GeoCoordinateBasic.Latitude, this._GeoCoordinateBasic.Longitude, new Angle(azimuth.AsDegrees()), distance, csMapStatusCalculated, translatedLatitudeCalculated, translatedLongitudeCalculated).Wait();
            int num = csMapStatusCalculated.Value;
            if (num != 0)
                return num;
            translatedGeoCoordinate = new GeoCoordinate(translatedLatitudeCalculated.Value, translatedLongitudeCalculated.Value);
            return num;
        }

        private async Task ConvertCartesianToGeoCoordinateAsync(
          double x,
          double y,
          string projectionOfCartesianCoordinates,
          GeoCoordinate.Ref<int> csMapStatusCalculated,
          GeoCoordinate.Ref<double> latitudeCalculated,
          GeoCoordinate.Ref<double> longitudeCalculated)
        {
            LatLongCoordinate latLongCoordinate = new LatLongCoordinate();
            StringContent content = new StringContent(string.Format("{{ \"xx\": {0}, \"yy\": {1}, \"coordinateSystem\": \"{2}\" }}", (object)x.ToString(), (object)y.ToString(), (object)projectionOfCartesianCoordinates), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await client.PostAsync("http://fpassistantwa.azurewebsites.net/api/ConvertToDms", (HttpContent)content);
                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                        latLongCoordinate = JsonSerializer.Deserialize<LatLongCoordinate>(await httpResponseMessage.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                }
                csMapStatusCalculated.Value = latLongCoordinate.CsMapStatus;
                latitudeCalculated.Value = latLongCoordinate.Latitute;
                longitudeCalculated.Value = latLongCoordinate.Longitude;
            }
            latLongCoordinate = (LatLongCoordinate)null;
        }

        public int ConvertCartesianToGeoCoordinate(
          double x,
          double y,
          string projectionOfCartesianCoordinates)
        {
            GeoCoordinate.Ref<double> latitudeCalculated = new GeoCoordinate.Ref<double>();
            GeoCoordinate.Ref<double> longitudeCalculated = new GeoCoordinate.Ref<double>();
            GeoCoordinate.Ref<int> csMapStatusCalculated = new GeoCoordinate.Ref<int>();
            this.ConvertCartesianToGeoCoordinateAsync(x, y, projectionOfCartesianCoordinates, csMapStatusCalculated, latitudeCalculated, longitudeCalculated).Wait();
            int geoCoordinate = csMapStatusCalculated.Value;
            if (csMapStatusCalculated.Value != 0)
                return geoCoordinate;
            latitudeCalculated.Value = Math.Round(latitudeCalculated.Value, 8);
            longitudeCalculated.Value = Math.Round(longitudeCalculated.Value, 8);
            this = new GeoCoordinate(latitudeCalculated.Value, longitudeCalculated.Value);
            return geoCoordinate;
        }

        private async Task ConvertGeoCoordinateToCartesianAsync(
          double latitude,
          double longitude,
          string projectionOfCartesianCoordinates,
          GeoCoordinate.Ref<int> csMapStatusCalculated,
          GeoCoordinate.Ref<double> xCalculated,
          GeoCoordinate.Ref<double> yCalculated)
        {
            CartesianCoordinateWeb cartesianCoordinate = new CartesianCoordinateWeb();
            StringContent content = new StringContent(string.Format("{{ \"latitude\": {0}, \"longitude\": {1}, \"coordinateSystem\": \"{2}\" }}", (object)latitude.ToString(), (object)longitude.ToString(), (object)projectionOfCartesianCoordinates), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await client.PostAsync("http://fpassistantwa.azurewebsites.net/api/ConvertToCartesian", (HttpContent)content);
                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                        cartesianCoordinate = JsonSerializer.Deserialize<CartesianCoordinateWeb>(await httpResponseMessage.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                }
                csMapStatusCalculated.Value = cartesianCoordinate.CsMapStatus;
                xCalculated.Value = cartesianCoordinate.X;
                yCalculated.Value = cartesianCoordinate.Y;
            }
            cartesianCoordinate = (CartesianCoordinateWeb)null;
        }

        public Point2d ConvertGeoCoordinateToCartesian(string projectionOfCartesianCoordinates)
        {
            Point2d cartesian1 = new Point2d();
            double x = 0.0;
            double y = 0.0;
            int cartesian2;
            if ((cartesian2 = this.ConvertGeoCoordinateToCartesian(projectionOfCartesianCoordinates, ref x, ref y)) == 0)
            {
                cartesian1.X = x;
                cartesian1.Y = y;
                return cartesian1;
            }
            if (cartesian2 == -1)
                throw new ArgumentException(string.Format("Project zone {0} not found!", (object)projectionOfCartesianCoordinates), nameof(projectionOfCartesianCoordinates));
            throw new Exception("Unknomn error coverting to Cartesian in ConvertGeoCoordinateToCartesian()!");
        }

        public int ConvertGeoCoordinateToCartesian(
          string projectionOfCartesianCoordinates,
          ref double x,
          ref double y)
        {
            GeoCoordinate.Ref<double> xCalculated = new GeoCoordinate.Ref<double>();
            GeoCoordinate.Ref<double> yCalculated = new GeoCoordinate.Ref<double>();
            GeoCoordinate.Ref<int> csMapStatusCalculated = new GeoCoordinate.Ref<int>();
            this.ConvertGeoCoordinateToCartesianAsync(this._GeoCoordinateBasic.Latitude, this._GeoCoordinateBasic.Longitude, projectionOfCartesianCoordinates, csMapStatusCalculated, xCalculated, yCalculated).Wait();
            int cartesian = csMapStatusCalculated.Value;
            if (csMapStatusCalculated.Value != 0)
                return cartesian;
            x = xCalculated.Value;
            y = yCalculated.Value;
            return cartesian;
        }

        public enum ModesOfOperation
        {
            CsMapWebServiceAPI,
            CsMapLocalFiles,
        }

        public class Ref<T>
        {
            public T Value { get; set; }
        }
    }
}
