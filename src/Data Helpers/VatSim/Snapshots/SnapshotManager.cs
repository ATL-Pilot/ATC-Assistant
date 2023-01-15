using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VatSim.Data;

namespace VatSim.Snapshots
{
    public class SnapshotManager : ISnapshotManager
    {
        private const string JSON_DATA_FEED_URL = "http://cluster.data.vatsim.net/v3/vatsim-data.json";
        private const string STATUS_FILE_URL = "https://status.vatsim.net/";
        private List<Uri> mDataServers = new List<Uri>();
        public System.Windows.Forms.Timer mRefreshTimer;
        private WebClient mRefreshClient;
        private Snapshot mPendingSnapshot;
        private readonly IDataManager mDataManager;

        public event EventHandler UrlFetchInitiated;

        public event EventHandler<int> UrlFetchCompleted;

        public event EventHandler<string> UrlFetchError;

        public event EventHandler<string> DataRefreshInitiated;

        public event EventHandler<int> DataRefreshProgress;

        public event EventHandler<bool> DataRefreshCompleted;

        public event EventHandler<SnapshotRefreshErrorArgs> DataRefreshError;

        public Snapshot CurrentSnapshot { get; private set; } = new Snapshot();

        public bool Suspended { get; set; }

        public string MetarServer { get; private set; } = string.Empty;

        public string MemberStatsUrl { get; private set; } = string.Empty;

        public SnapshotManager(IDataManager dataManager)
        {
            this.mDataManager = dataManager;

            this.mRefreshTimer = new System.Windows.Forms.Timer() { Interval = 20000 }; //will automatically refresh after 60 seconds.
            this.mRefreshTimer.Tick += new EventHandler(this.RefreshTimer_Tick);
            this.mRefreshTimer.Enabled = true;
        }

        public async Task FetchUrls()
        {
            SnapshotManager sender = this;
            EventHandler urlFetchInitiated = sender.UrlFetchInitiated;
            if (urlFetchInitiated != null)
                urlFetchInitiated((object)sender, EventArgs.Empty);
            sender.mDataServers = new List<Uri>()
      {
        new Uri("http://cluster.data.vatsim.net/v3/vatsim-data.json")
      };
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("user-agent", Application.ProductName + "/" + Application.ProductVersion);
                    string str1 = await client.DownloadStringTaskAsync("https://status.vatsim.net/");
                    string[] separator = new string[1] { "\n" };
                    foreach (string str2 in str1.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (str2.Length >= 14 && str2.Substring(0, 7) == "metar0=")
                            sender.MetarServer = str2.Substring(7).Trim();
                        else if (str2.Length >= 13 && str2.Substring(0, 6) == "user0=")
                            sender.MemberStatsUrl = str2.Substring(6).Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                EventHandler<string> urlFetchError = sender.UrlFetchError;
                if (urlFetchError != null)
                    urlFetchError((object)sender, ex.Message);
            }
            EventHandler<int> urlFetchCompleted = sender.UrlFetchCompleted;
            if (urlFetchCompleted == null)
                return;
            urlFetchCompleted((object)sender, sender.mDataServers.Count);
        }

        public void StopAutoRefresh() => this.mRefreshTimer.Stop();

        private async void RefreshTimer_Tick(object sender, EventArgs e) => await this.RefreshData();

        public async Task RefreshData()
        {
            //MessageBox.Show("Snapshot refresh started");
            SnapshotManager sender = this;
            Uri server;
            // ISSUE: explicit non-virtual call

            sender.mRefreshTimer.Stop();
            if (sender.mDataServers.Count == 0)
            {
                EventHandler<SnapshotRefreshErrorArgs> dataRefreshError = sender.DataRefreshError;
                if (dataRefreshError == null)
                {
                    server = (Uri)null;
                }
                else
                {
                    dataRefreshError((object)sender, new SnapshotRefreshErrorArgs(SnapshotRefreshErrorType.NoServers));
                    server = (Uri)null;
                }
            }
            else
            {
                server = sender.mDataServers[new Random().Next(0, sender.mDataServers.Count)];
                EventHandler<string> refreshInitiated = sender.DataRefreshInitiated;
                if (refreshInitiated != null)
                    refreshInitiated((object)sender, server.Host);
                try
                {
                    string json = await sender.DownloadSnapshot(server);
                    sender.ProcessSnapshot(json, server);
                    server = (Uri)null;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private async Task<string> DownloadSnapshot(Uri server)
        {
            SnapshotManager snapshotManager = this;
            snapshotManager.mRefreshClient = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            snapshotManager.mRefreshClient.Headers.Add("user-agent", Application.ProductName + "/" + Application.ProductVersion);
            snapshotManager.mRefreshClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(snapshotManager.RefreshClient_DownloadProgressChanged);
            return await snapshotManager.mRefreshClient.DownloadStringTaskAsync(server);
        }

        private void ProcessSnapshot(string json, Uri server)
        {
            if (System.IO.File.Exists("test_data.json"))
                json = System.IO.File.ReadAllText("test_data.json");
            this.mPendingSnapshot = this.BuildSnapshotFromJson(ref json);
            if (this.mPendingSnapshot.LastUpdated == DateTime.MinValue)
            {
                EventHandler<SnapshotRefreshErrorArgs> dataRefreshError = this.DataRefreshError;
                if (dataRefreshError == null)
                    return;
                dataRefreshError((object)this, new SnapshotRefreshErrorArgs(SnapshotRefreshErrorType.Network, "Could not find data timestamp", server));
            }
            else if ((DateTime.UtcNow - this.mPendingSnapshot.LastUpdated).TotalSeconds > (double)120)  //Data is considered out dated after 120 seconds
            {
                EventHandler<SnapshotRefreshErrorArgs> dataRefreshError = this.DataRefreshError;
                if (dataRefreshError == null)
                    return;
                dataRefreshError((object)this, new SnapshotRefreshErrorArgs(SnapshotRefreshErrorType.StaleData, server, this.mPendingSnapshot.LastUpdated));
            }
            else
            {
                this.ActivatePendingSnapshot();
                this.Resume();
            }
        }

        public void CancelRefresh()
        {
            if (this.mRefreshClient == null)
                return;
            this.mRefreshClient.CancelAsync();
        }

        private void RefreshClient_DownloadProgressChanged(
          object sender,
          DownloadProgressChangedEventArgs e)
        {
            EventHandler<int> dataRefreshProgress = this.DataRefreshProgress;
            if (dataRefreshProgress == null)
                return;
            dataRefreshProgress((object)this, e.ProgressPercentage);
        }

        public void Resume()
        {
            this.mRefreshTimer.Enabled = true;
            this.mRefreshTimer.Start();
        }

        public void ActivatePendingSnapshot()
        {
            this.CurrentSnapshot = this.mPendingSnapshot;
            EventHandler<bool> refreshCompleted = this.DataRefreshCompleted;
            if (refreshCompleted == null)
                return;
            refreshCompleted((object)this, false);
        }

        private Snapshot BuildSnapshotFromJson(ref string json)
        {
            Application.CurrentCulture = new CultureInfo("en-US");
            Snapshot snapshot = new Snapshot();
            RawData rawData = JsonConvert.DeserializeObject<RawData>(json);
            snapshot.LastUpdated = rawData.General.UpdateTimestamp;
            if (rawData.Pilots != null)
            {
                foreach (RawDataPilot pilot in rawData.Pilots)
                {
                    try
                    {
                        this.ProcessPilot(snapshot, pilot, false);
                    }
                    catch
                    {
                    }
                }
            }
            if (rawData.Prefiles != null)
            {
                foreach (RawDataPilot prefile in rawData.Prefiles)
                {
                    try
                    {
                        this.ProcessPilot(snapshot, prefile, true);
                    }
                    catch
                    {
                    }
                }
            }
            if (rawData.Controllers != null)
            {
                foreach (RawDataController controller in rawData.Controllers)
                {
                    try
                    {
                        this.ProcessController(snapshot, controller);
                    }
                    catch
                    {
                    }
                }
            }
            if (rawData.Atises != null)
            {
                foreach (RawDataController atise in rawData.Atises)
                {
                    try
                    {
                        this.ProcessController(snapshot, atise);
                    }
                    catch
                    {
                    }
                }
            }
            if (rawData.Servers != null)
            {
                foreach (RawDataServer server in rawData.Servers)
                {
                    try
                    {
                        this.ProcessServer(snapshot, server);
                    }
                    catch
                    {
                    }
                }
            }
            if (rawData.PilotRatings != null)
            {
                foreach (RawDataPilotRating pilotRating in rawData.PilotRatings)
                    snapshot.PilotRatings.Add(pilotRating.Id, new PilotRating()
                    {
                        Id = pilotRating.Id,
                        ShortName = pilotRating.ShortName,
                        LongName = pilotRating.LongName
                    });
            }
            foreach (Atc atc in snapshot.Atc.Values)
            {
                if (snapshot.NetworkServers.ContainsKey(atc.NetworkServer))
                    ++snapshot.NetworkServers[atc.NetworkServer].Connections;
            }
            foreach (Flight flight in snapshot.Flights.Values)
            {
                if (!flight.Prefile && snapshot.NetworkServers.ContainsKey(flight.NetworkServer))
                    ++snapshot.NetworkServers[flight.NetworkServer].Connections;
            }
            foreach (KeyValuePair<string, Airport> airport in this.mDataManager.Airports)
            {
                if (!(airport.Value.Id != airport.Value.Icao) && !snapshot.AirportPositionInfos.ContainsKey(airport.Key))
                    snapshot.InactiveAirports[airport.Key] = airport.Value.Loc;
            }
            return snapshot;
        }

        private void ProcessPilot(Snapshot snapshot, RawDataPilot pilot, bool isPrefile)
        {
            if (snapshot.Flights.ContainsKey(pilot.Callsign))
                return;
            Flight flight1 = new Flight();
            flight1.Prefile = isPrefile;
            flight1.Callsign = pilot.Callsign;
            flight1.Cid = pilot.Cid.ToString();
            flight1.RealName = pilot.Name;
            flight1.Loc = new WorldPoint(pilot.Longitude, pilot.Latitude);
            flight1.Alt = pilot.Altitude;
            flight1.Speed = pilot.GroundSpeed;
            flight1.Equipment = pilot.FlightPlan?.AircraftFaa ?? string.Empty;
            flight1.PlannedSpeed = int.Parse(pilot.FlightPlan?.CruiseTas ?? "0", (IFormatProvider)CultureInfo.InvariantCulture);
            flight1.PlannedAlt = pilot.FlightPlan?.Altitude ?? string.Empty;
            flight1.PlannedDep = pilot.FlightPlan?.Departure ?? string.Empty;
            flight1.PlannedDest = pilot.FlightPlan?.Arrival ?? string.Empty;
            flight1.PlannedAlternate = pilot.FlightPlan?.Alternate ?? string.Empty;
            flight1.NetworkServer = pilot.Server;
            flight1.PilotRating = pilot.PilotRating;
            flight1.Rating = Rating.OBS;
            flight1.Squawk = pilot.Transponder;
            RawDataFlightPlan flightPlan = pilot.FlightPlan;
            flight1.FlightRules = flightPlan != null ? flightPlan.FlightRules.ToFlightRules() : FlightRules.Unknown;
            flight1.Remarks = pilot.FlightPlan?.Remarks ?? string.Empty;
            flight1.Route = pilot.FlightPlan?.Route ?? string.Empty;
            flight1.Heading = pilot.Heading;
            Flight flight2 = flight1;
            if (!string.IsNullOrEmpty(flight2.PlannedDep) && flight2.PlannedDep.Length < 4)
            {
                string airportIcao = this.mDataManager.GetAirportIcao(flight2.PlannedDep);
                if (!string.IsNullOrEmpty(airportIcao))
                    flight2.PlannedDep = airportIcao;
            }
            if (!string.IsNullOrEmpty(flight2.PlannedAlternate) && flight2.PlannedAlternate.Length < 4)
            {
                string airportIcao = this.mDataManager.GetAirportIcao(flight2.PlannedAlternate);
                if (!string.IsNullOrEmpty(airportIcao))
                    flight2.PlannedAlternate = airportIcao;
            }
            if (!string.IsNullOrEmpty(flight2.PlannedDest) && flight2.PlannedDest.Length < 4)
            {
                string airportIcao = this.mDataManager.GetAirportIcao(flight2.PlannedDest);
                if (!string.IsNullOrEmpty(airportIcao))
                    flight2.PlannedDest = airportIcao;
            }
            if (isPrefile)
            {
                flight2.Eta = DateTime.MaxValue;
                flight2.TimeOnline = TimeSpan.Zero;
            }
            else
                flight2.TimeOnline = pilot.LogonTime == DateTime.MinValue ? TimeSpan.Zero : snapshot.LastUpdated - pilot.LogonTime;
            if (flight2.HasFlightPlan)
            {
                flight2.PlannedDepLoc = this.mDataManager.GetAirportLoc(flight2.PlannedDep);
                flight2.PlannedDestLoc = this.mDataManager.GetAirportLoc(flight2.PlannedDest);
                flight2.DistanceFromDep = flight2.Loc.DistanceTo(flight2.PlannedDepLoc);
                flight2.DistanceToDest = flight2.Loc.DistanceTo(flight2.PlannedDestLoc);
            }
            else
            {
                flight2.DistanceFromDep = -1.0;
                flight2.DistanceToDest = -1.0;
            }
            if (flight2.HasFlightPlan)
            {
                if (flight2.Speed < 50 && flight2.DistanceFromDep < 3.0)
                {
                    flight2.Status = FlightStatus.Departing;
                    flight2.Eta = DateTime.MaxValue.AddHours(-2.0);
                }
                else if (flight2.Speed < 50 && flight2.DistanceToDest < 3.0)
                {
                    flight2.Status = FlightStatus.Arrived;
                    flight2.Eta = DateTime.MaxValue.AddHours(-1.0);
                }
                else
                {
                    flight2.Status = FlightStatus.Airborne;
                    if (flight2.Speed > 0 && flight2.Loc.IsNonZero)
                    {
                        double num = flight2.DistanceToDest / (double)flight2.Speed;
                        flight2.Eta = snapshot.LastUpdated.AddHours(num);
                    }
                    else
                        flight2.Eta = DateTime.MaxValue;
                }
            }
            else if (flight2.Speed < 50 && flight2.Loc.IsNonZero)
            {
                string nearbyAirport = this.mDataManager.GetNearbyAirport(flight2.Loc);
                if (!string.IsNullOrEmpty(nearbyAirport))
                {
                    flight2.PlannedDep = nearbyAirport;
                    flight2.Status = FlightStatus.Departing;
                    flight2.Eta = DateTime.MaxValue.AddHours(-2.0);
                    flight2.DistanceFromDep = 0.0;
                }
            }
            else
            {
                flight2.Status = FlightStatus.Airborne;
                flight2.Eta = DateTime.MaxValue;
            }
            if (!snapshot.AirportPositionInfos.ContainsKey(flight2.PlannedDep))
                snapshot.AirportPositionInfos[flight2.PlannedDep] = new AirportPositionInfo(this.mDataManager.GetAirportLoc(flight2.PlannedDep));
            if (!snapshot.AirportPositionInfos.ContainsKey(flight2.PlannedDest))
                snapshot.AirportPositionInfos[flight2.PlannedDest] = new AirportPositionInfo(this.mDataManager.GetAirportLoc(flight2.PlannedDest));
            if (flight2.Status == FlightStatus.Arrived)
                snapshot.AirportPositionInfos[flight2.PlannedDest].Operations.Arrivals.Add(flight2);
            else if (flight2.Status == FlightStatus.Departing)
            {
                snapshot.AirportPositionInfos[flight2.PlannedDep].Operations.Departures.Add(flight2);
                snapshot.AirportPositionInfos[flight2.PlannedDest].Operations.Inbounds.Add(flight2);
            }
            else if (flight2.Status == FlightStatus.Airborne)
            {
                snapshot.AirportPositionInfos[flight2.PlannedDep].Operations.Outbounds.Add(flight2);
                snapshot.AirportPositionInfos[flight2.PlannedDest].Operations.Inbounds.Add(flight2);
            }
            Airport airport1 = this.mDataManager.GetAirport(flight2.PlannedDep);
            Airport airport2 = this.mDataManager.GetAirport(flight2.PlannedDest);
            flight2.DepAirportName = airport1?.Name ?? string.Empty;
            flight2.DestAirportName = airport2?.Name ?? string.Empty;
            flight2.DepFirIcao = airport1?.FirIcao ?? string.Empty;
            flight2.DestFirIcao = airport2?.FirIcao ?? string.Empty;
            flight2.DepCountryName = this.mDataManager.GetCountryName(flight2.PlannedDep);
            flight2.DestCountryName = this.mDataManager.GetCountryName(flight2.PlannedDest);
            if (flight2.Loc.IsNonZero)
            {
                flight2.WithinFirIcao = this.mDataManager.GetContainingFir(flight2.Loc);
                flight2.WithinCountry = !(flight2.WithinFirIcao != string.Empty) ? string.Empty : this.mDataManager.GetCountryName(flight2.WithinFirIcao);
            }
            else
            {
                flight2.WithinFirIcao = string.Empty;
                flight2.WithinCountry = string.Empty;
            }
            snapshot.Flights.Add(flight2.Callsign, flight2);
        }

        private void ProcessController(Snapshot snapshot, RawDataController controller)
        {
            if (snapshot.Atc.ContainsKey(controller.Callsign))
                return;
            Atc atc = new Atc()
            {
                Callsign = controller.Callsign,
                Cid = controller.Cid.ToString(),
                RealName = controller.Name,
                Frequency = controller.Frequency,
                NetworkServer = controller.Server,
                Rating = controller.Rating.ToRating(),
                VisualRange = controller.VisualRange,
                Atis = controller.TextAtis != null ? string.Join("\r\n", controller.TextAtis.ToArray()) : string.Empty,
                TimeOnline = controller.LogonTime == DateTime.MinValue ? TimeSpan.Zero : snapshot.LastUpdated - controller.LogonTime
            };
            string s = "";
            int num = atc.Callsign.LastIndexOf('_');
            if (num > 0)
                s = atc.Callsign.Substring(num + 1);
            atc.Facility = s.ToFacility();
            if (atc.Frequency == "199.998")
                atc.Facility = Facility.OBS;
            if (atc.Callsign.Length >= 5)
            {
                if (atc.Facility != Facility.OBS)
                {
                    int length = atc.Callsign.IndexOf('_');
                    if (length > 0)
                    {
                        atc.Prefix = atc.Callsign.Substring(0, length);
                        switch (atc.Facility)
                        {
                            case Facility.CTR:
                            case Facility.FSS:
                                Uir uir = this.mDataManager.GetUir(atc.Prefix);
                                if (uir != null)
                                {
                                    atc.IsUir = true;
                                    atc.UirCode = uir.Id;
                                    atc.UirName = uir.Name;
                                    atc.FirIcao = string.Empty;
                                    atc.FirName = string.Empty;
                                    atc.UirFirIcaos = new List<string>();
                                    atc.UirCountryNames = new List<string>();
                                    atc.PositionName = uir.Name;
                                    atc.IsOceanic = false;
                                    atc.AirportCode = "";
                                    atc.AirportName = "";
                                    using (List<string>.Enumerator enumerator = uir.MemberFirs.GetEnumerator())
                                    {
                                        while (enumerator.MoveNext())
                                        {
                                            string current = enumerator.Current;
                                            atc.UirFirIcaos.Add(current);
                                            atc.UirCountryNames.Add(this.mDataManager.GetCountryName(current));
                                        }
                                        break;
                                    }
                                }
                                else
                                {
                                    atc.IsUir = false;
                                    Fir fir = this.mDataManager.GetFIR(atc.Prefix);
                                    if (fir != null)
                                    {
                                        atc.FirIcao = fir.Icao;
                                        atc.FirName = fir.Name;
                                        atc.CountryName = this.mDataManager.GetCountryName(fir.Icao);
                                        atc.PositionName = atc.Facility != Facility.CTR ? fir.Name + " " + atc.Facility.GetName() : fir.Name + " " + this.mDataManager.GetCenterName(atc.CountryName);
                                    }
                                    else
                                    {
                                        atc.FirIcao = string.Empty;
                                        atc.FirName = string.Empty;
                                        atc.CountryName = this.mDataManager.GetCountryName(atc.Callsign);
                                        atc.PositionName = "Unknown " + atc.Facility.GetName();
                                    }
                                    atc.IsOceanic = atc.Facility == Facility.FSS && this.mDataManager.OceanicBoundaries.ContainsKey(atc.FirIcao);
                                    atc.AirportCode = string.Empty;
                                    atc.AirportName = string.Empty;
                                    break;
                                }
                            default:
                                Airport airport = this.mDataManager.GetAirport(atc.Prefix);
                                atc.IsOceanic = false;
                                if (airport != null)
                                {
                                    atc.AirportCode = airport.Icao;
                                    atc.AirportName = airport.Name;
                                    atc.CountryName = this.mDataManager.GetCountryName(airport.Icao);
                                    atc.FirIcao = airport.FirIcao;
                                    atc.FirName = this.mDataManager.GetFIRName(atc.FirIcao);
                                }
                                else
                                {
                                    atc.AirportCode = string.Empty;
                                    atc.AirportName = string.Empty;
                                    atc.CountryName = string.Empty;
                                    atc.FirIcao = string.Empty;
                                    atc.FirName = string.Empty;
                                }
                                atc.PositionName = (atc.AirportName == string.Empty ? "Unknown " : atc.AirportName + " ") + atc.Facility.GetName();
                                break;
                        }
                    }
                    else
                        atc.Facility = Facility.OBS;
                }
            }
            else
                atc.Facility = Facility.OBS;
            switch (atc.Facility)
            {
                case Facility.ATIS:
                case Facility.DEL:
                case Facility.GND:
                case Facility.TWR:
                case Facility.APP:
                case Facility.DEP:
                    if (!snapshot.AirportPositionInfos.ContainsKey(atc.AirportCode))
                        snapshot.AirportPositionInfos[atc.AirportCode] = new AirportPositionInfo(this.mDataManager.GetAirportLoc(atc.AirportCode), this.mDataManager.GetIsPseudoAirport(atc.AirportCode));
                    snapshot.AirportPositionInfos[atc.AirportCode].Members.Add(atc);
                    break;
                case Facility.CTR:
                case Facility.FSS:
                    if (atc.IsUir)
                    {
                        Uir uir = this.mDataManager.GetUir(atc.UirCode);
                        if (uir != null)
                        {
                            if (!snapshot.UirPositionInfos.ContainsKey(atc.UirCode))
                            {
                                snapshot.UirPositionInfos.Add(atc.UirCode, new UirPositionInfo());
                                snapshot.UirPositionInfos[atc.UirCode].Uir = atc.UirCode;
                                snapshot.UirPositionInfos[atc.UirCode].FirLabelScreenLocs = new Point[uir.MemberFirs.Count * 3];
                                foreach (string memberFir in uir.MemberFirs)
                                {
                                    snapshot.UirPositionInfos[atc.UirCode].FirIcaos.Add(memberFir);
                                    snapshot.UirPositionInfos[atc.UirCode].FirCenterLocs.Add(this.mDataManager.GetFirCenter(memberFir, false));
                                }
                            }
                            snapshot.UirPositionInfos[atc.UirCode].Members.Add(atc);
                            break;
                        }
                        break;
                    }
                    string key = atc.FirIcao + (atc.IsOceanic ? "o" : string.Empty);
                    if (!snapshot.FirPositionInfos.ContainsKey(key))
                    {
                        snapshot.FirPositionInfos.Add(key, new FirPositionInfo());
                        snapshot.FirPositionInfos[key].FirCenterLoc = this.mDataManager.GetFirCenter(atc.FirIcao, atc.IsOceanic);
                    }
                    snapshot.FirPositionInfos[key].Members.Add(atc);
                    break;
            }
            if (atc.Facility == Facility.OBS)
            {
                atc.AirportCode = string.Empty;
                atc.AirportName = string.Empty;
                atc.CountryName = string.Empty;
                atc.FirIcao = string.Empty;
                atc.FirName = string.Empty;
                atc.PositionName = string.Empty;
            }
            snapshot.Atc.Add(atc.Callsign, atc);
        }

        private void ProcessServer(Snapshot snapshot, RawDataServer server)
        {
            if (server.ClientsConnectionAllowed != 1)
                return;
            snapshot.NetworkServers[server.Ident] = new NetworkServer()
            {
                Id = server.Ident,
                Address = server.HostnameOrIp,
                Location = server.Location,
                Name = server.Name
            };
        }
    }
}
