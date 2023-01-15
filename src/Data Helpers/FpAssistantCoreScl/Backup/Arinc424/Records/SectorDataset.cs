// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.Arinc424.Records.SectorDataset
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using System;

namespace FpAssistantCore.Arinc424.Records
{
  public struct SectorDataset : IEquatable<SectorDataset>
  {
    private string _Bearing;
    private string _Altitude;
    private string _Radius;

    public string Bearing
    {
      get => this._Bearing;
      set => this._Bearing = value;
    }

    public string Altitude
    {
      get => this._Altitude;
      set => this._Altitude = value;
    }

    public string Radius
    {
      get => this._Radius;
      set => this._Radius = value;
    }

    public override bool Equals(object obj) => obj != null && obj is SectorDataset sectorDataset && this._Bearing == sectorDataset.Bearing && this._Altitude == sectorDataset.Altitude && this._Radius == sectorDataset.Radius;

    public override int GetHashCode() => (this._Bearing + this._Altitude + this._Radius).GetHashCode();

    public static bool operator ==(SectorDataset left, SectorDataset right) => left.Equals(right);

    public static bool operator !=(SectorDataset left, SectorDataset right) => !(left == right);

    public bool Equals(SectorDataset other) => this.Equals((object) other);
  }
}
