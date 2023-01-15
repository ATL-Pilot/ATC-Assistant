using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace VatSim.Data
{
    public class DataManager : IDataManager
    {
        private readonly Dictionary<string, string> mCountryCodeMap = new Dictionary<string, string>();

        public event EventHandler<string> DataLoadStatus;

        public event EventHandler DataLoadCompleted;

        public event EventHandler<string> DataLoadError;

        public Dictionary<string, FirBoundary> FirBoundaries { get; } = new Dictionary<string, FirBoundary>();

        public Dictionary<string, FirBoundary> FirBoundaryExtensions { get; } = new Dictionary<string, FirBoundary>();

        public Dictionary<string, FirBoundary> OceanicBoundaries { get; } = new Dictionary<string, FirBoundary>();

        public Dictionary<string, FirBoundary> OceanicBoundaryExtensions { get; } = new Dictionary<string, FirBoundary>();

        public Dictionary<string, Country> Countries { get; } = new Dictionary<string, Country>();

        public Dictionary<string, Airport> Airports { get; } = new Dictionary<string, Airport>();

        public Dictionary<string, Fir> Firs { get; } = new Dictionary<string, Fir>();

        public Dictionary<string, Uir> Uirs { get; } = new Dictionary<string, Uir>();

        public List<WorldPoint> Idl { get; } = new List<WorldPoint>();

        private void RaiseDataLoadStatus(string dataType)
        {
            EventHandler<string> dataLoadStatus = this.DataLoadStatus;
            if (dataLoadStatus == null)
                return;
            dataLoadStatus((object)this, dataType);
        }

        private void RaiseDataLoadError(string error)
        {
            EventHandler<string> dataLoadError = this.DataLoadError;
            if (dataLoadError == null)
                return;
            dataLoadError((object)this, error);
        }

        public void LoadData() => new Thread(new ThreadStart(this.DoLoadData)).Start();

        private void DoLoadData()
        {
            Application.CurrentCulture = new CultureInfo("en-US");
            this.RaiseDataLoadStatus("FIR/ARTCC Boundaries");
            string str1 = ".\\VatSim_Data\\FIRBoundaries.dat";
            if (!new FileInfo(str1).Exists)
            {
                this.RaiseDataLoadError("FIR/ARTCC boundary data file not found! Please reinstall " + Application.ProductName + ".");
            }
            else
            {
                StreamReader streamReader1 = new StreamReader(str1);
                try
                {
                    int num1 = 0;
                    string str2;
                    while ((str2 = streamReader1.ReadLine()) != null)
                    {
                        ++num1;
                        string[] strArray1 = str2.Trim().Split('|');
                        if (strArray1.Length != 10)
                        {
                            this.RaiseDataLoadError(string.Format("Invalid formatting in FIR/ARTCC boundary file on line {0}.", (object)num1));
                            return;
                        }
                        string str3 = strArray1[0].Trim();
                        bool flag1 = strArray1[1].Trim() == "1";
                        bool flag2 = strArray1[2].Trim() == "1";
                        int num2 = int.Parse(strArray1[3].Trim(), (IFormatProvider)CultureInfo.InvariantCulture);
                        double minLat = double.Parse(strArray1[4].Trim(), (IFormatProvider)CultureInfo.InvariantCulture);
                        double minLon = double.Parse(strArray1[5].Trim(), (IFormatProvider)CultureInfo.InvariantCulture);
                        double maxLat = double.Parse(strArray1[6].Trim(), (IFormatProvider)CultureInfo.InvariantCulture);
                        double maxLon = double.Parse(strArray1[7].Trim(), (IFormatProvider)CultureInfo.InvariantCulture);
                        double lat = double.Parse(strArray1[8].Trim(), (IFormatProvider)CultureInfo.InvariantCulture);
                        double lon = double.Parse(strArray1[9].Trim(), (IFormatProvider)CultureInfo.InvariantCulture);
                        FirBoundary firBoundary = new FirBoundary()
                        {
                            Icao = str3,
                            Bounds = new WorldRect(minLon, maxLon, minLat, maxLat),
                            Center = new WorldPoint(lon, lat),
                            Points = new List<WorldPoint>()
                        };
                        for (int index = 1; index <= num2; ++index)
                        {
                            ++num1;
                            string str4 = streamReader1.ReadLine().Trim();
                            if (str4 == null)
                            {
                                this.RaiseDataLoadError("Short read while loading FIR/ARTCC boundary file. Bad record ICAO is " + firBoundary.Icao + ".");
                                return;
                            }
                            string[] strArray2 = str4.Split(new char[1]
                            {
                '|'
                            }, StringSplitOptions.None);
                            if (strArray2.Length != 2)
                            {
                                this.RaiseDataLoadError(string.Format("Invalid point formatting in FIR/ARTCC boundary file on line {0}.", (object)num1));
                                return;
                            }
                            firBoundary.Points.Add(new WorldPoint(double.Parse(strArray2[1].Trim(), (IFormatProvider)CultureInfo.InvariantCulture), double.Parse(strArray2[0].Trim(), (IFormatProvider)CultureInfo.InvariantCulture)));
                        }
                        if (flag2)
                        {
                            if (flag1)
                                this.OceanicBoundaryExtensions.Add(firBoundary.Icao, firBoundary);
                            else
                                this.FirBoundaryExtensions.Add(firBoundary.Icao, firBoundary);
                        }
                        else if (flag1)
                            this.OceanicBoundaries.Add(firBoundary.Icao, firBoundary);
                        else
                            this.FirBoundaries.Add(firBoundary.Icao, firBoundary);
                    }
                }
                catch (Exception ex)
                {
                    this.RaiseDataLoadError(ex.Message);
                    return;
                }
                finally
                {
                    streamReader1.Close();
                }
                string str5 = ".\\VatSim_Data\\VATSpy.dat";
                if (!new FileInfo(str5).Exists)
                {
                    this.RaiseDataLoadError("Main data file not found! Please reinstall " + Application.ProductName + ".");
                }
                else
                {
                    StreamReader streamReader2 = new StreamReader(str5);
                    try
                    {
                        int lineNum = 0;
                        DataManager.DataFileSection dataFileSection = DataManager.DataFileSection.Unknown;
                        string str6;
                        while ((str6 = streamReader2.ReadLine()) != null)
                        {
                            ++lineNum;
                            string line = str6.Trim();
                            if (line.Length != 0 && !(line.Substring(0, 1) == ";"))
                            {
                                if (line.Substring(0, 1) == "[" && line.Substring(line.Length - 1, 1) == "]")
                                {
                                    string str7 = line.Substring(line.IndexOf('[') + 1, line.LastIndexOf(']') - 1);
                                    if (!(str7 == "Countries"))
                                    {
                                        if (!(str7 == "Airports"))
                                        {
                                            if (!(str7 == "FIRs"))
                                            {
                                                if (!(str7 == "UIRs"))
                                                {
                                                    if (str7 == "IDL")
                                                    {
                                                        dataFileSection = DataManager.DataFileSection.Idl;
                                                        this.RaiseDataLoadStatus("IDL");
                                                    }
                                                    else
                                                    {
                                                        this.RaiseDataLoadError(string.Format("Unknown section header found in main data file: {0}", (object)str7));
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    dataFileSection = DataManager.DataFileSection.Uirs;
                                                    this.RaiseDataLoadStatus("UIRs");
                                                }
                                            }
                                            else
                                            {
                                                dataFileSection = DataManager.DataFileSection.Firs;
                                                this.RaiseDataLoadStatus("FIRs/ARTCCs");
                                            }
                                        }
                                        else
                                        {
                                            dataFileSection = DataManager.DataFileSection.Airports;
                                            this.RaiseDataLoadStatus("Airports");
                                        }
                                    }
                                    else
                                    {
                                        dataFileSection = DataManager.DataFileSection.Countries;
                                        this.RaiseDataLoadStatus("Countries");
                                    }
                                }
                                else
                                {
                                    switch (dataFileSection)
                                    {
                                        case DataManager.DataFileSection.Countries:
                                            if (!this.ProcessSectionDataCountries(ref line, lineNum))
                                                return;
                                            continue;
                                        case DataManager.DataFileSection.Airports:
                                            if (!this.ProcessSectionDataAirports(ref line, lineNum))
                                                return;
                                            continue;
                                        case DataManager.DataFileSection.Firs:
                                            if (!this.ProcessSectionDataFIRs(ref line, lineNum))
                                                return;
                                            continue;
                                        case DataManager.DataFileSection.Uirs:
                                            if (!this.ProcessSectionDataUIRs(ref line, lineNum))
                                                return;
                                            continue;
                                        case DataManager.DataFileSection.Idl:
                                            if (!this.ProcessSectionDataIDL(ref line, lineNum))
                                                return;
                                            continue;
                                        default:
                                            continue;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        this.RaiseDataLoadError(ex.Message);
                        return;
                    }
                    finally
                    {
                        streamReader2.Close();
                    }
                    EventHandler dataLoadCompleted = this.DataLoadCompleted;
                    if (dataLoadCompleted == null)
                        return;
                    dataLoadCompleted((object)this, EventArgs.Empty);
                }
            }
        }

        private bool ProcessSectionDataCountries(ref string line, int lineNum)
        {
            string[] strArray = line.Split(new char[1] { '|' }, StringSplitOptions.None);
            if (strArray.Length != 3)
            {
                this.RaiseDataLoadError(string.Format("Invalid field count in Countries section on line {0}", (object)lineNum));
                return false;
            }
            string str1 = strArray[0].Trim();
            string key = strArray[1].Trim();
            string str2 = strArray[2].Trim();
            if (this.Countries.ContainsKey(str1))
            {
                if (key != "" && !this.Countries[str1].AirportPrefixes.Contains(key))
                    this.Countries[str1].AirportPrefixes.Add(key);
                if (str2 != "")
                    this.Countries[str1].CenterName = str2;
            }
            else
            {
                this.Countries.Add(str1, new Country(str1, str2 != "" ? str2 : "Center"));
                if (key != "")
                    this.Countries[str1].AirportPrefixes.Add(key);
            }
            if (!this.mCountryCodeMap.ContainsKey(key))
                this.mCountryCodeMap.Add(key, str1);
            return true;
        }

        private bool ProcessSectionDataAirports(ref string line, int lineNum)
        {
            string[] strArray = line.Split(new char[1] { '|' }, StringSplitOptions.None);
            if (strArray.Length != 7)
            {
                this.RaiseDataLoadError(string.Format("Invalid field count in Airports section on line {0}", (object)lineNum));
                return false;
            }
            string str1 = strArray[0].Trim();
            string name = strArray[1].Trim();
            string s1 = strArray[2].Trim();
            string s2 = strArray[3].Trim();
            string str2 = strArray[4].Trim();
            string firIcao = strArray[5].Trim();
            string str3 = strArray[6].Trim();
            WorldPoint loc;
            try
            {
                loc = new WorldPoint(double.Parse(s2, (IFormatProvider)CultureInfo.InvariantCulture), double.Parse(s1, (IFormatProvider)CultureInfo.InvariantCulture));
            }
            catch
            {
                this.RaiseDataLoadError(string.Format("Error parsing airport coordinates on line {0}", (object)lineNum));
                return false;
            }
            if (!this.Airports.ContainsKey(str1))
                this.Airports.Add(str1, new Airport(str1, str1, name, loc, firIcao, str3 == "1"));
            if (str2 != "" && !this.Airports.ContainsKey(str2))
                this.Airports.Add(str2, new Airport(str2, str1, name, loc, firIcao, str3 == "1"));
            return true;
        }

        private bool ProcessSectionDataFIRs(ref string line, int lineNum)
        {
            string[] strArray = line.Split(new char[1] { '|' }, StringSplitOptions.None);
            if (strArray.Length != 4)
            {
                this.RaiseDataLoadError(string.Format("Invalid field count in FIRs section on line {0}", (object)lineNum));
                return false;
            }
            string str1 = strArray[0].Trim();
            string name = strArray[1].Trim();
            string key = strArray[2].Trim();
            string str2 = strArray[3].Trim();
            string icao = str2 == "" || str2 == "0000" ? str1 : str2;
            if (!this.Firs.ContainsKey(str1))
                this.Firs.Add(str1, new Fir(str1, name, icao));
            if (key != "" && !this.Firs.ContainsKey(key))
                this.Firs.Add(key, new Fir(str1, name, icao));
            return true;
        }

        private bool ProcessSectionDataUIRs(ref string line, int lineNum)
        {
            string[] strArray1 = line.Split(new char[1] { '|' }, StringSplitOptions.None);
            if (strArray1.Length != 3)
            {
                this.RaiseDataLoadError(string.Format("Invalid field count in UIRs section on line {0}", (object)lineNum));
                return false;
            }
            string str = strArray1[0].Trim();
            string name = strArray1[1].Trim();
            string[] strArray2 = strArray1[2].Trim().Split(new char[1]
            {
        ','
            }, StringSplitOptions.None);
            this.Uirs.Add(str, new Uir(str, name));
            for (int index = 0; index < strArray2.Length; ++index)
                this.Uirs[str].MemberFirs.Add(strArray2[index]);
            return true;
        }

        private bool ProcessSectionDataIDL(ref string line, int lineNum)
        {
            string[] strArray = line.Split(new char[1] { '|' }, StringSplitOptions.None);
            if (strArray.Length != 2)
            {
                this.RaiseDataLoadError(string.Format("Invalid field count in IDL section on line {0}", (object)lineNum));
                return false;
            }
            string s1 = strArray[0].Trim();
            string s2 = strArray[1].Trim();
            WorldPoint worldPoint;
            try
            {
                worldPoint = new WorldPoint(double.Parse(s2, (IFormatProvider)CultureInfo.InvariantCulture), double.Parse(s1, (IFormatProvider)CultureInfo.InvariantCulture));
            }
            catch
            {
                this.RaiseDataLoadError(string.Format("Error parsing IDL coordinates on line {0}", (object)lineNum));
                return false;
            }
            this.Idl.Add(worldPoint);
            return true;
        }

        public Airport GetAirport(string code) => !this.Airports.ContainsKey(code) ? (Airport)null : this.Airports[code];

        public string GetAirportIcao(string code) => !this.Airports.ContainsKey(code) ? string.Empty : this.Airports[code].Icao;

        public WorldPoint GetAirportLoc(string icao) => !this.Airports.ContainsKey(icao) ? WorldPoint.Zero : this.Airports[icao].Loc;

        public string GetAirportName(string icao) => !this.Airports.ContainsKey(icao) ? string.Empty : this.Airports[icao].Name;

        public bool GetIsPseudoAirport(string icao) => this.Airports.ContainsKey(icao) && this.Airports[icao].IsPseudo;

        public string GetCountryName(string code)
        {
            if (code.Length < 2)
                return "";
            string key = code.Substring(0, 2);
            return !this.mCountryCodeMap.ContainsKey(key) ? string.Empty : this.mCountryCodeMap[key];
        }

        public Fir GetFIR(string prefix) => !this.Firs.ContainsKey(prefix) ? (Fir)null : this.Firs[prefix];

        public string GetFIRName(string icao) => !this.Firs.ContainsKey(icao) ? string.Empty : this.Firs[icao].Name;

        public Uir GetUir(string prefix) => !this.Uirs.ContainsKey(prefix) ? (Uir)null : this.Uirs[prefix];

        public string GetUIRName(string code) => !this.Uirs.ContainsKey(code) ? string.Empty : this.Uirs[code].Name;

        public WorldPoint GetFirCenter(string icao, bool oceanic) => oceanic ? (this.OceanicBoundaries.ContainsKey(icao) ? this.OceanicBoundaries[icao].Center : WorldPoint.Zero) : (this.FirBoundaries.ContainsKey(icao) ? this.FirBoundaries[icao].Center : WorldPoint.Zero);

        public string GetCenterName(string country) => !this.Countries.ContainsKey(country) ? string.Empty : this.Countries[country].CenterName;

        public string GetContainingFir(WorldPoint point)
        {
            FirBoundary firBoundary = this.FirBoundaries.Values.Concat<FirBoundary>((IEnumerable<FirBoundary>)this.FirBoundaryExtensions.Values).Concat<FirBoundary>((IEnumerable<FirBoundary>)this.OceanicBoundaries.Values).Concat<FirBoundary>((IEnumerable<FirBoundary>)this.OceanicBoundaryExtensions.Values).FirstOrDefault<FirBoundary>((Func<FirBoundary, bool>)(x => x.Contains(point)));
            return firBoundary == null ? string.Empty : firBoundary.Icao;
        }

        public string GetNearbyAirport(WorldPoint point) => this.Airports.Values.FirstOrDefault<Airport>((Func<Airport, bool>)(x => x.Loc.DistanceTo(point) < 3.0))?.Icao;

        private enum DataFileSection
        {
            Unknown,
            Countries,
            Airports,
            Firs,
            Uirs,
            Idl,
        }
    }
}
