// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Aerodromes.AerodromeSurfaces
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FpAssistantCore.Aerodromes
{
  public abstract class AerodromeSurfaces : BaseObjectAerodromeSurfaces
  {
    private readonly BaseObjectAerodromeSurfaces.AerodromeCriteria _AerodromeCriteria;
    private Dictionary<string, Runway> _Runways = new Dictionary<string, Runway>();
    protected CoordinateSystem _CoordinateSystem;

    public AerodromeSurfaces(
      BaseObjectAerodromeSurfaces.AerodromeCriteria aerodromeCriteria)
      : base(aerodromeCriteria)
    {
      this._AerodromeCriteria = aerodromeCriteria;
    }

    public AerodromeSurfaces.AircraftCategoryOption AircraftCategory { get; set; }

    [JsonInclude]
    public GeoCoordinate Arp { get; set; }

    [JsonInclude]
    public LinearDistance AerdromeElevation { get; set; }

    [JsonInclude]
    public Dictionary<string, Runway> Runways
    {
      get => this._Runways;
      set => this._Runways = value;
    }

    public void SetCoordinateSystem(CoordinateSystem coordinateSystem) => this._CoordinateSystem = coordinateSystem;

    public void AddRunway(Runway runway)
    {
      if (runway == null)
        throw new ArgumentNullException(nameof (runway));
      if (this.FindRunwayByIdentifier(runway.Identifier).found)
        throw new ArgumentException("Runway identifier already in Aerodrome", nameof (runway));
      this._Runways.Add(runway.Identifier, runway);
    }

    public (bool found, Runway runway) FindRunwayByIdentifier(string indentifier) => this._Runways.ContainsKey(indentifier) ? (true, this._Runways[indentifier]) : (false, new Runway(""));

    public void SaveParameters(string filename)
    {
      JsonSerializerOptions options = new JsonSerializerOptions()
      {
        WriteIndented = true,
        IncludeFields = true
      };
      string contents = JsonSerializer.Serialize((object) this, this.GetType(), options);
      File.WriteAllText(filename, contents);
    }

    public enum AircraftCategoryOption
    {
      CatA,
      CatB,
      CatC,
      CatD,
    }
  }
}
