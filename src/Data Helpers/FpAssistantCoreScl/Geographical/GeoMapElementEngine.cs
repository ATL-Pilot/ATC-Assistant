// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.GeoMapElementEngine
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ArincReader.Geographical
{
    public abstract class GeoMapElementEngine
    {
        protected abstract object CreateGeoPolygon(GeoPolygon geoPolygon);

        protected abstract object CreateGeoLine(GeoLine geoLine);

        protected abstract object CreateGeoLineString(GeoLineString geoLineString);

        protected abstract object CreateGeoArc(GeoArc geoArc);

        protected abstract object CreateGeoCircle(GeoCircle geoCircle);

        protected abstract object CreateGeoPoint(GeoPoint geoPoint);

        protected abstract object CreateGeoMapIcon(GeoMapIcon geoMapIcon);

        protected abstract object CreateGeoMapImage(GeoMapImage geoMapImage);

        protected abstract object CreateAction(GeoMapElementActions geoMapElementAction);

        public virtual List<GeoMapEngineElement> CreateGeoMapElements(
          GeoMapElementCollection geoMapElements)
        {
            List<GeoMapEngineElement> geoMapElements1 = new List<GeoMapEngineElement>();
            foreach (IGeoMapElement geoMapElement1 in (Collection<IGeoMapElement>)geoMapElements)
            {
                GeoMapElement geoMapElement2 = geoMapElement1 as GeoMapElement;
                GeoMapEngineElement mapEngineElement = new GeoMapEngineElement()
                {
                    EngineObject = this.CreateGeoMapElement(geoMapElement2),
                    UniqueId = geoMapElement2.UniqueId
                };
                if (mapEngineElement != null)
                    geoMapElements1.Add(mapEngineElement);
            }
            return geoMapElements1;
        }

        private object CreateGeoMapElement(GeoMapElement geoMapElement)
        {
            object geoMapElement1 = (object)null;
            switch (geoMapElement)
            {
                case GeoMapAction geoMapAction:
                    geoMapElement1 = this.CreateAction(geoMapAction.Action);
                    break;
                case GeoPoint geoPoint:
                    geoMapElement1 = this.CreateGeoPoint(geoPoint);
                    break;
                case GeoLine geoLine:
                    geoMapElement1 = this.CreateGeoLine(geoLine);
                    break;
                case GeoMapIcon geoMapIcon:
                    geoMapElement1 = this.CreateGeoMapIcon(geoMapIcon);
                    break;
                case GeoArc geoArc:
                    geoMapElement1 = this.CreateGeoArc(geoArc);
                    break;
                case GeoCircle geoCircle:
                    geoMapElement1 = this.CreateGeoCircle(geoCircle);
                    break;
                case GeoPolygon geoPolygon:
                    geoMapElement1 = this.CreateGeoPolygon(geoPolygon);
                    break;
                case GeoMapImage geoMapImage:
                    geoMapElement1 = this.CreateGeoMapImage(geoMapImage);
                    break;
                case GeoLineString geoLineString:
                    geoMapElement1 = this.CreateGeoLineString(geoLineString);
                    break;
            }
            return geoMapElement1;
        }
    }
}
