// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.GeoMapElementCollection
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;
using System.Collections.ObjectModel;

namespace FpAssistantCore.Geographical
{
  public class GeoMapElementCollection : Collection<IGeoMapElement>
  {
    public void Add(GeoMapElementCollection geoMapElements)
    {
      if (geoMapElements == null)
        throw new ArgumentNullException(nameof (geoMapElements));
      foreach (IGeoMapElement geoMapElement in (Collection<IGeoMapElement>) geoMapElements)
      {
        if (!this.Contains(geoMapElement))
          this.Add(geoMapElement);
      }
    }

    public void UpdateIdNameDescription(bool updateId, string name, string description)
    {
      foreach (GeoMapElement geoMapElement in (Collection<IGeoMapElement>) this)
      {
        if (updateId)
          geoMapElement.UniqueId = Guid.NewGuid();
        geoMapElement.Name = name;
        geoMapElement.Description = description;
      }
    }
  }
}
