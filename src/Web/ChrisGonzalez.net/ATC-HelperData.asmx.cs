using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using WebDB_EDM;
using ATC_Helper_EDM;


namespace ChrisGonzalez.net
{
    /// <summary>
    /// Summary description for ATC_HelperData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ATC_HelperData : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Airport> GetAirportData()
        {
            var airports = from ap in AtcHelperEntities.Airports select ap;
            return airports.ToList();
        }

        [WebMethod]
        public List<Aircraft> GetAircraftData()
        {
            var aircraft = from ap in AtcHelperEntities.Aircraft select ap;
            return aircraft.ToList();
        }

        [WebMethod]
        public List<AirportSid_Restrictions> GetSidRestrictionData()
        {
            var sidRestrictions = from ap in AtcHelperEntities.AirportSid_Restrictions select ap;
            return sidRestrictions.ToList();
        }

        [WebMethod]
        public List<DeparturePlan> GetDeparturePlanData()
        {
            var departurePlans = from ap in AtcHelperEntities.DeparturePlans select ap;
            return departurePlans.ToList();
        }

        [WebMethod]
        public List<CallSign> GetCallSigns()
        {
            var Callsigns = from ap in AtcHelperEntities.CallSigns select ap;
            return Callsigns.ToList();
        }


        #region EDM Properties

        private static AtcHelperEntities _ATCHelperEntities;
        /// <summary>
        /// Entry Point to an ADO.NET Entity Data Model for Database   
        /// </summary>
        public static AtcHelperEntities AtcHelperEntities
        {
            get
            {
                if (_ATCHelperEntities == null)
                {
                    _ATCHelperEntities = new AtcHelperEntities();
                }
                return _ATCHelperEntities;
            }
            private set { _ATCHelperEntities = value; }
        }

        #endregion EDM Properties
    }
}
