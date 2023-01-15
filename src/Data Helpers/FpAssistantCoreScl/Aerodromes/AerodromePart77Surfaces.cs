// Decompiled with JetBrains decompiler
// Type: ArincReader.Aerodromes.AerodromePart77Surfaces
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.Geographical;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ArincReader.Aerodromes
{
    public class AerodromePart77Surfaces : AerodromeSurfaces
    {
        private AerodromePart77Surfaces.FaaClassifications _Classification;
        private readonly Point3d[] _ConstructionPointsApproach = new Point3d[4];
        private readonly Point3d[] _ConstructionPointsApproach2 = new Point3d[2];
        private LinearDistance _ApproachSurfaceOuterEnd = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _ApproachSurfaceAdditionalOuterEnd = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _ApproachSurfaceAdditionalLength = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _ApproachSurfaceLength = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private double _ApproachSurfaceSlopeRatio;
        private double _ApproachSurfaceAdditionalSlopeRatio;
        private readonly Point3d[] _ConstructionPointsPrimary = new Point3d[4];
        private LinearDistance _PrimarySurfaceWidth = new LinearDistance(0.0, LinearDistanceUnits.Feet);
        private LinearDistance _PrimarySurfaceRunwayExtends = new LinearDistance(0.0, LinearDistanceUnits.Feet);

        public AerodromePart77Surfaces(
          AerodromePart77Surfaces.FaaClassifications classification)
          : base(BaseObjectAerodromeSurfaces.AerodromeCriteria.FaaPart77)
        {
            this._Classification = classification;
            this.SetPrimarySurfaceFaaDefaultValues();
            this.SetApproachSurfaceFaaDefaultValues();
        }

        [JsonInclude]
        public AerodromePart77Surfaces.FaaClassifications Classification
        {
            get => this._Classification;
            set => this._Classification = value;
        }

        public static AerodromePart77Surfaces LoadParameters(string filename) => File.Exists(filename) ? JsonSerializer.Deserialize<AerodromePart77Surfaces>(File.ReadAllText(filename), new JsonSerializerOptions()
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true
        }) : throw new FileNotFoundException(string.Format("File was not found: {0}", (object)filename));

        [JsonInclude]
        public LinearDistance ApproachSurfaceOuterEnd
        {
            get => this._ApproachSurfaceOuterEnd;
            set => this._ApproachSurfaceOuterEnd = value > new LinearDistance(0.0, LinearDistanceUnits.Feet) ? value : throw new ArgumentException("ApproachSurfaceOuterEnd invalid, must be greater than 0", nameof(ApproachSurfaceOuterEnd));
        }

        [JsonInclude]
        public LinearDistance ApproachSurfaceAdditionalOuterEnd
        {
            get => this._ApproachSurfaceAdditionalOuterEnd;
            set => this._ApproachSurfaceAdditionalOuterEnd = value > new LinearDistance(0.0, LinearDistanceUnits.Feet) ? value : throw new ArgumentException("ApproachSurfaceAdditionalOuterEnd invalid, must be greater than 0", nameof(ApproachSurfaceAdditionalOuterEnd));
        }

        [JsonInclude]
        public LinearDistance ApproachSurfaceLength
        {
            get => this._ApproachSurfaceLength;
            set => this._ApproachSurfaceLength = value > new LinearDistance(0.0, LinearDistanceUnits.Feet) ? value : throw new ArgumentException("ApproachSurfaceLength invalid, must be greater than 0", nameof(ApproachSurfaceLength));
        }

        [JsonInclude]
        public LinearDistance ApproachSurfaceAdditionalLength
        {
            get => this._ApproachSurfaceAdditionalLength;
            set => this._ApproachSurfaceAdditionalLength = value > new LinearDistance(0.0, LinearDistanceUnits.Feet) ? value : throw new ArgumentException("ApproachSurfaceAdditionalLength invalid, must be greater than 0", nameof(ApproachSurfaceAdditionalLength));
        }

        [JsonInclude]
        public double ApproachSurfaceSlopeRatio
        {
            get => this._ApproachSurfaceSlopeRatio;
            set => this._ApproachSurfaceSlopeRatio = value;
        }

        [JsonInclude]
        public double ApproachSurfaceAdditionalSlopeRatio
        {
            get => this._ApproachSurfaceAdditionalSlopeRatio;
            set => this._ApproachSurfaceAdditionalSlopeRatio = value;
        }

        private void SetApproachSurfaceFaaDefaultValues()
        {
            switch (this.Classification)
            {
                case AerodromePart77Surfaces.FaaClassifications.VisualApproachRunwayUtility:
                    this._ApproachSurfaceOuterEnd = new LinearDistance(1250.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceAdditionalOuterEnd = this._ApproachSurfaceAdditionalLength = new LinearDistance(0.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceLength = new LinearDistance(5000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceSlopeRatio = 20.0;
                    this._ApproachSurfaceAdditionalSlopeRatio = 0.0;
                    break;
                case AerodromePart77Surfaces.FaaClassifications.VisualApproachRunway:
                    this._ApproachSurfaceOuterEnd = new LinearDistance(1500.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceAdditionalOuterEnd = this._ApproachSurfaceAdditionalLength = new LinearDistance(0.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceLength = new LinearDistance(5000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceSlopeRatio = 20.0;
                    this._ApproachSurfaceAdditionalSlopeRatio = 0.0;
                    break;
                case AerodromePart77Surfaces.FaaClassifications.NonPrecisionInstrucmentApproachRunwayUtility:
                    this._ApproachSurfaceOuterEnd = new LinearDistance(2000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceAdditionalOuterEnd = this._ApproachSurfaceAdditionalLength = new LinearDistance(0.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceLength = new LinearDistance(5000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceSlopeRatio = 20.0;
                    this._ApproachSurfaceAdditionalSlopeRatio = 0.0;
                    break;
                case AerodromePart77Surfaces.FaaClassifications.NonPrecisionInstrumentApproachRunwayGreater:
                    this._ApproachSurfaceOuterEnd = new LinearDistance(3500.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceAdditionalOuterEnd = this._ApproachSurfaceAdditionalLength = new LinearDistance(0.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceLength = new LinearDistance(10000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceSlopeRatio = 34.0;
                    this._ApproachSurfaceAdditionalSlopeRatio = 0.0;
                    break;
                case AerodromePart77Surfaces.FaaClassifications.NonPrecisionInstrumentApproachRunwayLowAs:
                    this._ApproachSurfaceOuterEnd = new LinearDistance(4000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceAdditionalOuterEnd = this._ApproachSurfaceAdditionalLength = new LinearDistance(0.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceLength = new LinearDistance(10000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceSlopeRatio = 34.0;
                    this._ApproachSurfaceAdditionalSlopeRatio = 0.0;
                    break;
                case AerodromePart77Surfaces.FaaClassifications.PrecisionInstrumentRunwayPIR:
                    this._ApproachSurfaceOuterEnd = new LinearDistance(4000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceAdditionalOuterEnd = new LinearDistance(16000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceAdditionalLength = new LinearDistance(40000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceAdditionalSlopeRatio = 40.0;
                    this._ApproachSurfaceLength = new LinearDistance(10000.0, LinearDistanceUnits.Feet);
                    this._ApproachSurfaceSlopeRatio = 50.0;
                    break;
                default:
                    throw new NotImplementedException("Classification not supported!");
            }
        }

        public Point3d[] ApproachSurfaceConstructionPoints() => this._ConstructionPointsApproach;

        public Point3d[] ApproachSurface2ConstructionPoints() => this._ConstructionPointsApproach2;

        public GeoMapElementCollection ApproachSurfaces(
          string runwayIdentifier,
          GraphicalRepresentation graphicalRepresentation)
        {
            (bool found, Runway runway) runwayByIdentifier = this.FindRunwayByIdentifier(runwayIdentifier);
            int num = runwayByIdentifier.found ? 1 : 0;
            Runway runway = runwayByIdentifier.runway;
            if (num == 0)
                throw new ArgumentException("Runway identifier not found!", nameof(runwayIdentifier));
            string projectionZone = runway.StartAsGeoCoordinate().UTMWGS84ProjectionZone().GetDescription();
            ConstructApproachKeyPoints();
            GeoCoordinateElevationCollection coordinates1 = new GeoCoordinateElevationCollection();
            foreach (Point3d point3d in this._ConstructionPointsApproach)
            {
                GeoCoordinate coordinate = new GeoCoordinate(point3d.X, point3d.Y, projectionZone);
                coordinates1.Add(new GeoCoordinateElevation(coordinate, new LinearDistance(point3d.Z, this._CoordinateSystem.CoordinateSystemUnit)));
            }
            GeoCoordinateElevation coordinate3 = new GeoCoordinateElevation();
            GeoCoordinateElevation coordinate4 = new GeoCoordinateElevation();
            if (this.Classification == AerodromePart77Surfaces.FaaClassifications.PrecisionInstrumentRunwayPIR)
            {
                GeoCoordinate coordinate = new GeoCoordinate(this._ConstructionPointsApproach2[0].X, this._ConstructionPointsApproach2[0].Y, projectionZone);
                coordinate3 = new GeoCoordinateElevation(coordinate, new LinearDistance(this._ConstructionPointsApproach2[0].Z, this._CoordinateSystem.CoordinateSystemUnit));
                coordinate = new GeoCoordinate(this._ConstructionPointsApproach2[1].X, this._ConstructionPointsApproach2[1].Y, projectionZone);
                coordinate4 = new GeoCoordinateElevation(coordinate, new LinearDistance(this._ConstructionPointsApproach2[1].Z, this._CoordinateSystem.CoordinateSystemUnit));
            }
            MapObjectProperties properties = ObjectMappingProperties.GetProperties(this.GetType().Name);
            GeoMapElementCollection elementCollection = new GeoMapElementCollection();
            if (graphicalRepresentation != GraphicalRepresentation.Lines)
            {
                if (graphicalRepresentation != GraphicalRepresentation.Polygons)
                    throw new NotImplementedException("GraphicalRespresentation enum value is not currently supported in AerodromePart77Surfaces");
                elementCollection.Add((IGeoMapElement)new GeoPolygon(coordinates1[0], coordinates1[1], coordinates1[2], coordinates1[3], properties));
                if (this.Classification == AerodromePart77Surfaces.FaaClassifications.PrecisionInstrumentRunwayPIR)
                    elementCollection.Add((IGeoMapElement)new GeoPolygon(coordinates1[2], coordinates1[3], coordinate3, coordinate4, properties));
            }
            else
            {
                coordinates1.Add(coordinates1[0]);
                elementCollection.Add((IGeoMapElement)new GeoLineString(coordinates1));
                if (this.Classification == AerodromePart77Surfaces.FaaClassifications.PrecisionInstrumentRunwayPIR)
                {
                    GeoCoordinateElevationCollection elevationCollection = new GeoCoordinateElevationCollection();
                    elevationCollection.Add(coordinates1[2]);
                    elevationCollection.Add(coordinate4);
                    elevationCollection.Add(coordinate3);
                    elevationCollection.Add(coordinates1[3]);
                    GeoCoordinateElevationCollection coordinates2 = elevationCollection;
                    elementCollection.Add((IGeoMapElement)new GeoLineString(coordinates2));
                }
            }
            elementCollection.UpdateIdNameDescription(true, string.Format("{0}-Approach Surface", (object)runwayIdentifier), nameof(AerodromePart77Surfaces));
            return elementCollection;

            void ConstructApproachKeyPoints()
            {
                LinearDistance primarySurfaceWidth = this.PrimarySurfaceWidth;
                primarySurfaceWidth = primarySurfaceWidth.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double num1 = primarySurfaceWidth.Value;
                LinearDistance surfaceRunwayExtends = this.PrimarySurfaceRunwayExtends;
                surfaceRunwayExtends = surfaceRunwayExtends.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double num2 = surfaceRunwayExtends.Value;
                LinearDistance approachSurfaceLength = this.ApproachSurfaceLength;
                approachSurfaceLength = approachSurfaceLength.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double num3 = approachSurfaceLength.Value;
                LinearDistance linearDistance = this.ApproachSurfaceOuterEnd;
                linearDistance = linearDistance.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double num4 = linearDistance.Value;
                linearDistance = this.AerdromeElevation;
                linearDistance = linearDistance.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double zAddition = linearDistance.Value;
                Point3d point3d = new Point3d(0.0, 0.0, 0.0);
                this._ConstructionPointsApproach[0] = point3d.GetTranslated(-num2, -num1 / 2.0);
                this._ConstructionPointsApproach[1] = point3d.GetTranslated(-num2, num1 / 2.0);
                double deltaY1 = num4 / 2.0 - num1 / 2.0;
                this._ConstructionPointsApproach[2] = this._ConstructionPointsApproach[1].GetTranslated(-num3, deltaY1);
                this._ConstructionPointsApproach[3] = this._ConstructionPointsApproach[0].GetTranslated(-num3, -deltaY1);
                this._ConstructionPointsApproach[2].Z = this._ConstructionPointsApproach[3].Z = num3 / this.ApproachSurfaceSlopeRatio;
                this._ConstructionPointsApproach.ZAddition(zAddition);
                if (this.Classification == AerodromePart77Surfaces.FaaClassifications.PrecisionInstrumentRunwayPIR)
                {
                    LinearDistance additionalLength = this.ApproachSurfaceAdditionalLength;
                    additionalLength = additionalLength.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                    double num5 = additionalLength.Value;
                    LinearDistance additionalOuterEnd = this.ApproachSurfaceAdditionalOuterEnd;
                    additionalOuterEnd = additionalOuterEnd.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                    double deltaY2 = additionalOuterEnd.Value / 2.0 - num1 / 2.0;
                    this._ConstructionPointsApproach2[0] = this._ConstructionPointsApproach[0].GetTranslated(-(num3 + num5), -deltaY2);
                    this._ConstructionPointsApproach2[1] = this._ConstructionPointsApproach[1].GetTranslated(-(num3 + num5), deltaY2);
                    this._ConstructionPointsApproach2[0].Z = this._ConstructionPointsApproach2[1].Z = num3 / this.ApproachSurfaceSlopeRatio + num5 / this.ApproachSurfaceAdditionalSlopeRatio;
                }
                GridCoordinate gridCoordinate1 = new GridCoordinate(runway.StartAsGeoCoordinate(), this._CoordinateSystem.MapProjection, projectionZone);
                GridCoordinate gridCoordinate2 = new GridCoordinate(runway.EndAsGeoCoordinate(), this._CoordinateSystem.MapProjection, projectionZone);
                double degrees = gridCoordinate1.CartesianAngleTo(gridCoordinate2);
                this._ConstructionPointsApproach.Rotate2DByDegrees(degrees);
                Point3d[] constructionPointsApproach = this._ConstructionPointsApproach;
                double x1 = gridCoordinate1.XYCoordinate.X;
                Point3d xyCoordinate = gridCoordinate1.XYCoordinate;
                double y1 = xyCoordinate.Y;
                constructionPointsApproach.Translate(x1, y1);
                if (this.Classification != AerodromePart77Surfaces.FaaClassifications.PrecisionInstrumentRunwayPIR)
                    return;
                this._ConstructionPointsApproach2.Rotate2DByDegrees(degrees);
                Point3d[] constructionPointsApproach2 = this._ConstructionPointsApproach2;
                xyCoordinate = gridCoordinate1.XYCoordinate;
                double x2 = xyCoordinate.X;
                xyCoordinate = gridCoordinate1.XYCoordinate;
                double y2 = xyCoordinate.Y;
                constructionPointsApproach2.Translate(x2, y2);
            }
        }

        [JsonInclude]
        public LinearDistance PrimarySurfaceRunwayExtends
        {
            get => this._PrimarySurfaceRunwayExtends;
            set => this._PrimarySurfaceRunwayExtends = value > new LinearDistance(0.0, LinearDistanceUnits.Feet) ? value : throw new ArgumentException("PrimarySurfaceRunwayExtends invalid, must be greater than 0", nameof(PrimarySurfaceRunwayExtends));
        }

        [JsonInclude]
        public LinearDistance PrimarySurfaceWidth
        {
            get => this._PrimarySurfaceWidth;
            set => this._PrimarySurfaceWidth = value > new LinearDistance(0.0, LinearDistanceUnits.Feet) ? value : throw new ArgumentException("PrimarySurfaceWidth invalid, must be greater than 0", nameof(PrimarySurfaceWidth));
        }

        private void SetPrimarySurfaceFaaDefaultValues()
        {
            this._PrimarySurfaceRunwayExtends = new LinearDistance(200.0, LinearDistanceUnits.Feet);
            switch (this.Classification)
            {
                case AerodromePart77Surfaces.FaaClassifications.VisualApproachRunwayUtility:
                    this._PrimarySurfaceWidth = new LinearDistance(250.0, LinearDistanceUnits.Feet);
                    break;
                case AerodromePart77Surfaces.FaaClassifications.VisualApproachRunway:
                    this._PrimarySurfaceWidth = new LinearDistance(500.0, LinearDistanceUnits.Feet);
                    break;
                case AerodromePart77Surfaces.FaaClassifications.NonPrecisionInstrucmentApproachRunwayUtility:
                    this._PrimarySurfaceWidth = new LinearDistance(500.0, LinearDistanceUnits.Feet);
                    break;
                case AerodromePart77Surfaces.FaaClassifications.NonPrecisionInstrumentApproachRunwayGreater:
                    this._PrimarySurfaceWidth = new LinearDistance(500.0, LinearDistanceUnits.Feet);
                    break;
                case AerodromePart77Surfaces.FaaClassifications.NonPrecisionInstrumentApproachRunwayLowAs:
                    this._PrimarySurfaceWidth = new LinearDistance(1000.0, LinearDistanceUnits.Feet);
                    break;
                case AerodromePart77Surfaces.FaaClassifications.PrecisionInstrumentRunwayPIR:
                    this._PrimarySurfaceWidth = new LinearDistance(1000.0, LinearDistanceUnits.Feet);
                    break;
                default:
                    throw new NotImplementedException("Classification not supported!SetPrimarySurfaceFaaDefaultValues");
            }
        }

        public Point3d[] PrimarySurfaceConstructionPoints() => this._ConstructionPointsPrimary;

        public GeoMapElementCollection PrimarySurface(
          string runwayIdentifier,
          GraphicalRepresentation graphicalRepresentation)
        {
            (bool found, Runway runway) runwayByIdentifier = this.FindRunwayByIdentifier(runwayIdentifier);
            int num = runwayByIdentifier.found ? 1 : 0;
            Runway runway = runwayByIdentifier.runway;
            if (num == 0)
                throw new ArgumentException("Runway identifier not found!", nameof(runwayIdentifier));
            string zoneIdentifier = runway.StartAsGeoCoordinate().ProjectionZoneDescription(this._CoordinateSystem.MapProjection);
            ConstructPrimarySurfaceKeyPoints();
            GeoCoordinateElevationCollection coordinates = new GeoCoordinateElevationCollection();
            foreach (Point3d point3d in this._ConstructionPointsPrimary)
            {
                GeoCoordinate coordinate = new GeoCoordinate(point3d.X, point3d.Y, zoneIdentifier);
                coordinates.Add(new GeoCoordinateElevation(coordinate, new LinearDistance(point3d.Z, this._CoordinateSystem.CoordinateSystemUnit)));
            }
            MapObjectProperties properties = ObjectMappingProperties.GetProperties(this.GetType().Name);
            GeoMapElementCollection elementCollection = new GeoMapElementCollection();
            if (graphicalRepresentation != GraphicalRepresentation.Lines)
            {
                if (graphicalRepresentation != GraphicalRepresentation.Polygons)
                    throw new NotImplementedException("GraphicalRespresentation enum value is not currently supported in AerodromePart77Surfaces");
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
                geoMapElement.Name = string.Format((IFormatProvider)CultureInfo.CurrentCulture, "{0}-Primary Surface", (object)runwayIdentifier);
                geoMapElement.Description = nameof(AerodromePart77Surfaces);
            }
            return elementCollection;

            void ConstructPrimarySurfaceKeyPoints()
            {
                LinearDistance surfaceRunwayExtends = this.PrimarySurfaceRunwayExtends;
                surfaceRunwayExtends = surfaceRunwayExtends.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double distanceToExtend = surfaceRunwayExtends.Value;
                LinearDistance primarySurfaceWidth = this.PrimarySurfaceWidth;
                primarySurfaceWidth = primarySurfaceWidth.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double num = primarySurfaceWidth.Value;
                LinearDistance aerdromeElevation = this.AerdromeElevation;
                aerdromeElevation = aerdromeElevation.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
                double z = aerdromeElevation.Value;
                GridCoordinate gridCoordinate1 = new GridCoordinate(runway.StartAsGeoCoordinate(), this._CoordinateSystem.MapProjection, zoneIdentifier);
                GridCoordinate gridCoordinate2 = new GridCoordinate(runway.EndAsGeoCoordinate(), this._CoordinateSystem.MapProjection, zoneIdentifier);
                Point3d xyCoordinate = gridCoordinate1.XYCoordinate;
                Point2d start = xyCoordinate.As2d();
                xyCoordinate = gridCoordinate2.XYCoordinate;
                Point2d end = xyCoordinate.As2d();
                Line2d line2d = new Line2d(start, end);
                line2d.ExtendBy(distanceToExtend, Line2dPointType.Start);
                line2d.ExtendBy(distanceToExtend, Line2dPointType.End);
                Line2d offset1 = line2d.GetOffset(num / 2.0 * -1.0);
                Line2d offset2 = line2d.GetOffset(num / 2.0);
                this._ConstructionPointsPrimary[0] = offset1.Start.As3d(z);
                this._ConstructionPointsPrimary[1] = offset2.Start.As3d(z);
                this._ConstructionPointsPrimary[2] = offset2.End.As3d(z);
                this._ConstructionPointsPrimary[3] = offset1.End.As3d(z);
            }
        }

        public enum FaaClassifications
        {
            VisualApproachRunwayUtility,
            VisualApproachRunway,
            NonPrecisionInstrucmentApproachRunwayUtility,
            NonPrecisionInstrumentApproachRunwayGreater,
            NonPrecisionInstrumentApproachRunwayLowAs,
            PrecisionInstrumentRunwayPIR,
        }
    }
}
