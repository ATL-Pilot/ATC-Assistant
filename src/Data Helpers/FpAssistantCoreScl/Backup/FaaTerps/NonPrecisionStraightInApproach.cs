// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.FaaTerps.NonPrecisionStraightInApproach
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.GeneralAviation;
using FpAssistantCore.Geographical;

namespace FpAssistantCore.FaaTerps
{
  public class NonPrecisionStraightInApproach : BaseObjectTerps
  {
    private GeoCoordinate _RunwayThreashold;
    private GeoCoordinate _NavAid;
    private CompassBearing _RunwayTrueAzimuth;
    private CompassBearing _FAC_RadialTrueBearing;
    private bool _Result;

    public NonPrecisionStraightInApproach(CriteriaUnits terpsUnit)
      : base(terpsUnit)
    {
    }

    public GeoCoordinate RunwayThreasholdCoordinate
    {
      set
      {
        this._RunwayThreashold = value;
        this.Calculate();
      }
      get => this._RunwayThreashold;
    }

    public GeoCoordinate NavAidCoordinate
    {
      set
      {
        this._NavAid = value;
        this.Calculate();
      }
      get => this._NavAid;
    }

    public CompassBearing RunwayTrueBearing
    {
      set
      {
        this._RunwayTrueAzimuth = value;
        this.Calculate();
      }
      get => this._RunwayTrueAzimuth;
    }

    public CompassBearing FACorTrueRadialBearing
    {
      set
      {
        this._FAC_RadialTrueBearing = value;
        this.Calculate();
      }
      get => this._FAC_RadialTrueBearing;
    }

    public bool Result => this._Result;

    private void Calculate() => this._Result = true;
  }
}
