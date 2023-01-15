// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.ProjectedCoordinateSystem
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using System;
using System.Xml;

namespace FpAssistantCore.Geographical
{
  public class ProjectedCoordinateSystem
  {
    public const string XmlTag = "ProjectedCoordinateSystem";
    private const string XmlTagId = "id";
    private const string XmlTagName = "Name";
    private const string XmlTagDescription = "Description";
    private const string XmlTagWestBoundLongitude = "WestBoundLongitude";
    private const string XmlTagEastBoundLongitude = "EastBoundLongitude";
    private const string XmlTagSouthBoundLatitude = "SouthBoundLatitude";
    private const string XmlTagNorthBoundLatitude = "NorthBoundLatitude";
    private const string XmlTagAxis = "Axis";
    private const string XmlTagUom = "uom";
    private const string XmlTagDatumId = "DatumId";
    private const string XmlTagDatumIdNad83 = "NAD83";
    private const string XmlTagDatumIdWgs84 = "WGS84";
    private readonly string _Identifier;
    private readonly string _ProjectionName;
    private readonly string _Description;
    private readonly double _WestBoundLongitude;
    private readonly double _EastBoundLongitude;
    private readonly double _SouthBoundLatitude;
    private readonly double _NorthBoundLatitude;
    private readonly CoordinateSystemUnits _CoordinateSystemUnit;
    private readonly MapDatums _MapDatum;

    public ProjectedCoordinateSystem(XmlTextReader xmlTextReader)
    {
      if (!xmlTextReader.IsStartElement() || !(xmlTextReader.Name == nameof (ProjectedCoordinateSystem)))
        return;
      bool flag = true;
      for (int index = 0; index < xmlTextReader.AttributeCount; ++index)
      {
        xmlTextReader.MoveToNextAttribute();
        if (xmlTextReader.Name == "id")
        {
          this._Identifier = xmlTextReader.Value;
          break;
        }
      }
      xmlTextReader.MoveToElement();
      while (xmlTextReader.Read())
      {
        if (xmlTextReader.NodeType == XmlNodeType.EndElement && xmlTextReader.LocalName == nameof (ProjectedCoordinateSystem))
          flag = false;
        else if (xmlTextReader.NodeType == XmlNodeType.Element)
        {
          switch (xmlTextReader.LocalName)
          {
            case "Axis":
              xmlTextReader.MoveToNextAttribute();
              if (xmlTextReader.Name == "uom")
              {
                if (string.Equals(xmlTextReader.Value, "METER", StringComparison.OrdinalIgnoreCase))
                {
                  this._CoordinateSystemUnit = CoordinateSystemUnits.Metres;
                  continue;
                }
                if (!string.Equals(xmlTextReader.Value, "FOOT", StringComparison.OrdinalIgnoreCase))
                  throw new NotImplementedException(string.Format("UOM {0} in XML element {1} not supported, contact Developer", (object) xmlTextReader.Value, (object) xmlTextReader.Name));
                this._CoordinateSystemUnit = CoordinateSystemUnits.Feet;
                continue;
              }
              continue;
            case "DatumId":
              xmlTextReader.Read();
              if (xmlTextReader.NodeType == XmlNodeType.Text & flag)
              {
                string str = xmlTextReader.Value;
                if (!(str == "NAD83"))
                {
                  if (!(str == "WGS84"))
                    throw new NotImplementedException(string.Format("Datum {0} in XML element {1} not supported, contact Developer", (object) xmlTextReader.Value, (object) xmlTextReader.Name));
                  this._MapDatum = MapDatums.Wgs84;
                  continue;
                }
                this._MapDatum = MapDatums.Nad83;
                continue;
              }
              continue;
            case nameof (Description):
              xmlTextReader.Read();
              if (xmlTextReader.NodeType == XmlNodeType.Text)
              {
                this._Description = xmlTextReader.Value;
                continue;
              }
              continue;
            case nameof (EastBoundLongitude):
              xmlTextReader.Read();
              if (xmlTextReader.NodeType == XmlNodeType.Text & flag)
              {
                this._EastBoundLongitude = ConvertToDouble(xmlTextReader.Value);
                continue;
              }
              continue;
            case "Name":
              xmlTextReader.Read();
              if (xmlTextReader.NodeType == XmlNodeType.Text && string.IsNullOrEmpty(this._ProjectionName))
              {
                this._ProjectionName = xmlTextReader.Value;
                continue;
              }
              continue;
            case nameof (NorthBoundLatitude):
              xmlTextReader.Read();
              if (xmlTextReader.NodeType == XmlNodeType.Text & flag)
              {
                this._NorthBoundLatitude = ConvertToDouble(xmlTextReader.Value);
                continue;
              }
              continue;
            case nameof (SouthBoundLatitude):
              xmlTextReader.Read();
              if (xmlTextReader.NodeType == XmlNodeType.Text & flag)
              {
                this._SouthBoundLatitude = ConvertToDouble(xmlTextReader.Value);
                continue;
              }
              continue;
            case nameof (WestBoundLongitude):
              xmlTextReader.Read();
              if (xmlTextReader.NodeType == XmlNodeType.Text & flag)
              {
                this._WestBoundLongitude = ConvertToDouble(xmlTextReader.Value);
                continue;
              }
              continue;
            default:
              continue;
          }
        }
      }

      double ConvertToDouble(string value)
      {
        double num = 0.0;
        (bool status, double value) = Utilities.ConvertStringToDouble(xmlTextReader.Value);
        if (status)
          num = value;
        return num;
      }
    }

    public string ProjectionName => this._ProjectionName;

    public MapDatums Datum => this._MapDatum;

    public string Identifier => this._Identifier;

    public string Description => this._Description;

    public CoordinateSystemUnits Uom => this._CoordinateSystemUnit;

    public double WestBoundLongitude => this._WestBoundLongitude;

    public double EastBoundLongitude => this._EastBoundLongitude;

    public double SouthBoundLatitude => this._SouthBoundLatitude;

    public double NorthBoundLatitude => this._NorthBoundLatitude;
  }
}
