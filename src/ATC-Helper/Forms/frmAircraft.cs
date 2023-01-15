using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ATC_Helper.Forms
{
    public partial class frmAircraft : Form
    {
        public frmAircraft()
        {
            InitializeComponent();

        }

        public event EventHandler AircraftClosing;

        private void btnLookup_Click(object sender, EventArgs e)
        {


            tbAircraftID.Text = "";
            tbManufacturer.Text = "";
            tbModel.Text = "";
            tbTypeDesignator.Text = "";
            tbDescription.Text = "";
            tbEngineType.Text = "";
            tbSimplifiedEngineType.Text = "";
            tbEngineCount.Text = "";
            tbWakeTurbulence.Text = "";
            cbIsHeavy.Checked = false;

            String TempEquiptmentType = "";

            try
            {

                if (tbAcType.Text.Contains("/"))
                {
                    TempEquiptmentType = tbAcType.Text.Substring(0, tbAcType.Text.IndexOf("/"));
                }
                else
                {
                    TempEquiptmentType = tbAcType.Text;
                }

            }
            catch (Exception ex)
            {
                Program.ErrorHandler(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString(), ex.StackTrace.ToString(), null);
            }


            string engType = "prop";
            var matches = Program.AtcHelper_AircraftTypes.Where(p => p.TypeDesignator == TempEquiptmentType);


            foreach (var match in matches)
            {
                if (match.SimplifiedEngineType.ToLower() == "jet")
                {
                    tbSimplifiedEngineType.Text = "Jet";
                }
                else
                {
                    tbSimplifiedEngineType.Text = "Prop";
                }


                if (match.WTC.ToUpper() == "H" || match.WTC.ToUpper() == "J")
                {
                    cbIsHeavy.Checked = true;
                }
                else
                {
                    cbIsHeavy.Checked = false;
                }

                tbAircraftID.Text = match.Id.ToString();
                tbManufacturer.Text = match.Manufacturer;
                tbModel.Text = match.Model;
                tbTypeDesignator.Text = match.TypeDesignator;
                tbDescription.Text = match.Description;
                tbEngineType.Text = match.EngineType;
                tbEngineCount.Text = match.EngineCount.ToString();
                tbWakeTurbulence.Text = match.WTC;

            }
        }

        private void frmCallSign_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHandler handler = AircraftClosing;
            handler?.Invoke(this, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAircraft_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberWindowsSettings)
            {
                this.Location = Properties.Settings.Default.frmAircraftPosition;
            }

            this.LocationChanged += FrmAircraft_LocationChanged;
        }

        private void FrmAircraft_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.frmAircraftPosition = this.Location;
            Properties.Settings.Default.Save();
        }
    }
}
