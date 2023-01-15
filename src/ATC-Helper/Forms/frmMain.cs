using ATC_Helper.chrisgonzalez;
using ATC_Helper.Classes;
using ATC_Helper.Classes.GPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VatSim.Data;
using VatSim.Snapshots;
using Timer = System.Windows.Forms.Timer;
using ATC_Helper;
using ATC_HelperData = ATC_Helper.WebService.ATC_HelperData;
using System.IO;
using System.Net.Http.Formatting;
using Aircraft = ATC_Helper.WebService.Aircraft;

namespace ATC_Helper.Forms
{
    public partial class frmMain : Form
    {
        #region Members

        private flightplan flightplan;

        private Flight VatsimFlight = new Flight();

        private Timer refresh = new Timer();

        private bool CallsignFormLoaded = false;
        private frmCallSign CallsignForm;

        private bool AircraftFormLoaded = false;
        private frmAircraft AircraftForm;

        private bool AirportFormLoaded = false;
        private frmAirport AirportForm;

        private const string AtcAircraftFileName = "Atc_Aircrafts.dat";
        private const string AtcAirportsFileName = "Atc_Airports.dat";
        private const string AtcSidRestrictionsFilename = "Atc_SidRestrictions.dat";
        private const string AtcCallSignsFileName = "Atc_CallSigns.dat";
        private const string AtcDeparturePlansFileName = "Atc_DeparturePlans.dat";

        #endregion Members

        #region Form Event Handlers

        public frmMain()
        {
            InitializeComponent();

            
            this.MaximumSize = new Size(723, 941);
            this.MinimumSize = new Size(0, 0);
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.AutoSize = true;

            Program.dataManager = new DataManager();
            Program.snapshotManager = new SnapshotManager(Program.dataManager);
            Program.dataUpdateManager = new DataUpdateManager();

            Program.dataManager.DataLoadCompleted += _dataManager_DataLoadCompleted;
            Program.dataManager.DataLoadError += _dataManager_DataLoadError;
            Program.dataManager.DataLoadStatus += _dataManager_DataLoadStatus;

            Program.dataUpdateManager.FirBoundaryDataDownloadStarted += DataUpdateManager_FirBoundaryDataDownloadStarted;
            Program.dataUpdateManager.MainDataDownloadStarted += DataUpdateManager_MainDataDownloadStarted;

            Program.snapshotManager.DataRefreshProgress += SnapshotManager_DataRefreshProgress;
            Program.snapshotManager.DataRefreshError += SnapshotManager_DataRefreshError;
            Program.snapshotManager.DataRefreshCompleted += SnapshotManager_DataRefreshCompleted;
            Program.snapshotManager.DataRefreshInitiated += SnapshotManager_DataRefreshInitiated;

            Program.snapshotManager.UrlFetchError += SnapshotManager_UrlFetchError;
            Program.snapshotManager.UrlFetchCompleted += SnapshotManager_UrlFetchCompleted;
            Program.snapshotManager.UrlFetchInitiated += SnapshotManager_UrlFetchInitiated;

            gbPdcCommands.CollapseBoxClickedEvent += RelocateControls;
            gbAirportInfo.CollapseBoxClickedEvent += RelocateControls;
            gbClearanceDetails.CollapseBoxClickedEvent += RelocateControls;
            gbFlightplanDetails.CollapseBoxClickedEvent += RelocateControls;

        }

        private void RelocateControls(object sender)
        {
            Point gbEntryBottomLeft = gbEntry.Location + new Size(0, gbEntry.Size.Height);

            //Relocate Airport information
            gbAirportInfo.Location = gbEntryBottomLeft + new Size(0, 1);
            Point gbAirportInformationBottomLeft = gbAirportInfo.Location + new Size(0, gbAirportInfo.Size.Height);
            //this.Invalidate();

            //Relocate Flightplan Details
            gbFlightplanDetails.Location = gbAirportInformationBottomLeft + new Size(0, 1);
            Point GbFlightplanDetailsBottomLeft = gbFlightplanDetails.Location + new Size(0, gbFlightplanDetails.Size.Height);
            //this.Invalidate();

            //Relocate Clearance Details
            gbClearanceDetails.Location = GbFlightplanDetailsBottomLeft + new Size(0, 1);
            Point gbClearanceDetailsBottomLeft = gbClearanceDetails.Location + new Size(0, gbClearanceDetails.Size.Height);
            //this.Invalidate();

            //Relocate PDC Commands
            gbPdcCommands.Location = gbClearanceDetailsBottomLeft + new Size(0, 1);
            Point gbPdcCommandsBottomLeft = gbPdcCommands.Location + new Size(0, gbPdcCommands.Size.Height);
            this.Invalidate();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadNavData();
            LoadLookUpValues();
            cbFlightRules.SelectedIndex = 0;
            cbDirectionOfFlight.SelectedIndex = 0;

            refresh.Tick += Refresh_Tick;
            refresh.Interval = 20000;
            refresh.Enabled = true;

            if (Properties.Settings.Default.RememberWindowsSettings)
            {
                this.Location = Properties.Settings.Default.frmMainPosition;
            }

            this.LocationChanged += FrmMain_LocationChanged;

        }

        private void FrmMain_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.frmMainPosition = this.Location;
            Properties.Settings.Default.Save();
        }

        private async void frmMain_Shown(object sender, EventArgs e)
        {
            //Update Datafiles from VATSIM
            //await UpdateData();

            //Get Vatsim Data URL
            await UpdateUrls();
        }

        #endregion Form Event Handlers

        #region Control Event Handlers

        private void btnLoadFlightplan_Click(object sender, EventArgs e)
        {
            try
            {
                lock (Program.snapshotManager.CurrentSnapshot)
                    VatsimFlight = VatSim_Helper.GetFlightplan(tbCallsign.Text.ToUpper().Trim(), Program.snapshotManager.CurrentSnapshot);
            }

            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            if (VatsimFlight != null)
            {
                ProcessVatSimData();
                OutputData();
                ProcessClearance();
            }
            else
            {
                string tempcallsign = tbCallsign.Text.ToUpper().Trim();
                ClearControls();
                tbCallsign.Text = tempcallsign;
                MsgBox.Show("Unable to locate flight plan for selected callsign", "No Flightplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ProcessClearance();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            flightplan = null;
            ClearControls();
        }

        public void EnablebtnRefresh()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(EnablebtnRefresh), new object[] { });
                return;
            }

            tsbRefresh.Enabled = true;
        }

        public void DisablebtnRefresh()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(DisablebtnRefresh), new object[] { });
                return;
            }

            tsbRefresh.Enabled = false;
        }

        #endregion Control Event Handlers

        #region Data Load

        private void LoadLookUpValues()
        {
            List<WebService.Aircraft> AtcAircraftData = null;
            List<WebService.Airport> AtcAirportData = null;
            List<WebService.AirportSid_Restrictions> AtcAirportSidRestrictionData = null;
            List<WebService.CallSign> AtcCallSignData = null;
            List<WebService.DeparturePlan> AtcDeparturePlanData = null;

            try
            {
                //Get the latest Information from ATC-Helper Webservice
                WebService.ATC_HelperData ATC_HelperWs = new WebService.ATC_HelperData();

                AtcAircraftData = ATC_HelperWs.GetAircraftData().ToList();
                WriteDatFile(AtcAircraftData, AtcAircraftFileName);

                AtcAirportData = ATC_HelperWs.GetAirportData().ToList();
                WriteDatFile(AtcAirportData, AtcAirportsFileName);

                AtcAirportSidRestrictionData = ATC_HelperWs.GetSidRestrictionData().ToList();
                WriteDatFile(AtcAirportSidRestrictionData, AtcSidRestrictionsFilename);

                AtcCallSignData = ATC_HelperWs.GetCallSigns().ToList();
                WriteDatFile(AtcCallSignData, AtcCallSignsFileName);

                AtcDeparturePlanData = ATC_HelperWs.GetDeparturePlanData().ToList();
                WriteDatFile(AtcDeparturePlanData, AtcDeparturePlansFileName);
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), null);
            }


            if (AtcAircraftData != null)
            {
                Program.AtcHelper_AircraftTypes = AtcAircraftData;
            }
            else
            {
                Program.AtcHelper_AircraftTypes = ReadAtcAircraftDataFile(AtcAircraftFileName);
            }

            if (AtcAirportData != null)
            {
                Program.AtcHelper_AirportDetails = AtcAirportData;
            }
            else
            {
                Program.AtcHelper_AirportDetails = ReadAtcAirportDataFile(AtcAirportsFileName);
            }

            if (AtcAirportSidRestrictionData != null)
            {
                Program.AtcHelper_SidRestrictions = AtcAirportSidRestrictionData;
            }
            else
            {
                Program.AtcHelper_SidRestrictions = ReadAtcSidRestrictionsDataFile(AtcSidRestrictionsFilename);
            }

            if (AtcCallSignData != null)
            {
                Program.AtcHelper_CallSigns = AtcCallSignData;
            }
            else
            {
                Program.AtcHelper_CallSigns = ReadAtcCallsignstDataFile(AtcCallSignsFileName);
            }

            if (AtcDeparturePlanData != null)
            {
                Program.AtcHelper_DeparturePlan = AtcDeparturePlanData;
            }
            else
            {
                Program.AtcHelper_DeparturePlan = ReadAtcDeparturePlansDataFile(AtcDeparturePlansFileName);
            }

        }

        private void WriteDatFile(object Data, string fileName)
        {
            try
            {
                using (Stream stream = File.Open(".//Data//" + fileName, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, Data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        private List<WebService.Aircraft> ReadAtcAircraftDataFile(string filename)
        {
            try
            {
                using (Stream stream = File.Open(".//Data//" + filename, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return (List<WebService.Aircraft>)bformatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), null);
            }

            return null;
        }

        private List<WebService.Airport> ReadAtcAirportDataFile(string filename)
        {
            try
            {
                using (Stream stream = File.Open(".//Data//" + filename, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return (List<WebService.Airport>)bformatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return null;
        }

        private List<WebService.AirportSid_Restrictions> ReadAtcSidRestrictionsDataFile(string filename)
        {
            try
            {
                using (Stream stream = File.Open(".//Data//" + filename, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return (List<WebService.AirportSid_Restrictions>)bformatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), null);
            }

            return null;
        }

        private List<WebService.CallSign> ReadAtcCallsignstDataFile(string filename)
        {
            try
            {
                using (Stream stream = File.Open(".//Data//" + filename, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return (List<WebService.CallSign>)bformatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), null);
            }

            return null;
        }

        private List<WebService.DeparturePlan> ReadAtcDeparturePlansDataFile(string filename)
        {
            try
            {
                using (Stream stream = File.Open(".//Data//" + filename, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return (List<WebService.DeparturePlan>)bformatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), null);
            }

            return null;
        }

        private void LoadNavData()
        {
            //Load ARINC Data from FAA
            Program.NavData.Open("./FaaData/FAACIFP18");
        }

        #endregion Data Load 

        #region Flightplan Methods

        private flightplan BuildFlightplan()
        {
            flightplan fp = new flightplan((DataManager)Program.dataManager);
            fp.Destination = tbArrive.Text;
            fp.AcType = tbAcType.Text;
            fp.Alternate = tbAlternate.Text;
            fp.FlightRules = cbFlightRules.Text;
            fp.Callsign = tbCallsign.Text;
            fp.Departure = tbDepart.Text;
            fp.Squawk = tbSquawk.Text;
            fp.DirectionOfFlight = cbDirectionOfFlight.Text;

            //Add SID and Transition
            string[] WayPoints = tbRoute.Text.Split(' ');

            string SidName = "";
            string TransitionName = "";



            if (WayPoints[0].ToUpper() == tbDepart.Text.ToUpper())
            {
                SidName = WayPoints[1];
                if (WayPoints.Count() >= 3)
                    TransitionName = WayPoints[2];
                else
                    TransitionName = "";
            }
            else
            {
                SidName = WayPoints[0];
                if (WayPoints.Count() >= 2)
                    TransitionName = WayPoints[1];
                else
                    TransitionName = "";
            }

            Classes.SID SelectedSID = new Classes.SID(SidName, fp.Departure);

            if (SelectedSID.IsTransitionValid(TransitionName))
            {
                fp.Transition = TransitionName;

                ArincReader.Arinc424.Records.AirportSid asid;

                switch (SelectedSID.SidType)
                {
                    case SidType.EngineOut:
                        flightplan.IsTransitionCommon = true;
                        break;

                    case SidType.Standard:
                        asid = SelectedSID.SidDetails.FindLast(y => y.RouteType == "2");
                        if (asid != null && asid.FixIdentifier == TransitionName)
                        {
                            fp.IsTransitionCommon = true;
                        }
                        else
                        {
                            fp.IsTransitionCommon = false;
                        }
                        break;

                    case SidType.RNAV:
                        asid = SelectedSID.SidDetails.FindLast(y => y.RouteType == "5");
                        if (asid != null && asid.FixIdentifier == TransitionName)
                        {
                            fp.IsTransitionCommon = true;
                        }
                        else
                        {
                            fp.IsTransitionCommon = false;
                        }
                        break;

                    case SidType.FMS:
                        asid = SelectedSID.SidDetails.FindLast(y => y.RouteType.ToUpper() == "M");
                        if (asid != null && asid.FixIdentifier == TransitionName)
                        {
                            fp.IsTransitionCommon = true;
                        }
                        else
                        {
                            fp.IsTransitionCommon = false;
                        }
                        break;

                    case SidType.Vector:
                        asid = SelectedSID.SidDetails.FindLast(y => y.RouteType.ToUpper() == "V");
                        if (asid != null && asid.FixIdentifier == TransitionName)
                        {
                            fp.IsTransitionCommon = true;
                        }
                        else
                        {
                            fp.IsTransitionCommon = false;
                        }
                        break;

                    case SidType.Unknown:
                        break;
                }
            }
            else
            {

            }

            if (SelectedSID.IsSidValid)
            {
                fp.SID = SelectedSID;
            }
            else
            {

            }

            //Process the AC type and Equiptment Suffix
            try
            {

                if (tbAcType.Text.Contains("/"))
                {
                    string temp = tbAcType.Text.Substring(tbAcType.Text.IndexOf("/") + 1, 1);
                    Enum.TryParse(temp, out EquiptmentSuffix suffix);


                    fp.EquiptmentSuffix = suffix;
                    fp.ACTypeDesignator = tbAcType.Text.Substring(0, tbAcType.Text.IndexOf("/"));
                }
                else
                {
                    fp.ACTypeDesignator = tbAcType.Text;
                }

            }
            catch (Exception ex)
            {

                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }


            fp.EngineType = GetAircraftType(fp);
            fp.IsHeavy = IsHeavy(fp);

            //Process Cruise Altitude
            if (tbCruiseAlt.Text == "")
            {
                fp.CruiseAlt = 0;
            }
            else
            {
                int Result = 0;
                try
                {
                    Result = int.Parse(tbCruiseAlt.Text);
                    fp.CruiseAlt = Result;
                }
                catch (FormatException ex)
                {
                    Result = 0;
                    fp.CruiseAlt = Result;

                    Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
                }

            }

            fp.RouteString = tbRoute.Text;

            try
            {
                fp.DepartureRW = GetPreferedRW(fp);
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            return fp;
        }

        private bool IsHeavy(flightplan fp)
        {
            bool result = false;
            string engType = "prop";
            var matches = Program.AtcHelper_AircraftTypes.Where(p => p.TypeDesignator == fp.ACTypeDesignator);


            foreach (var match in matches)
            {
                if (match.WTC.ToUpper() == "H" || match.WTC.ToUpper() == "J") result = true;
            }

            return result;
        }

        private string GetAircraftType(flightplan fp)
        {
            string engType = "prop";
            var matches = Program.AtcHelper_AircraftTypes.Where(p => p.TypeDesignator == fp.ACTypeDesignator);


            foreach (var match in matches)
            {
                fp.Aircraft = match;
                if (match.SimplifiedEngineType.ToLower() == "jet") engType = "Jet";
            }

            return engType;
        }

        #endregion Flightplan Methods

        #region Flightplan Helper Methods

        private void ProcessClearance()
        {

            bool Error = false;
            string ErrorMessage;
            StringBuilder sb = new StringBuilder();


            if (!ValidateFields(out ErrorMessage))
            {
                MsgBox.Show(ErrorMessage, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            flightplan = BuildFlightplan();
            OutputData();

            if (ValidateACtype(out ErrorMessage))
            {

            }
            else if (!Error)
            {
                MsgBox.Show(ErrorMessage, "Aircraft INFORMATION NEEDED", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            if (!IsValidAltitude(out ErrorMessage))
            {
                Error = true;
                sb.AppendLine(ErrorMessage);
                ErrorMessage = "";
            }

            if (cbFlightRules.SelectedItem == "IFR")
            {
                bool SidValid = isSIDValid(out ErrorMessage);

                if (!SidValid)
                {
                    Error = true;
                    sb.AppendLine(ErrorMessage);
                    ErrorMessage = "";
                }


                if (SidValid && !isTransitionValid(out ErrorMessage))
                {
                    Error = true;
                    sb.AppendLine(ErrorMessage);
                    ErrorMessage = "";
                }

                if (SidValid && !CheckRestrictions(out ErrorMessage))
                {
                    Error = true;
                    sb.AppendLine(ErrorMessage);
                    ErrorMessage = "";
                }
            }

            if (Error)
            {
                MsgBox.Show(sb.ToString(), "FLIGHTPLAN ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DisplayScript();
            }
        }

        private bool isSIDValid(out string errorMessage)
        {
            if (flightplan.DepartureCustomRecord != null && flightplan.DepartureCustomRecord.SidRequired == false)
            {
                errorMessage = "";
                return true;
            }

            if (flightplan.SID != null)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = "SID is invalid you must select a valid SID";
                return false;
            }
        }

        private void ShowPreferedRunway(flightplan fp)
        {
            tbPreferedRW.Text = fp.DepartureRW;
        }

        private void ShowAircraftType()
        {
            tbPropType.Text = flightplan.EngineType.ToString();
            tbAcInfo.Text = flightplan.Aircraft.Manufacturer.ToString().Trim() + " " + flightplan.Aircraft.Model.ToString().Trim();
            cbIsHeavy.Checked = flightplan.IsHeavy;
        }

        private bool GetAirportInfo(flightplan fp)
        {
            //Create DataSet
            DataSet ds = new DataSet("dsAirportInfo");

            //Create data Table and populate Columns
            DataTable dt = ds.Tables.Add("AirPortDetails");
            dt.Columns.Add("Source");
            dt.Columns.Add("ICAO");
            dt.Columns.Add("Name");
            dt.Columns.Add("Location");
            dt.Columns.Add("Country");
            dt.Columns.Add("SidRequired");
            dt.Columns.Add("HasDeparturePlan");

            //Get Departure Airport Details
            WebService.Airport Departure = null;

            var Departures = Program.AtcHelper_AirportDetails.Where(p => p.ICAO_ID == fp.Departure);
            foreach (var match in Departures)
            {
                Departure = match;
            }

            if (Departure == null)
            {
                VatSim.Data.Airport va = Program.dataManager.Airports[fp.Departure.Trim().ToUpper()];

                if (va != null)
                {
                    Departure = new WebService.Airport();
                    Departure.ICAO_ID = va.Icao;
                    Departure.Name = va.Name;
                }
            }

            //Get Arrival Airport Details
            WebService.Airport Arrival = null;
            var Arrivals = Program.AtcHelper_AirportDetails.Where(p => p.ICAO_ID == fp.Destination);
            foreach (var match in Arrivals)
            {
                Arrival = match;
            }

            if (Arrival == null)
            {
                VatSim.Data.Airport va = Program.dataManager.Airports[fp.Destination.Trim().ToUpper()];

                if (va != null)
                {
                    Arrival = new WebService.Airport();
                    Arrival.ICAO_ID = va.Icao;
                    Arrival.Name = va.Name;
                }
            }

            //Populate Rows
            DataRow drDeparture = dt.NewRow();
            drDeparture["Source"] = "Depart";
            drDeparture["ICAO"] = Departure.ICAO_ID;
            drDeparture["Name"] = Departure.Name;
            drDeparture["Location"] = Departure.Location;
            drDeparture["Country"] = Departure.Country;
            drDeparture["SidRequired"] = Departure.SidRequired == false ? "No" : "Yes";
            drDeparture["HasDeparturePlan"] = Departure.HasDeparturePlan == false ? "No" : "Yes";

            DataRow drArrival = dt.NewRow();
            drArrival["Source"] = "Arrive";
            drArrival["ICAO"] = Arrival.ICAO_ID;
            drArrival["Name"] = Arrival.Name;
            drArrival["Location"] = Arrival.Location;
            drArrival["Country"] = Arrival.Country;

            //Add Rows to Table
            dt.Rows.Add(drDeparture);
            dt.Rows.Add(drArrival);

            dgvAirports.DataSource = dt;

            dgvAirports.AutoResizeColumns();

            return true;
        }

        private void ShowRouteInformation(flightplan fp)
        {
            //Create DataSet
            DataSet ds = new DataSet("dsRoute");

            //Create data Table and populate Columns
            DataTable dt = ds.Tables.Add("RouteDetails");
            dt.Columns.Add("Identifier");
            dt.Columns.Add("Name");
            dt.Columns.Add("Type");


            foreach (Waypoint wp in fp.Route.Waypoints)
            {
                if (wp != null && wp.Record != null)
                {
                    DataRow dr = dt.NewRow();


                    switch (wp.Type)
                    {
                        case WaypointTypes.Airport:
                            ArincReader.Arinc424.Records.Airport APrecord = (ArincReader.Arinc424.Records.Airport)wp.Record;
                            dr["Identifier"] = APrecord.AirportICAOIdentifier;
                            dr["Name"] = APrecord.AirportName;
                            dr["Type"] = "Airport";
                            break;
                        case WaypointTypes.AirportApproach:
                            ArincReader.Arinc424.Records.AirportApproach AArecord = (ArincReader.Arinc424.Records.AirportApproach)wp.Record;
                            dr["Identifier"] = AArecord.ProcedureIdentifier;
                            dr["Name"] = AArecord.ProcedureIdentifier;
                            dr["Type"] = "Approach";
                            break;
                        case WaypointTypes.AirportRunway:
                            ArincReader.Arinc424.Records.AirportRunway ARrecord = (ArincReader.Arinc424.Records.AirportRunway)wp.Record;
                            dr["Identifier"] = ARrecord.RunwayIdentifier;
                            dr["Name"] = ARrecord.RunwayIdentifier;
                            dr["Type"] = "Runway";
                            break;
                        case WaypointTypes.AirportSid:
                            ArincReader.Arinc424.Records.AirportSid ASrecord = (ArincReader.Arinc424.Records.AirportSid)wp.Record;
                            dr["Identifier"] = ASrecord.ProcedureIdentifier;
                            dr["Name"] = ASrecord.ProcedureIdentifier;
                            dr["Type"] = "SID";
                            break;
                        case WaypointTypes.AirportStar:
                            ArincReader.Arinc424.Records.AirportStar ASTrecord = (ArincReader.Arinc424.Records.AirportStar)wp.Record;
                            dr["Identifier"] = ASTrecord.ProcedureIdentifier;
                            dr["Name"] = ASTrecord.ProcedureIdentifier;
                            dr["Type"] = "STAR";
                            break;
                        case WaypointTypes.EnrouteAirway:
                            ArincReader.Arinc424.Records.EnrouteAirway EArecord = (ArincReader.Arinc424.Records.EnrouteAirway)wp.Record;
                            dr["Identifier"] = EArecord.RouteIdentifier;
                            dr["Name"] = EArecord.RouteType;
                            dr["Type"] = "Airway";
                            break;
                        case WaypointTypes.NDBNavAidEnroute:
                            ArincReader.Arinc424.Records.NdbNavaidEnroute NErecord = (ArincReader.Arinc424.Records.NdbNavaidEnroute)wp.Record;
                            dr["Identifier"] = NErecord.NDBIdentifier;
                            dr["Name"] = NErecord.NDBName;
                            dr["Type"] = "NDB - Enroute";
                            break;
                        case WaypointTypes.NDBNavAidTerminal:
                            ArincReader.Arinc424.Records.NdbNavaidTerminal NTrecord = (ArincReader.Arinc424.Records.NdbNavaidTerminal)wp.Record;
                            dr["Identifier"] = NTrecord.NDBIdentifier;
                            dr["Name"] = NTrecord.NDBName;
                            dr["Type"] = "NDB - Terminal";
                            break;
                        case WaypointTypes.NDBNavAid:
                            //This is a base class and SHOULD NOT be used
                            break;
                        case WaypointTypes.VhfNavAid:
                            ArincReader.Arinc424.Records.VhfNavaid VNrecord = (ArincReader.Arinc424.Records.VhfNavaid)wp.Record;
                            dr["Identifier"] = VNrecord.VORIdentifier;
                            dr["Name"] = VNrecord.VORName;
                            dr["Type"] = "VOR";
                            break;
                        case WaypointTypes.Waypoint:
                            //This is a base class and SHOULD NOT be used
                            break;
                        case WaypointTypes.WaypointEnroute:
                            ArincReader.Arinc424.Records.WaypointEnroute WErecord = (ArincReader.Arinc424.Records.WaypointEnroute)wp.Record;
                            dr["Identifier"] = WErecord.WaypointIdentifier;
                            dr["Name"] = WErecord.WaypointName;
                            dr["Type"] = "Waypoint - Enroute";
                            break;
                        case WaypointTypes.WaypointHeliportTerminal:
                            ArincReader.Arinc424.Records.WaypointHeliportTerminal WHTrecord = (ArincReader.Arinc424.Records.WaypointHeliportTerminal)wp.Record;
                            dr["Identifier"] = WHTrecord.WaypointIdentifier;
                            dr["Name"] = WHTrecord.WaypointName;
                            dr["Type"] = "Waypoint - Heliport Terminal";
                            break;
                        case WaypointTypes.WaypointTerminal:
                            ArincReader.Arinc424.Records.WaypointTerminal WTrecord = (ArincReader.Arinc424.Records.WaypointTerminal)wp.Record;
                            dr["Identifier"] = WTrecord.WaypointIdentifier;
                            dr["Name"] = WTrecord.WaypointName;
                            dr["Type"] = "Waypoint - Terminal";
                            break;
                        case WaypointTypes.HeliportApproach:
                            ArincReader.Arinc424.Records.HeliportApproach HArecord = (ArincReader.Arinc424.Records.HeliportApproach)wp.Record;
                            dr["Identifier"] = HArecord.ProcedureIdentifier;
                            dr["Name"] = HArecord.ProcedureIdentifier;
                            dr["Type"] = "Heliport Approach";
                            break;
                        case WaypointTypes.HeliportMSA:
                            //NOT USED
                            break;
                        case WaypointTypes.HeliportSid:
                            ArincReader.Arinc424.Records.HeliportSid HSrecord = (ArincReader.Arinc424.Records.HeliportSid)wp.Record;
                            dr["Identifier"] = HSrecord.ProcedureIdentifier;
                            dr["Name"] = HSrecord.ProcedureIdentifier;
                            dr["Type"] = "Heliport SID";
                            break;
                        case WaypointTypes.HeliportStar:
                            ArincReader.Arinc424.Records.HeliportStar HSTrecord = (ArincReader.Arinc424.Records.HeliportStar)wp.Record;
                            dr["Identifier"] = HSTrecord.ProcedureIdentifier;
                            dr["Name"] = HSTrecord.ProcedureIdentifier;
                            dr["Type"] = "Heliport STAR";
                            break;
                        case WaypointTypes.Heliport:
                            ArincReader.Arinc424.Records.Heliport HPrecord = (ArincReader.Arinc424.Records.Heliport)wp.Record;
                            dr["Identifier"] = HPrecord.PADIdentifier;
                            dr["Name"] = HPrecord.HeliportName;
                            dr["Type"] = "Heliport";
                            break;
                        case WaypointTypes.Transition:
                            switch (wp.TransitionType)
                            {
                                case WaypointTypes.Airport:
                                    //ArincReader.Arinc424.Records.Airport APrecord = (ArincReader.Arinc424.Records.Airport)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.Airport)wp.Record).AirportICAOIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.Airport)wp.Record).AirportName;
                                    dr["Type"] = "Transition - Airport";
                                    break;
                                case WaypointTypes.AirportApproach:
                                    //ArincReader.Arinc424.Records.AirportApproach AArecord = (ArincReader.Arinc424.Records.AirportApproach)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.AirportApproach)wp.Record).ProcedureIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.AirportApproach)wp.Record).ProcedureIdentifier;
                                    dr["Type"] = "Transition - Approach";
                                    break;
                                case WaypointTypes.AirportRunway:
                                    //ArincReader.Arinc424.Records.AirportRunway ARrecord = (ArincReader.Arinc424.Records.AirportRunway)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.AirportRunway)wp.Record).RunwayIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.AirportRunway)wp.Record).RunwayIdentifier;
                                    dr["Type"] = "Transition - Runway";
                                    break;
                                case WaypointTypes.AirportSid:
                                    //ArincReader.Arinc424.Records.AirportSid ASrecord = (ArincReader.Arinc424.Records.AirportSid)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.AirportSid)wp.Record).ProcedureIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.AirportSid)wp.Record).ProcedureIdentifier;
                                    dr["Type"] = "Transition - SID";
                                    break;
                                case WaypointTypes.AirportStar:
                                    //ArincReader.Arinc424.Records.AirportStar ASTrecord = (ArincReader.Arinc424.Records.AirportStar)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.AirportStar)wp.Record).ProcedureIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.AirportStar)wp.Record).ProcedureIdentifier;
                                    dr["Type"] = "Transition - STAR";
                                    break;
                                case WaypointTypes.EnrouteAirway:
                                    //ArincReader.Arinc424.Records.EnrouteAirway EArecord = (ArincReader.Arinc424.Records.EnrouteAirway)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.EnrouteAirway)wp.Record).RouteIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.EnrouteAirway)wp.Record).RouteType;
                                    dr["Type"] = "Transition - Airway";
                                    break;
                                case WaypointTypes.NDBNavAidEnroute:
                                    //ArincReader.Arinc424.Records.NdbNavaidEnroute NErecord = (ArincReader.Arinc424.Records.NdbNavaidEnroute)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.NdbNavaidEnroute)wp.Record).NDBIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.NdbNavaidEnroute)wp.Record).NDBName;
                                    dr["Type"] = "Transition - NDB - Enroute";
                                    break;
                                case WaypointTypes.NDBNavAidTerminal:
                                    //ArincReader.Arinc424.Records.NdbNavaidTerminal NTrecord = (ArincReader.Arinc424.Records.NdbNavaidTerminal)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.NdbNavaidTerminal)wp.Record).NDBIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.NdbNavaidTerminal)wp.Record).NDBName;
                                    dr["Type"] = "Transition - NDB - Terminal";
                                    break;
                                case WaypointTypes.NDBNavAid:
                                    //This is a base class and SHOULD NOT be used
                                    break;
                                case WaypointTypes.VhfNavAid:
                                    //ArincReader.Arinc424.Records.VhfNavaid VNrecord = (ArincReader.Arinc424.Records.VhfNavaid)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.VhfNavaid)wp.Record).VORIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.VhfNavaid)wp.Record).VORName;
                                    dr["Type"] = "Transition - VOR";
                                    break;
                                case WaypointTypes.Waypoint:
                                    //This is a base class and SHOULD NOT be used
                                    break;
                                case WaypointTypes.WaypointEnroute:
                                    //ArincReader.Arinc424.Records.WaypointEnroute WErecord = (ArincReader.Arinc424.Records.WaypointEnroute)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.WaypointEnroute)wp.Record).WaypointIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.WaypointEnroute)wp.Record).WaypointName;
                                    dr["Type"] = "Transition - Waypoint - Enroute";
                                    break;
                                case WaypointTypes.WaypointHeliportTerminal:
                                    //ArincReader.Arinc424.Records.WaypointHeliportTerminal WHTrecord = (ArincReader.Arinc424.Records.WaypointHeliportTerminal)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.WaypointHeliportTerminal)wp.Record).WaypointIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.WaypointHeliportTerminal)wp.Record).WaypointName;
                                    dr["Type"] = "Transition - Waypoint - Heliport Terminal";
                                    break;
                                case WaypointTypes.WaypointTerminal:
                                    //ArincReader.Arinc424.Records.WaypointTerminal WTrecord = (ArincReader.Arinc424.Records.WaypointTerminal)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.WaypointTerminal)wp.Record).WaypointIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.WaypointTerminal)wp.Record).WaypointName;
                                    dr["Type"] = "Transition - Waypoint - Terminal";
                                    break;
                                case WaypointTypes.HeliportApproach:
                                    //ArincReader.Arinc424.Records.HeliportApproach HArecord = (ArincReader.Arinc424.Records.HeliportApproach)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.HeliportApproach)wp.Record).ProcedureIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.HeliportApproach)wp.Record).ProcedureIdentifier;
                                    dr["Type"] = "Transition - Heliport Approach";
                                    break;
                                case WaypointTypes.HeliportMSA:
                                    //NOT USED
                                    break;
                                case WaypointTypes.HeliportSid:
                                    //ArincReader.Arinc424.Records.HeliportSid HSrecord = (ArincReader.Arinc424.Records.HeliportSid)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.HeliportSid)wp.Record).ProcedureIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.HeliportSid)wp.Record).ProcedureIdentifier;
                                    dr["Type"] = "Transition - Heliport SID";
                                    break;
                                case WaypointTypes.HeliportStar:
                                    //ArincReader.Arinc424.Records.HeliportStar HSTrecord = (ArincReader.Arinc424.Records.HeliportStar)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.HeliportStar)wp.Record).ProcedureIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.HeliportStar)wp.Record).ProcedureIdentifier;
                                    dr["Type"] = "Transition - Heliport STAR";
                                    break;
                                case WaypointTypes.Heliport:
                                    //ArincReader.Arinc424.Records.Heliport HPrecord = (ArincReader.Arinc424.Records.Heliport)wp.Record;
                                    dr["Identifier"] = ((ArincReader.Arinc424.Records.Heliport)wp.Record).PADIdentifier;
                                    dr["Name"] = ((ArincReader.Arinc424.Records.Heliport)wp.Record).HeliportName;
                                    dr["Type"] = "Transition - Heliport";
                                    break;
                                case WaypointTypes.Transition:
                                    break;
                                default:
                                    break;
                            }
                            //ArincReader.Arinc424.Records.BaseRecord TPrecord = (ArincReader.Arinc424.Records.Airport)wp.Record;
                            //dr["Identifier"] = APrecord.AirportICAOIdentifier;
                            //dr["Name"] = APrecord.AirportName;
                            //dr["Type"] = "Transition";
                            break;
                        default:
                            break;
                    }

                    if (dr != null)
                        dt.Rows.Add(dr);
                }

            }

            dgvRouteInformation.DataSource = dt;

            dgvRouteInformation.AutoResizeColumns();
        }

        private string ShowFullCallsign()
        {
            //take first 3
            string cs = tbCallsign.Text.Substring(0, 3);
            string num = tbCallsign.Text.Substring(3, tbCallsign.Text.Length - 3);
            string expandedCallsign = "";

            string result = tbCallsign.Text;

            var matches = Program.AtcHelper_CallSigns.Where(p => p.AirlineID == cs);
            foreach (var match in matches)
            {
                expandedCallsign = match.CallSign1 ?? match.Company;
            }

            if (expandedCallsign != "")
            {
                result = expandedCallsign + " " + num.ToString();
                tbCS.Text = expandedCallsign + " " + num.ToString();
            }

            return result;
        }

        private bool isTransitionValid(out string error)
        {

            if (flightplan.DepartureCustomRecord != null && flightplan.DepartureCustomRecord.SidRequired == false)
            {
                error = "";
                return true;
            }

            if (flightplan.SID == null)
            {
                error = "";
                return false;
            }
            if (flightplan.SID.strSidTransitions.Contains(flightplan.Transition))
            {
                error = "";
                return true;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Invalid transition Selected.  Valid SIDs are:");
                foreach (string item in flightplan.SID.strSidTransitions)
                {
                    sb.AppendLine("     " + item);
                }

                error = sb.ToString();
                return false;

            }
        }

        private bool ValidateAirport(string airportID)
        {
            if (string.IsNullOrEmpty(airportID))
            {
                return false;
            }

            var airports =
                from ap
                in Program.AtcHelper_AirportDetails
                where ap.ICAO_ID.ToUpper() == airportID.ToUpper()
                select ap;

            foreach (var item in airports)
            {
                if (item.ICAO_ID.Trim().ToUpper() == airportID.Trim().ToUpper())
                {
                    return true;
                }
            }

            try
            {
                VatSim.Data.Airport va = Program.dataManager.Airports[airportID.Trim().ToUpper()];

                if (va != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }



            return false;
        }

        private bool IsValidAltitude(out string ErrorMessage)
        {
            int Ones, Tens, Hundreds, Thousands, TenThousands;
            PlaceValues(flightplan.CruiseAlt, out Ones, out Tens, out Hundreds, out Thousands, out TenThousands);

            StringBuilder sbErrorMessage = new StringBuilder();

            if (flightplan.FlightRules.ToUpper() == "IFR")
            {

                if (Hundreds != 0)
                {
                    //VFR Altitude Selected

                    sbErrorMessage.Append(ShowFullCallsign() + " Incorrect altitude selected for Flight rules do you want ");

                    int high;
                    int low;

                    GetRecomendedAlt(flightplan, out high, out low);

                    sbErrorMessage.Append(AltString(high) + " or " + AltString(low));

                    ErrorMessage = sbErrorMessage.ToString();
                    this.ActiveControl = tbCruiseAlt;
                    return false;
                }

                bool isEvenAlt;
                if (Thousands % 2 == 0) { isEvenAlt = true; } else { isEvenAlt = false; }

                //Altitude for direction of flight
                if (cbDirectionOfFlight.SelectedItem.ToString().ToLower() == "east")
                {
                    if (isEvenAlt)
                    {
                        //Incorrect Alt for direction of flight
                        sbErrorMessage.Append(ShowFullCallsign() + " Incorrect altitude for direction of flight do you want ");

                        int high;
                        int low;

                        GetRecomendedAlt(flightplan, out high, out low);

                        sbErrorMessage.Append(AltString(high) + " or " + AltString(low));

                        ErrorMessage = sbErrorMessage.ToString();
                        this.ActiveControl = tbCruiseAlt;
                        return false;
                    }
                }
                else
                {
                    if (!isEvenAlt)
                    {
                        //Incorrect Alt for direction of flight
                        sbErrorMessage.Append(ShowFullCallsign() + " Incorrect altitude for direction of flight do you want ");

                        int high;
                        int low;

                        GetRecomendedAlt(flightplan, out high, out low);

                        sbErrorMessage.Append(AltString(high) + " or " + AltString(low));

                        ErrorMessage = sbErrorMessage.ToString();
                        this.ActiveControl = tbCruiseAlt;
                        return false;
                    }
                }
            }

            if (flightplan.FlightRules.ToUpper() == "VFR")
            {
                if (Hundreds != 5)
                {
                    //IFR Altitude Selected
                    sbErrorMessage.Append(ShowFullCallsign() + " Incorrect altitude selected for Flight rules do you want ");

                    int high;
                    int low;

                    GetRecomendedAlt(flightplan, out high, out low);

                    sbErrorMessage.Append(AltString(high) + " or " + AltString(low));

                    ErrorMessage = sbErrorMessage.ToString();
                    this.ActiveControl = tbCruiseAlt;
                    return false;
                }

                bool isEvenAlt;
                if (Thousands % 2 == 0) { isEvenAlt = true; } else { isEvenAlt = false; }

                //Altitude for direction of flight
                if (cbDirectionOfFlight.SelectedItem.ToString().ToLower() == "east")
                {
                    if (isEvenAlt)
                    {
                        //Incorrect Alt for direction of flight

                        sbErrorMessage.Append(ShowFullCallsign() + " Incorrect altitude for direction of flight do you want ");

                        int high;
                        int low;

                        GetRecomendedAlt(flightplan, out high, out low);

                        sbErrorMessage.Append(AltString(high) + " or " + AltString(low));

                        ErrorMessage = sbErrorMessage.ToString();
                        this.ActiveControl = tbCruiseAlt;
                        return false;
                    }
                }
                else
                {
                    if (!isEvenAlt)
                    {
                        //Incorrect Alt for direction of flight
                        sbErrorMessage.Append(ShowFullCallsign() + " Incorrect altitude for direction of flight do you want ");

                        int high;
                        int low;

                        GetRecomendedAlt(flightplan, out high, out low);

                        sbErrorMessage.Append(AltString(high) + " or " + AltString(low));

                        ErrorMessage = sbErrorMessage.ToString();
                        this.ActiveControl = tbCruiseAlt;
                        return false;
                    }
                }
            }

            ErrorMessage = null;
            return true;
        }

        private void PlaceValues(int alt, out int ones, out int tens, out int hundreds, out int thousands, out int tenthousands)
        {
            string num = alt.ToString();
            ones = 0; tens = 0; hundreds = 0; thousands = 0; tenthousands = 0;
            for (int i = 1; i <= num.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        ones = int.Parse(num.Substring(num.Length - i, 1));
                        break;
                    case 2:
                        tens = int.Parse(num.Substring(num.Length - i, 1));
                        break;
                    case 3:
                        hundreds = int.Parse(num.Substring(num.Length - i, 1));
                        break;
                    case 4:
                        thousands = int.Parse(num.Substring(num.Length - i, 1));
                        break;
                    case 5:
                        tenthousands = int.Parse(num.Substring(num.Length - i, 1));
                        break;



                }
            }
        }

        private void GetRecomendedAlt(flightplan fp, out int suggestedHigh, out int suggestedLow)
        {
            int RequestedAlt = fp.CruiseAlt;

            int Ones, Tens, Hundreds, Thousands, TenThousands;
            PlaceValues(RequestedAlt, out Ones, out Tens, out Hundreds, out Thousands, out TenThousands);

            int intFirstTwoDigits;
            string strFirstTwoDigits;

            strFirstTwoDigits = TenThousands.ToString() + Thousands.ToString();
            intFirstTwoDigits = int.Parse(strFirstTwoDigits);

            StringBuilder HighAlt = new StringBuilder();
            StringBuilder LowAlt = new StringBuilder();

            if (fp.DirectionOfFlight.ToLower() == "east")
            {
                //Traveling EAST

                if (fp.FlightRules.ToLower() == "ifr")
                {
                    //EAST bound IFR
                    //ODD Thousand 0 hundreds

                    if (intFirstTwoDigits % 2 == 0)
                    {
                        //EVEN Altitude we need to Change
                        HighAlt.Append((intFirstTwoDigits + 1));
                        LowAlt.Append((intFirstTwoDigits - 1));

                        //Add 1's, 10's and 100's
                        HighAlt.Append(("000"));
                        LowAlt.Append(("000"));
                    }
                    else
                    {
                        //Original Altitude was even

                        if (Hundreds == 5)
                        {
                            //Original Altitude was VFR
                            HighAlt.Append((intFirstTwoDigits + 2));
                            LowAlt.Append((intFirstTwoDigits));

                        }
                        else
                        {
                            //Original Altitude was IFR
                            //Do not need to change High Alt
                            HighAlt.Append((intFirstTwoDigits));
                            LowAlt.Append((intFirstTwoDigits - 2));
                        }

                        //Add 1's, 10's and 100's
                        HighAlt.Append(("000"));
                        LowAlt.Append(("000"));
                    }

                }
                else
                {
                    //EAST bound VFR
                    //ODD thousands 5 hundreds
                    if (intFirstTwoDigits % 2 == 0)
                    {
                        //EVEN Altitude we need to Change
                        HighAlt.Append((intFirstTwoDigits + 1));
                        LowAlt.Append((intFirstTwoDigits - 1));

                        //Add 1's, 10's and 100's
                        HighAlt.Append(("500"));
                        LowAlt.Append(("500"));
                    }
                    else
                    {
                        //ODD Do not need to change high alt
                        HighAlt.Append((intFirstTwoDigits));
                        LowAlt.Append((intFirstTwoDigits - 2));

                        //Add 1's, 10's and 100's
                        HighAlt.Append(("500"));
                        LowAlt.Append(("500"));
                    }
                }
            }
            else
            {
                //Traveling WEST

                if (fp.FlightRules.ToLower() == "ifr")
                {
                    //WEST bound IFR
                    //EVEN Thousand 0 hundreds
                    if (intFirstTwoDigits % 2 != 0)
                    {
                        //ODD Altitude we need to Change
                        HighAlt.Append((intFirstTwoDigits + 1));
                        LowAlt.Append((intFirstTwoDigits - 1));

                        //Add 1's, 10's and 100's
                        HighAlt.Append(("000"));
                        LowAlt.Append(("000"));
                    }
                    else
                    {
                        //Original Altitude was even

                        if (Hundreds == 5)
                        {
                            //Original Altitude was VFR
                            HighAlt.Append((intFirstTwoDigits + 2));
                            LowAlt.Append((intFirstTwoDigits));

                        }
                        else
                        {
                            //Original Altitude was IFR
                            //Do not need to change High Alt
                            HighAlt.Append((intFirstTwoDigits));
                            LowAlt.Append((intFirstTwoDigits - 2));
                        }



                        //Add 1's, 10's and 100's
                        HighAlt.Append(("000"));
                        LowAlt.Append(("000"));
                    }

                }
                else
                {
                    //WEST bound VFR
                    //EVEN Thousand 5 hundreds
                    if (intFirstTwoDigits % 2 != 0)
                    {
                        //ODD Altitude we need to Change
                        HighAlt.Append((intFirstTwoDigits + 1));
                        LowAlt.Append((intFirstTwoDigits - 1));

                        //Add 1's, 10's and 100's
                        HighAlt.Append(("500"));
                        LowAlt.Append(("500"));
                    }
                    else
                    {
                        //Even Do not need to change high alt
                        HighAlt.Append((intFirstTwoDigits));
                        LowAlt.Append((intFirstTwoDigits - 2));

                        //Add 1's, 10's and 100's
                        HighAlt.Append(("500"));
                        LowAlt.Append(("500"));
                    }

                }

            }

            if (HighAlt.Length > 0)
            {
                suggestedHigh = int.Parse(HighAlt.ToString());
            }
            else
            {
                suggestedHigh = 0;
            }

            if (LowAlt.Length > 0)
            {
                suggestedLow = int.Parse(LowAlt.ToString());
            }
            else
            {
                suggestedLow = 0;
            }


        }

        private string AltString(int alt)
        {
            string Altitude;

            int Ones, Tens, Hundreds, Thousands, TenThousands;

            PlaceValues(alt, out Ones, out Tens, out Hundreds, out Thousands, out TenThousands);

            if (alt >= 18000)
            {
                Altitude = "FL" + TenThousands.ToString() + Thousands.ToString() + Hundreds.ToString();
            }
            else
            {
                Altitude = alt.ToString();
            }

            return Altitude;
        }

        private bool CheckRestrictions(out string errorMessage)
        {
            bool result = true;
            errorMessage = string.Empty;

            if (flightplan.DepartureCustomRecord != null || flightplan.DepartureCustomRecord.SidRequired == false)
            {
                errorMessage = "";
                return true;
            }


            var Restrictions =
                from rest
                in Program.AtcHelper_SidRestrictions
                where rest.Airport_ICAO_Id == flightplan.Departure && rest.SID_Id == flightplan.SID.SidIdentifier
                select rest;

            if (Restrictions == null)
                return true;

            foreach (var item in Restrictions)
            {
                //Check if Max altitude restriction violation
                if (flightplan.CruiseAlt > item.Max_Cruise_Alt)
                {
                    result = false;
                    errorMessage += "Flight plan cruise altitude of " + flightplan.CruiseAlt.ToString() + " violates the max altitude restriction of " + item.Max_Cruise_Alt.ToString() + " for the " + flightplan.SID.SidIdentifier + " departure";
                    errorMessage += "\n\r";
                }

                if (flightplan.CruiseAlt < item.Min_Cruise_Alt)
                {
                    result = false;
                    errorMessage += "Flight plan cruise altitude of " + flightplan.CruiseAlt.ToString() + " violates the minimum altitude restriction of " + item.Min_Cruise_Alt.ToString() + " for the " + flightplan.SID.SidIdentifier + " departure";
                    errorMessage += "\n\r";
                }

                if (flightplan.EngineType.ToUpper() != item.EngineType.ToUpper() && item.EngineType.ToUpper() != "ALL")
                {
                    result = false;
                    errorMessage += "Engine type of " + flightplan.EngineType + " violates the engine type of " + item.EngineType + " for the " + flightplan.SID.SidIdentifier + " departure";
                    errorMessage += "\n\r";
                }

                //Rnav TypeDesignators are /L /Z /G
                if (item.RNAV_Only.ToUpper() == "TRUE")
                {
                    if (flightplan.EquiptmentSuffix != EquiptmentSuffix.L && flightplan.EquiptmentSuffix != EquiptmentSuffix.Z && flightplan.EquiptmentSuffix != EquiptmentSuffix.G)
                    {
                        result = false;
                        errorMessage += "Aircraft type designatior of " + flightplan.EquiptmentSuffix + " can not fly the " + flightplan.SID.SidIdentifier + " RNAV departure";
                        errorMessage += "\n\r";
                    }

                }
            }

            return result;
        }

        private string GetFullNavAidName(Waypoint wp)
        {
            string result;

            string LongName;
            string ShortName;

            if (wp == null || wp.Record == null)
                return "";

            if (wp.Type == WaypointTypes.Transition)
            {
                switch (wp.TransitionType)
                {
                    case WaypointTypes.Airport:
                        LongName = ((ArincReader.Arinc424.Records.Airport)wp.Record).AirportName;
                        ShortName = ((ArincReader.Arinc424.Records.Airport)wp.Record).AirportICAOIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                    case WaypointTypes.AirportApproach:
                        return ((ArincReader.Arinc424.Records.AirportApproach)wp.Record).ProcedureIdentifier.Trim();

                    case WaypointTypes.AirportRunway:
                        return ((ArincReader.Arinc424.Records.AirportRunway)wp.Record).RunwayIdentifier.Trim();

                    case WaypointTypes.AirportSid:
                        return ((ArincReader.Arinc424.Records.AirportSid)wp.Record).ProcedureIdentifier.Trim();

                    case WaypointTypes.AirportStar:
                        return ((ArincReader.Arinc424.Records.AirportStar)wp.Record).ProcedureIdentifier.Trim();

                    case WaypointTypes.EnrouteAirway:
                        return ((ArincReader.Arinc424.Records.EnrouteAirway)wp.Record).RouteIdentifier.Trim();

                    case WaypointTypes.NDBNavAidEnroute:
                        LongName = ((ArincReader.Arinc424.Records.NdbNavaidEnroute)wp.Record).NDBName;
                        ShortName = ((ArincReader.Arinc424.Records.NdbNavaidEnroute)wp.Record).NDBIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                    case WaypointTypes.NDBNavAidTerminal:
                        LongName = ((ArincReader.Arinc424.Records.NdbNavaidTerminal)wp.Record).NDBName;
                        ShortName = ((ArincReader.Arinc424.Records.NdbNavaidTerminal)wp.Record).NDBIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                    case WaypointTypes.NDBNavAid:
                        //This is a base class and SHOULD NOT be used
                        LongName = ((ArincReader.Arinc424.Records.NdbNavaid)wp.Record).NDBName;
                        ShortName = ((ArincReader.Arinc424.Records.NdbNavaid)wp.Record).NDBIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                    case WaypointTypes.VhfNavAid:
                        LongName = ((ArincReader.Arinc424.Records.VhfNavaid)wp.Record).VORName;
                        ShortName = ((ArincReader.Arinc424.Records.VhfNavaid)wp.Record).VORIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                    case WaypointTypes.Waypoint:
                        //This is a base class and SHOULD NOT be used
                        LongName = ((ArincReader.Arinc424.Records.Waypoint)wp.Record).WaypointName;
                        ShortName = ((ArincReader.Arinc424.Records.Waypoint)wp.Record).WaypointIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                        break;
                    case WaypointTypes.WaypointEnroute:
                        LongName = ((ArincReader.Arinc424.Records.WaypointEnroute)wp.Record).WaypointName;
                        ShortName = ((ArincReader.Arinc424.Records.WaypointEnroute)wp.Record).WaypointIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                    case WaypointTypes.WaypointHeliportTerminal:
                        LongName = ((ArincReader.Arinc424.Records.WaypointHeliportTerminal)wp.Record).WaypointName;
                        ShortName = ((ArincReader.Arinc424.Records.WaypointHeliportTerminal)wp.Record).WaypointIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                    case WaypointTypes.WaypointTerminal:
                        LongName = ((ArincReader.Arinc424.Records.WaypointTerminal)wp.Record).WaypointName;
                        ShortName = ((ArincReader.Arinc424.Records.WaypointTerminal)wp.Record).WaypointIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                    case WaypointTypes.HeliportApproach:
                        return ((ArincReader.Arinc424.Records.HeliportApproach)wp.Record).ProcedureIdentifier.Trim();

                    case WaypointTypes.HeliportMSA:
                        //NOT USED
                        break;
                    case WaypointTypes.HeliportSid:
                        return ((ArincReader.Arinc424.Records.HeliportSid)wp.Record).ProcedureIdentifier.Trim();

                    case WaypointTypes.HeliportStar:
                        return ((ArincReader.Arinc424.Records.HeliportStar)wp.Record).ProcedureIdentifier.Trim();

                    case WaypointTypes.Heliport:
                        LongName = ((ArincReader.Arinc424.Records.Heliport)wp.Record).HeliportName;
                        ShortName = ((ArincReader.Arinc424.Records.Heliport)wp.Record).PADIdentifier;
                        return (NullIfEmpty(LongName) ?? ShortName).Trim();

                    case WaypointTypes.Transition:
                        return wp.Name.Trim();

                    default:
                        break;
                }
            }
            else
            {
                switch (wp.Type)
                {
                    case WaypointTypes.Airport:
                        LongName = ((ArincReader.Arinc424.Records.Airport)wp.Record).AirportName;
                        ShortName = ((ArincReader.Arinc424.Records.Airport)wp.Record).AirportICAOIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                    case WaypointTypes.AirportApproach:
                        return ((ArincReader.Arinc424.Records.AirportApproach)wp.Record).ProcedureIdentifier;

                    case WaypointTypes.AirportRunway:
                        return ((ArincReader.Arinc424.Records.AirportRunway)wp.Record).RunwayIdentifier;

                    case WaypointTypes.AirportSid:
                        return ((ArincReader.Arinc424.Records.AirportSid)wp.Record).ProcedureIdentifier;

                    case WaypointTypes.AirportStar:
                        return ((ArincReader.Arinc424.Records.AirportStar)wp.Record).ProcedureIdentifier;

                    case WaypointTypes.EnrouteAirway:
                        return ((ArincReader.Arinc424.Records.EnrouteAirway)wp.Record).RouteIdentifier;

                    case WaypointTypes.NDBNavAidEnroute:
                        LongName = ((ArincReader.Arinc424.Records.NdbNavaidEnroute)wp.Record).NDBName;
                        ShortName = ((ArincReader.Arinc424.Records.NdbNavaidEnroute)wp.Record).NDBIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                    case WaypointTypes.NDBNavAidTerminal:
                        LongName = ((ArincReader.Arinc424.Records.NdbNavaidTerminal)wp.Record).NDBName;
                        ShortName = ((ArincReader.Arinc424.Records.NdbNavaidTerminal)wp.Record).NDBIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                    case WaypointTypes.NDBNavAid:
                        //This is a base class and SHOULD NOT be used
                        LongName = ((ArincReader.Arinc424.Records.NdbNavaid)wp.Record).NDBName;
                        ShortName = ((ArincReader.Arinc424.Records.NdbNavaid)wp.Record).NDBIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                    case WaypointTypes.VhfNavAid:
                        LongName = ((ArincReader.Arinc424.Records.VhfNavaid)wp.Record).VORName;
                        ShortName = ((ArincReader.Arinc424.Records.VhfNavaid)wp.Record).VORIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                    case WaypointTypes.Waypoint:
                        //This is a base class and SHOULD NOT be used
                        LongName = ((ArincReader.Arinc424.Records.Waypoint)wp.Record).WaypointName;
                        ShortName = ((ArincReader.Arinc424.Records.Waypoint)wp.Record).WaypointIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                        break;
                    case WaypointTypes.WaypointEnroute:
                        LongName = ((ArincReader.Arinc424.Records.WaypointEnroute)wp.Record).WaypointName;
                        ShortName = ((ArincReader.Arinc424.Records.WaypointEnroute)wp.Record).WaypointIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                    case WaypointTypes.WaypointHeliportTerminal:
                        LongName = ((ArincReader.Arinc424.Records.WaypointHeliportTerminal)wp.Record).WaypointName;
                        ShortName = ((ArincReader.Arinc424.Records.WaypointHeliportTerminal)wp.Record).WaypointIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                    case WaypointTypes.WaypointTerminal:
                        LongName = ((ArincReader.Arinc424.Records.WaypointTerminal)wp.Record).WaypointName;
                        ShortName = ((ArincReader.Arinc424.Records.WaypointTerminal)wp.Record).WaypointIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                    case WaypointTypes.HeliportApproach:
                        return ((ArincReader.Arinc424.Records.HeliportApproach)wp.Record).ProcedureIdentifier;

                    case WaypointTypes.HeliportMSA:
                        //NOT USED
                        break;
                    case WaypointTypes.HeliportSid:
                        return ((ArincReader.Arinc424.Records.HeliportSid)wp.Record).ProcedureIdentifier;

                    case WaypointTypes.HeliportStar:
                        return ((ArincReader.Arinc424.Records.HeliportStar)wp.Record).ProcedureIdentifier;

                    case WaypointTypes.Heliport:
                        LongName = ((ArincReader.Arinc424.Records.Heliport)wp.Record).HeliportName;
                        ShortName = ((ArincReader.Arinc424.Records.Heliport)wp.Record).PADIdentifier;
                        return NullIfEmpty(LongName) ?? ShortName;

                    case WaypointTypes.Transition:
                        return wp.Name;

                    default:
                        break;
                }
            }

            return "";
        }

        private bool ValidateACtype(out string ErrorMessage)
        {

            if (tbAcType.Text.Contains("/"))
            {
                ErrorMessage = "";
                return true;
            }
            else
            {
                ErrorMessage = ShowFullCallsign() + " say equiptment suffix.";
                tbAcType.BackColor = Color.PaleVioletRed;
                this.ActiveControl = tbAcType;
                return false;
            }
        }

        private bool ValidateFlightplan(out string ErrorMessage)
        {

            bool Error = false;
            StringBuilder sb = new StringBuilder();

            if (!ValidateACtype(out ErrorMessage))
            {
                tbAcType.Focus();
                tbAcType.BackColor = Color.MediumVioletRed;
                return false;
            }

            if (!IsValidAltitude(out ErrorMessage))
            {
                tbCruiseAlt.Focus();
                tbCruiseAlt.BackColor = Color.MediumVioletRed;
                return false;
            }

            if (cbFlightRules.SelectedItem == "IFR")
            {
                if (!isSIDValid(out ErrorMessage))
                {
                    tbRoute.Focus();
                    tbRoute.BackColor = Color.MediumVioletRed;
                    return false;
                }


                if (!isTransitionValid(out ErrorMessage))
                {
                    tbRoute.Focus();
                    tbRoute.BackColor = Color.MediumVioletRed;
                    return false;
                }

                if (!CheckRestrictions(out ErrorMessage))
                {
                    tbRoute.Focus();
                    tbRoute.BackColor = Color.MediumVioletRed;
                    return false;
                }
            }

            tbCallsign.Focus();
            return true;

        }

        private string GetPreferedRW(flightplan fp)
        {
            if (fp != null && (fp.PreferedRunway != null))
            {
                return fp.PreferedRunway;
            }

            string PreferedRW = "";

            if (fp == null) return "";

            bool airportconfigured = false;
            try
            {
                var airport =
                    (from ap
                    in Program.AtcHelper_AirportDetails
                     where ap.ICAO_ID == fp.Departure
                     select ap.IsConfigured).Single();

                airportconfigured = airport;

                if (!airportconfigured)
                {
                    return "";
                }
            }
            catch (Exception ex)
            {

            }

            if (fp.FlightRules.ToUpper() == "IFR")
            {
                var runway =
                        from rw
                        in Program.AtcHelper_DeparturePlan
                        where rw.ICAO_ID == fp.Departure && rw.FlightRules.ToUpper() == "IFR" && rw.SID_ID.ToUpper() == fp.SID.SidIdentifier.ToUpper()
                        select rw;

                if (runway == null | runway.Count() == 0)
                {
                    return "";
                }
                else if (runway.Count() == 1)
                {
                    fp.PreferedRunway = runway.First().Runway;
                    return runway.First().Runway;
                }
                else
                {
                    foreach (var item in runway)
                    {
                        if (item.Transition_ID.ToUpper() == fp.Transition.ToUpper())
                        {
                            fp.PreferedRunway = item.Runway;
                            return item.Runway;
                        }
                    }
                }



                return "";
            }
            else
            {

                if (flightplan.DepartureRecord != null || flightplan.DestinationRecord != null)
                {

                    double Dep_Lat = 0;
                    double Dep_Lon = 0;
                    double Dest_Lat = 0;
                    double Dest_Lon = 0;

                    if (flightplan != null && flightplan.DepartureRecord != null)
                    {
                        Dep_Lat = flightplan.DepartureRecord.ArpCoordinate.Latitude;
                        Dep_Lon = flightplan.DepartureRecord.ArpCoordinate.Longitude;
                    }

                    if (flightplan != null && flightplan.DestinationRecord != null)
                    {
                        Dest_Lat = flightplan.DestinationRecord.ArpCoordinate.Latitude;
                        Dest_Lon = flightplan.DestinationRecord.ArpCoordinate.Longitude;
                    }

                    if (Dep_Lat == 0 && Dep_Lon == 0)
                    {
                        //Go get from the Vatsim Record
                        Dep_Lat = flightplan.VatSim_DepartureAirport.Loc.Lat;
                        Dep_Lon = flightplan.VatSim_DepartureAirport.Loc.Lon;
                    }

                    if (Dest_Lat == 0 && Dest_Lon == 0)
                    {
                        //Go get from the Vatsim Record
                        Dest_Lat = flightplan.VatSim_DepartureAirport.Loc.Lat;
                        Dest_Lon = flightplan.VatSim_DepartureAirport.Loc.Lon;
                    }

                    GlobalPosition departure = new GlobalPosition(new Latitude(Dep_Lat), new Longitude(Dep_Lon));
                    GlobalPosition destination = new GlobalPosition(new Latitude(Dest_Lat), new Longitude(Dest_Lon));

                    double heading = departure.HeadingTo(destination);

                    if (heading > 315 || heading <= 45)
                    {
                        //North
                        var runway =
                            from rw
                            in Program.AtcHelper_DeparturePlan
                            where rw.ICAO_ID == fp.Departure && rw.FlightRules.ToUpper() == "VFR" && rw.DirectionOfFlight.ToUpper() == "NORTH"
                            select rw;

                        foreach (var item in runway)
                        {
                            fp.PreferedRunway = item.Runway;
                            return item.Runway;
                        }

                        return "";

                    }
                    else if (heading > 45 && heading <= 135)
                    {
                        //East
                        var runway =
                            from rw
                            in Program.AtcHelper_DeparturePlan
                            where rw.ICAO_ID == fp.Departure && rw.FlightRules.ToUpper() == "VFR" && rw.DirectionOfFlight.ToUpper() == "EAST"
                            select rw;

                        foreach (var item in runway)
                        {
                            fp.PreferedRunway = item.Runway;
                            return item.Runway;
                        }

                        return "";
                    }
                    else if (heading > 135 && heading <= 225)
                    {
                        //South
                        var runway =
                            from rw
                            in Program.AtcHelper_DeparturePlan
                            where rw.ICAO_ID == fp.Departure && rw.FlightRules.ToUpper() == "VFR" && rw.DirectionOfFlight.ToUpper() == "SOUTH"
                            select rw;

                        foreach (var item in runway)
                        {
                            fp.PreferedRunway = item.Runway;
                            return item.Runway;
                        }

                        return "";
                    }
                    else if (heading > 225 && heading <= 315)
                    {
                        //West
                        var runway =
                            from rw
                            in Program.AtcHelper_DeparturePlan
                            where rw.ICAO_ID == fp.Departure && rw.FlightRules.ToUpper() == "VFR" && rw.DirectionOfFlight.ToUpper() == "WEST"
                            select rw;

                        foreach (var item in runway)
                        {
                            fp.PreferedRunway = item.Runway;
                            return item.Runway;
                        }

                        return "";
                    }
                    else
                    {
                        //I have no idea where this is going!!!
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }


        }

        private string GetDestinationAirportName()
        {
            string Name = "";

            if (flightplan != null && flightplan.DestinationRecord != null)
                Name = (NullIfEmpty(flightplan.DestinationRecord.AirportName) ?? flightplan.DestinationRecord.AirportICAOIdentifier).Trim();
            else if (flightplan != null && flightplan.VatSim_DestinationAirport != null)
                Name = (NullIfEmpty(flightplan.VatSim_DestinationAirport.Name) ?? flightplan.VatSim_DestinationAirport.Icao).Trim();

            return Name.Trim();
        }

        private string GetDepartureAirportName()
        {
            string Name = "";

            if (flightplan != null && flightplan.DepartureRecord != null)
                Name = (NullIfEmpty(flightplan.DepartureRecord.AirportName) ?? flightplan.DepartureRecord.AirportICAOIdentifier).Trim();
            else if (flightplan != null && flightplan.VatSim_DepartureAirport != null)
                Name = (NullIfEmpty(flightplan.VatSim_DepartureAirport.Name) ?? flightplan.VatSim_DepartureAirport.Icao).Trim();

            return Name.Trim();
        }

        private bool ShowPDC(flightplan fp)
        {
            bool result = true;

            string RW = GetPreferedRW(fp);

            if (RW != null && tbDepId.Text != "")
            {
                tbPdc.Text = Properties.Settings.Default.Pdc + " " + tbDepId.Text.Trim() + " " + RW;
            }

            if (RW != null)
            {
                tbPdcMe.Text = Properties.Settings.Default.PdcMe + " " + RW;
                tbPdcNoDep.Text = Properties.Settings.Default.PdcNoDep + " " + RW;
            }



            return result;
        }

        #endregion Flightplan Helper Methods

        #region Geo Methods

        private void ShowDirectionOfFlight()
        {
            double Dep_Lat = 0;
            double Dep_Lon = 0;
            double Dest_Lat = 0;
            double Dest_Lon = 0;

            if (flightplan != null && flightplan.DepartureRecord != null)
            {
                Dep_Lat = flightplan.DepartureRecord.ArpCoordinate.Latitude;
                Dep_Lon = flightplan.DepartureRecord.ArpCoordinate.Longitude;
            }

            if (flightplan != null && flightplan.DestinationRecord != null)
            {
                Dest_Lat = flightplan.DestinationRecord.ArpCoordinate.Latitude;
                Dest_Lon = flightplan.DestinationRecord.ArpCoordinate.Longitude;
            }

            if (Dep_Lat == 0 && Dep_Lon == 0)
            {
                //Go get from the Vatsim Record
                Dep_Lat = flightplan.VatSim_DepartureAirport.Loc.Lat;
                Dep_Lon = flightplan.VatSim_DepartureAirport.Loc.Lon;
            }

            if (Dest_Lat == 0 && Dest_Lon == 0)
            {
                //Go get from the Vatsim Record
                Dest_Lat = flightplan.VatSim_DepartureAirport.Loc.Lat;
                Dest_Lon = flightplan.VatSim_DepartureAirport.Loc.Lon;
            }

            GlobalPosition departure = new GlobalPosition(new Latitude(Dep_Lat), new Longitude(Dep_Lon));
            GlobalPosition destination = new GlobalPosition(new Latitude(Dest_Lat), new Longitude(Dest_Lon));

            double heading = departure.HeadingTo(destination);

            tbDOF.Text = heading.ToString();

            if (heading >= 0 && heading <= 179)
            {
                cbDirectionOfFlight.SelectedValue = "East";
                cbDirectionOfFlight.SelectedIndex = 1;
            }
            else
            {
                cbDirectionOfFlight.SelectedValue = "West";
                cbDirectionOfFlight.SelectedIndex = 2;
            }

            int intCruiseAlt = int.Parse(tbCruiseAlt.Text);

            if (intCruiseAlt > 0)
            {
                switch (intCruiseAlt)
                {
                    //Source FAA Data - https://www.faa.gov/air_traffic/publications/atpubs/atc_html/chap4_section_5.html
                    case int n when (n < 3000):
                        tbAltEvenOdd.Text = "ANY";
                        break;
                    case int n when (n >= 3000 && n < 41000):
                        if (heading >= 0 && heading <= 179) tbAltEvenOdd.Text = "Odd Alt";
                        else tbAltEvenOdd.Text = "Even Alt";
                        break;
                    case int n when (n > 41000):
                        if (heading >= 0 && heading <= 179) tbAltEvenOdd.Text = "Odd Alt";
                        else tbAltEvenOdd.Text = "Even Alt";
                        break;

                }
            }


        }

        #region Samples

        private void SampleGPSInvocation()
        {
            //Source: https://www.codeproject.com/Articles/1136877/A-Handy-GPS-Class
            GlobalPosition pos1 = new GlobalPosition(new Latitude(flightplan.DepartureRecord.ArpCoordinate.Latitude), new Longitude(flightplan.DepartureRecord.ArpCoordinate.Longitude));
            GlobalPosition pos2 = new GlobalPosition(new Latitude(flightplan.DestinationRecord.ArpCoordinate.Latitude), new Longitude(flightplan.DestinationRecord.ArpCoordinate.Longitude));

            double distance = pos1.DistanceFrom(pos2, GlobalPosition.DistanceType.Miles, GlobalPosition.CalcType.Haversine);
            double distance2 = pos1.DistanceFrom(pos2, GlobalPosition.DistanceType.Miles, GlobalPosition.CalcType.Rhumb);

            double heading = pos1.HeadingTo(pos2);
            double heading2 = pos2.HeadingTo(pos1);
            double diff = Math.Round(Math.Abs(heading - heading2), 0);
            double diff2 = Math.Round(Math.Abs(heading2 - heading), 0);

            string pos1Str = pos1.ToString("DA");
            pos1Str = pos1.ToString("AD");
            string pos2Str = pos2.ToString("DA");
            pos1Str = pos1.ToString("da");
            pos1Str = pos1.ToString("DV");
            pos1Str = pos1.ToString("VD");

            List<GlobalPosition> list = new List<GlobalPosition>();
            list.Add(pos1);
            list.Add(pos2);
            list.Add(pos1);

            double bigDistance = GlobalPosition.TotalDistanceBetweenManyPoints(list, GlobalPosition.DistanceType.Miles, GlobalPosition.CalcType.Rhumb);
            double bigDistance2 = GlobalPosition.TotalDistanceBetweenManyPoints(list, GlobalPosition.DistanceType.Miles, GlobalPosition.CalcType.Rhumb);
        }

        #endregion Samples

        #endregion Geo Methods

        #region VatSim Event Handlers

        private void SnapshotManager_UrlFetchInitiated(object sender, EventArgs e)
        {

        }

        private void SnapshotManager_UrlFetchCompleted(object sender, int e)
        {
            Program.dataManager.LoadData();
        }

        private void SnapshotManager_UrlFetchError(object sender, string e)
        {

        }

        private void SnapshotManager_DataRefreshInitiated(object sender, string e)
        {
            DisablebtnRefresh();
        }

        private void SnapshotManager_DataRefreshCompleted(object sender, bool e)
        {
            EnablebtnRefresh();
            refresh.Start();
        }

        private void SnapshotManager_DataRefreshError(object sender, SnapshotRefreshErrorArgs e)
        {
            tsbRefresh.Enabled = true;
        }

        private void SnapshotManager_DataRefreshProgress(object sender, int e)
        {

        }

        private void _dataManager_DataLoadStatus(object sender, string e)
        {

        }

        private void _dataManager_DataLoadError(object sender, string e)
        {
            Program.dataManager.LoadData();
        }

        private async void _dataManager_DataLoadCompleted(object sender, EventArgs e)
        {
            await Program.snapshotManager.RefreshData();
        }

        private void DataUpdateManager_MainDataDownloadStarted(object sender, EventArgs e)
        {

        }

        private void DataUpdateManager_FirBoundaryDataDownloadStarted(object sender, EventArgs e)
        {

        }

        #endregion VatSim Event Handlers

        #region VatSim Methods

        private void ProcessVatSimData()
        {
            string tempCallSign = tbCallsign.Text.Trim().ToUpper();

            ClearControls();

            tbCallsign.Text = tempCallSign;

            if (VatsimFlight.Equipment.StartsWith("H/"))
            {
                tbAcType.Text = VatsimFlight.Equipment.Substring(2, VatsimFlight.Equipment.Length - 2).Trim().ToUpper();
            }
            else
            {
                tbAcType.Text = VatsimFlight.Equipment.Trim().ToUpper();
            }

            switch (VatsimFlight.FlightRules)
            {
                case FlightRules.Unknown:
                    cbFlightRules.SelectedItem = string.Empty;
                    break;
                case FlightRules.VFR:
                    cbFlightRules.SelectedItem = "VFR";
                    break;
                case FlightRules.IFR:
                    cbFlightRules.SelectedItem = "IFR";
                    break;
                case FlightRules.SVFR:
                    cbFlightRules.SelectedItem = "SVFR";
                    break;
                case FlightRules.DVFR:
                    cbFlightRules.SelectedItem = "DVFR";
                    break;
                default:
                    cbFlightRules.SelectedItem = string.Empty;
                    break;
            }

            tbDepart.Text = VatsimFlight.PlannedDep.ToUpper().Trim();
            tbArrive.Text = VatsimFlight.PlannedDest.ToUpper().Trim();
            tbAlternate.Text = VatsimFlight.PlannedAlternate.ToUpper().Trim();
            tbCruiseAlt.Text = VatsimFlight.PlannedAlt;

            tbSquawk.Text = VatsimFlight.Squawk;

            tbRoute.Text = GetLettersOnly(VatsimFlight.Route.ToUpper().Trim());
            tbRemarks.Text = VatsimFlight.Remarks.ToUpper().Trim();

            int selectedCruise;

            if (int.TryParse(tbCruiseAlt.Text, out selectedCruise) && flightplan != null)
                flightplan.CruiseAlt = selectedCruise;


            if (tbRoute.Text != "")
            {
                try
                {
                    flightplan = BuildFlightplan();
                }
                catch (Exception ex)
                {
                    Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
                }

                try
                {
                    OutputData();
                }
                catch (Exception ex)
                {
                    Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
                }
            }

            string errormessage;
            if (ValidateFields(out errormessage))
            {

            }


        }

        private async Task UpdateData()
        {
            await UpdateDataFiles();
        }

        private async Task UpdateDataFiles()
        {
            try
            {
                await Program.dataUpdateManager.CheckForNewDataFiles();
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }
        }

        private async Task UpdateUrls()
        {
            await Program.snapshotManager.FetchUrls();
        }

        #endregion VatSim Methods

        #region Clearance Methods

        private void DisplayScript()
        {
            String Clearance = "";

            switch (flightplan.FlightRules)
            {
                case "":
                    //Nothing was selected
                    break;

                case "IFR":
                    //IFR was selected
                    if (cbGetFRC.Checked) Clearance = GetFrcIfrClearance();
                    else Clearance = GetIfrClearance();
                    break;

                case "VFR":
                    //VFR was selected
                    Clearance = GetVfrClearance();
                    break;

                default:
                    break;
            }

            if (Clearance != null)
            {
                MsgBox.Show(Clearance, "CLEARANCE", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private string GetIfrClearance()
        {
            lock (Program.snapshotManager.CurrentSnapshot) ;
            string departure = null;
            try
            {
                departure = VatSim_Helper.GetDepartureFrequency(flightplan.Departure, Program.snapshotManager.CurrentSnapshot, (VatSim.Data.DataManager)Program.dataManager);
            }
            catch (Exception_ATC_Helper ex)
            {
                Program.ErrorHandler(ex.SourceMethod, ex.Exception.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            if (departure == null || departure == String.Empty)
                departure = "122.80";

            StringBuilder ATCScript = new StringBuilder();


            if (tbRoute.Text.ToLower().Contains("pattern") || tbRoute.Text.ToLower().Contains("practice"))
            {
                //Pattern Work
                ATCScript.AppendLine(ShowFullCallsign() + ", Cleared to the " + GetDestinationAirportName() + " airport via radar vectors maintain " +
                    AltString(flightplan.IntAlt) + ", expect " + AltString(flightplan.CruiseAlt) + " 1 0 minutes after departure, Departure Frequency " + (NullIfEmpty(departure) ?? "<get from screen>" + " squawk ") + (NullIfEmpty(flightplan.Squawk) ?? "0000"));
            }
            else if (Enum.IsDefined(typeof(TraconAirport), flightplan.Destination))
            {
                //Destination in TRACON
                ATCScript.AppendLine(ShowFullCallsign() + ", Cleared to the " + GetDestinationAirportName() + " airport via radar vectors direct maintain " +
                    AltString(flightplan.IntAlt) + ", expect " + AltString(flightplan.CruiseAlt) + " 1 0 minutes after departure, Departure Frequency " + (NullIfEmpty(departure) ?? "<get from screen>" + " squawk ") + (NullIfEmpty(flightplan.Squawk) ?? "0000"));
            }
            else
            {
                //Desination outside TRACON
                ATCScript.Append(ShowFullCallsign() + ", Cleared to the " + GetDestinationAirportName() + " airport ");

                if (flightplan.Route.Waypoints[0].Type == WaypointTypes.AirportSid)
                {
                    //Will display detarture information
                    ATCScript.Append(flightplan.SID.SidIdentifier + " departure, ");

                    if (flightplan.IsTransitionCommon)
                    {
                        ATCScript.Append(" then as filed,");
                    }
                    else
                    {
                        ATCScript.Append(GetFullNavAidName(flightplan.Route.Waypoints[1]) + " transition then as filed,");
                    }

                }
                else
                {
                    if (flightplan.Route.Waypoints[0].Name != flightplan.DepartureRecord.AirportICAOIdentifier.Trim())
                    {
                        ATCScript.Append("direct " + GetFullNavAidName(flightplan.Route.Waypoints[0]).Trim());
                        if (flightplan.Route.Waypoints[0].Name.Trim() != flightplan.DesinationCustomRecord.ICAO_ID.Trim())
                        {
                            ATCScript.Append(" then as filed,");
                        }
                        else
                        {
                            ATCScript.Append(",");
                        }
                    }
                    else
                    {
                        if (flightplan.Route.Waypoints[1].Name != flightplan.DepartureRecord.AirportICAOIdentifier.Trim())
                            ATCScript.Append("direct " + GetFullNavAidName(flightplan.Route.Waypoints[1]).Trim() + ",");


                    }
                }

                ATCScript.AppendLine(" maintain " + AltString(flightplan.IntAlt) + ", expect " + AltString(flightplan.CruiseAlt) + " 1 0 minutes after departure, Departure Frequency " + (NullIfEmpty(departure) ?? "<get from screen>") + " squawk " + (NullIfEmpty(flightplan.Squawk) ?? "0000"));

            }

            return ATCScript.ToString();

        }

        private Fields BuildFields()
        {
            chrisgonzalez.Fields result = new Fields();
            result.AcType = tbAcType.Text;
            result.AlternateAirport = tbAlternate.Text;
            result.ArrivalAirport = tbArrive.Text;
            result.CallSign = tbCallsign.Text;
            result.CruiseAltitude = tbCruiseAlt.Text;
            result.DepartureAirport = tbDepart.Text;
            result.FlightRules = cbFlightRules.Text;
            result.Remarks = tbRemarks.Text;
            result.Route = tbRoute.Text;
            result.ScratchPad = tbScratchpad.Text;
            result.Squwak = tbSquawk.Text;

            return result;
        }

        private string GetVfrClearance()
        {
            lock (Program.snapshotManager.CurrentSnapshot) ;
            string departure = null;
            try
            {
                departure = VatSim_Helper.GetDepartureFrequency(flightplan.Departure, Program.snapshotManager.CurrentSnapshot, (VatSim.Data.DataManager)Program.dataManager);
            }
            catch (Exception_ATC_Helper ex)
            {
                Program.ErrorHandler(ex.SourceMethod, ex.Exception.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            if (departure != null || departure == String.Empty)
                departure = "122.80";

            StringBuilder ATCScript = new StringBuilder();

            if (tbRoute.Text.ToLower().Contains("pattern") || tbRoute.Text.ToLower().Contains("practice") || tbArrive.Text.ToUpper() == "KCLT")
            {
                ATCScript.AppendLine(ShowFullCallsign() + ", Cleared into the " + GetDepartureAirportName() + " class bravo airspace squawk " + (NullIfEmpty(flightplan.Squawk) ?? "0000"));
            }
            else
            {
                ATCScript.Append(ShowFullCallsign() + ", Cleared out of the " + GetDepartureAirportName() + " class bravo airspace, Maintain VFR at ");

                if (flightplan.CruiseAlt >= flightplan.IntAlt)
                {
                    ATCScript.Append(flightplan.IntAlt);
                }
                else
                {
                    ATCScript.Append("or below " + flightplan.IntAlt);
                }

                ATCScript.Append(", departure freqency " + (NullIfEmpty(departure) ?? "<get from screen>") + " squawk " + (NullIfEmpty(flightplan.Squawk) ?? "0000"));

            }

            return ATCScript.ToString();
        }

        private string GetFrcIfrClearance()
        {
            lock (Program.snapshotManager.CurrentSnapshot) ;
            string departure = null;
            try
            {
                departure = VatSim_Helper.GetDepartureFrequency(flightplan.Departure, Program.snapshotManager.CurrentSnapshot, (VatSim.Data.DataManager)Program.dataManager);
            }
            catch (Exception_ATC_Helper ex)
            {
                Program.ErrorHandler(ex.SourceMethod, ex.Exception.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            if (departure != null || departure == String.Empty)
                departure = "122.80";

            StringBuilder ATCScript = new StringBuilder();

            if (tbRoute.Text.Contains("Pattern") || tbRoute.Text.Contains("Practice"))
            {
                //Pattern Work
                ATCScript.AppendLine(ShowFullCallsign() + ", Cleared to the " + GetDestinationAirportName() + " airport via radar vectors maintain " +
                    AltString(flightplan.IntAlt) + ", expect " + AltString(flightplan.CruiseAlt) + " 1 0 minutes after departure, Departure Frequency " + (NullIfEmpty(departure) ?? "<get from screen>") + " squawk " +
                    (NullIfEmpty(flightplan.Squawk) ?? "0000"));
            }
            else if (Enum.IsDefined(typeof(TraconAirport), flightplan.Destination))
            {
                //Destination in TRACON
                ATCScript.AppendLine(ShowFullCallsign() + ", Cleared to the " + GetDestinationAirportName() + " airport via radar vectors direct maintain " +
                    AltString(flightplan.IntAlt) + ", expect " + AltString(flightplan.CruiseAlt) + " 1 0 minutes after departure, Departure Frequency " + (NullIfEmpty(departure) ?? "<get from screen>") + " squawk " +
                    (NullIfEmpty(flightplan.Squawk) ?? "0000"));
            }
            else
            {
                //Desination outside TRACON

                ATCScript.Append(ShowFullCallsign() + ", Cleared to the " + GetDestinationAirportName() + " airport " + flightplan.SID.SidIdentifier + " departure, ");

                if (flightplan.IsTransitionCommon)
                {
                    ATCScript.Append(flightplan.Transition);
                }
                else
                {
                    ATCScript.AppendLine(GetFullNavAidName(flightplan.Route.Waypoints[1]) + " transition");
                }

                bool IsLastNotDirect = true;
                List<Waypoint> wps = flightplan.Route.Waypoints;

                for (int i = 2; i <= wps.Count - 1; i++)
                {
                    bool IsThisNotDirect = false;

                    switch (wps[i].TransitionType)
                    {
                        case WaypointTypes.Airport:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.AirportApproach:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.AirportRunway:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.AirportSid:
                            IsThisNotDirect = true;
                            break;
                        case WaypointTypes.AirportStar:
                            IsThisNotDirect = true;
                            break;
                        case WaypointTypes.EnrouteAirway:
                            IsThisNotDirect = true;
                            break;
                        case WaypointTypes.NDBNavAidEnroute:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.NDBNavAidTerminal:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.NDBNavAid:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.VhfNavAid:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.Waypoint:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.WaypointEnroute:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.WaypointHeliportTerminal:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.WaypointTerminal:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.HeliportApproach:
                            IsThisNotDirect = true;
                            break;
                        case WaypointTypes.HeliportMSA:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.HeliportSid:
                            IsThisNotDirect = true;
                            break;
                        case WaypointTypes.HeliportStar:
                            IsThisNotDirect = true;
                            break;
                        case WaypointTypes.Heliport:
                            IsThisNotDirect = false;
                            break;
                        case WaypointTypes.Transition:
                            IsThisNotDirect = true;
                            break;
                        default:
                            break;
                    }

                    if (IsThisNotDirect || IsLastNotDirect)
                    {
                        ATCScript.Append(", " + GetFullNavAidName(wps[i]).Trim() + " (" + wps[i].Name + ")");
                    }
                    else
                    {
                        ATCScript.Append(", DIRECT, " + GetFullNavAidName(wps[i]).Trim() + " (" + wps[i].Name + ")");
                    }

                    if (wps[i].Type == WaypointTypes.AirportStar) ATCScript.Append(" Arrival ");
                    if (wps[i].Type == WaypointTypes.NDBNavAid) ATCScript.Append(" NDB ");
                    if (wps[i].Type == WaypointTypes.NDBNavAidEnroute) ATCScript.Append(" NDB ");
                    if (wps[i].Type == WaypointTypes.NDBNavAidTerminal) ATCScript.Append(" NDB ");
                    if (wps[i].Type == WaypointTypes.VhfNavAid) ATCScript.Append(" VOR ");
                    ATCScript.AppendLine();

                    IsLastNotDirect = IsThisNotDirect;
                }



                ATCScript.Append(", maintain " + AltString(flightplan.IntAlt) + ", expect " + AltString(flightplan.CruiseAlt) + " 1 0 minutes after departure, Departure Frequency " + (NullIfEmpty(departure) ?? "<get from screen>") + " squawk " +
                (NullIfEmpty(flightplan.Squawk) ?? "0000"));

            }

            return ATCScript.ToString();

        }

        #endregion Clearance Methods

        #region Helper Methods

        private string NullIfEmpty(string s)
        {
            return String.IsNullOrWhiteSpace(s) ? null : s;

        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            refresh.Stop();
            _dataManager_DataLoadCompleted(sender, e);

        }

        private void ClearControls()
        {
            tbArrive.Text = "";
            tbAcType.Text = "";
            tbAlternate.Text = "";

            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();

            if (methodBase.Name != "ProcessVatSimData")
                tbCallsign.Text = "";

            tbCruiseAlt.Text = "";
            tbDepart.Text = "";
            tbScratchpad.Text = "";
            tbSquawk.Text = "";
            tbRoute.Text = "";
            cbDirectionOfFlight.SelectedIndex = 0;
            cbFlightRules.SelectedIndex = 0;
            dgvAirports.DataSource = null;
            dgvRouteInformation.DataSource = null;
            tbCS.Text = "";
            tbAcInfo.Text = "";
            tbPropType.Text = "";
            tbDOF.Text = "";
            tbAltEvenOdd.Text = "";
            cbIsHeavy.Checked = false;
            cbDirectionOfFlight.SelectedIndex = 0;
            tbRemarks.Text = "";
        }

        private string GetLettersOnly(string _String)
        {
            string result = "";
            bool FoundFirstLetter = false;

            foreach (Char item in _String)
            {
                if (FoundFirstLetter || Char.IsLetter(item))
                {
                    FoundFirstLetter = true;
                    result += item;
                }
            }

            return result;
        }

        private void OutputData()
        {
            try
            {
                ShowPreferedRunway(flightplan);
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            try
            {
                GetAirportInfo(flightplan);
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            try
            {
                ShowRouteInformation(flightplan);
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            try
            {
                ShowFullCallsign();
            }
            catch (Exception ex)
            {

                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            try
            {
                ShowDirectionOfFlight();
            }
            catch (Exception ex)
            {

                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            try
            {
                ShowAircraftType();
            }
            catch (Exception ex)
            {

                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }

            try
            {
                ShowPDC(flightplan);
            }
            catch (Exception ex)
            {

                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), BuildFields());
            }


        }

        private bool ValidateFields(out String ErrorMessage)
        {
            tbAcType.BackColor = SystemColors.Window;
            tbArrive.BackColor = SystemColors.Window;
            tbCallsign.BackColor = SystemColors.Window;
            tbCruiseAlt.BackColor = SystemColors.Window;
            tbDepart.BackColor = SystemColors.Window;
            tbRoute.BackColor = SystemColors.Window;
            tbSquawk.BackColor = SystemColors.Window;
            cbFlightRules.BackColor = SystemColors.Window;
            //cbDirectionOfFlight.BackColor = SystemColors.Window;

            ErrorMessage = "";
            Boolean Error = false;

            if (tbAcType.Text == string.Empty)
            {
                tbAcType.BackColor = Color.MediumVioletRed;
                tbAcType.Focus();
                ErrorMessage += "Please enter the Aircraft Type";
                ErrorMessage += "\n\r";
                Error = true;
            }

            if (tbCallsign.Text == string.Empty)
            {
                tbCallsign.BackColor = Color.MediumVioletRed;
                tbCallsign.Focus();
                ErrorMessage += "Please enter the Callsign";
                ErrorMessage += "\n\r";
                Error = true;
            }

            if (tbDepart.Text == string.Empty)
            {
                tbDepart.BackColor = Color.MediumVioletRed;
                tbDepart.Focus();
                ErrorMessage += "Please enter the departure airport";
                ErrorMessage += "\n\r";
                Error = true;
            }

            if (cbFlightRules.SelectedIndex <= 0)
            {
                cbFlightRules.BackColor = Color.MediumVioletRed;
                cbFlightRules.Focus();
                ErrorMessage += "Please select the flight rules";
                ErrorMessage += "\n\r";
                Error = true;
            }

            //if (cbDirectionOfFlight.SelectedIndex <= 0)
            //{
            //    cbDirectionOfFlight.BackColor = Color.MediumVioletRed;
            //    cbDirectionOfFlight.Focus();
            //    ErrorMessage += "Please select the direction of flight";
            //    ErrorMessage += "\n\r";
            //    Error = true;
            //}

            if (tbRoute.Text == string.Empty)
            {
                tbRoute.BackColor = Color.MediumVioletRed;
                tbRoute.Focus();
                ErrorMessage += "Please enter the route";
                ErrorMessage += "\n\r";
                Error = true;
            }

            if (tbCruiseAlt.Text == string.Empty)
            {
                tbCruiseAlt.BackColor = Color.MediumVioletRed;
                tbCruiseAlt.Focus();
                ErrorMessage += "Please enter the cruise altitude";
                ErrorMessage += "\n\r";
                Error = true;
            }

            if (!ValidateAirport(tbDepart.Text))
            {
                tbDepart.BackColor = Color.MediumVioletRed;
                tbDepart.Focus();
                ErrorMessage += "Departure airport is not valid";
                ErrorMessage += "\n\r";
                Error = true;
            }

            if (!ValidateAirport(tbArrive.Text))
            {
                tbArrive.BackColor = Color.MediumVioletRed;
                tbArrive.Focus();
                ErrorMessage += "Arrival airport is not valid";
                ErrorMessage += "\n\r";
                Error = true;
            }


            return !Error;

        }

        #endregion Helper Methods

        #region EDM Properties

        //private static VatSimEntities _VatSimEntities;
        ///// <summary>
        ///// Entry Point to an ADO.NET Entity Data Model for EnterpriseObjects Database   
        ///// </summary>
        //public static VatSimEntities VatSimEntities
        //{
        //    get
        //    {
        //        if (_VatSimEntities == null)
        //        {
        //            _VatSimEntities = new VatSimEntities();
        //        }
        //        return _VatSimEntities;
        //    }
        //    private set { _VatSimEntities = value; }
        //}

        #endregion EDM Properties

        //#region Vatsim Network Data

        //private static Classes.VATSIM.Data _VatsimData;
        //public static Classes.VATSIM.Data VatsimData
        //{
        //    get 
        //    { 
        //        if (_VatsimData == null)
        //        {
        //            _VatsimData = new Classes.VATSIM.Data();
        //        }

        //        return _VatsimData; 

        //    }
        //    set { _VatsimData = value; }
        //}
        //ATC_Helper.Classes.VATSIM.Data vatsimData = new ATC_Helper.Classes.VATSIM.Data();



        //#endregion Vatsim Network Data

        #region Menu Methods

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSettings = new Forms.frmSettings();
            formSettings.Show();
        }

        private void callSignLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CallsignFormLoaded == true)
                CallsignForm.Focus();
            else
            {
                CallsignForm = new frmCallSign();
                CallsignForm.Show();
                CallsignFormLoaded = true;
                CallsignForm.CallSignClosing += CallsignForm_CallSignClosing;
            }
        }

        private void aircraftLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AircraftFormLoaded == true)
                AircraftForm.Focus();
            else
            {
                AircraftForm = new frmAircraft();
                AircraftForm.Show();
                AircraftFormLoaded = true;
                AircraftForm.AircraftClosing += AircraftForm_CallSignClosing;
            }
        }

        private void airportLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AirportFormLoaded == true)
                AirportForm.Focus();
            else
            {
                AirportForm = new frmAirport();
                AirportForm.Show();
                AirportFormLoaded = true;
                AirportForm.AirportClosing += AirportForm_CallSignClosing;
            }
        }



        #endregion Menu Methods

        #region External Form Event Handlers

        private void AirportForm_CallSignClosing(object sender, EventArgs e)
        {
            AirportFormLoaded = false;
        }

        private void AircraftForm_CallSignClosing(object sender, EventArgs e)
        {
            AircraftFormLoaded = false;
        }

        private void CallsignForm_CallSignClosing(object sender, EventArgs e)
        {
            CallsignFormLoaded = false;
        }

        #endregion

        #region Toolbar Events

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            tsbRefresh.Enabled = false;
            Program.snapshotManager.RefreshData();
        }

        private void tsbCallsign_Click(object sender, EventArgs e)
        {
            if (CallsignFormLoaded == true)
                CallsignForm.Focus();
            else
            {
                CallsignForm = new frmCallSign();
                CallsignForm.Show();
                CallsignFormLoaded = true;
                CallsignForm.CallSignClosing += CallsignForm_CallSignClosing;
            }
        }

        private void tsbAircraft_Click(object sender, EventArgs e)
        {
            if (AircraftFormLoaded == true)
                AircraftForm.Focus();
            else
            {
                AircraftForm = new frmAircraft();
                AircraftForm.Show();
                AircraftFormLoaded = true;
                AircraftForm.AircraftClosing += AircraftForm_CallSignClosing;
            }
        }

        private void tsbAirport_Click(object sender, EventArgs e)
        {
            if (AirportFormLoaded == true)
                AirportForm.Focus();
            else
            {
                AirportForm = new frmAirport();
                AirportForm.Show();
                AirportFormLoaded = true;
                AirportForm.AirportClosing += AirportForm_CallSignClosing;
            }
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            var formSettings = new Forms.frmSettings();
            formSettings.Show();
        }



        #endregion Toolbar Events


    }
}
