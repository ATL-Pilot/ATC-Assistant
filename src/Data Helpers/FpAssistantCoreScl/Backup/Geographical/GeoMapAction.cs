// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Geographical.GeoMapAction
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;

namespace FpAssistantCore.Geographical
{
  public class GeoMapAction : GeoMapElement
  {
    private readonly GeoMapElementActions _GeoMapElementActions;

    public GeoMapAction(GeoMapElementActions geoMapElementActions) => this._GeoMapElementActions = geoMapElementActions;

    public GeoMapElementActions Action => this._GeoMapElementActions;

    public static GeoMapElement EraseAll() => (GeoMapElement) new GeoMapAction(GeoMapElementActions.EraseAllMapElements);

    public static GeoMapElement EraseMapElementByUniqueId(Guid id)
    {
      GeoMapAction geoMapAction = new GeoMapAction(GeoMapElementActions.EraseMapElementByUniqueId);
      geoMapAction.UniqueId = id;
      return (GeoMapElement) geoMapAction;
    }
  }
}
