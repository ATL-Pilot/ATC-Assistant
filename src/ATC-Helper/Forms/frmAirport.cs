using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ATC_Helper.Forms
{
    public partial class frmAirport : Form
    {
        public frmAirport()
        {
            InitializeComponent();

        }

        public event EventHandler AirportClosing;

        private void btnLookup_Click(object sender, EventArgs e)
        {
            tbAirportID.Text = "";
            tbCountry.Text = "";
            tbFir.Text = "";
            tbIataID.Text = "";
            tbIcaoID.Text = "";
            tbLocation.Text = "";
            tbName.Text = "";

            cbHasDeparturePlan.Visible = true;
            cbHasDeparturePlan.Enabled = true;
            cbHasDeparturePlan.Checked = false;

            cbIsPseudo.Visible = true;
            cbIsPseudo.Enabled = true;
            cbIsPseudo.Checked = false;

            cbSidRequired.Visible = true;
            cbSidRequired.Enabled = true;
            cbSidRequired.Checked = false;

            lblHasDeparturePlan.Enabled = true;
            lblHasDeparturePlan.Visible = true;

            lblIsPseudo.Enabled = true;
            lblIsPseudo.Visible = true;

            lblSidRequired.Enabled = true;
            lblSidRequired.Visible = true;


            WebService.Airport EdmAirport = null;
            VatSim.Data.Airport vatSimAirport = null;

            //Get Airport Details
            var Airports = Program.AtcHelper_AirportDetails.Where(p => p.ICAO_ID == tbAirport.Text.ToUpper().Trim());
            foreach (var match in Airports)
            {
                EdmAirport = match;
            }


            vatSimAirport = Program.dataManager.Airports[tbAirport.Text.ToUpper().Trim()];

            tbIcaoID.Text = EdmAirport != null ? EdmAirport.ICAO_ID : vatSimAirport != null ? vatSimAirport.Icao : "Unknown";
            tbName.Text = EdmAirport != null ? EdmAirport.Name : vatSimAirport != null ? vatSimAirport.Name : "Unknown";

            tbAirportID.Text = EdmAirport != null ? EdmAirport.Id.ToString() : "";
            tbCountry.Text = EdmAirport != null ? EdmAirport.Country : "";
            tbIataID.Text = EdmAirport != null ? EdmAirport.IATA_ID : "";
            tbLocation.Text = EdmAirport != null ? EdmAirport.Location : "";

            tbFir.Text = vatSimAirport != null ? vatSimAirport.FirIcao : "";

            if (EdmAirport != null && EdmAirport.IsConfigured == true)
            {
                cbHasDeparturePlan.Enabled = true;
                cbSidRequired.Enabled = true;
                cbHasDeparturePlan.Visible = true;
                cbSidRequired.Visible = true;

                cbHasDeparturePlan.Checked = EdmAirport.HasDeparturePlan;
                cbSidRequired.Checked = EdmAirport.SidRequired;
            }
            else
            {
                cbHasDeparturePlan.Enabled = false;
                cbHasDeparturePlan.Checked = false;
                cbHasDeparturePlan.Visible = false;

                cbSidRequired.Enabled = false;
                cbSidRequired.Checked = false;
                cbSidRequired.Visible = false;

                lblHasDeparturePlan.Enabled = false;
                lblHasDeparturePlan.Visible = false;

                lblSidRequired.Enabled = false;
                lblSidRequired.Visible = false;


            }

            if (vatSimAirport != null)
            {
                cbIsPseudo.Enabled = true;
                cbIsPseudo.Visible = true;
                cbIsPseudo.Checked = vatSimAirport.IsPseudo;
            }
            else
            {
                cbIsPseudo.Enabled = false;
                cbIsPseudo.Checked = false;
                cbIsPseudo.Visible = false;

                lblIsPseudo.Enabled = false;
                lblIsPseudo.Visible = false;
            }


        }

        private void frmAirport_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHandler handler = AirportClosing;
            handler?.Invoke(this, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAirport_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberWindowsSettings)
            {
                this.Location = Properties.Settings.Default.frmAirportPosition;
            }

            this.LocationChanged += FrmAirport_LocationChanged;
        }

        private void FrmAirport_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.frmAirportPosition = this.Location;
            Properties.Settings.Default.Save();
        }
    }
}
