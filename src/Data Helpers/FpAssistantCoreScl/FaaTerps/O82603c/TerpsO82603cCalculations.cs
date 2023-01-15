// Decompiled with JetBrains decompiler
// Type: ArincReader.FaaTerps.O82603c.TerpsO82603cCalculations
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.GeneralAviation;
using System;

namespace ArincReader.FaaTerps.O82603c
{
    public static class TerpsO82603cCalculations
    {
        static TerpsO82603cCalculations()
        {
            //if (!DeveloperLicense.IsFaaTerpsLicensed)
            //  throw new Exception(ConstantMessages.ForLicensing.FaaTerpsModuleNotLicensed);
        }

        public static double MaximumDescentGradientDGMax(Altitude altitude1, Altitude altitude2)
        {
            if (altitude1.AsFeet() < altitude2.AsFeet())
                throw new ArgumentException(ConstantMessages.ForExceptions.Altitude1LessThanAltitude2, nameof(altitude1));
            return (altitude1.AsFeet() - 10000.0) * 12.0 / (altitude1.AsFeet() - altitude2.AsFeet()) + 318.0;
        }

        public static LinearDistance MinimumDecelerationDistanceDD(
          Altitude altitude1,
          Altitude altitude2,
          DecelerationDistanceGradients DecelerationDistanceGradient,
          LinearDistance K)
        {
            if (altitude1.AsFeet() < altitude2.AsFeet())
                throw new ArgumentException(ConstantMessages.ForExceptions.Altitude1LessThanAltitude2, nameof(altitude1));
            double num1 = altitude1.AsFeet() - altitude2.AsFeet();
            double num2 = (double)DecelerationDistanceGradient;
            double num3 = K.ConvertTo(LinearDistanceUnits.NM).Value;
            double num4 = num2;
            return new LinearDistance(num1 / num4 + num3, LinearDistanceUnits.NM);
        }
    }
}
