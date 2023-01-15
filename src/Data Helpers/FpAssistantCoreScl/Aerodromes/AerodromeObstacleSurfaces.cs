// Decompiled with JetBrains decompiler
// Type: ArincReader.Aerodromes.AerodromeObstacleSurfaces
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.Geographical;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ArincReader.Aerodromes
{
    public class AerodromeObstacleSurfaces : AerodromeSurfaces
    {
        private readonly Point3d[] _ApproachConstructionPoints = new Point3d[4];
        private LinearDistance _ApproachInnerEdgeLength = new LinearDistance(0.0, LinearDistanceUnits.Metres);
        private LinearDistance _ApproachDistanceFromThr = new LinearDistance(0.0, LinearDistanceUnits.Metres);
        private Percentage _ApproachDivergence;
        private LinearDistance _ApproachLength = new LinearDistance(0.0, LinearDistanceUnits.Metres);
        private Percentage _ApproachSlope;

        public AerodromeObstacleSurfaces(
          AerodromeObstacleSurfaces.RunwayTypeOption runwayType,
          AerodromeSurfaces.AircraftCategoryOption aircraftCategory)
          : base(BaseObjectAerodromeSurfaces.AerodromeCriteria.IcaoAos)
        {
            this.RunwayType = runwayType;
            this.AircraftCategory = aircraftCategory;
            this.SetApproachSurfaceDefaultValues();
        }

        [JsonConstructor]
        public AerodromeObstacleSurfaces(
          AerodromeObstacleSurfaces.RunwayTypeOption runwayType,
          AerodromeSurfaces.AircraftCategoryOption aircraftCategory,
          AerodromeObstacleSurfaces.ApproachGuidanceOption approachGuidance)
          : this(runwayType, aircraftCategory)
        {
            this.ApproachGuidance = approachGuidance;
        }

        [JsonInclude]
        public AerodromeObstacleSurfaces.RunwayTypeOption RunwayType { get; set; }

        public static AerodromeObstacleSurfaces LoadParameters(string filename) => File.Exists(filename) ? JsonSerializer.Deserialize<AerodromeObstacleSurfaces>(File.ReadAllText(filename), new JsonSerializerOptions()
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true
        }) : throw new FileNotFoundException(string.Format("File was not found: {0}", (object)filename));

        public AerodromeObstacleSurfaces.ApproachGuidanceOption ApproachGuidance { get; set; }

        [JsonInclude]
        public LinearDistance ApproachInnerEdgeLength
        {
            get => this._ApproachInnerEdgeLength;
            set => this._ApproachInnerEdgeLength = value;
        }

        public LinearDistance ApproachDistanceFromThr
        {
            get => this._ApproachDistanceFromThr;
            set => this._ApproachDistanceFromThr = value;
        }

        public Percentage ApproachDivergence
        {
            get => this._ApproachDivergence;
            set => this._ApproachDivergence = value;
        }

        public LinearDistance ApproachLength
        {
            get => this._ApproachLength;
            set => this._ApproachLength = value;
        }

        public Percentage ApproachSlope
        {
            get => this._ApproachSlope;
            set => this._ApproachSlope = value;
        }

        private void SetApproachSurfaceDefaultValues()
        {
            this._ApproachInnerEdgeLength = this.RunwayType != AerodromeObstacleSurfaces.RunwayTypeOption.NonInstrument || this.AircraftCategory != AerodromeSurfaces.AircraftCategoryOption.CatA && this.AircraftCategory != AerodromeSurfaces.AircraftCategoryOption.CatB ? new LinearDistance(150.0, LinearDistanceUnits.Metres) : new LinearDistance(60.0, LinearDistanceUnits.Metres);
            this._ApproachDistanceFromThr = this.RunwayType != AerodromeObstacleSurfaces.RunwayTypeOption.NonInstrument || this.AircraftCategory != AerodromeSurfaces.AircraftCategoryOption.CatA ? new LinearDistance(60.0, LinearDistanceUnits.Metres) : new LinearDistance(30.0, LinearDistanceUnits.Metres);
            this._ApproachDivergence = new Percentage(10.0);
            this._ApproachLength = this.RunwayType != AerodromeObstacleSurfaces.RunwayTypeOption.NonInstrument ? new LinearDistance(4300.0, LinearDistanceUnits.Metres) : (this.AircraftCategory != AerodromeSurfaces.AircraftCategoryOption.CatA ? (this.AircraftCategory != AerodromeSurfaces.AircraftCategoryOption.CatB ? new LinearDistance(3000.0, LinearDistanceUnits.Metres) : new LinearDistance(2500.0, LinearDistanceUnits.Metres)) : new LinearDistance(2000.0, LinearDistanceUnits.Metres));
            if (this.RunwayType == AerodromeObstacleSurfaces.RunwayTypeOption.NonInstrument)
            {
                if (this.AircraftCategory == AerodromeSurfaces.AircraftCategoryOption.CatA)
                    this._ApproachSlope = new Percentage(5.0);
                else if (this.AircraftCategory == AerodromeSurfaces.AircraftCategoryOption.CatB)
                    this._ApproachSlope = new Percentage(4.0);
                else
                    this._ApproachSlope = new Percentage(3.5);
            }
            else
                this._ApproachSlope = new Percentage(3.5);
        }

        public GeoMapElementCollection ApproachSurfaces(
          string runwayIdentifier,
          GraphicalRepresentation graphicalRepresentation)
        {
            (bool found, Runway runway) runwayByIdentifier = this.FindRunwayByIdentifier(runwayIdentifier);
            int num = runwayByIdentifier.found ? 1 : 0;
            Runway runway = runwayByIdentifier.runway;
            if (num == 0)
                throw new ArgumentException("Runway identifier not found!", nameof(runwayIdentifier));
            string projectZone = runway.StartAsGeoCoordinate().UTMWGS84ProjectionZone().GetDescription();
            ConstructApproachKeyPoints();
            GeoCoordinateElevationCollection coordinates = new GeoCoordinateElevationCollection();
            foreach (Point3d constructionPoint in this._ApproachConstructionPoints)
            {
                GeoCoordinate coordinate = new GeoCoordinate(constructionPoint.X, constructionPoint.Y, projectZone);
                coordinates.Add(new GeoCoordinateElevation(coordinate, new LinearDistance(constructionPoint.Z, this._CoordinateSystem.CoordinateSystemUnit)));
            }
            MapObjectProperties properties = ObjectMappingProperties.GetProperties(this.GetType().Name);
            GeoMapElementCollection elementCollection = new GeoMapElementCollection();
            if (graphicalRepresentation != GraphicalRepresentation.Lines)
            {
                if (graphicalRepresentation != GraphicalRepresentation.Polygons)
                    throw new NotImplementedException("GraphicalRespresentation enum value is not currently supported in AerodromeObstacleSurfaces");
                elementCollection.Add((IGeoMapElement)new GeoPolygon(coordinates[0], coordinates[1], coordinates[2], coordinates[3], properties));
            }
            else
            {
                coordinates.Add(coordinates[0]);
                elementCollection.Add((IGeoMapElement)new GeoLineString(coordinates));
            }
            foreach (GeoMapElement geoMapElement in (Collection<IGeoMapElement>)elementCollection)
            {
                geoMapElement.UniqueId = Guid.NewGuid();
                geoMapElement.Name = string.Format("{0}-Approach Surface", (object)runwayIdentifier);
                geoMapElement.Description = "AerodromeSurfaces";
            }
            return elementCollection;

            void ConstructApproachKeyPoints()
            {
                LinearDistance approachDistanceFromThr = this.ApproachDistanceFromThr;
                approachDistanceFromThr = approachDistanceFromThr.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double num1 = approachDistanceFromThr.Value;
                LinearDistance approachInnerEdgeLength = this.ApproachInnerEdgeLength;
                approachInnerEdgeLength = approachInnerEdgeLength.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double deltaY = approachInnerEdgeLength.Value;
                LinearDistance approachLength = this.ApproachLength;
                approachLength = approachLength.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double num2 = approachLength.Value;
                LinearDistance aerdromeElevation = this.AerdromeElevation;
                aerdromeElevation = aerdromeElevation.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double num3 = aerdromeElevation.Value;
                Point3d point3d = new Point3d(0.0, 0.0, 0.0);
                this._ApproachConstructionPoints[0] = point3d.GetTranslated(-num1, -deltaY);
                this._ApproachConstructionPoints[1] = point3d.GetTranslated(-num1, deltaY);
                this._ApproachConstructionPoints[0].Z = this._ApproachConstructionPoints[1].Z = num3;
                this._ApproachConstructionPoints[2].X = (num1 + num2) * -1.0;
                this._ApproachConstructionPoints[2].Y = deltaY + Math.Tan(Angle.DegreesToRadians(this.ApproachDivergence.Value)) * num2;
                this._ApproachConstructionPoints[3] = this._ApproachConstructionPoints[2].GetMirror(Axes.XAxis);
                this._ApproachConstructionPoints[2].Z = this._ApproachConstructionPoints[3].Z = num3 + this.ApproachSlope / 100.0 * num2;
                GridCoordinate gridCoordinate1 = new GridCoordinate(runway.StartAsGeoCoordinate(), MapProjections.UtmWgs84, projectZone);
                GridCoordinate gridCoordinate2 = new GridCoordinate(runway.EndAsGeoCoordinate(), MapProjections.UtmWgs84, projectZone);
                this._ApproachConstructionPoints.Rotate2DByDegrees(gridCoordinate1.CartesianAngleTo(gridCoordinate2));
                Point3d[] constructionPoints = this._ApproachConstructionPoints;
                Point3d xyCoordinate = gridCoordinate1.XYCoordinate;
                double x = xyCoordinate.X;
                xyCoordinate = gridCoordinate1.XYCoordinate;
                double y = xyCoordinate.Y;
                constructionPoints.Translate(x, y);
            }
        }

        public enum RunwayTypeOption
        {
            NonInstrument,
            NonPrecisionApproach,
            PrecisionApproach,
        }

        public enum ApproachGuidanceOption
        {
            NonLpProcedures,
            LpProcedures,
        }
    }
}
