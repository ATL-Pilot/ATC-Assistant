// Decompiled with JetBrains decompiler
// Type: ArincReader.Geographical.GeoMapElement
// Assembly: ArincReaderScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\ArincReaderScl.dll

using ArincReader.General;
using System;
using System.Collections.Generic;

namespace ArincReader.Geographical
{
    public abstract class GeoMapElement : IGeoMapElement
    {
        private readonly Dictionary<string, string> _DataList = new Dictionary<string, string>();

        public Guid UniqueId { get; set; }

        public FpaColour Color { get; set; }

        public int Thickness { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> DataList => this._DataList;

        public void AddDataList(string uniqueKey, string value) => this._DataList.Add(uniqueKey, value);

        public virtual void AssignProperties(MapObjectProperties mapObjectProperties)
        {
            this.Color = mapObjectProperties != null ? mapObjectProperties.StrokeColour : throw new NullReferenceException(nameof(mapObjectProperties));
            this.Thickness = mapObjectProperties.StrokeThickness;
        }

        public virtual void Draw()
        {
        }
    }
}
