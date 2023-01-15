using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ATC_Helper.chrisgonzalez;
using VatSim.Data;
using VatSim.Snapshots;


namespace ATC_Helper
{
    internal static class Program
    {
        /// <summary>
        /// Global Variables
        /// </summary>
        public static ArincReader.Arinc424.Arinc424Io NavData = new ArincReader.Arinc424.Arinc424Io();
        public static List<WebService.Aircraft> AtcHelper_AircraftTypes = new List<WebService.Aircraft>();
        public static List<WebService.CallSign> AtcHelper_CallSigns = new List<WebService.CallSign>();
        public static List<WebService.Airport> AtcHelper_AirportDetails = new List<WebService.Airport>();
        public static List<WebService.AirportSid_Restrictions> AtcHelper_SidRestrictions = new List<WebService.AirportSid_Restrictions>();
        public static List<WebService.DeparturePlan> AtcHelper_DeparturePlan = new List<WebService.DeparturePlan>();

        public static IDataManager dataManager;
        public static ISnapshotManager snapshotManager;
        public static IDataUpdateManager dataUpdateManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            try
            {
                Application.Run(new Forms.frmMain());
            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), null);
            }
        }

        public static void ErrorHandler(string method, string exception, string stackTrace, chrisgonzalez.Fields fields)
        {

            //MessageBox.Show(errorText.ToString(), "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (fields == null)
            {
                fields = new Fields();
                fields.AcType = "";
                fields.AlternateAirport = "";
                fields.ArrivalAirport = "";
                fields.CallSign = "";
                fields.CruiseAltitude = "";
                fields.DepartureAirport = "";
                fields.FlightRules = "";
                fields.Remarks = "";
                fields.Route = "";
                fields.ScratchPad = "";
                fields.Squwak = "";
            }

            chrisgonzalez.Logging logws = new chrisgonzalez.Logging();

            try
            {
                
                bool success = logws.LogError(method, "ATC-Helper", exception, stackTrace, fields);
            }
            catch (Exception e)
            {
               //TODO: Need to log this somewhere.....
            }
            
        }

        public static void GenerateException()
        {
            chrisgonzalez.Fields newFields = new Fields();
            newFields.AcType = "AC Type";
            newFields.AlternateAirport = "ATL";
            newFields.ArrivalAirport = "CLT";
            newFields.CallSign = "DAL7";
            newFields.CruiseAltitude = "27000";
            newFields.DepartureAirport = "TPA";
            newFields.FlightRules = "IFR";
            newFields.Remarks = "Remarks";
            newFields.Route = "KTPA KATL";
            newFields.ScratchPad = "ScratchPad";
            newFields.Squwak = "6301";

            ErrorHandler("GenerateException", "Test Exception", "Stack Trace", newFields);


        }

    }
}
