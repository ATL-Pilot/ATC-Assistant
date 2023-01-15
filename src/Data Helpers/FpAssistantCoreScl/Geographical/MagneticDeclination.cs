// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.MagneticDeclination
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using System;

namespace ArincReader.Geographical
{
    public class MagneticDeclination
    {
        public static Angle Compute(
          GeoCoordinate geoCoordinate,
          LinearDistance altitude,
          DateTime date)
        {
            double[] field = new double[6];
            double radians1 = Angle.DegreesToRadians(geoCoordinate.Latitude);
            double radians2 = Angle.DegreesToRadians(geoCoordinate.Longitude);
            long julianDays = MagVar.Yymmdd_to_julian_days(Convert.ToInt32(date.ToString("yy")), date.Month, date.Day);
            return new Angle(Angle.RadiansToDegrees(new MagVar().SGMagVar(radians1, radians2, altitude.ConvertTo(LinearDistanceUnits.KM).Value, julianDays, (int)MagneticDeclination.AssignEnumBasedOnYear(date), field)));
        }

        private static MagneticDeclination.ModelTypeAndYear AssignEnumBasedOnYear(
          DateTime date)
        {
            MagneticDeclination.ModelTypeAndYear modelTypeAndYear = MagneticDeclination.ModelTypeAndYear.WMM2015;
            if (date.Year < 1985)
                throw new ArgumentOutOfRangeException(nameof(date), "The year of the date is below 1985");
            if (date.Year >= 1985 && date.Year < 1990)
                modelTypeAndYear = MagneticDeclination.ModelTypeAndYear.WMM85;
            else if (date.Year >= 1990 && date.Year < 1995)
                modelTypeAndYear = MagneticDeclination.ModelTypeAndYear.WMM90;
            else if (date.Year >= 1990 && date.Year < 1995)
                modelTypeAndYear = MagneticDeclination.ModelTypeAndYear.WMM90;
            else if (date.Year >= 1995 && date.Year < 2000)
                modelTypeAndYear = MagneticDeclination.ModelTypeAndYear.WMM95;
            else if (date.Year >= 2000 && date.Year < 2005)
                modelTypeAndYear = MagneticDeclination.ModelTypeAndYear.WMM2000;
            else if (date.Year >= 2005 && date.Year < 2010)
                modelTypeAndYear = MagneticDeclination.ModelTypeAndYear.WMM2005;
            else if (date.Year >= 2010 && date.Year < 2015)
                modelTypeAndYear = MagneticDeclination.ModelTypeAndYear.WMM2010;
            else if (date.Year >= 2015)
                modelTypeAndYear = MagneticDeclination.ModelTypeAndYear.WMM2015;
            return modelTypeAndYear;
        }

        public enum MagneticModelType
        {
            WMM,
            IGRF,
        }

        private enum ModelTypeAndYear
        {
            IGRF90 = 1,
            WMM85 = 2,
            WMM90 = 3,
            WMM95 = 4,
            IGRF95 = 5,
            WMM2000 = 6,
            IGRF2000 = 7,
            WMM2005 = 8,
            IGRF2005 = 9,
            WMM2010 = 10, // 0x0000000A
            IGRF2010 = 11, // 0x0000000B
            WMM2015 = 12, // 0x0000000C
        }
    }
}
