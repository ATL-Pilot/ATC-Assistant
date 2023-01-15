using System;

namespace VatSim.Data
{
    public static class FacilityExtensions
    {
        public static string GetName(this Facility facility)
        {
            switch (facility)
            {
                case Facility.OBS:
                    return "Observer";
                case Facility.ATIS:
                    return "ATIS";
                case Facility.DEL:
                    return "Clearance Delivery";
                case Facility.GND:
                    return "Ground";
                case Facility.TWR:
                    return "Tower";
                case Facility.APP:
                    return "Approach";
                case Facility.DEP:
                    return "Departure";
                case Facility.CTR:
                    return "Center";
                case Facility.FSS:
                    return "Flight Service Station";
                default:
                    throw new ArgumentException(string.Format("Unknown facility type: {0}", (object)facility));
            }
        }

        public static Facility ToFacility(this string s)
        {
            switch (s)
            {
                case "APP":
                    return Facility.APP;
                case "ATIS":
                    return Facility.ATIS;
                case "CTR":
                    return Facility.CTR;
                case "DEL":
                    return Facility.DEL;
                case "DEP":
                    return Facility.DEP;
                case "FSS":
                    return Facility.FSS;
                case "GND":
                    return Facility.GND;
                case "TWR":
                    return Facility.TWR;
                default:
                    return Facility.OBS;
            }
        }
    }
}
