// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.GeoArc
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;

namespace FpAssistantCore.Geographical
{
  public class GeoArc : GeoMapElement
  {
    private GeoCoordinate _CentreCoordinate = new GeoCoordinate(0.0, 0.0);
    private CompassBearing _StartAngle;
    private Angle _DrawAngleCW;
    private LinearDistance _Radius;

    public GeoArc(
      GeoCoordinate centreCoordinate,
      LinearDistance radiusOfArc,
      CompassBearing startAngle,
      Angle angleTodraw)
    {
      this._CentreCoordinate = centreCoordinate;
      this.StartAngle = startAngle;
      this.DrawAngleCW = angleTodraw;
      this.Radius = radiusOfArc;
    }

    public GeoCoordinate CentreCoordinate
    {
      get => this._CentreCoordinate;
      set => this._CentreCoordinate = value;
    }

    public CompassBearing StartAngle
    {
      get => this._StartAngle;
      set => this._StartAngle = value;
    }

    public Angle DrawAngleCW
    {
      get => this._DrawAngleCW;
      set => this._DrawAngleCW = value.AsDegrees() > 0.0 ? value : throw new ArgumentException("Draw sweep angle must be greater than 0", nameof (DrawAngleCW));
    }

    public CompassBearing EndAngle => new CompassBearing(this._StartAngle.AsDegrees() + this._DrawAngleCW.AsDegrees());

    public LinearDistance Radius
    {
      get => this._Radius;
      set => this._Radius = value.Value > 0.0 ? value : throw new ArgumentException("Radius must be greater than 0", nameof (Radius));
    }

    public string AsGmlPosCentreCoordinate(GmlDimension gmlDimension)
    {
      double num = this.CentreCoordinate.Latitude;
      string str1 = num.ToString();
      num = this.CentreCoordinate.Longitude;
      string str2 = num.ToString();
      string str3 = string.Format("{0} {1}", (object) str1, (object) str2);
      if (gmlDimension == GmlDimension.Output3D)
        str3 += " 0";
      return str3;
    }

    public string AsGmlRadius(LinearDistanceUnits linearDistanceUnits)
    {
      LinearDistance radius = this.Radius;
      radius = radius.ConvertTo(linearDistanceUnits);
      return string.Format("{0}", (object) radius.Value.ToString());
    }
  }
}
