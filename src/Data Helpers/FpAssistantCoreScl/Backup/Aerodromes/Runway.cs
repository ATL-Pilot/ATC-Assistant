// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Aerodromes.Runway
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Text.Json.Serialization;

namespace FpAssistantCore.Aerodromes
{
  public class Runway
  {
    private string _Identifier = string.Empty;
    private GeoCoordinateElevationCollection _RunwayCentreLine = new GeoCoordinateElevationCollection();
    private readonly GeoCoordinateElevationCollection _RunwayLeftEdge = new GeoCoordinateElevationCollection();
    private readonly GeoCoordinateElevationCollection _RunwayRightEdge = new GeoCoordinateElevationCollection();

    [JsonConstructor]
    public Runway(string identifier) => this._Identifier = identifier;

    public string Identifier
    {
      get => this._Identifier;
      private set => this._Identifier = value;
    }

    public GeoCoordinateElevationCollection CentreLineCoordinates
    {
      get => this._RunwayCentreLine;
      set => this._RunwayCentreLine = value;
    }

    [JsonIgnore]
    public int CentreLineCoordinateCount => this._RunwayCentreLine.Count;

    public CompassBearing ForwardBearing()
    {
      if (this._RunwayCentreLine.Count > 1)
        return this._RunwayCentreLine[0].Coordinate.GeoCoordinateBasic.WGS84Distance(this._RunwayCentreLine[this._RunwayCentreLine.Count - 1].Coordinate.GeoCoordinateBasic).AzimuthForward;
      throw new ArgumentException("Not enough runway coordinates!", nameof (ForwardBearing));
    }

    public CompassBearing ReverseBearing()
    {
      if (this._RunwayCentreLine.Count > 1)
        return this._RunwayCentreLine[0].Coordinate.GeoCoordinateBasic.WGS84Distance(this._RunwayCentreLine[this._RunwayCentreLine.Count - 1].Coordinate.GeoCoordinateBasic).AzimuthReverse;
      throw new ArgumentException("Not enough runway coordinates!", "ForwardBearing");
    }

    public GeoCoordinate StartAsGeoCoordinate() => this._RunwayCentreLine.Count > 1 ? this._RunwayCentreLine[0].Coordinate : throw new ArgumentException("Not enough runway coordinates!", nameof (StartAsGeoCoordinate));

    public GeoCoordinateBasic StartAsGeoCoordinateBasic()
    {
      if (this._RunwayCentreLine.Count > 1)
        return this._RunwayCentreLine[0].Coordinate.GeoCoordinateBasic;
      throw new ArgumentException("Not enough runway coordinates!", nameof (StartAsGeoCoordinateBasic));
    }

    public LinearDistance StartElevation() => this._RunwayCentreLine.Count > 1 ? this._RunwayCentreLine[0].Elevation : throw new ArgumentException("Not enough runway coordinates!", nameof (StartElevation));

    public GeoCoordinate EndAsGeoCoordinate()
    {
      if (this._RunwayCentreLine.Count > 1)
        return this._RunwayCentreLine[this._RunwayCentreLine.Count - 1].Coordinate;
      throw new ArgumentException("Not enough runway coordinates!", nameof (EndAsGeoCoordinate));
    }

    public GeoCoordinateBasic EndAsGeoCoordinateBasic()
    {
      if (this._RunwayCentreLine.Count > 1)
        return this._RunwayCentreLine[this._RunwayCentreLine.Count - 1].Coordinate.GeoCoordinateBasic;
      throw new ArgumentException("Not enough runway coordinates!", nameof (EndAsGeoCoordinateBasic));
    }

    public LinearDistance EndElevation()
    {
      if (this._RunwayCentreLine.Count > 1)
        return this._RunwayCentreLine[this._RunwayCentreLine.Count - 1].Elevation;
      throw new ArgumentException("Not enough runway coordinates!", nameof (EndElevation));
    }

    public void AddRunwayCoordinate(GeoCoordinateElevation runwayCoordinateElevation)
    {
      this._RunwayCentreLine.Add(runwayCoordinateElevation);
      this._RunwayCentreLine.SortByDistanceFrom(this._RunwayCentreLine[0].Coordinate.GeoCoordinateBasic);
    }

    public GeoMapElement AsGeoMapElementCentreline(
      Runway.GeoMapElementOptions geoMapElementOption)
    {
      GeoMapElement geoMapElement = (GeoMapElement) null;
      switch (geoMapElementOption)
      {
        case Runway.GeoMapElementOptions.TwoPointsFirstLast:
          GeoLine geoLine = new GeoLine(this.StartAsGeoCoordinate(), this.EndAsGeoCoordinate());
          geoLine.StartElevation = this.StartElevation();
          geoLine.EndElevation = this.EndElevation();
          geoLine.Name = this.Identifier;
          geoLine.Description = "Runway centreline";
          geoMapElement = (GeoMapElement) geoLine;
          break;
        case Runway.GeoMapElementOptions.CentrelinePoints:
          GeoLineString geoLineString = new GeoLineString(this._RunwayCentreLine);
          geoLineString.Name = this.Identifier;
          geoLineString.Description = "Runway centreline";
          geoMapElement = (GeoMapElement) geoLineString;
          break;
      }
      return geoMapElement;
    }

    public GeoMapElementCollection Surfaces(
      LinearDistance width,
      GraphicalRepresentation graphicalRepresentation)
    {
      if (this._RunwayCentreLine.Count < 2)
        throw new ArgumentException("Not enough runway coordinates!");
      CalculateRunwayEdges();
      GeoMapElementCollection elementCollection = new GeoMapElementCollection();
      switch (graphicalRepresentation)
      {
        case GraphicalRepresentation.Lines:
          for (int index = 0; index < this._RunwayCentreLine.Count; ++index)
          {
            GeoMapElement geoMapElement = (GeoMapElement) new GeoLine(this._RunwayLeftEdge[index], this._RunwayRightEdge[index]);
            elementCollection.Add((IGeoMapElement) geoMapElement);
          }
          elementCollection.Add((IGeoMapElement) new GeoLineString(this._RunwayLeftEdge));
          elementCollection.Add((IGeoMapElement) new GeoLineString(this._RunwayRightEdge));
          break;
        case GraphicalRepresentation.Polygons:
          MapObjectProperties properties = ObjectMappingProperties.GetProperties(this.GetType().Name);
          for (int index = 0; index < this._RunwayCentreLine.Count - 1; ++index)
          {
            GeoMapElement geoMapElement = (GeoMapElement) new GeoPolygon(this._RunwayRightEdge[index], this._RunwayLeftEdge[index], this._RunwayLeftEdge[index + 1], this._RunwayRightEdge[index + 1], properties);
            elementCollection.Add((IGeoMapElement) geoMapElement);
          }
          break;
      }
      return elementCollection;

      void CalculateRunwayEdges()
      {
        this._RunwayLeftEdge.Clear();
        this._RunwayRightEdge.Clear();
        CompassBearing compassBearing = this.ForwardBearing();
        for (int index = 0; index < this._RunwayCentreLine.Count; ++index)
        {
          GeoCoordinateElevation coordinateElevation1 = this._RunwayCentreLine[index];
          GeoCoordinate coordinate = coordinateElevation1.Coordinate;
          GeoCoordinateBasic geoCoordinateBasic1 = coordinate.GeoCoordinateBasic;
          GeoCoordinateBasic geoCoordinateBasic2 = geoCoordinateBasic1.WGS84Destination(compassBearing - 90.0, width);
          GeoCoordinateElevationCollection runwayLeftEdge = this._RunwayLeftEdge;
          GeoCoordinateBasic geoCoordinateBasic3 = geoCoordinateBasic2;
          coordinateElevation1 = this._RunwayCentreLine[index];
          LinearDistance elevation1 = coordinateElevation1.Elevation;
          GeoCoordinateElevation coordinateElevation2 = new GeoCoordinateElevation(geoCoordinateBasic3, elevation1);
          runwayLeftEdge.Add(coordinateElevation2);
          coordinateElevation1 = this._RunwayCentreLine[index];
          coordinate = coordinateElevation1.Coordinate;
          geoCoordinateBasic1 = coordinate.GeoCoordinateBasic;
          GeoCoordinateBasic geoCoordinateBasic4 = geoCoordinateBasic1.WGS84Destination(compassBearing + 90.0, width);
          GeoCoordinateElevationCollection runwayRightEdge = this._RunwayRightEdge;
          GeoCoordinateBasic geoCoordinateBasic5 = geoCoordinateBasic4;
          coordinateElevation1 = this._RunwayCentreLine[index];
          LinearDistance elevation2 = coordinateElevation1.Elevation;
          GeoCoordinateElevation coordinateElevation3 = new GeoCoordinateElevation(geoCoordinateBasic5, elevation2);
          runwayRightEdge.Add(coordinateElevation3);
        }
      }
    }

    public enum GeoMapElementOptions
    {
      TwoPointsFirstLast,
      CentrelinePoints,
    }
  }
}
