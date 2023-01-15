// Decompiled with JetBrains decompiler
// Type: ArincReader.IcaoPansOps.Dme
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.GeneralAviation;

namespace ArincReader.IcaoPansOps
{
    public class Dme : BaseObjectPansOps
    {
        public Dme(CriteriaUnits pansOpsUnit)
          : base(pansOpsUnit)
        {
        }

        public static LinearDistance Tolerance(LinearDistance nominalDistance)
        {
            LinearDistance constant1NonSi = Dme.IcaoValues.Constant1NonSi;
            constant1NonSi = constant1NonSi.ConvertTo(nominalDistance.ValueUnit);
            double num = constant1NonSi.Value;
            if (nominalDistance.IsSi)
            {
                LinearDistance constant1Si = Dme.IcaoValues.Constant1Si;
                constant1Si = constant1Si.ConvertTo(nominalDistance.ValueUnit);
                num = constant1Si.Value;
            }
            return new LinearDistance(num + 1.0 / 80.0 * nominalDistance.Value, nominalDistance.ValueUnit);
        }

        public static class IcaoValues
        {
            public static readonly LinearDistance Constant1Si = new LinearDistance(0.46, LinearDistanceUnits.KM);
            public static readonly LinearDistance Constant1NonSi = new LinearDistance(0.25, LinearDistanceUnits.NM);
        }
    }
}
