//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VatSim_EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeparturePlan
    {
        public int ID { get; set; }
        public string ICAO_ID { get; set; }
        public string FlightRules { get; set; }
        public string SID_ID { get; set; }
        public string Transition_ID { get; set; }
        public string DirectionOfFlight { get; set; }
        public string Runway { get; set; }
    }
}
