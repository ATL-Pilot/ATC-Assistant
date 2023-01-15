// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Aerodromes.AerodromeAnnex14Surfaces
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FpAssistantCore.Aerodromes
{
  public class AerodromeAnnex14Surfaces : AerodromeSurfaces
  {
    private AerodromeAnnex14Surfaces.IcaoClassifcations _Classification;
    private AerodromeAnnex14Surfaces.RunwayCodes _RunwayCode;
    private readonly Point3d[] _Approach1stSectionConstructionPoints = new Point3d[4];
    private readonly Point3d[] _Approach2ndSectionConstructionPoints = new Point3d[4];
    private readonly Point3d[] _ApproachHorizontalSectionConstructionPoints = new Point3d[4];
    private LinearDistance _ApproachInnerEdgeLength;
    private LinearDistance _ApproachDistanceFromThr;
    private Percentage _ApproachDivergence;
    private LinearDistance _ApproachLength1stSection;
    private Percentage _ApproachSlope1stSection;
    private LinearDistance _ApproachLength2ndSection;
    private Percentage _ApproachSlope2ndSection;
    private LinearDistance _ApproachLengthHorizontalSection;
    private LinearDistance _ApproachTotalApproachLength;
    private LinearDistance _InnerHorizontalHeight;
    private LinearDistance _InnerHorizontalRadius;
    private LinearDistance _StripExtends;
    private LinearDistance _StripWidth;
    private Percentage _TransitionalSlope;

    public AerodromeAnnex14Surfaces(
      AerodromeAnnex14Surfaces.IcaoClassifcations classification,
      AerodromeAnnex14Surfaces.RunwayCodes runwayCode)
      : base(BaseObjectAerodromeSurfaces.AerodromeCriteria.IcaoAnnex14)
    {
      this._Classification = classification;
      this.RunwayCode = runwayCode;
      this.SetIcaoStripDefaultValues();
      this.SetIcaoApproachDefaultValues();
      this.SetIcaoTransitionalDefaultValues();
      this.SetIcaoInnerHorizontalDefaultValues();
    }

    [JsonInclude]
    public AerodromeAnnex14Surfaces.IcaoClassifcations Classification
    {
      get => this._Classification;
      set => this._Classification = value;
    }

    [JsonInclude]
    public AerodromeAnnex14Surfaces.RunwayCodes RunwayCode
    {
      get => this._RunwayCode;
      set => this._RunwayCode = this._Classification != AerodromeAnnex14Surfaces.IcaoClassifcations.PrecisionApproachCategoryIIorIII || value != AerodromeAnnex14Surfaces.RunwayCodes.Code1 && value != AerodromeAnnex14Surfaces.RunwayCodes.Code2 ? value : throw new NotImplementedException("Runway codes 1 or 2 not valid with Precision Approach CAT II or CAT III");
    }

    public static AerodromeAnnex14Surfaces LoadParameters(string filename) => File.Exists(filename) ? JsonSerializer.Deserialize<AerodromeAnnex14Surfaces>(File.ReadAllText(filename), new JsonSerializerOptions()
    {
      IncludeFields = true,
      PropertyNameCaseInsensitive = true
    }) : throw new FileNotFoundException(string.Format("File was not found: {0}", (object) filename));

    [JsonInclude]
    public LinearDistance ApproachInnerEdgeLength
    {
      get => this._ApproachInnerEdgeLength;
      set => this._ApproachInnerEdgeLength = value > new LinearDistance(0.0, LinearDistanceUnits.Metres) ? value : throw new ArgumentException("ApproachInnerEdgeLength invalid, must be greater than 0", nameof (ApproachInnerEdgeLength));
    }

    [JsonInclude]
    public LinearDistance ApproachDistanceFromThr
    {
      get => this._ApproachDistanceFromThr;
      set => this._ApproachDistanceFromThr = value > new LinearDistance(0.0, LinearDistanceUnits.Metres) ? value : throw new ArgumentException("ApproachDistanceFromThr invalid, must be greater than 0", nameof (ApproachDistanceFromThr));
    }

    [JsonInclude]
    public Percentage ApproachDivergence
    {
      get => this._ApproachDivergence;
      set => this._ApproachDivergence = value;
    }

    [JsonInclude]
    public LinearDistance ApproachLengthOfFirstSection
    {
      get => this._ApproachLength1stSection;
      set => this._ApproachLength1stSection = value > new LinearDistance(0.0, LinearDistanceUnits.Metres) ? value : throw new ArgumentException("ApproachLengthOfFirstSection invalid, must be greater than 0", nameof (ApproachLengthOfFirstSection));
    }

    [JsonInclude]
    public Percentage ApproachSlopeOfFirstSection
    {
      get => this._ApproachSlope1stSection;
      set => this._ApproachSlope1stSection = value;
    }

    [JsonInclude]
    public LinearDistance ApproachLengthOfSecondSection
    {
      get => this._ApproachLength2ndSection;
      set => this._ApproachLength2ndSection = !(value < new LinearDistance(0.0, LinearDistanceUnits.Metres)) ? value : throw new ArgumentException("ApproachLengthOfSecondSection invalid, must be 0 or greater", nameof (ApproachLengthOfSecondSection));
    }

    [JsonInclude]
    public Percentage ApproachSlopeOfSecondSection
    {
      get => this._ApproachSlope2ndSection;
      set => this._ApproachSlope2ndSection = value;
    }

    [JsonInclude]
    public LinearDistance ApproachLengthOfHorizontalSection
    {
      get => this._ApproachLengthHorizontalSection;
      set => this._ApproachLengthHorizontalSection = !(value < new LinearDistance(0.0, LinearDistanceUnits.Metres)) ? value : throw new ArgumentException("ApproachLengthOfSecondSection invalid, must be 0 or greater", nameof (ApproachLengthOfHorizontalSection));
    }

    [JsonIgnore]
    public int ApproachSectionCount => this._Classification == AerodromeAnnex14Surfaces.IcaoClassifcations.NonPrecisionApproach && (this._RunwayCode == AerodromeAnnex14Surfaces.RunwayCodes.Code3 || this._RunwayCode == AerodromeAnnex14Surfaces.RunwayCodes.Code4) || this._Classification == AerodromeAnnex14Surfaces.IcaoClassifcations.PrecisionApproachCategoryI || this._Classification == AerodromeAnnex14Surfaces.IcaoClassifcations.PrecisionApproachCategoryIIorIII ? 3 : 1;

    private void SetIcaoApproachDefaultValues()
    {
      this._ApproachDistanceFromThr = new LinearDistance(60.0, LinearDistanceUnits.Metres);
      this._ApproachDivergence = new Percentage(15.0);
      this._ApproachLength2ndSection = LinearDistance.ZeroMetres();
      this._ApproachSlope2ndSection = new Percentage(0.0);
      this._ApproachLengthHorizontalSection = LinearDistance.ZeroMetres();
      switch (this._Classification)
      {
        case AerodromeAnnex14Surfaces.IcaoClassifcations.NonInstrument:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
              this._ApproachInnerEdgeLength = new LinearDistance(60.0, LinearDistanceUnits.Metres);
              this._ApproachDistanceFromThr = new LinearDistance(30.0, LinearDistanceUnits.Metres);
              this._ApproachLength1stSection = new LinearDistance(1600.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(5.0);
              break;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._ApproachInnerEdgeLength = new LinearDistance(80.0, LinearDistanceUnits.Metres);
              this._ApproachLength1stSection = new LinearDistance(2500.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(4.0);
              break;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
              this._ApproachInnerEdgeLength = new LinearDistance(150.0, LinearDistanceUnits.Metres);
              this._ApproachLength1stSection = new LinearDistance(3000.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(3.33);
              break;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._ApproachInnerEdgeLength = new LinearDistance(150.0, LinearDistanceUnits.Metres);
              this._ApproachLength1stSection = new LinearDistance(3000.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(2.5);
              break;
          }
          this._ApproachDivergence = new Percentage(10.0);
          break;
        case AerodromeAnnex14Surfaces.IcaoClassifcations.NonPrecisionApproach:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._ApproachInnerEdgeLength = new LinearDistance(140.0, LinearDistanceUnits.Metres);
              this._ApproachLength1stSection = new LinearDistance(2500.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(3.33);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
              this._ApproachInnerEdgeLength = new LinearDistance(280.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(2.0);
              this._ApproachLength1stSection = new LinearDistance(3000.0, LinearDistanceUnits.Metres);
              this._ApproachLength2ndSection = new LinearDistance(3600.0, LinearDistanceUnits.Metres);
              this._ApproachSlope2ndSection = new Percentage(2.5);
              this._ApproachLengthHorizontalSection = new LinearDistance(8400.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._ApproachInnerEdgeLength = new LinearDistance(280.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(2.0);
              this._ApproachLength1stSection = new LinearDistance(3000.0, LinearDistanceUnits.Metres);
              this._ApproachLength2ndSection = new LinearDistance(3600.0, LinearDistanceUnits.Metres);
              this._ApproachSlope2ndSection = new Percentage(2.5);
              this._ApproachLengthHorizontalSection = new LinearDistance(8400.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
        case AerodromeAnnex14Surfaces.IcaoClassifcations.PrecisionApproachCategoryI:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._ApproachInnerEdgeLength = new LinearDistance(140.0, LinearDistanceUnits.Metres);
              this._ApproachLength1stSection = new LinearDistance(3000.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(2.5);
              this._ApproachLength2ndSection = new LinearDistance(12000.0, LinearDistanceUnits.Metres);
              this._ApproachSlope2ndSection = new Percentage(3.0);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._ApproachInnerEdgeLength = new LinearDistance(280.0, LinearDistanceUnits.Metres);
              this._ApproachLength1stSection = new LinearDistance(3000.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(2.0);
              this._ApproachLength2ndSection = new LinearDistance(3600.0, LinearDistanceUnits.Metres);
              this._ApproachSlope2ndSection = new Percentage(2.5);
              this._ApproachLengthHorizontalSection = new LinearDistance(8400.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
        case AerodromeAnnex14Surfaces.IcaoClassifcations.PrecisionApproachCategoryIIorIII:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._ApproachInnerEdgeLength = new LinearDistance(280.0, LinearDistanceUnits.Metres);
              this._ApproachLength1stSection = new LinearDistance(3000.0, LinearDistanceUnits.Metres);
              this._ApproachSlope1stSection = new Percentage(2.0);
              this._ApproachLength2ndSection = new LinearDistance(3600.0, LinearDistanceUnits.Metres);
              this._ApproachSlope2ndSection = new Percentage(2.5);
              this._ApproachLengthHorizontalSection = new LinearDistance(8400.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
      }
    }

    public Point3d[] Approach1stSectionSurfaceConstructionPoints() => this._Approach1stSectionConstructionPoints;

    public Point3d[] Approach2ndSectionSurfaceConstructionPoints() => this._Approach2ndSectionConstructionPoints;

    public Point3d[] ApproachHorizontalSectionSurfaceConstructionPoints() => this._ApproachHorizontalSectionConstructionPoints;

    public GeoMapElementCollection ApproachSurfaces(
      string runwayIdentifier,
      GraphicalRepresentation graphicalRepresentation)
    {
      (bool found, Runway runway) runwayByIdentifier = this.FindRunwayByIdentifier(runwayIdentifier);
      int num = runwayByIdentifier.found ? 1 : 0;
      Runway runway = runwayByIdentifier.runway;
      if (num == 0)
        throw new ArgumentException("Runway identifier not found!", nameof (runwayIdentifier));
      string projectionZone = runway.StartAsGeoCoordinate().UTMWGS84ProjectionZone().GetDescription();
      ConstructApproachKeyPoints();
      GeoCoordinateElevationCollection coordinates1 = this._Approach1stSectionConstructionPoints.AsGeoCoordinateElevationCollection(projectionZone, this._CoordinateSystem);
      GeoCoordinateElevationCollection coordinates2 = (GeoCoordinateElevationCollection) null;
      GeoCoordinateElevationCollection coordinates3 = (GeoCoordinateElevationCollection) null;
      if (this.ApproachSectionCount > 1)
      {
        coordinates2 = this._Approach2ndSectionConstructionPoints.AsGeoCoordinateElevationCollection(projectionZone, this._CoordinateSystem);
        coordinates3 = this._ApproachHorizontalSectionConstructionPoints.AsGeoCoordinateElevationCollection(projectionZone, this._CoordinateSystem);
      }
      MapObjectProperties properties = ObjectMappingProperties.GetProperties(this.GetType().Name);
      GeoMapElementCollection elementCollection = new GeoMapElementCollection();
      if (graphicalRepresentation != GraphicalRepresentation.Lines)
      {
        if (graphicalRepresentation != GraphicalRepresentation.Polygons)
          throw new NotImplementedException("GraphicalRespresentation enum value is not currently supported in AerodromeAnnex14Surfaces");
        elementCollection.Add((IGeoMapElement) new GeoPolygon(coordinates1, properties));
        if (this.ApproachSectionCount > 1)
        {
          elementCollection.Add((IGeoMapElement) new GeoPolygon(coordinates2, properties));
          elementCollection.Add((IGeoMapElement) new GeoPolygon(coordinates3, properties));
        }
      }
      else
      {
        coordinates1.Add(coordinates1[0]);
        elementCollection.Add((IGeoMapElement) new GeoLineString(coordinates1));
        if (this.ApproachSectionCount > 1)
        {
          coordinates2.Add(coordinates2[0]);
          elementCollection.Add((IGeoMapElement) new GeoLineString(coordinates2));
          coordinates3.Add(coordinates3[0]);
          elementCollection.Add((IGeoMapElement) new GeoLineString(coordinates3));
        }
      }
      elementCollection.UpdateIdNameDescription(true, string.Format("{0}-Approach Surface", (object) runwayIdentifier), nameof (AerodromeAnnex14Surfaces));
      return elementCollection;

      void ConstructApproachKeyPoints()
      {
        LinearDistance approachDistanceFromThr = this.ApproachDistanceFromThr;
        approachDistanceFromThr = approachDistanceFromThr.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
        double num1 = approachDistanceFromThr.Value;
        LinearDistance approachInnerEdgeLength = this.ApproachInnerEdgeLength;
        approachInnerEdgeLength = approachInnerEdgeLength.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
        double num2 = approachInnerEdgeLength.Value;
        LinearDistance lengthOfFirstSection = this.ApproachLengthOfFirstSection;
        lengthOfFirstSection = lengthOfFirstSection.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
        double num3 = lengthOfFirstSection.Value;
        LinearDistance lengthOfSecondSection = this.ApproachLengthOfSecondSection;
        lengthOfSecondSection = lengthOfSecondSection.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
        double num4 = lengthOfSecondSection.Value;
        LinearDistance horizontalSection = this.ApproachLengthOfHorizontalSection;
        horizontalSection = horizontalSection.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
        double num5 = horizontalSection.Value;
        LinearDistance linearDistance = runway.StartElevation();
        linearDistance = linearDistance.ConvertTo(this._CoordinateSystem.CoordinateSystemUnit);
        double num6 = linearDistance.Value;
        this._Approach1stSectionConstructionPoints[0] = new Point3d(0.0, 0.0, 0.0).GetTranslated(-num1, -num2 / 2.0);
        this._Approach1stSectionConstructionPoints[1] = this._Approach1stSectionConstructionPoints[0].GetMirror(Axes.XAxis);
        this._Approach1stSectionConstructionPoints[2].X = -num1 + -num3;
        this._Approach1stSectionConstructionPoints[2].Y = this._Approach1stSectionConstructionPoints[1].Y + this._ApproachDivergence.PercentageOf(num3);
        this._Approach1stSectionConstructionPoints[3] = this._Approach1stSectionConstructionPoints[2].GetMirror(Axes.XAxis);
        this._Approach1stSectionConstructionPoints[0].Z = this._Approach1stSectionConstructionPoints[1].Z = num6;
        double num7 = num6 + this._ApproachSlope1stSection.PercentageOf(num3);
        this._Approach1stSectionConstructionPoints[3].Z = this._Approach1stSectionConstructionPoints[2].Z = num7;
        if (this.ApproachSectionCount > 1)
        {
          this._Approach2ndSectionConstructionPoints[0] = this._Approach1stSectionConstructionPoints[3];
          this._Approach2ndSectionConstructionPoints[1] = this._Approach1stSectionConstructionPoints[2];
          this._Approach2ndSectionConstructionPoints[2].X = this._Approach2ndSectionConstructionPoints[1].X + -num4;
          this._Approach2ndSectionConstructionPoints[2].Y = this._Approach2ndSectionConstructionPoints[1].Y + this._ApproachDivergence.PercentageOf(num4);
          this._Approach2ndSectionConstructionPoints[3] = this._Approach2ndSectionConstructionPoints[2].GetMirror(Axes.XAxis);
          double num8 = num7 + this._ApproachSlope2ndSection.PercentageOf(num4);
          this._Approach2ndSectionConstructionPoints[3].Z = this._Approach2ndSectionConstructionPoints[2].Z = num8;
          this._ApproachHorizontalSectionConstructionPoints[0] = this._Approach2ndSectionConstructionPoints[3];
          this._ApproachHorizontalSectionConstructionPoints[1] = this._Approach2ndSectionConstructionPoints[2];
          this._ApproachHorizontalSectionConstructionPoints[2].X = this._ApproachHorizontalSectionConstructionPoints[1].X + -num5;
          this._ApproachHorizontalSectionConstructionPoints[2].Y = this._ApproachHorizontalSectionConstructionPoints[1].Y + this._ApproachDivergence.PercentageOf(num5);
          this._ApproachHorizontalSectionConstructionPoints[2].Z = num8;
          this._ApproachHorizontalSectionConstructionPoints[3] = this._ApproachHorizontalSectionConstructionPoints[2].GetMirror(Axes.XAxis);
        }
        GridCoordinate gridCoordinate1 = new GridCoordinate(runway.StartAsGeoCoordinate(), this._CoordinateSystem.MapProjection, projectionZone);
        GridCoordinate gridCoordinate2 = new GridCoordinate(runway.EndAsGeoCoordinate(), this._CoordinateSystem.MapProjection, projectionZone);
        double degrees = gridCoordinate1.CartesianAngleTo(gridCoordinate2);
        this._Approach1stSectionConstructionPoints.Rotate2DByDegrees(degrees);
        Point3d[] constructionPoints1 = this._Approach1stSectionConstructionPoints;
        double x1 = gridCoordinate1.XYCoordinate.X;
        Point3d xyCoordinate = gridCoordinate1.XYCoordinate;
        double y1 = xyCoordinate.Y;
        constructionPoints1.Translate(x1, y1);
        this._Approach2ndSectionConstructionPoints.Rotate2DByDegrees(degrees);
        Point3d[] constructionPoints2 = this._Approach2ndSectionConstructionPoints;
        xyCoordinate = gridCoordinate1.XYCoordinate;
        double x2 = xyCoordinate.X;
        xyCoordinate = gridCoordinate1.XYCoordinate;
        double y2 = xyCoordinate.Y;
        constructionPoints2.Translate(x2, y2);
        this._ApproachHorizontalSectionConstructionPoints.Rotate2DByDegrees(degrees);
        Point3d[] constructionPoints3 = this._ApproachHorizontalSectionConstructionPoints;
        xyCoordinate = gridCoordinate1.XYCoordinate;
        double x3 = xyCoordinate.X;
        xyCoordinate = gridCoordinate1.XYCoordinate;
        double y3 = xyCoordinate.Y;
        constructionPoints3.Translate(x3, y3);
      }
    }

    [JsonInclude]
    public LinearDistance InnerHorizontalHeight
    {
      get => this._InnerHorizontalHeight;
      set => this._InnerHorizontalHeight = value > new LinearDistance(0.0, LinearDistanceUnits.Metres) ? value : throw new ArgumentException("InnerHorizontalHeight invalid, must be greater than 0", nameof (InnerHorizontalHeight));
    }

    [JsonInclude]
    public LinearDistance InnerHorizontalRadius
    {
      get => this._InnerHorizontalRadius;
      set => this._InnerHorizontalRadius = value > new LinearDistance(0.0, LinearDistanceUnits.Metres) ? value : throw new ArgumentException("InnerHorizontalRadius invalid, must be greater than 0", nameof (InnerHorizontalRadius));
    }

    private void SetIcaoInnerHorizontalDefaultValues()
    {
      this._InnerHorizontalHeight = new LinearDistance(45.0, LinearDistanceUnits.Metres);
      switch (this._Classification)
      {
        case AerodromeAnnex14Surfaces.IcaoClassifcations.NonInstrument:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
              this._InnerHorizontalRadius = new LinearDistance(2000.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._InnerHorizontalRadius = new LinearDistance(2500.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
              this._InnerHorizontalRadius = new LinearDistance(4000.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._InnerHorizontalRadius = new LinearDistance(4000.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
        case AerodromeAnnex14Surfaces.IcaoClassifcations.NonPrecisionApproach:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
              this._InnerHorizontalRadius = new LinearDistance(3500.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._InnerHorizontalRadius = new LinearDistance(3500.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
              this._InnerHorizontalRadius = new LinearDistance(4000.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._InnerHorizontalRadius = new LinearDistance(4000.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
        case AerodromeAnnex14Surfaces.IcaoClassifcations.PrecisionApproachCategoryI:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
              this._InnerHorizontalRadius = new LinearDistance(3500.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._InnerHorizontalRadius = new LinearDistance(3500.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
              this._InnerHorizontalRadius = new LinearDistance(4000.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._InnerHorizontalRadius = new LinearDistance(4000.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
        case AerodromeAnnex14Surfaces.IcaoClassifcations.PrecisionApproachCategoryIIorIII:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
              this._InnerHorizontalRadius = new LinearDistance(4000.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._InnerHorizontalRadius = new LinearDistance(4000.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
      }
    }

    public GeoMapElementCollection InnerHorizontalSurfaces(
      string runwayIdentifier,
      GraphicalRepresentation graphicalRepresentation)
    {
      (bool found, Runway runway1) = this.FindRunwayByIdentifier(runwayIdentifier);
      if (!found)
        throw new ArgumentException("Runway identifier not found!", nameof (runwayIdentifier));
      GeoCoordinateBasic geoCoordinateBasic1 = runway1.EndAsGeoCoordinateBasic().WGS84Destination(runway1.ForwardBearing(), this._StripExtends);
      GeoCoordinateBasic geoCoordinateBasic2 = runway1.StartAsGeoCoordinateBasic().WGS84Destination(runway1.ReverseBearing(), this._StripExtends);
      Runway runway2 = new Runway("tmp");
      runway2.AddRunwayCoordinate(new GeoCoordinateElevation(geoCoordinateBasic2, runway1.StartElevation()));
      runway2.AddRunwayCoordinate(new GeoCoordinateElevation(geoCoordinateBasic1, runway1.EndElevation()));
      foreach (GeoCoordinateElevation centreLineCoordinate in (Collection<GeoCoordinateElevation>) runway1.CentreLineCoordinates)
        runway2.AddRunwayCoordinate(centreLineCoordinate);
      return runway2.Surfaces(this._StripWidth, graphicalRepresentation);
    }

    [JsonInclude]
    public LinearDistance StripExtends
    {
      get => this._StripExtends;
      set => this._StripExtends = value > new LinearDistance(0.0, LinearDistanceUnits.Feet) ? value : throw new ArgumentException("StripExtends invalid, must be greater than 0", nameof (StripExtends));
    }

    [JsonInclude]
    public LinearDistance StripWidth
    {
      get => this._StripWidth;
      set => this._StripWidth = value > new LinearDistance(0.0, LinearDistanceUnits.Feet) ? value : throw new ArgumentException("StripWidth invalid, must be greater than 0", nameof (StripWidth));
    }

    private void SetIcaoStripDefaultValues()
    {
      switch (this._RunwayCode)
      {
        case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
          this._StripExtends = this._Classification != AerodromeAnnex14Surfaces.IcaoClassifcations.NonInstrument ? new LinearDistance(60.0, LinearDistanceUnits.Metres) : new LinearDistance(30.0, LinearDistanceUnits.Metres);
          break;
        case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
          this._StripExtends = new LinearDistance(60.0, LinearDistanceUnits.Metres);
          break;
        case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
          this._StripExtends = new LinearDistance(60.0, LinearDistanceUnits.Metres);
          break;
        case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
          this._StripExtends = new LinearDistance(60.0, LinearDistanceUnits.Metres);
          break;
        default:
          throw new NotImplementedException("Runway code not supported! - SetIcaoStripDefaultValues");
      }
      switch (this._Classification)
      {
        case AerodromeAnnex14Surfaces.IcaoClassifcations.NonInstrument:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
              this._StripWidth = new LinearDistance(30.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._StripWidth = new LinearDistance(40.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
              this._StripWidth = new LinearDistance(75.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._StripWidth = new LinearDistance(75.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
        case AerodromeAnnex14Surfaces.IcaoClassifcations.NonPrecisionApproach:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._StripWidth = new LinearDistance(70.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._StripWidth = new LinearDistance(140.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
        case AerodromeAnnex14Surfaces.IcaoClassifcations.PrecisionApproachCategoryI:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._StripWidth = new LinearDistance(70.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._StripWidth = new LinearDistance(140.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
        case AerodromeAnnex14Surfaces.IcaoClassifcations.PrecisionApproachCategoryIIorIII:
          switch (this._RunwayCode)
          {
            case AerodromeAnnex14Surfaces.RunwayCodes.Code1:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code2:
              this._StripWidth = new LinearDistance(70.0, LinearDistanceUnits.Metres);
              return;
            case AerodromeAnnex14Surfaces.RunwayCodes.Code3:
            case AerodromeAnnex14Surfaces.RunwayCodes.Code4:
              this._StripWidth = new LinearDistance(140.0, LinearDistanceUnits.Metres);
              return;
            default:
              return;
          }
        default:
          throw new NotImplementedException("Runway classifcation not supported! - SetIcaoStripDefaultValues");
      }
    }

    public GeoMapElementCollection StripSurfaces(
      string runwayIdentifier,
      GraphicalRepresentation graphicalRepresentation)
    {
      (bool found, Runway runway1) = this.FindRunwayByIdentifier(runwayIdentifier);
      if (!found)
        throw new ArgumentException("Runway identifier not found!", nameof (runwayIdentifier));
      GeoCoordinateBasic geoCoordinateBasic1 = runway1.EndAsGeoCoordinateBasic().WGS84Destination(runway1.ForwardBearing(), this._StripExtends);
      GeoCoordinateBasic geoCoordinateBasic2 = runway1.StartAsGeoCoordinateBasic().WGS84Destination(runway1.ReverseBearing(), this._StripExtends);
      Runway runway2 = new Runway("tmp");
      runway2.AddRunwayCoordinate(new GeoCoordinateElevation(geoCoordinateBasic2, runway1.StartElevation()));
      runway2.AddRunwayCoordinate(new GeoCoordinateElevation(geoCoordinateBasic1, runway1.EndElevation()));
      foreach (GeoCoordinateElevation centreLineCoordinate in (Collection<GeoCoordinateElevation>) runway1.CentreLineCoordinates)
        runway2.AddRunwayCoordinate(centreLineCoordinate);
      return runway2.Surfaces(this._StripWidth, graphicalRepresentation);
    }

    [JsonInclude]
    public Percentage TransitionalSlope
    {
      get => this._TransitionalSlope;
      set => this._TransitionalSlope = value;
    }

    private void SetIcaoTransitionalDefaultValues()
    {
      if (this._Classification == AerodromeAnnex14Surfaces.IcaoClassifcations.NonInstrument && (this._RunwayCode == AerodromeAnnex14Surfaces.RunwayCodes.Code1 || this._RunwayCode == AerodromeAnnex14Surfaces.RunwayCodes.Code2))
        this._TransitionalSlope = new Percentage(20.0);
      else if (this._Classification == AerodromeAnnex14Surfaces.IcaoClassifcations.NonPrecisionApproach && (this._RunwayCode == AerodromeAnnex14Surfaces.RunwayCodes.Code1 || this._RunwayCode == AerodromeAnnex14Surfaces.RunwayCodes.Code2))
        this._TransitionalSlope = new Percentage(20.0);
      else
        this._TransitionalSlope = new Percentage(14.3);
    }

    public GeoMapElementCollection TransitionalSurfaces(
      string runwayIdentifier,
      GraphicalRepresentation graphicalRepresentation)
    {
      (bool found, Runway runway1) = this.FindRunwayByIdentifier(runwayIdentifier);
      if (!found)
        throw new ArgumentException("Runway identifier not found!", nameof (runwayIdentifier));
      GeoCoordinateBasic geoCoordinateBasic1 = runway1.EndAsGeoCoordinateBasic().WGS84Destination(runway1.ForwardBearing(), this._StripExtends);
      GeoCoordinateBasic geoCoordinateBasic2 = runway1.StartAsGeoCoordinateBasic().WGS84Destination(runway1.ReverseBearing(), this._StripExtends);
      Runway runway2 = new Runway("tmp");
      runway2.AddRunwayCoordinate(new GeoCoordinateElevation(geoCoordinateBasic2, runway1.StartElevation()));
      runway2.AddRunwayCoordinate(new GeoCoordinateElevation(geoCoordinateBasic1, runway1.EndElevation()));
      foreach (GeoCoordinateElevation centreLineCoordinate in (Collection<GeoCoordinateElevation>) runway1.CentreLineCoordinates)
        runway2.AddRunwayCoordinate(centreLineCoordinate);
      return runway2.Surfaces(this._StripWidth, graphicalRepresentation);
    }

    public enum IcaoClassifcations
    {
      NonInstrument,
      NonPrecisionApproach,
      PrecisionApproachCategoryI,
      PrecisionApproachCategoryIIorIII,
    }

    public enum RunwayCodes
    {
      Code1,
      Code2,
      Code3,
      Code4,
    }
  }
}
