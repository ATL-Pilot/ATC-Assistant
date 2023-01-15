// Decompiled with JetBrains decompiler
// Type: FpAssistantCore.GeneralAviation.ADSBexchangeFeed
// Assembly: FpAssistantCoreScl, Version=2021.10.8.1, Culture=neutral, PublicKeyToken=1928072adf1fc70c
// MVID: ED7682A4-0062-40BE-BD58-F87033EB2068
// Assembly location: C:\Users\Me\OneDrive\Documents\Visual Studio 2022\Projects\CLT Clearence\CLT Clearence\bin\Debug\FpAssistantCoreScl.dll

using FpAssistantCore.General;
using FpAssistantCore.Geographical;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FpAssistantCore.GeneralAviation
{
  [Obfuscation(ApplyToMembers = true, Exclude = true)]
  [ExcludeFromCodeCoverage]
  public class ADSBexchangeFeed
  {
    private readonly Dictionary<int, ADSBexchangeFeed.AircraftFlight> _AircraftFlightDictionary = new Dictionary<int, ADSBexchangeFeed.AircraftFlight>();
    private string _SpatialQuery = string.Empty;
    private readonly string urlOfADSBFeed = "https://public-api.adsbexchange.com/VirtualRadar/AircraftList.json";

    public ADSBexchangeFeed()
    {
      this.ReadAdsbFeed();
      this._SpatialQuery = "";
    }

    public ADSBexchangeFeed(GeoCoordinateBasic centrePoint, LinearDistance searchRadius) => this.ReadAdsbFeedByPointAndRadius(centrePoint, searchRadius);

    public AircraftFlightData FindByCallsign(string callsign)
    {
      foreach (ADSBexchangeFeed.AircraftFlight aircraftFlight in this._AircraftFlightDictionary.Values)
      {
        if (aircraftFlight.Call == callsign)
          return this.CreateAircraftFlightData(aircraftFlight);
      }
      return (AircraftFlightData) null;
    }

    public List<AircraftFlightData> FindByCoordinateAndRadius(
      GeoCoordinateBasic centreCoordinate,
      LinearDistance radiusAroundPoint)
    {
      List<AircraftFlightData> coordinateAndRadius = new List<AircraftFlightData>();
      foreach (ADSBexchangeFeed.AircraftFlight aircraftFlight in this._AircraftFlightDictionary.Values)
      {
        double? nullable = aircraftFlight.Latitude;
        double valueOrDefault1 = nullable.GetValueOrDefault();
        nullable = aircraftFlight.Longitude;
        double valueOrDefault2 = nullable.GetValueOrDefault();
        LinearDistance linearDistance = GeoCoordinate.DistanceBetweenSpherical(centreCoordinate.Latitude, centreCoordinate.Longitude, valueOrDefault1, valueOrDefault2);
        if (linearDistance.Value < radiusAroundPoint.ConvertTo(linearDistance.ValueUnit).Value)
          coordinateAndRadius.Add(this.CreateAircraftFlightData(aircraftFlight));
      }
      return coordinateAndRadius;
    }

    public List<AircraftFlightData> All()
    {
      List<AircraftFlightData> aircraftFlightDataList = new List<AircraftFlightData>();
      foreach (ADSBexchangeFeed.AircraftFlight aircraftFlight in this._AircraftFlightDictionary.Values)
        aircraftFlightDataList.Add(this.CreateAircraftFlightData(aircraftFlight));
      return aircraftFlightDataList;
    }

    public void Refresh(GeoCoordinateBasic centrePoint, LinearDistance searchRadius)
    {
      double num = centrePoint.Latitude;
      string str1 = num.ToString();
      num = centrePoint.Longitude;
      string str2 = num.ToString();
      num = searchRadius.ConvertTo(LinearDistanceUnits.KM).Value;
      string str3 = num.ToString();
      this._SpatialQuery = string.Format("?lat={0}&lng={1}&fDstL=0&fDstU={2}", (object) str1, (object) str2, (object) str3);
      foreach (ADSBexchangeFeed.AircraftFlight aircraftFlight in this._AircraftFlightDictionary.Values)
        aircraftFlight.DeleteThis = true;
      foreach (ADSBexchangeFeed.AircraftFlight aircraftFlight in this.Download_serialized_json_data<ADSBexchangeFeed.AdsbDataFeed>(this.urlOfADSBFeed + this._SpatialQuery).AircraftFlights)
      {
        if (this._AircraftFlightDictionary.ContainsKey(aircraftFlight.Id))
        {
          this._AircraftFlightDictionary[aircraftFlight.Id].Latitude = aircraftFlight.Latitude;
          this._AircraftFlightDictionary[aircraftFlight.Id].Longitude = aircraftFlight.Longitude;
          this._AircraftFlightDictionary[aircraftFlight.Id].Trak = aircraftFlight.Trak;
          this._AircraftFlightDictionary[aircraftFlight.Id].DeleteThis = false;
        }
        else
        {
          this._AircraftFlightDictionary.Add(aircraftFlight.Id, aircraftFlight);
          this._AircraftFlightDictionary[aircraftFlight.Id].DeleteThis = false;
        }
      }
      List<int> intList = new List<int>();
      foreach (ADSBexchangeFeed.AircraftFlight aircraftFlight in this._AircraftFlightDictionary.Values)
      {
        if (aircraftFlight.DeleteThis)
          intList.Add(aircraftFlight.Id);
      }
      foreach (int key in intList)
        this._AircraftFlightDictionary.Remove(key);
    }

    private AircraftFlightData CreateAircraftFlightData(
      ADSBexchangeFeed.AircraftFlight aircraftFlight)
    {
      double valueOrDefault1 = aircraftFlight.Latitude.GetValueOrDefault();
      double valueOrDefault2 = aircraftFlight.Longitude.GetValueOrDefault();
      double valueOrDefault3 = aircraftFlight.Trak.GetValueOrDefault();
      return new AircraftFlightData(aircraftFlight.GuidID, aircraftFlight.Id, aircraftFlight.Call, valueOrDefault1, valueOrDefault2, aircraftFlight.Alt, valueOrDefault3, aircraftFlight.From, aircraftFlight.To, aircraftFlight.Operator, aircraftFlight.Model);
    }

    private void ReadAdsbFeedByPointAndRadius(
      GeoCoordinateBasic centrePoint,
      LinearDistance searchRadius)
    {
      double num = centrePoint.Latitude;
      string str1 = num.ToString();
      num = centrePoint.Longitude;
      string str2 = num.ToString();
      num = searchRadius.ConvertTo(LinearDistanceUnits.KM).Value;
      string str3 = num.ToString();
      this._SpatialQuery = string.Format("?lat={0}&lng={1}&fDstL=0&fDstU={2}", (object) str1, (object) str2, (object) str3);
      this.ReadFeedToDictionary(this.urlOfADSBFeed + this._SpatialQuery);
    }

    private void ReadAdsbFeed() => this.ReadFeedToDictionary(this.urlOfADSBFeed);

    private void ReadFeedToDictionary(string url)
    {
      ADSBexchangeFeed.AdsbDataFeed adsbDataFeed = this.Download_serialized_json_data<ADSBexchangeFeed.AdsbDataFeed>(url);
      if (adsbDataFeed.AircraftFlights == null)
        return;
      foreach (ADSBexchangeFeed.AircraftFlight aircraftFlight in adsbDataFeed.AircraftFlights)
      {
        if (!this._AircraftFlightDictionary.ContainsKey(aircraftFlight.Id))
          this._AircraftFlightDictionary.Add(aircraftFlight.Id, aircraftFlight);
      }
    }

    private T Download_serialized_json_data<T>(string url) where T : new()
    {
      using (WebClient webClient = new WebClient())
      {
        string json = string.Empty;
        try
        {
          json = webClient.DownloadString(url);
        }
        catch (Exception ex)
        {
        }
        return !string.IsNullOrEmpty(json) ? JsonSerializer.Deserialize<T>(json) : new T();
      }
    }

    private class Feed
    {
      public int Id { get; set; }

      public string Name { get; set; }

      public bool PolarPlot { get; set; }
    }

    private class AircraftFlight
    {
      public AircraftFlight() => this.GuidID = Guid.NewGuid();

      public Guid GuidID { get; set; }

      public bool DeleteThis { get; set; }

      public int Id { get; set; }

      public int Rcvr { get; set; }

      public bool HasSig { get; set; }

      public string Icao { get; set; }

      public bool Bad { get; set; }

      public DateTime FSeen { get; set; }

      public int CMsgs { get; set; }

      public int Alt { get; set; }

      public int GAlt { get; set; }

      public int AltT { get; set; }

      public string Call { get; set; }

      public bool Tisb { get; set; }

      public bool TrkH { get; set; }

      public string Sqk { get; set; }

      public int VsiT { get; set; }

      public int WTC { get; set; }

      public int Species { get; set; }

      public int EngType { get; set; }

      public int EngMount { get; set; }

      public bool Mil { get; set; }

      public string Cou { get; set; }

      public bool HasPic { get; set; }

      public bool Interested { get; set; }

      public int FlightsCount { get; set; }

      public bool Gnd { get; set; }

      public int SpdTyp { get; set; }

      public bool CallSus { get; set; }

      public int Trt { get; set; }

      public int? Sig { get; set; }

      public string Reg { get; set; }

      public int? TSecs { get; set; }

      public string Type { get; set; }

      [JsonPropertyName("Mdl")]
      public string Model { get; set; }

      public string Man { get; set; }

      public string CNum { get; set; }

      [JsonPropertyName("Op")]
      public string Operator { get; set; }

      public string OpIcao { get; set; }

      public string Engines { get; set; }

      public string Year { get; set; }

      public double? InHg { get; set; }

      [JsonPropertyName("lat")]
      public double? Latitude { get; set; }

      [JsonPropertyName("long")]
      public double? Longitude { get; set; }

      public long? PosTime { get; set; }

      public bool? Mlat { get; set; }

      public double? Spd { get; set; }

      public double? Trak { get; set; }

      public bool? Help { get; set; }

      public int? Vsi { get; set; }

      public string From { get; set; }

      public string To { get; set; }

      public int? TAlt { get; set; }

      public double? TTrk { get; set; }

      public List<string> Stops { get; set; }

      public int? PicX { get; set; }

      public int? PicY { get; set; }

      public string Tag { get; set; }

      public bool? PosStale { get; set; }

      public bool? Sat { get; set; }
    }

    private class AdsbDataFeed
    {
      public int Src { get; set; }

      public List<ADSBexchangeFeed.Feed> Feeds { get; set; }

      public int SrcFeed { get; set; }

      public bool ShowSil { get; set; }

      public bool ShowFlg { get; set; }

      public bool ShowPic { get; set; }

      public int FlgH { get; set; }

      public int FlgW { get; set; }

      [JsonPropertyName("acList")]
      public List<ADSBexchangeFeed.AircraftFlight> AircraftFlights { get; set; }

      public int TotalAc { get; set; }

      public string LastDv { get; set; }

      public int ShtTrlSec { get; set; }

      public long Stm { get; set; }
    }
  }
}
