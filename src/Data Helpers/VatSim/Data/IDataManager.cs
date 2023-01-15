using System;
using System.Collections.Generic;

namespace VatSim.Data
{
    public interface IDataManager
    {
        event EventHandler<string> DataLoadStatus;

        event EventHandler DataLoadCompleted;

        event EventHandler<string> DataLoadError;

        Dictionary<string, Airport> Airports { get; }

        Dictionary<string, Country> Countries { get; }

        Dictionary<string, FirBoundary> FirBoundaries { get; }

        Dictionary<string, FirBoundary> FirBoundaryExtensions { get; }

        Dictionary<string, Fir> Firs { get; }

        List<WorldPoint> Idl { get; }

        Dictionary<string, FirBoundary> OceanicBoundaries { get; }

        Dictionary<string, FirBoundary> OceanicBoundaryExtensions { get; }

        Dictionary<string, Uir> Uirs { get; }

        Airport GetAirport(string code);

        string GetAirportIcao(string code);

        WorldPoint GetAirportLoc(string icao);

        string GetAirportName(string icao);

        string GetCenterName(string country);

        string GetContainingFir(WorldPoint point);

        string GetCountryName(string code);

        Fir GetFIR(string prefix);

        WorldPoint GetFirCenter(string icao, bool oceanic);

        string GetFIRName(string icao);

        bool GetIsPseudoAirport(string icao);

        string GetNearbyAirport(WorldPoint point);

        Uir GetUir(string prefix);

        string GetUIRName(string code);

        void LoadData();
    }
}
