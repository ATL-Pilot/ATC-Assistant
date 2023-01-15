using System;
using System.Collections.Generic;
using VatSim.Data;

namespace ATC_Helper.Classes
{
    internal class VatSim_Helper
    {
        public VatSim_Helper()
        {

        }

        public static Flight GetFlightplan(string callSign, VatSim.Snapshots.Snapshot currentSnapshot)
        {
            Flight result = null;

            result = PilotFlightplanLookup(callSign, currentSnapshot);

            if (result != null)
            {
                return result;
            }

            //We tried return null result
            return result;
        }

        public static string GetDepartureFrequency(string Departure, VatSim.Snapshots.Snapshot currentSnapshot, VatSim.Data.DataManager dataManager)
        {

            List<Atc> t = null;

            try
            {
                t = currentSnapshot.AirportPositionInfos[Departure].Members;
            }
            catch (Exception ex)
            {
                throw new Exception_ATC_Helper("VatSim_Helper.GetDepartureFrequency", ex);
            }

            string DEP_Freq = null;
            string APP_Freq = null;
            string TWR_Freq = null;
            string GND_Freq = null;
            string DEL_Freq = null;
            string CTR_Freq = null;

            if (t != null)
            {
                foreach (var item in t)
                {
                    switch (item.Facility)
                    {
                        case Facility.OBS:
                            break;
                        case Facility.ATIS:
                            break;
                        case Facility.DEL:
                            DEL_Freq = item.Frequency;
                            break;
                        case Facility.GND:
                            GND_Freq = item.Frequency;
                            break;
                        case Facility.TWR:
                            TWR_Freq = item.Frequency;
                            break;
                        case Facility.APP:
                            APP_Freq = item.Frequency;
                            break;
                        case Facility.DEP:
                            DEP_Freq = item.Frequency;
                            break;
                        case Facility.CTR:
                            CTR_Freq = item.Frequency;
                            break;
                        case Facility.FSS:
                            break;
                        default:
                            break;
                    }
                }
            }

            //Get FIR Positions
            FirPositionInfo f = null;
            try
            {
                string airportFir = dataManager.GetAirport(Departure).FirIcao.ToUpper();
                f = currentSnapshot.FirPositionInfos[airportFir];
            }
            catch (Exception ex)
            {
                //This is expected behavior if no one is on a departure Frequency
            }

            if (f != null)
            {
                foreach (var item in f.Members)
                {
                    if (item.Facility == Facility.CTR)
                        CTR_Freq = item.Frequency;
                }
            }


            if (DEP_Freq != null)
                return DEP_Freq;
            else if (APP_Freq != null)
                return APP_Freq;
            else if (CTR_Freq != null)
                return CTR_Freq;
            else
                return "122.80";
        }



        private static Flight PilotFlightplanLookup(string callSign, VatSim.Snapshots.Snapshot currentSnapshot)
        {
            Flight result = null;

            try
            {
                Flight fl = currentSnapshot.Flights[callSign];

                //Pilot pilot = data.pilots.Find(p => p.callsign == callSign);

                //if (pilot != null)
                //{
                //    result = pilot.flight_plan;
                //}

                if (fl != null) result = fl;
            }
            catch (Exception ex)
            {
                //this would be expected behavior if the lookup failed for the callsign
            }

            return result;
        }
    }
}
