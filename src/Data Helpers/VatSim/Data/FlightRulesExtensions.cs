namespace VatSim.Data
{
    public static class FlightRulesExtensions
    {
        public static FlightRules ToFlightRules(this string s)
        {
            string upper = s.ToUpper();
            if (upper == "V")
                return FlightRules.VFR;
            if (upper == "I")
                return FlightRules.IFR;
            if (upper == "D")
                return FlightRules.DVFR;
            return upper == "S" ? FlightRules.SVFR : FlightRules.Unknown;
        }
    }
}
