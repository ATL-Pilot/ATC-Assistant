// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.GmlHelper
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml;

namespace FpAssistantCore.Geographical
{
  public class GmlHelper
  {
    private readonly XmlDocument _XmlDocument = new XmlDocument();
    private readonly XmlElement _FeatureCollectionElement;
    private readonly CultureInfo _GmlCulture = CultureInfo.GetCultureInfo("en-US");
    private const string gmlPrefix = "gml";
    private const string xmlnsPrefix = "xmlns";
    private const string W3OrgXmlNsUri = "http://www.w3.org/2000/xmlns/";
    private const string W3OrgXmlSchemaInstanceUri = "http://www.w3.org/2001/XMLSchema-instance";
    private const string OpenGisGml32Uri = "http://www.opengis.net/gml/3.2";
    private const string GmlElementArcByCenterPoint = "ArcByCenterPoint";
    private const string GmlElementCircleByCenterPoint = "CircleByCenterPoint";
    private const string GmlElementLineString = "LineString";
    private const string GmlElementPolygon = "Polygon";
    private const string GmlElementPoint = "Point";
    private const string GmlElementPos = "pos";
    private const string GmlElementPosList = "posList";
    private const string GmlElementRadius = "radius";
    private const string GmlElementStartAngle = "startAngle";
    private const string GmlElementEndAngle = "endAngle";
    private const string GmlAttributeSrsDimension = "srsDimension";
    private const string GmlAttributeSrsName = "srsName";
    private const string GmlAttributeId = "id";
    private const string GmlAttributeNumArc = "numArc";
    private const string GmlAttributeUom = "uom";
    private const string FeatureCollectionElementName = "FPAssistantObjects";
    private const string Epsg4326 = "urn:ogc:def:crs:EPSG::4326";

    public GmlHelper()
    {
      XmlDeclaration xmlDeclaration = this._XmlDocument.CreateXmlDeclaration("1.0", "UTF-8", (string) null);
      XmlElement documentElement = this._XmlDocument.DocumentElement;
      this._XmlDocument.InsertBefore((XmlNode) xmlDeclaration, (XmlNode) documentElement);
      this._XmlDocument.InsertBefore((XmlNode) this._XmlDocument.CreateComment("Created by FPAssistant SDK - FPAssistant.com - CADology Limited"), (XmlNode) documentElement);
      this._FeatureCollectionElement = this._XmlDocument.CreateElement("FPAssistantObjects");
      this._FeatureCollectionElement.Attributes.Append(this.AddAttribute("xmlns", "xsi", "http://www.w3.org/2000/xmlns/", "http://www.w3.org/2001/XMLSchema-instance"));
      this._FeatureCollectionElement.Attributes.Append(this.AddAttribute("xmlns", "gml", "http://www.w3.org/2000/xmlns/", "http://www.opengis.net/gml/3.2"));
      this._FeatureCollectionElement.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", "bFeatureCollection"));
    }

    public void AddFeatureMemberGeoMapElement(
      string featureName,
      GeoMapElement geoMapElement,
      GmlDimension gmlDimension)
    {
      XmlElement newChild;
      switch (geoMapElement)
      {
        case GeoPoint geoPoint:
          newChild = this.CreateFeatureMemberElementPoint(featureName, geoPoint, gmlDimension);
          break;
        case GeoLine geoLine:
          newChild = this.CreateFeatureMemberElementLineString(featureName, (GeoMapElement) geoLine, gmlDimension);
          break;
        case GeoPolygon geoPolygon:
          newChild = this.CreateFeatureMemberElementPolygon(featureName, geoPolygon, gmlDimension);
          break;
        case GeoLineString geoLineString:
          newChild = this.CreateFeatureMemberElementLineString(featureName, (GeoMapElement) geoLineString, gmlDimension);
          break;
        case GeoCircle geoCircle:
          newChild = this.CreateFeatureMemberElementCircle(featureName, geoCircle, gmlDimension);
          break;
        case GeoArc geoArc:
          newChild = this.CreateFeatureMemberElementArc(featureName, geoArc, gmlDimension);
          break;
        default:
          throw new NotImplementedException("This feature is not currently supported!");
      }
      this._FeatureCollectionElement.AppendChild((XmlNode) newChild);
    }

    public void AddFeatureMemberGeoMapElements(
      string featureName,
      GeoMapElementCollection geoMapElementCollection,
      GmlDimension gmlDimension)
    {
      foreach (GeoMapElement geoMapElement in (Collection<IGeoMapElement>) geoMapElementCollection)
        this.AddFeatureMemberGeoMapElement(featureName, geoMapElement, gmlDimension);
    }

    public void CompleteXml() => this._XmlDocument.AppendChild((XmlNode) this._FeatureCollectionElement);

    public void Save(string filename) => this._XmlDocument.Save(filename);

    public string GetXml() => this._XmlDocument.OuterXml;

    public static bool CreateGml(
      string filename,
      string featureName,
      GeoMapElementCollection geoMapElementCollection)
    {
      GmlHelper gmlHelper = new GmlHelper();
      gmlHelper.AddFeatureMemberGeoMapElements(featureName, geoMapElementCollection, GmlDimension.Output3D);
      gmlHelper.CompleteXml();
      gmlHelper.Save(filename);
      return true;
    }

    private XmlElement CreateFeatureMemberElementLineString(
      string featureName,
      GeoMapElement geoMapElement,
      GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("FeatureMember");
      XmlElement element2 = this._XmlDocument.CreateElement(featureName);
      element2.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      XmlElement element3 = this._XmlDocument.CreateElement("geometryProperty");
      switch (geoMapElement)
      {
        case GeoLineString geoLineString:
          element3.AppendChild((XmlNode) this.CreateLineString(geoLineString, gmlDimension));
          break;
        case GeoLine geoLine:
          element3.AppendChild((XmlNode) this.CreateLineString(geoLine, gmlDimension));
          break;
        default:
          throw new NotImplementedException("This GeoMapElement type is not currently supported in CreateFeatureMemberElementLineString()!");
      }
      element2.AppendChild((XmlNode) element3);
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private void AddDataListToXml(XmlElement xmlElement, Dictionary<string, string> dataList)
    {
      if (dataList.Count <= 0)
        return;
      foreach (KeyValuePair<string, string> data in dataList)
      {
        XmlElement element = this._XmlDocument.CreateElement(data.Key);
        element.InnerText = data.Value;
        xmlElement.AppendChild((XmlNode) element);
      }
    }

    private XmlElement CreateFeatureMemberElementPoint(
      string featureName,
      GeoPoint geoPoint,
      GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("FeatureMember");
      XmlElement element2 = this._XmlDocument.CreateElement(featureName);
      element2.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      this.AddDataListToXml(element2, geoPoint.DataList);
      XmlElement element3 = this._XmlDocument.CreateElement("geometryProperty");
      element3.AppendChild((XmlNode) this.CreatePoint(geoPoint, gmlDimension));
      element2.AppendChild((XmlNode) element3);
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private XmlElement CreateFeatureMemberElementCircle(
      string featureName,
      GeoCircle geoCircle,
      GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("FeatureMember");
      XmlElement element2 = this._XmlDocument.CreateElement(featureName);
      element2.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      this.AddDataListToXml(element2, geoCircle.DataList);
      XmlElement element3 = this._XmlDocument.CreateElement("geometryProperty");
      element3.AppendChild((XmlNode) this.CreateCircle(geoCircle, gmlDimension));
      element2.AppendChild((XmlNode) element3);
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private XmlElement CreateFeatureMemberElementArc(
      string featureName,
      GeoArc geoArc,
      GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("FeatureMember");
      XmlElement element2 = this._XmlDocument.CreateElement(featureName);
      element2.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      this.AddDataListToXml(element2, geoArc.DataList);
      XmlElement element3 = this._XmlDocument.CreateElement("geometryProperty");
      element3.AppendChild((XmlNode) this.CreateArc(geoArc, gmlDimension));
      element2.AppendChild((XmlNode) element3);
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private XmlElement CreateFeatureMemberElementPolygon(
      string featureName,
      GeoPolygon geoPolygon,
      GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("FeatureMember");
      XmlElement element2 = this._XmlDocument.CreateElement(featureName);
      element2.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      XmlElement element3 = this._XmlDocument.CreateElement("geometryProperty");
      element3.AppendChild((XmlNode) this.CreatePolygon(geoPolygon, gmlDimension));
      element2.AppendChild((XmlNode) element3);
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private XmlElement CreateLineString(GeoLine geoLine, GmlDimension gmlDimension) => this.CreateLineStringDetail(geoLine.AsGmlPosList(gmlDimension, (IFormatProvider) this._GmlCulture), gmlDimension);

    private XmlElement CreateLineString(
      GeoLineString geoLineString,
      GmlDimension gmlDimension)
    {
      return this.CreateLineStringDetail(geoLineString.AsGmlPosList(gmlDimension, (IFormatProvider) this._GmlCulture), gmlDimension);
    }

    private XmlElement CreateLineStringDetail(
      string gmlPosList,
      GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("gml", "LineString", "http://www.opengis.net/gml/3.2");
      element1.Attributes.Append(this.AddAttribute("xmlns", "gml", "http://www.w3.org/2000/xmlns/", "http://www.opengis.net/gml/3.2"));
      element1.Attributes.Append(this.AddAttribute("xmlns", "xsi", "http://www.w3.org/2000/xmlns/", "http://www.w3.org/2001/XMLSchema-instance"));
      element1.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      element1.Attributes.Append(this.AddAttribute("srsName", "urn:ogc:def:crs:EPSG::4326"));
      XmlElement element2 = this._XmlDocument.CreateElement("gml", "posList", "http://www.opengis.net/gml/3.2");
      if (gmlDimension == GmlDimension.Output3D)
        element1.Attributes.Append(this.AddAttribute("srsDimension", "3"));
      element2.InnerText = gmlPosList;
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private XmlElement CreatePolygon(GeoPolygon geoPolygon, GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("gml", "Polygon", "http://www.opengis.net/gml/3.2");
      element1.Attributes.Append(this.AddAttribute("xmlns", "gml", "http://www.w3.org/2000/xmlns/", "http://www.opengis.net/gml/3.2"));
      element1.Attributes.Append(this.AddAttribute("xmlns", "xsi", "http://www.w3.org/2000/xmlns/", "http://www.w3.org/2001/XMLSchema-instance"));
      element1.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      element1.Attributes.Append(this.AddAttribute("srsName", "urn:ogc:def:crs:EPSG::4326"));
      XmlElement element2 = this._XmlDocument.CreateElement("gml", "exterior", "http://www.opengis.net/gml/3.2");
      XmlElement element3 = this._XmlDocument.CreateElement("gml", "LinearRing", "http://www.opengis.net/gml/3.2");
      XmlElement element4 = this._XmlDocument.CreateElement("gml", "posList", "http://www.opengis.net/gml/3.2");
      if (gmlDimension == GmlDimension.Output3D)
        element1.Attributes.Append(this.AddAttribute("srsDimension", "3"));
      element4.InnerText = geoPolygon.AsGmlPosList(gmlDimension, (IFormatProvider) this._GmlCulture);
      element3.AppendChild((XmlNode) element4);
      element2.AppendChild((XmlNode) element3);
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private XmlElement CreatePoint(GeoPoint geoPoint, GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("gml", "Point", "http://www.opengis.net/gml/3.2");
      element1.Attributes.Append(this.AddAttribute("xmlns", "gml", "http://www.w3.org/2000/xmlns/", "http://www.opengis.net/gml/3.2"));
      element1.Attributes.Append(this.AddAttribute("xmlns", "xsi", "http://www.w3.org/2000/xmlns/", "http://www.w3.org/2001/XMLSchema-instance"));
      element1.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      element1.Attributes.Append(this.AddAttribute("srsName", "urn:ogc:def:crs:EPSG::4326"));
      XmlElement element2 = this._XmlDocument.CreateElement("gml", "pos", "http://www.opengis.net/gml/3.2");
      if (gmlDimension == GmlDimension.Output3D)
        element1.Attributes.Append(this.AddAttribute("srsDimension", "3"));
      element2.InnerText = geoPoint.AsGmlPos(gmlDimension);
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private XmlElement CreateCircle(GeoCircle geoCircle, GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("gml", "curveMember", "http://www.opengis.net/gml/3.2");
      XmlElement element2 = this._XmlDocument.CreateElement("gml", "Curve", "http://www.opengis.net/gml/3.2");
      element2.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      element2.Attributes.Append(this.AddAttribute("srsName", "urn:ogc:def:crs:EPSG::4326"));
      XmlElement element3 = this._XmlDocument.CreateElement("gml", "segments", "http://www.opengis.net/gml/3.2");
      XmlElement element4 = this._XmlDocument.CreateElement("gml", "CircleByCenterPoint", "http://www.opengis.net/gml/3.2");
      element4.Attributes.Append(this.AddAttribute("xmlns", "gml", "http://www.w3.org/2000/xmlns/", "http://www.opengis.net/gml/3.2"));
      element4.Attributes.Append(this.AddAttribute("xmlns", "xsi", "http://www.w3.org/2000/xmlns/", "http://www.w3.org/2001/XMLSchema-instance"));
      element4.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      element4.Attributes.Append(this.AddAttribute("srsName", "urn:ogc:def:crs:EPSG::4326"));
      element4.Attributes.Append(this.AddAttribute("numArc", "1"));
      XmlElement element5 = this._XmlDocument.CreateElement("gml", "pos", "http://www.opengis.net/gml/3.2");
      if (gmlDimension == GmlDimension.Output3D)
        element4.Attributes.Append(this.AddAttribute("srsDimension", "3"));
      element5.InnerText = geoCircle.AsGmlPos(gmlDimension);
      element4.AppendChild((XmlNode) element5);
      XmlElement element6 = this._XmlDocument.CreateElement("gml", "radius", "http://www.opengis.net/gml/3.2");
      element6.Attributes.Append(this.AddAttribute("uom", "m"));
      element6.InnerText = geoCircle.AsGmlRadius(LinearDistanceUnits.Metres);
      element4.AppendChild((XmlNode) element6);
      element3.AppendChild((XmlNode) element4);
      element2.AppendChild((XmlNode) element3);
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private XmlElement CreateArc(GeoArc geoArc, GmlDimension gmlDimension)
    {
      XmlElement element1 = this._XmlDocument.CreateElement("gml", "curveMember", "http://www.opengis.net/gml/3.2");
      XmlElement element2 = this._XmlDocument.CreateElement("gml", "Curve", "http://www.opengis.net/gml/3.2");
      element2.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      element2.Attributes.Append(this.AddAttribute("srsName", "urn:ogc:def:crs:EPSG::4326"));
      XmlElement element3 = this._XmlDocument.CreateElement("gml", "segments", "http://www.opengis.net/gml/3.2");
      XmlElement element4 = this._XmlDocument.CreateElement("gml", "ArcByCenterPoint", "http://www.opengis.net/gml/3.2");
      element4.Attributes.Append(this.AddAttribute("xmlns", "gml", "http://www.w3.org/2000/xmlns/", "http://www.opengis.net/gml/3.2"));
      element4.Attributes.Append(this.AddAttribute("xmlns", "xsi", "http://www.w3.org/2000/xmlns/", "http://www.w3.org/2001/XMLSchema-instance"));
      element4.Attributes.Append(this.AddAttribute("gml", "id", "http://www.opengis.net/gml/3.2", Guid.NewGuid().ToString()));
      element4.Attributes.Append(this.AddAttribute("srsName", "urn:ogc:def:crs:EPSG::4326"));
      element4.Attributes.Append(this.AddAttribute("numArc", "1"));
      XmlElement element5 = this._XmlDocument.CreateElement("gml", "pos", "http://www.opengis.net/gml/3.2");
      if (gmlDimension == GmlDimension.Output3D)
        element4.Attributes.Append(this.AddAttribute("srsDimension", "3"));
      element5.InnerText = geoArc.AsGmlPosCentreCoordinate(gmlDimension);
      element4.AppendChild((XmlNode) element5);
      XmlElement element6 = this._XmlDocument.CreateElement("gml", "radius", "http://www.opengis.net/gml/3.2");
      element6.Attributes.Append(this.AddAttribute("uom", "m"));
      element6.InnerText = geoArc.AsGmlRadius(LinearDistanceUnits.Metres);
      element4.AppendChild((XmlNode) element6);
      CompassBearing compassBearing = geoArc.StartAngle;
      double num1 = compassBearing.AsDegrees();
      compassBearing = geoArc.EndAngle;
      double num2 = compassBearing.AsDegrees();
      if (num1 > num2)
        num1 -= 360.0;
      XmlElement element7 = this._XmlDocument.CreateElement("gml", "startAngle", "http://www.opengis.net/gml/3.2");
      element7.Attributes.Append(this.AddAttribute("uom", "deg"));
      element7.InnerText = num1.ToString();
      element4.AppendChild((XmlNode) element7);
      XmlElement element8 = this._XmlDocument.CreateElement("gml", "endAngle", "http://www.opengis.net/gml/3.2");
      element8.Attributes.Append(this.AddAttribute("uom", "deg"));
      element8.InnerText = num2.ToString();
      element4.AppendChild((XmlNode) element8);
      element3.AppendChild((XmlNode) element4);
      element2.AppendChild((XmlNode) element3);
      element1.AppendChild((XmlNode) element2);
      return element1;
    }

    private XmlAttribute AddAttribute(
      string prefix,
      string localName,
      string UriNamespace,
      string value)
    {
      XmlAttribute attribute = this._XmlDocument.CreateAttribute(prefix, localName, UriNamespace);
      attribute.Value = value;
      return attribute;
    }

    private XmlAttribute AddAttribute(string localName, string value)
    {
      XmlAttribute attribute = this._XmlDocument.CreateAttribute(localName);
      attribute.Value = value;
      return attribute;
    }
  }
}
