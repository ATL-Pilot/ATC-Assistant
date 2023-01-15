// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.Obstacles.PolygonObstacle
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.Geographical;
using System;
using System.Collections.Generic;

namespace ArincReader.GeneralAviation.Obstacles
{
    public class PolygonObstacle : Obstacle
    {
        private List<GeoCoordinate> _GeoCoordinates = new List<GeoCoordinate>();

        public List<GeoCoordinate> GeoCoordinates
        {
            get => this._GeoCoordinates;
            set => this._GeoCoordinates = value.Count >= 3 ? value : throw new ArgumentOutOfRangeException(nameof(GeoCoordinates), "Should have 3 or more coordinates for polygon");
        }

        public LinearDistance HeightMsl { get; set; }

        public override void AssignGridCoordinate(
          CoordinateSystem coordinateSystem,
          string projectionZoneIdentifier)
        {
            throw new NotImplementedException();
        }

        public override void AssignGridCoordinate(MapProjections mapProjection) => throw new NotImplementedException();

        public override GeoMapElement AsGeoMapElement(
          ObstacleGeographyMappings obstacleGeographyMappings)
        {
            throw new NotImplementedException();
        }
    }
}
