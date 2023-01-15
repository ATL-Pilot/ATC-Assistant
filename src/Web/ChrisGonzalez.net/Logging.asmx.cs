using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Services;
using ATCHelper_CommonClasses;
using WebDB_EDM;

namespace ChrisGonzalez.net
{
    /// <summary>
    /// Summary description for Logging
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Logging : System.Web.Services.WebService
    {

        [WebMethod]
        public bool LogError(string method, string application, string exception, string stackTrace, Fields fields)
        {
            bool result = true;
            Field newField = new Field();
            LogEntry logentry = new LogEntry();

            if (exception == null)
            {
                return false;
            }
            else
            {
            }

            if (fields == null)
            {
                newField.ACType = "";
                newField.Alternate = "";
                newField.Arrive = "";
                newField.CallSign = "";
                newField.CruiseAtl = "";
                newField.Depart = "";
                newField.FlightRule = "";
                newField.Remarks = "";
                newField.Route = "";
                newField.Scratch = "";
                newField.Squawk = "";
            }
            else
            {
                //Add the Field Table Entry
                newField.ACType = fields.AcType;
                newField.Alternate = fields.AlternateAirport;
                newField.Arrive = fields.ArrivalAirport;
                newField.CallSign = fields.CallSign;
                newField.CruiseAtl = fields.CruiseAltitude;
                newField.Depart = fields.DepartureAirport;
                newField.FlightRule = fields.FlightRules;
                newField.Remarks = fields.Remarks;
                newField.Route = fields.Route;
                newField.Scratch = fields.ScratchPad;
                newField.Squawk = fields.Squwak;

            }

            try
            {

                //Post the fields record
                ErrorLogEntities.Fields.Add(newField);
                ErrorLogEntities.SaveChanges();

                //Get the applicationID
                int appID = (from ai in ErrorLogEntities.Applications where ai.ApplicationName == application select ai.ApplicationID).FirstOrDefault();

                logentry.ApplicationID = appID;
                logentry.Exception = exception;
                logentry.StackTrace = stackTrace;
                logentry.Action = method;
                logentry.ApplicationID = appID;
                logentry.FieldId = newField.FieldID;

                ErrorLogEntities.LogEntries.Add(logentry);
                ErrorLogEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
                LogError(ex);
            }


            return result;
        }

        private void LogError(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = "D:\\WebSite\\inetpub\\logs\\ApplicationLogs\\ErrorLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        private void LogMessage(string Message)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", Message);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = "D:\\WebSite\\inetpub\\logs\\ApplicationLogs\\ErrorLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        #region EDM Properties

        private static ErrorLoggingEntities _ErrorLogEntities;
        /// <summary>
        /// Entry Point to an ADO.NET Entity Data Model for EnterpriseObjects Database   
        /// </summary>
        public static ErrorLoggingEntities ErrorLogEntities
        {
            get
            {
                if (_ErrorLogEntities == null)
                {
                    _ErrorLogEntities = new ErrorLoggingEntities();
                }
                return _ErrorLogEntities;
            }
            private set { _ErrorLogEntities = value; }
        }

        #endregion EDM Properties
    }
}
