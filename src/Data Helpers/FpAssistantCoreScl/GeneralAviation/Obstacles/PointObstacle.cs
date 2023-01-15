// Decompiled with JetBrains decompiler
// Type: ArincReader.GeneralAviation.Obstacles.PointObstacle
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.Geographical;
using System;

namespace ArincReader.GeneralAviation.Obstacles
{
    public class PointObstacle : Obstacle
    {
        private LinearDistance _Radius;

        public PointObstacle(GeoCoordinate center, LinearDistance heightMsl, LinearDistance radius)
        {
            this.Center = center;
            this.HeightMsl = heightMsl;
            this.Radius = radius;
        }

        public GeoCoordinate Center { get; set; }

        public GridCoordinate CenterXY { get; private set; }

        public LinearDistance Radius
        {
            get => this._Radius;
            set => this._Radius = value.Value >= 0.0 ? value : throw new ArgumentOutOfRangeException(nameof(Radius), "Radius must not be less than 0.0");
        }

        public LinearDistance HeightMsl { get; set; }

        public override void AssignGridCoordinate(
          CoordinateSystem coordinateSystem,
          string projectionZoneIdentifier)
        {
            this.CenterXY = new GridCoordinate(this.Center, coordinateSystem.MapProjection, projectionZoneIdentifier);
        }

        public override void AssignGridCoordinate(MapProjections mapProjection)
        {
            string projectionZoneIdentifier = this.Center.ProjectionZoneDescription(mapProjection);
            this.CenterXY = new GridCoordinate(this.Center, mapProjection, projectionZoneIdentifier);
        }

        public override GeoMapElement AsGeoMapElement(
          ObstacleGeographyMappings obstacleGeographyMappings)
        {
            GeoMapElement geoMapElement;
            if (obstacleGeographyMappings == ObstacleGeographyMappings.PointObstacleToGeograpghyLinestring)
            {
                GeoCircle geoCircle = new GeoCircle(this.Center, this.Radius, this.HeightMsl);
                geoCircle.Name = this.Id;
                geoCircle.Description = this.Description;
                geoCircle.UniqueId = this.InternalId;
                geoMapElement = (GeoMapElement)geoCircle;
            }
            else
            {
                GeoPoint geoPoint = new GeoPoint(this.Center);
                geoPoint.Name = this.Id;
                geoPoint.Description = this.Description;
                geoPoint.UniqueId = this.InternalId;
                geoMapElement = (GeoMapElement)geoPoint;
            }
            return geoMapElement;
        }
    }
}
