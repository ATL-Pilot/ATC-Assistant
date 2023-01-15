using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ATC_Helper.Forms
{
    public partial class frmCallSign : Form
    {
        public frmCallSign()
        {
            InitializeComponent();

        }

        public event EventHandler CallSignClosing;

        private void btnLookup_Click(object sender, EventArgs e)
        {
            tbAirlineID.Text = "";
            tbCallsign.Text = "";
            tbCompany.Text = "";
            tbCountry.Text = "";


            //take first 3
            string cs = tbFlight.Text.Substring(0, 3);
            string num = tbFlight.Text.Substring(3, tbFlight.Text.Length - 3);

            var matches = Program.AtcHelper_CallSigns.Where(p => p.AirlineID == cs);
            foreach (var match in matches)
            {
                tbAirlineID.Text = match.AirlineID.ToString().Trim();
                tbCallsign.Text = match.CallSign1.Trim();
                tbCompany.Text = match.Company.ToString().Trim();
                tbCountry.Text = match.Country.ToString().Trim();
            }
        }

        private void frmCallSign_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHandler handler = CallSignClosing;
            handler?.Invoke(this, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCallSign_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberWindowsSettings)
                this.Location = Properties.Settings.Default.frmCallsignPosition;

            this.LocationChanged += FrmCallSign_LocationChanged;
        }

        private void FrmCallSign_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.frmCallsignPosition = this.Location;
            Properties.Settings.Default.Save();
        }
    }
}
