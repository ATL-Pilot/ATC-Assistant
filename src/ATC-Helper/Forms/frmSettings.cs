using System;
using System.Windows.Forms;

namespace ATC_Helper.Forms
{
    public partial class frmSettings : Form
    {
        private static string Original_tbPdc;
        private static string Original_tbPdcNodep;
        private static string Original_tbPdcMe;
        private static bool Original_HideAirport;
        private static bool Original_HideFlightPlan;
        private static bool Original_HidePdcCommands;
        private static bool Original_HideClearanceDetails;
        private static bool Original_RememberWindowsLocations;

        public frmSettings()
        {
            InitializeComponent();

            //Hendle windows position change
            this.LocationChanged += FrmSettings_LocationChanged;
        }

        private void FrmSettings_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.frmSettingsPosition = this.Location;

            Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Pdc = Original_tbPdc = this.tbPdc.Text;
            Properties.Settings.Default.PdcNoDep = Original_tbPdcNodep = this.tbPdcNoDep.Text;
            Properties.Settings.Default.PdcMe = Original_tbPdcMe = this.tbPdcMe.Text;
            Properties.Settings.Default.Collapse_AirportDetails = Original_HideAirport = cbAirportDetails.Checked;
            Properties.Settings.Default.Collapse_ClearanceDetails = Original_HideClearanceDetails = cbClearanceDetails.Checked;
            Properties.Settings.Default.Collapse_FlightplanDetails = Original_HideFlightPlan = cbDetailedFlightPlan.Checked;
            Properties.Settings.Default.Collapse_PDCCommands = Original_HidePdcCommands = cbPDC.Checked;
            Properties.Settings.Default.RememberWindowsSettings = Original_RememberWindowsLocations = cbWindowsLocation.Checked;


            Properties.Settings.Default.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PendingChanges())
            {
                DialogResult Result = MessageBox.Show("You have unsaved changes.  Are you sure you want to close without saving the changes?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Original_tbPdc = this.tbPdc.Text = Properties.Settings.Default.Pdc;
            Original_tbPdcNodep = this.tbPdcNoDep.Text = Properties.Settings.Default.PdcNoDep;
            Original_tbPdcMe = this.tbPdcMe.Text = Properties.Settings.Default.PdcMe;
            Original_HideAirport = this.cbAirportDetails.Checked = Properties.Settings.Default.Collapse_AirportDetails;
            Original_HideFlightPlan = this.cbDetailedFlightPlan.Checked = Properties.Settings.Default.Collapse_FlightplanDetails;
            Original_HidePdcCommands = this.cbPDC.Checked = Properties.Settings.Default.Collapse_PDCCommands;
            Original_HideClearanceDetails = this.cbClearanceDetails.Checked = Properties.Settings.Default.Collapse_ClearanceDetails;
            Original_RememberWindowsLocations = this.cbWindowsLocation.Checked = Properties.Settings.Default.RememberWindowsSettings;

            //Position Window
            if (Properties.Settings.Default.RememberWindowsSettings)
            {
                this.Location = Properties.Settings.Default.frmSettingsPosition;
            }
        }

        private bool PendingChanges()
        {
            if (Original_tbPdc != tbPdc.Text ||
                Original_tbPdcMe != tbPdcMe.Text ||
                Original_tbPdcNodep != tbPdcNoDep.Text ||
                Original_HideAirport != cbAirportDetails.Checked ||
                Original_HideFlightPlan != cbDetailedFlightPlan.Checked ||
                Original_HidePdcCommands != cbPDC.Checked ||
                Original_HideClearanceDetails != cbClearanceDetails.Checked ||
                Original_RememberWindowsLocations != cbWindowsLocation.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
