// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.General.GridCoordinate
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.Geographical;
using System;

namespace FpAssistantCore.General
{
  public struct GridCoordinate
  {
    private Point3d _XyCoordinate;
    private readonly MapProjections _MapProjection;
    private readonly string _ProjectionZoneIdentifier;

    public GridCoordinate(
      GeoCoordinate geoCoordinate,
      MapProjections mapProjection,
      string projectionZoneIdentifier)
    {
      this._XyCoordinate = new Point3d();
      this._MapProjection = mapProjection;
      this._ProjectionZoneIdentifier = projectionZoneIdentifier;
      switch (this._MapProjection)
      {
        case MapProjections.UtmWgs84:
        case MapProjections.UtmNad83:
          if (!CoordinateSystems.IsProjectionZoneIdentifierValid(mapProjection, projectionZoneIdentifier))
            throw new ArgumentException(string.Format("{0} is not a valid item in the map projection", (object) projectionZoneIdentifier), nameof (projectionZoneIdentifier));
          this.Initialize(geoCoordinate);
          break;
        default:
          throw new NotImplementedException("MapProjection passed is not supported in GridCoordinate class constructor");
      }
    }

    public Point3d XYCoordinate => this._XyCoordinate;

    public MapProjections MapProjection => this._MapProjection;

    public string ProjectionZoneIdentifier => this._ProjectionZoneIdentifier;

    private void Initialize(GeoCoordinate geoCoordinate)
    {
      double x = 0.0;
      double y = 0.0;
      if (geoCoordinate.ConvertGeoCoordinateToCartesian(this._ProjectionZoneIdentifier, ref x, ref y) != 0)
        return;
      this._XyCoordinate = new Point3d(x, y, 0.0);
    }

    public double CartesianAngleTo(GridCoordinate gridCoordinate) => this._XyCoordinate.As2d().AngleTo(gridCoordinate._XyCoordinate.As2d());
  }
}
