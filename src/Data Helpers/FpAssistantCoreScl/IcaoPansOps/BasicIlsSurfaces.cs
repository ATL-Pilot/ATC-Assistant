// Decompiled with JetBrains decompiler
// Type: ArincReader.IcaoPansOps.BasicIlsSurfaces
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using ArincReader.GeneralAviation;
using ArincReader.Geographical;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace ArincReader.IcaoPansOps
{
    public class BasicIlsSurfaces : BaseObjectPansOps
    {
        private GeoCoordinate _BasePoint;
        private CompassBearing _DirectionOfFlight = new CompassBearing(0.0);
        private LinearDistance _HeightMSL = new LinearDistance(0.0, LinearDistanceUnits.Metres);
        private readonly Point3d[] _ConstructionPoints = new Point3d[19];

        public BasicIlsSurfaces(CriteriaUnits pansOpsUnit)
          : base(pansOpsUnit)
        {
        }

        public GeoCoordinate BasePoint
        {
            set => this._BasePoint = value;
            get => this._BasePoint;
        }

        public CompassBearing DirectionOfFlight
        {
            set => this._DirectionOfFlight = value;
            get => this._DirectionOfFlight;
        }

        public LinearDistance HeightMSL
        {
            set => this._HeightMSL = value;
            get => this._HeightMSL;
        }

        public Point3d[] ConstructionPoints() => this._ConstructionPoints;

        public GeoMapElementCollection CreateGeographicalGeometry(
          CoordinateSystem coordinateSystem,
          GraphicalRepresentation graphicalRepresentation)
        {
            if (coordinateSystem == null)
                throw new ArgumentNullException(nameof(coordinateSystem));
            GeoMapElementCollection geographicalGeometry = new GeoMapElementCollection();
            this.ComputeConstructionPoints(coordinateSystem);
            List<GeoCoordinateElevation> coordinateElevationList = new List<GeoCoordinateElevation>();
            foreach (Point3d constructionPoint in this._ConstructionPoints)
            {
                GeoCoordinate coordinate = new GeoCoordinate(constructionPoint.X, constructionPoint.Y, this._BasePoint.UTMWGS84ProjectionZone().GetDescription());
                coordinateElevationList.Add(new GeoCoordinateElevation(coordinate, new LinearDistance(constructionPoint.Z, coordinateSystem.CoordinateSystemUnit)));
            }
            MapObjectProperties properties = ObjectMappingProperties.GetProperties(this.GetType().Name);
            if (graphicalRepresentation != GraphicalRepresentation.Lines)
            {
                if (graphicalRepresentation != GraphicalRepresentation.Polygons)
                    throw new NotImplementedException("GraphicalRespresentation enum value is not currently supported in BasicIlsSurfaces");
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[0], coordinateElevationList[1], coordinateElevationList[2], coordinateElevationList[3], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[3], coordinateElevationList[2], coordinateElevationList[7], coordinateElevationList[4], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[4], coordinateElevationList[7], coordinateElevationList[17], coordinateElevationList[8], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[12], coordinateElevationList[13], coordinateElevationList[6], coordinateElevationList[5], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[5], coordinateElevationList[6], coordinateElevationList[1], coordinateElevationList[0], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[12], coordinateElevationList[5], coordinateElevationList[11], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[11], coordinateElevationList[5], coordinateElevationList[0], coordinateElevationList[10], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[10], coordinateElevationList[0], coordinateElevationList[3], coordinateElevationList[4], coordinateElevationList[9], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[9], coordinateElevationList[4], coordinateElevationList[8], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[13], coordinateElevationList[14], coordinateElevationList[6], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[6], coordinateElevationList[14], coordinateElevationList[15], coordinateElevationList[1], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[1], coordinateElevationList[15], coordinateElevationList[16], coordinateElevationList[7], coordinateElevationList[2], properties));
                geographicalGeometry.Add((IGeoMapElement)new GeoPolygon(coordinateElevationList[7], coordinateElevationList[16], coordinateElevationList[17], properties));
            }
            else
            {
                GeoMapElementCollection elementCollection1 = geographicalGeometry;
                GeoCoordinate coordinate1 = coordinateElevationList[0].Coordinate;
                GeoCoordinateElevation coordinateElevation = coordinateElevationList[1];
                GeoCoordinate coordinate2 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[0];
                LinearDistance elevation1 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[1];
                LinearDistance elevation2 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties1 = properties;
                GeoLine geoLine1 = new GeoLine(coordinate1, coordinate2, elevation1, elevation2, mapObjectProperties1);
                elementCollection1.Add((IGeoMapElement)geoLine1);
                GeoMapElementCollection elementCollection2 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[1];
                GeoCoordinate coordinate3 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[2];
                GeoCoordinate coordinate4 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[1];
                LinearDistance elevation3 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[2];
                LinearDistance elevation4 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties2 = properties;
                GeoLine geoLine2 = new GeoLine(coordinate3, coordinate4, elevation3, elevation4, mapObjectProperties2);
                elementCollection2.Add((IGeoMapElement)geoLine2);
                GeoMapElementCollection elementCollection3 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[2];
                GeoCoordinate coordinate5 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[3];
                GeoCoordinate coordinate6 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[2];
                LinearDistance elevation5 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[3];
                LinearDistance elevation6 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties3 = properties;
                GeoLine geoLine3 = new GeoLine(coordinate5, coordinate6, elevation5, elevation6, mapObjectProperties3);
                elementCollection3.Add((IGeoMapElement)geoLine3);
                GeoMapElementCollection elementCollection4 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[3];
                GeoCoordinate coordinate7 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[0];
                GeoCoordinate coordinate8 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[3];
                LinearDistance elevation7 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[0];
                LinearDistance elevation8 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties4 = properties;
                GeoLine geoLine4 = new GeoLine(coordinate7, coordinate8, elevation7, elevation8, mapObjectProperties4);
                elementCollection4.Add((IGeoMapElement)geoLine4);
                GeoMapElementCollection elementCollection5 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[12];
                GeoCoordinate coordinate9 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[13];
                GeoCoordinate coordinate10 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[12];
                LinearDistance elevation9 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[13];
                LinearDistance elevation10 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties5 = properties;
                GeoLine geoLine5 = new GeoLine(coordinate9, coordinate10, elevation9, elevation10, mapObjectProperties5);
                elementCollection5.Add((IGeoMapElement)geoLine5);
                GeoMapElementCollection elementCollection6 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[13];
                GeoCoordinate coordinate11 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[14];
                GeoCoordinate coordinate12 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[13];
                LinearDistance elevation11 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[14];
                LinearDistance elevation12 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties6 = properties;
                GeoLine geoLine6 = new GeoLine(coordinate11, coordinate12, elevation11, elevation12, mapObjectProperties6);
                elementCollection6.Add((IGeoMapElement)geoLine6);
                GeoMapElementCollection elementCollection7 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[14];
                GeoCoordinate coordinate13 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[15];
                GeoCoordinate coordinate14 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[14];
                LinearDistance elevation13 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[15];
                LinearDistance elevation14 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties7 = properties;
                GeoLine geoLine7 = new GeoLine(coordinate13, coordinate14, elevation13, elevation14, mapObjectProperties7);
                elementCollection7.Add((IGeoMapElement)geoLine7);
                GeoMapElementCollection elementCollection8 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[15];
                GeoCoordinate coordinate15 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[16];
                GeoCoordinate coordinate16 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[15];
                LinearDistance elevation15 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[16];
                LinearDistance elevation16 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties8 = properties;
                GeoLine geoLine8 = new GeoLine(coordinate15, coordinate16, elevation15, elevation16, mapObjectProperties8);
                elementCollection8.Add((IGeoMapElement)geoLine8);
                GeoMapElementCollection elementCollection9 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[16];
                GeoCoordinate coordinate17 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[17];
                GeoCoordinate coordinate18 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[16];
                LinearDistance elevation17 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[17];
                LinearDistance elevation18 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties9 = properties;
                GeoLine geoLine9 = new GeoLine(coordinate17, coordinate18, elevation17, elevation18, mapObjectProperties9);
                elementCollection9.Add((IGeoMapElement)geoLine9);
                GeoMapElementCollection elementCollection10 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[17];
                GeoCoordinate coordinate19 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[8];
                GeoCoordinate coordinate20 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[17];
                LinearDistance elevation19 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[8];
                LinearDistance elevation20 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties10 = properties;
                GeoLine geoLine10 = new GeoLine(coordinate19, coordinate20, elevation19, elevation20, mapObjectProperties10);
                elementCollection10.Add((IGeoMapElement)geoLine10);
                GeoMapElementCollection elementCollection11 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[8];
                GeoCoordinate coordinate21 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[9];
                GeoCoordinate coordinate22 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[8];
                LinearDistance elevation21 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[9];
                LinearDistance elevation22 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties11 = properties;
                GeoLine geoLine11 = new GeoLine(coordinate21, coordinate22, elevation21, elevation22, mapObjectProperties11);
                elementCollection11.Add((IGeoMapElement)geoLine11);
                GeoMapElementCollection elementCollection12 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[9];
                GeoCoordinate coordinate23 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[10];
                GeoCoordinate coordinate24 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[9];
                LinearDistance elevation23 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[10];
                LinearDistance elevation24 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties12 = properties;
                GeoLine geoLine12 = new GeoLine(coordinate23, coordinate24, elevation23, elevation24, mapObjectProperties12);
                elementCollection12.Add((IGeoMapElement)geoLine12);
                GeoMapElementCollection elementCollection13 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[10];
                GeoCoordinate coordinate25 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[11];
                GeoCoordinate coordinate26 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[10];
                LinearDistance elevation25 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[11];
                LinearDistance elevation26 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties13 = properties;
                GeoLine geoLine13 = new GeoLine(coordinate25, coordinate26, elevation25, elevation26, mapObjectProperties13);
                elementCollection13.Add((IGeoMapElement)geoLine13);
                GeoMapElementCollection elementCollection14 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[11];
                GeoCoordinate coordinate27 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[12];
                GeoCoordinate coordinate28 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[11];
                LinearDistance elevation27 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[12];
                LinearDistance elevation28 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties14 = properties;
                GeoLine geoLine14 = new GeoLine(coordinate27, coordinate28, elevation27, elevation28, mapObjectProperties14);
                elementCollection14.Add((IGeoMapElement)geoLine14);
                GeoMapElementCollection elementCollection15 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[12];
                GeoCoordinate coordinate29 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[5];
                GeoCoordinate coordinate30 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[12];
                LinearDistance elevation29 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[5];
                LinearDistance elevation30 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties15 = properties;
                GeoLine geoLine15 = new GeoLine(coordinate29, coordinate30, elevation29, elevation30, mapObjectProperties15);
                elementCollection15.Add((IGeoMapElement)geoLine15);
                GeoMapElementCollection elementCollection16 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[5];
                GeoCoordinate coordinate31 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[0];
                GeoCoordinate coordinate32 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[5];
                LinearDistance elevation31 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[0];
                LinearDistance elevation32 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties16 = properties;
                GeoLine geoLine16 = new GeoLine(coordinate31, coordinate32, elevation31, elevation32, mapObjectProperties16);
                elementCollection16.Add((IGeoMapElement)geoLine16);
                GeoMapElementCollection elementCollection17 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[13];
                GeoCoordinate coordinate33 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[6];
                GeoCoordinate coordinate34 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[13];
                LinearDistance elevation33 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[6];
                LinearDistance elevation34 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties17 = properties;
                GeoLine geoLine17 = new GeoLine(coordinate33, coordinate34, elevation33, elevation34, mapObjectProperties17);
                elementCollection17.Add((IGeoMapElement)geoLine17);
                GeoMapElementCollection elementCollection18 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[6];
                GeoCoordinate coordinate35 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[1];
                GeoCoordinate coordinate36 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[6];
                LinearDistance elevation35 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[1];
                LinearDistance elevation36 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties18 = properties;
                GeoLine geoLine18 = new GeoLine(coordinate35, coordinate36, elevation35, elevation36, mapObjectProperties18);
                elementCollection18.Add((IGeoMapElement)geoLine18);
                GeoMapElementCollection elementCollection19 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[3];
                GeoCoordinate coordinate37 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[4];
                GeoCoordinate coordinate38 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[3];
                LinearDistance elevation37 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[4];
                LinearDistance elevation38 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties19 = properties;
                GeoLine geoLine19 = new GeoLine(coordinate37, coordinate38, elevation37, elevation38, mapObjectProperties19);
                elementCollection19.Add((IGeoMapElement)geoLine19);
                GeoMapElementCollection elementCollection20 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[4];
                GeoCoordinate coordinate39 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[8];
                GeoCoordinate coordinate40 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[4];
                LinearDistance elevation39 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[8];
                LinearDistance elevation40 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties20 = properties;
                GeoLine geoLine20 = new GeoLine(coordinate39, coordinate40, elevation39, elevation40, mapObjectProperties20);
                elementCollection20.Add((IGeoMapElement)geoLine20);
                GeoMapElementCollection elementCollection21 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[2];
                GeoCoordinate coordinate41 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[7];
                GeoCoordinate coordinate42 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[2];
                LinearDistance elevation41 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[7];
                LinearDistance elevation42 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties21 = properties;
                GeoLine geoLine21 = new GeoLine(coordinate41, coordinate42, elevation41, elevation42, mapObjectProperties21);
                elementCollection21.Add((IGeoMapElement)geoLine21);
                GeoMapElementCollection elementCollection22 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[7];
                GeoCoordinate coordinate43 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[17];
                GeoCoordinate coordinate44 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[7];
                LinearDistance elevation43 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[17];
                LinearDistance elevation44 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties22 = properties;
                GeoLine geoLine22 = new GeoLine(coordinate43, coordinate44, elevation43, elevation44, mapObjectProperties22);
                elementCollection22.Add((IGeoMapElement)geoLine22);
                GeoMapElementCollection elementCollection23 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[14];
                GeoCoordinate coordinate45 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[6];
                GeoCoordinate coordinate46 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[14];
                LinearDistance elevation45 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[6];
                LinearDistance elevation46 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties23 = properties;
                GeoLine geoLine23 = new GeoLine(coordinate45, coordinate46, elevation45, elevation46, mapObjectProperties23);
                elementCollection23.Add((IGeoMapElement)geoLine23);
                GeoMapElementCollection elementCollection24 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[6];
                GeoCoordinate coordinate47 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[5];
                GeoCoordinate coordinate48 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[6];
                LinearDistance elevation47 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[5];
                LinearDistance elevation48 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties24 = properties;
                GeoLine geoLine24 = new GeoLine(coordinate47, coordinate48, elevation47, elevation48, mapObjectProperties24);
                elementCollection24.Add((IGeoMapElement)geoLine24);
                GeoMapElementCollection elementCollection25 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[5];
                GeoCoordinate coordinate49 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[11];
                GeoCoordinate coordinate50 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[5];
                LinearDistance elevation49 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[11];
                LinearDistance elevation50 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties25 = properties;
                GeoLine geoLine25 = new GeoLine(coordinate49, coordinate50, elevation49, elevation50, mapObjectProperties25);
                elementCollection25.Add((IGeoMapElement)geoLine25);
                GeoMapElementCollection elementCollection26 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[15];
                GeoCoordinate coordinate51 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[1];
                GeoCoordinate coordinate52 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[15];
                LinearDistance elevation51 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[1];
                LinearDistance elevation52 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties26 = properties;
                GeoLine geoLine26 = new GeoLine(coordinate51, coordinate52, elevation51, elevation52, mapObjectProperties26);
                elementCollection26.Add((IGeoMapElement)geoLine26);
                GeoMapElementCollection elementCollection27 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[0];
                GeoCoordinate coordinate53 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[10];
                GeoCoordinate coordinate54 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[0];
                LinearDistance elevation53 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[10];
                LinearDistance elevation54 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties27 = properties;
                GeoLine geoLine27 = new GeoLine(coordinate53, coordinate54, elevation53, elevation54, mapObjectProperties27);
                elementCollection27.Add((IGeoMapElement)geoLine27);
                GeoMapElementCollection elementCollection28 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[16];
                GeoCoordinate coordinate55 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[7];
                GeoCoordinate coordinate56 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[16];
                LinearDistance elevation55 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[7];
                LinearDistance elevation56 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties28 = properties;
                GeoLine geoLine28 = new GeoLine(coordinate55, coordinate56, elevation55, elevation56, mapObjectProperties28);
                elementCollection28.Add((IGeoMapElement)geoLine28);
                GeoMapElementCollection elementCollection29 = geographicalGeometry;
                coordinateElevation = coordinateElevationList[4];
                GeoCoordinate coordinate57 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[9];
                GeoCoordinate coordinate58 = coordinateElevation.Coordinate;
                coordinateElevation = coordinateElevationList[4];
                LinearDistance elevation57 = coordinateElevation.Elevation;
                coordinateElevation = coordinateElevationList[9];
                LinearDistance elevation58 = coordinateElevation.Elevation;
                MapObjectProperties mapObjectProperties29 = properties;
                GeoLine geoLine29 = new GeoLine(coordinate57, coordinate58, elevation57, elevation58, mapObjectProperties29);
                elementCollection29.Add((IGeoMapElement)geoLine29);
            }
            foreach (GeoMapElement geoMapElement in (Collection<IGeoMapElement>)geographicalGeometry)
            {
                geoMapElement.UniqueId = Guid.NewGuid();
                geoMapElement.Name = string.Format("{0}@{1}", (object)nameof(BasicIlsSurfaces), (object)this._BasePoint.ToString((IFormatProvider)CultureInfo.CurrentCulture, GeoCoordinateFormat.DegreesMinutesSecondsWithSymbols));
                geoMapElement.Description = string.Empty;
            }
            return geographicalGeometry;
        }

        private void ComputeConstructionPoints(CoordinateSystem coordinateSystem)
        {
            LinearDistance offsetBehindRunway = BasicIlsSurfaces.IcaoValues.OffsetBehindRunway;
            offsetBehindRunway = offsetBehindRunway.ConvertTo(coordinateSystem.CoordinateSystemUnit);
            double num1 = offsetBehindRunway.Value;
            LinearDistance runwayCentreLine1 = BasicIlsSurfaces.IcaoValues.OffsetFromRunwayCentreLine;
            runwayCentreLine1 = runwayCentreLine1.ConvertTo(coordinateSystem.CoordinateSystemUnit);
            double deltaY = runwayCentreLine1.Value;
            LinearDistance runwayCentreLine2 = BasicIlsSurfaces.IcaoValues.LengthAlongRunwayCentreLine;
            runwayCentreLine2 = runwayCentreLine2.ConvertTo(coordinateSystem.CoordinateSystemUnit);
            double deltaX = runwayCentreLine2.Value;
            LinearDistance approachFirstSection = BasicIlsSurfaces.IcaoValues.LengthMissedApproachFirstSection;
            approachFirstSection = approachFirstSection.ConvertTo(coordinateSystem.CoordinateSystemUnit);
            double distance1 = approachFirstSection.Value;
            LinearDistance approachSecondSection = BasicIlsSurfaces.IcaoValues.LengthMissedApproachSecondSection;
            approachSecondSection = approachSecondSection.ConvertTo(coordinateSystem.CoordinateSystemUnit);
            double num2 = approachSecondSection.Value;
            LinearDistance lengthArrivalSection1 = BasicIlsSurfaces.IcaoValues.LengthArrivalSection1;
            lengthArrivalSection1 = lengthArrivalSection1.ConvertTo(coordinateSystem.CoordinateSystemUnit);
            double distance2 = lengthArrivalSection1.Value;
            LinearDistance lengthArrivalSection2 = BasicIlsSurfaces.IcaoValues.LengthArrivalSection2;
            lengthArrivalSection2 = lengthArrivalSection2.ConvertTo(coordinateSystem.CoordinateSystemUnit);
            double distance3 = lengthArrivalSection2.Value;
            LinearDistance transitionalHeightGain = BasicIlsSurfaces.IcaoValues.TransitionalHeightGain;
            transitionalHeightGain = transitionalHeightGain.ConvertTo(coordinateSystem.CoordinateSystemUnit);
            double height = transitionalHeightGain.Value;
            Point3d point3d = new Point3d(0.0, 0.0, 0.0);
            this._ConstructionPoints[0] = point3d.GetTranslated(-num1, deltaY);
            this._ConstructionPoints[1] = point3d.GetTranslated(-num1, -deltaY);
            this._ConstructionPoints[2] = point3d.GetTranslated(deltaX, -deltaY);
            this._ConstructionPoints[3] = point3d.GetTranslated(deltaX, deltaY);
            this._ConstructionPoints[4] = point3d.GetTranslated(deltaX + distance1, deltaY + GradientSlopeCalculator.PercentageDistance(distance1, BasicIlsSurfaces.IcaoValues.MissedApproachFirstSectionPercentageSplay));
            this._ConstructionPoints[5] = point3d.GetTranslated(-(distance2 + num1), deltaY + GradientSlopeCalculator.PercentageDistance(distance2, BasicIlsSurfaces.IcaoValues.ArrivalPercentageSplay));
            this._ConstructionPoints[6] = this._ConstructionPoints[5].GetMirror(Axes.XAxis);
            this._ConstructionPoints[7] = this._ConstructionPoints[4].GetMirror(Axes.XAxis);
            this._ConstructionPoints[8] = this._ConstructionPoints[4].GetTranslated(num2, GradientSlopeCalculator.PercentageDistance(num2, BasicIlsSurfaces.IcaoValues.MissedApproachSecondSectionPercentageSplay));
            double num3 = GradientSlopeCalculator.PercentageDistance(distance1, BasicIlsSurfaces.IcaoValues.MissedApproachGradientPercentage);
            this._ConstructionPoints[9] = this._ConstructionPoints[4].GetTranslated(0.0, GradientSlopeCalculator.DistanceFromHeightAndPercentage(height - num3, BasicIlsSurfaces.IcaoValues.TransitionalSideGradientPercentage));
            this._ConstructionPoints[10] = this._ConstructionPoints[0].GetTranslated(0.0, GradientSlopeCalculator.DistanceFromHeightAndPercentage(height, BasicIlsSurfaces.IcaoValues.TransitionalSideGradientPercentage));
            double num4 = GradientSlopeCalculator.PercentageDistance(distance2, BasicIlsSurfaces.IcaoValues.ArrivalSection1GradientPercentage);
            this._ConstructionPoints[11] = this._ConstructionPoints[5].GetTranslated(0.0, GradientSlopeCalculator.DistanceFromHeightAndPercentage(height - num4, BasicIlsSurfaces.IcaoValues.TransitionalSideGradientPercentage));
            this._ConstructionPoints[12] = point3d.GetTranslated(-(distance2 + distance3 + num1), deltaY + GradientSlopeCalculator.PercentageDistance(distance2 + distance3, BasicIlsSurfaces.IcaoValues.ArrivalPercentageSplay));
            this._ConstructionPoints[13] = this._ConstructionPoints[12].GetMirror(Axes.XAxis);
            this._ConstructionPoints[14] = this._ConstructionPoints[11].GetMirror(Axes.XAxis);
            this._ConstructionPoints[15] = this._ConstructionPoints[10].GetMirror(Axes.XAxis);
            this._ConstructionPoints[16] = this._ConstructionPoints[9].GetMirror(Axes.XAxis);
            this._ConstructionPoints[17] = this._ConstructionPoints[8].GetMirror(Axes.XAxis);
            LinearDistance linearDistance = this._HeightMSL.ConvertTo(coordinateSystem.CoordinateSystemUnit);
            this._ConstructionPoints[4].Z = this._ConstructionPoints[7].Z = GradientSlopeCalculator.PercentageDistance(distance1, BasicIlsSurfaces.IcaoValues.MissedApproachGradientPercentage);
            this._ConstructionPoints[5].Z = this._ConstructionPoints[6].Z = GradientSlopeCalculator.PercentageDistance(distance2, BasicIlsSurfaces.IcaoValues.ArrivalSection1GradientPercentage);
            this._ConstructionPoints[8].Z = this._ConstructionPoints[17].Z = this._ConstructionPoints[4].Z + GradientSlopeCalculator.PercentageDistance(num2, BasicIlsSurfaces.IcaoValues.MissedApproachGradientPercentage);
            this._ConstructionPoints[9].Z = this._ConstructionPoints[16].Z = this._ConstructionPoints[8].Z;
            this._ConstructionPoints[10].Z = this._ConstructionPoints[15].Z = this._ConstructionPoints[8].Z;
            this._ConstructionPoints[11].Z = this._ConstructionPoints[14].Z = this._ConstructionPoints[8].Z;
            this._ConstructionPoints[12].Z = this._ConstructionPoints[13].Z = this._ConstructionPoints[5].Z + GradientSlopeCalculator.PercentageDistance(distance3, BasicIlsSurfaces.IcaoValues.ArrivalSection2GradientPercentage);
            for (int index = 0; index <= 17; ++index)
                this._ConstructionPoints[index].Z += linearDistance.Value;
            GridCoordinate gridCoordinate = new GridCoordinate(this._BasePoint, MapProjections.UtmWgs84, this._BasePoint.UTMWGS84ProjectionZone().GetDescription());
            this._ConstructionPoints[18].X = 0.0;
            this._ConstructionPoints[18].Y = 0.0;
            this._ConstructionPoints.Rotate2DByDegrees((double)this._DirectionOfFlight.AsCartesianAngleDegrees());
            this._ConstructionPoints.Translate(gridCoordinate.XYCoordinate.X, gridCoordinate.XYCoordinate.Y);
        }

        public static class IcaoValues
        {
            public static readonly LinearDistance OffsetFromRunwayCentreLine = new LinearDistance(150.0, LinearDistanceUnits.Metres);
            public static readonly LinearDistance OffsetBehindRunway = new LinearDistance(60.0, LinearDistanceUnits.Metres);
            public static readonly LinearDistance LengthAlongRunwayCentreLine = new LinearDistance(900.0, LinearDistanceUnits.Metres);
            public static readonly LinearDistance LengthMissedApproachFirstSection = new LinearDistance(1800.0, LinearDistanceUnits.Metres);
            public static readonly double MissedApproachFirstSectionPercentageSplay = 17.48;
            public static readonly LinearDistance LengthMissedApproachSecondSection = new LinearDistance(10200.0, LinearDistanceUnits.Metres);
            public static readonly double MissedApproachSecondSectionPercentageSplay = 25.0;
            public static readonly double MissedApproachGradientPercentage = 2.5;
            public static readonly double ArrivalPercentageSplay = 15.0;
            public static readonly LinearDistance LengthArrivalSection1 = new LinearDistance(3000.0, LinearDistanceUnits.Metres);
            public static readonly double ArrivalSection1GradientPercentage = 2.0;
            public static readonly LinearDistance LengthArrivalSection2 = new LinearDistance(9600.0, LinearDistanceUnits.Metres);
            public static readonly double ArrivalSection2GradientPercentage = 2.5;
            public static readonly double TransitionalSideGradientPercentage = 14.3;
            public static readonly LinearDistance TransitionalHeightGain = new LinearDistance(300.0, LinearDistanceUnits.Metres);
        }
    }
}
