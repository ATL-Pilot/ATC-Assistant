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
    
    public partial class Aircraft
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string TypeDesignator { get; set; }
        public string Description { get; set; }
        public string EngineType { get; set; }
        public string SimplifiedEngineType { get; set; }
        public Nullable<int> EngineCount { get; set; }
        public string WTC { get; set; }
    }
}
