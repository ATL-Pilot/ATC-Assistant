namespace ATC_Helper.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cbDirectionOfFlight = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCruiseAlt = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbScratchpad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFlightRules = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tbDOF = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbAltEvenOdd = new System.Windows.Forms.TextBox();
            this.tbCS = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbPropType = new System.Windows.Forms.TextBox();
            this.cbIsHeavy = new System.Windows.Forms.CheckBox();
            this.LastChange = new System.Windows.Forms.Timer(this.components);
            this.cbGetFRC = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbAcInfo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.gbEntry = new System.Windows.Forms.GroupBox();
            this.tbSquawk = new System.Windows.Forms.TextBox();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.tbAcType = new System.Windows.Forms.TextBox();
            this.tbCallsign = new System.Windows.Forms.TextBox();
            this.tbArrive = new System.Windows.Forms.TextBox();
            this.tbDepart = new System.Windows.Forms.TextBox();
            this.tbAlternate = new System.Windows.Forms.TextBox();
            this.tbCruiseAlt = new System.Windows.Forms.TextBox();
            this.tbRoute = new System.Windows.Forms.TextBox();
            this.btnLoadFlightplan = new System.Windows.Forms.Button();
            this.gbClearanceDetails = new UIToolbox.CollapsibleGroupBox();
            this.tbPreferedRW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbPdcCommands = new UIToolbox.CollapsibleGroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbPdcNoDep = new System.Windows.Forms.TextBox();
            this.tbPdcMe = new System.Windows.Forms.TextBox();
            this.tbPdc = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callSignLookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aircraftLookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airportLookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label21 = new System.Windows.Forms.Label();
            this.tbDepId = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCallsign = new System.Windows.Forms.ToolStripButton();
            this.tsbAircraft = new System.Windows.Forms.ToolStripButton();
            this.tsbAirport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.gbAirportInfo = new UIToolbox.CollapsibleGroupBox();
            this.dgvAirports = new System.Windows.Forms.DataGridView();
            this.gbFlightplanDetails = new UIToolbox.CollapsibleGroupBox();
            this.dgvRouteInformation = new System.Windows.Forms.DataGridView();
            this.gbEntry.SuspendLayout();
            this.gbClearanceDetails.SuspendLayout();
            this.gbPdcCommands.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbAirportInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirports)).BeginInit();
            this.gbFlightplanDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDirectionOfFlight
            // 
            this.cbDirectionOfFlight.Enabled = false;
            this.cbDirectionOfFlight.FormattingEnabled = true;
            this.cbDirectionOfFlight.Items.AddRange(new object[] {
            "",
            "East",
            "West"});
            this.cbDirectionOfFlight.Location = new System.Drawing.Point(401, 107);
            this.cbDirectionOfFlight.Name = "cbDirectionOfFlight";
            this.cbDirectionOfFlight.Size = new System.Drawing.Size(56, 21);
            this.cbDirectionOfFlight.TabIndex = 46;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(306, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "Direction of Flight";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Route:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCruiseAlt
            // 
            this.lblCruiseAlt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCruiseAlt.AutoSize = true;
            this.lblCruiseAlt.Location = new System.Drawing.Point(26, 92);
            this.lblCruiseAlt.Name = "lblCruiseAlt";
            this.lblCruiseAlt.Size = new System.Drawing.Size(54, 13);
            this.lblCruiseAlt.TabIndex = 54;
            this.lblCruiseAlt.Text = "Cruise Alt:";
            this.lblCruiseAlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Scratchpad";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbScratchpad
            // 
            this.tbScratchpad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbScratchpad.Location = new System.Drawing.Point(208, 92);
            this.tbScratchpad.Name = "tbScratchpad";
            this.tbScratchpad.Size = new System.Drawing.Size(56, 20);
            this.tbScratchpad.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(298, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Squawk:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Depart:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Arrive:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Alternate:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Callsign:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "A/C Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbFlightRules
            // 
            this.cbFlightRules.FormattingEnabled = true;
            this.cbFlightRules.Items.AddRange(new object[] {
            "",
            "IFR",
            "VFR",
            "SVFR",
            "DVFR"});
            this.cbFlightRules.Location = new System.Drawing.Point(345, 26);
            this.cbFlightRules.Name = "cbFlightRules";
            this.cbFlightRules.Size = new System.Drawing.Size(56, 21);
            this.cbFlightRules.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Flight Rules:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(601, 67);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 23);
            this.btnClear.TabIndex = 50;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(601, 38);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(96, 23);
            this.btnProcess.TabIndex = 48;
            this.btnProcess.Text = "Get Clearance";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(303, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 65;
            this.label14.Text = "Direction of Flight:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDOF
            // 
            this.tbDOF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDOF.Location = new System.Drawing.Point(401, 22);
            this.tbDOF.Name = "tbDOF";
            this.tbDOF.ReadOnly = true;
            this.tbDOF.Size = new System.Drawing.Size(157, 20);
            this.tbDOF.TabIndex = 63;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(347, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 67;
            this.label16.Text = "Alttitude:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbAltEvenOdd
            // 
            this.tbAltEvenOdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAltEvenOdd.Location = new System.Drawing.Point(401, 48);
            this.tbAltEvenOdd.Name = "tbAltEvenOdd";
            this.tbAltEvenOdd.ReadOnly = true;
            this.tbAltEvenOdd.Size = new System.Drawing.Size(157, 20);
            this.tbAltEvenOdd.TabIndex = 66;
            // 
            // tbCS
            // 
            this.tbCS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCS.Location = new System.Drawing.Point(82, 19);
            this.tbCS.Name = "tbCS";
            this.tbCS.ReadOnly = true;
            this.tbCS.Size = new System.Drawing.Size(157, 20);
            this.tbCS.TabIndex = 62;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 64;
            this.label15.Text = "Callsign:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 69;
            this.label17.Text = "AC Type:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPropType
            // 
            this.tbPropType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPropType.Location = new System.Drawing.Point(82, 71);
            this.tbPropType.Name = "tbPropType";
            this.tbPropType.ReadOnly = true;
            this.tbPropType.Size = new System.Drawing.Size(157, 20);
            this.tbPropType.TabIndex = 68;
            // 
            // cbIsHeavy
            // 
            this.cbIsHeavy.AutoSize = true;
            this.cbIsHeavy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIsHeavy.Location = new System.Drawing.Point(350, 74);
            this.cbIsHeavy.Name = "cbIsHeavy";
            this.cbIsHeavy.Size = new System.Drawing.Size(68, 17);
            this.cbIsHeavy.TabIndex = 71;
            this.cbIsHeavy.Text = "Is Heavy";
            this.cbIsHeavy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbIsHeavy.UseVisualStyleBackColor = true;
            // 
            // LastChange
            // 
            this.LastChange.Enabled = true;
            // 
            // cbGetFRC
            // 
            this.cbGetFRC.AutoSize = true;
            this.cbGetFRC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbGetFRC.Location = new System.Drawing.Point(618, 96);
            this.cbGetFRC.Name = "cbGetFRC";
            this.cbGetFRC.Size = new System.Drawing.Size(67, 17);
            this.cbGetFRC.TabIndex = 72;
            this.cbGetFRC.Text = "Get FRC";
            this.cbGetFRC.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(31, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 74;
            this.label18.Text = "AC Info:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbAcInfo
            // 
            this.tbAcInfo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAcInfo.Location = new System.Drawing.Point(82, 45);
            this.tbAcInfo.Name = "tbAcInfo";
            this.tbAcInfo.ReadOnly = true;
            this.tbAcInfo.Size = new System.Drawing.Size(157, 20);
            this.tbAcInfo.TabIndex = 73;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 158);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 76;
            this.label19.Text = "Remarks:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbEntry
            // 
            this.gbEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEntry.AutoSize = true;
            this.gbEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbEntry.Controls.Add(this.tbSquawk);
            this.gbEntry.Controls.Add(this.label19);
            this.gbEntry.Controls.Add(this.label2);
            this.gbEntry.Controls.Add(this.tbRemarks);
            this.gbEntry.Controls.Add(this.cbFlightRules);
            this.gbEntry.Controls.Add(this.tbAcType);
            this.gbEntry.Controls.Add(this.label3);
            this.gbEntry.Controls.Add(this.tbCallsign);
            this.gbEntry.Controls.Add(this.label4);
            this.gbEntry.Controls.Add(this.label7);
            this.gbEntry.Controls.Add(this.tbArrive);
            this.gbEntry.Controls.Add(this.label6);
            this.gbEntry.Controls.Add(this.tbDepart);
            this.gbEntry.Controls.Add(this.label5);
            this.gbEntry.Controls.Add(this.tbAlternate);
            this.gbEntry.Controls.Add(this.label10);
            this.gbEntry.Controls.Add(this.tbScratchpad);
            this.gbEntry.Controls.Add(this.label9);
            this.gbEntry.Controls.Add(this.tbCruiseAlt);
            this.gbEntry.Controls.Add(this.lblCruiseAlt);
            this.gbEntry.Controls.Add(this.tbRoute);
            this.gbEntry.Controls.Add(this.label8);
            this.gbEntry.Location = new System.Drawing.Point(12, 28);
            this.gbEntry.Name = "gbEntry";
            this.gbEntry.Size = new System.Drawing.Size(577, 211);
            this.gbEntry.TabIndex = 77;
            this.gbEntry.TabStop = false;
            this.gbEntry.Text = "Enter Flight Details";
            // 
            // tbSquawk
            // 
            this.tbSquawk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSquawk.Location = new System.Drawing.Point(344, 92);
            this.tbSquawk.Name = "tbSquawk";
            this.tbSquawk.Size = new System.Drawing.Size(56, 20);
            this.tbSquawk.TabIndex = 44;
            // 
            // tbRemarks
            // 
            this.tbRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRemarks.Location = new System.Drawing.Point(82, 158);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRemarks.Size = new System.Drawing.Size(489, 34);
            this.tbRemarks.TabIndex = 75;
            // 
            // tbAcType
            // 
            this.tbAcType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAcType.Location = new System.Drawing.Point(210, 28);
            this.tbAcType.Name = "tbAcType";
            this.tbAcType.Size = new System.Drawing.Size(56, 20);
            this.tbAcType.TabIndex = 32;
            // 
            // tbCallsign
            // 
            this.tbCallsign.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCallsign.Location = new System.Drawing.Point(82, 28);
            this.tbCallsign.Name = "tbCallsign";
            this.tbCallsign.Size = new System.Drawing.Size(56, 20);
            this.tbCallsign.TabIndex = 31;
            // 
            // tbArrive
            // 
            this.tbArrive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbArrive.Location = new System.Drawing.Point(208, 60);
            this.tbArrive.Name = "tbArrive";
            this.tbArrive.Size = new System.Drawing.Size(56, 20);
            this.tbArrive.TabIndex = 38;
            // 
            // tbDepart
            // 
            this.tbDepart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDepart.Location = new System.Drawing.Point(82, 60);
            this.tbDepart.Name = "tbDepart";
            this.tbDepart.Size = new System.Drawing.Size(56, 20);
            this.tbDepart.TabIndex = 37;
            // 
            // tbAlternate
            // 
            this.tbAlternate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAlternate.Location = new System.Drawing.Point(344, 60);
            this.tbAlternate.Name = "tbAlternate";
            this.tbAlternate.Size = new System.Drawing.Size(56, 20);
            this.tbAlternate.TabIndex = 39;
            // 
            // tbCruiseAlt
            // 
            this.tbCruiseAlt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCruiseAlt.Location = new System.Drawing.Point(82, 92);
            this.tbCruiseAlt.Name = "tbCruiseAlt";
            this.tbCruiseAlt.Size = new System.Drawing.Size(56, 20);
            this.tbCruiseAlt.TabIndex = 40;
            // 
            // tbRoute
            // 
            this.tbRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRoute.Location = new System.Drawing.Point(82, 118);
            this.tbRoute.Multiline = true;
            this.tbRoute.Name = "tbRoute";
            this.tbRoute.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRoute.Size = new System.Drawing.Size(489, 34);
            this.tbRoute.TabIndex = 47;
            // 
            // btnLoadFlightplan
            // 
            this.btnLoadFlightplan.Location = new System.Drawing.Point(603, 65);
            this.btnLoadFlightplan.Name = "btnLoadFlightplan";
            this.btnLoadFlightplan.Size = new System.Drawing.Size(95, 23);
            this.btnLoadFlightplan.TabIndex = 80;
            this.btnLoadFlightplan.Text = "Load Flightplan";
            this.btnLoadFlightplan.UseVisualStyleBackColor = true;
            this.btnLoadFlightplan.Click += new System.EventHandler(this.btnLoadFlightplan_Click);
            // 
            // gbClearanceDetails
            // 
            this.gbClearanceDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbClearanceDetails.Caption = "Clearance Details";
            this.gbClearanceDetails.ContainsTrashCan = false;
            this.gbClearanceDetails.Controls.Add(this.tbPreferedRW);
            this.gbClearanceDetails.Controls.Add(this.label1);
            this.gbClearanceDetails.Controls.Add(this.tbCS);
            this.gbClearanceDetails.Controls.Add(this.tbAcInfo);
            this.gbClearanceDetails.Controls.Add(this.tbPropType);
            this.gbClearanceDetails.Controls.Add(this.label15);
            this.gbClearanceDetails.Controls.Add(this.label18);
            this.gbClearanceDetails.Controls.Add(this.label17);
            this.gbClearanceDetails.Controls.Add(this.tbDOF);
            this.gbClearanceDetails.Controls.Add(this.cbDirectionOfFlight);
            this.gbClearanceDetails.Controls.Add(this.label16);
            this.gbClearanceDetails.Controls.Add(this.label12);
            this.gbClearanceDetails.Controls.Add(this.cbIsHeavy);
            this.gbClearanceDetails.Controls.Add(this.label14);
            this.gbClearanceDetails.Controls.Add(this.tbAltEvenOdd);
            this.gbClearanceDetails.Location = new System.Drawing.Point(12, 640);
            this.gbClearanceDetails.Name = "gbClearanceDetails";
            this.gbClearanceDetails.Size = new System.Drawing.Size(579, 131);
            this.gbClearanceDetails.TabIndex = 81;
            this.gbClearanceDetails.TabStop = false;
            // 
            // tbPreferedRW
            // 
            this.tbPreferedRW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPreferedRW.Location = new System.Drawing.Point(82, 104);
            this.tbPreferedRW.Name = "tbPreferedRW";
            this.tbPreferedRW.ReadOnly = true;
            this.tbPreferedRW.Size = new System.Drawing.Size(157, 20);
            this.tbPreferedRW.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Runway:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbPdcCommands
            // 
            this.gbPdcCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPdcCommands.Caption = "PDC Commands";
            this.gbPdcCommands.ContainsTrashCan = false;
            this.gbPdcCommands.Controls.Add(this.label11);
            this.gbPdcCommands.Controls.Add(this.label13);
            this.gbPdcCommands.Controls.Add(this.tbPdcNoDep);
            this.gbPdcCommands.Controls.Add(this.tbPdcMe);
            this.gbPdcCommands.Controls.Add(this.tbPdc);
            this.gbPdcCommands.Controls.Add(this.label20);
            this.gbPdcCommands.Location = new System.Drawing.Point(12, 777);
            this.gbPdcCommands.Name = "gbPdcCommands";
            this.gbPdcCommands.Size = new System.Drawing.Size(579, 95);
            this.gbPdcCommands.TabIndex = 83;
            this.gbPdcCommands.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "No Departure PDC:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Me as Departure PDC:";
            // 
            // tbPdcNoDep
            // 
            this.tbPdcNoDep.Location = new System.Drawing.Point(121, 46);
            this.tbPdcNoDep.Name = "tbPdcNoDep";
            this.tbPdcNoDep.Size = new System.Drawing.Size(247, 20);
            this.tbPdcNoDep.TabIndex = 9;
            // 
            // tbPdcMe
            // 
            this.tbPdcMe.Location = new System.Drawing.Point(121, 72);
            this.tbPdcMe.Name = "tbPdcMe";
            this.tbPdcMe.Size = new System.Drawing.Size(247, 20);
            this.tbPdcMe.TabIndex = 8;
            // 
            // tbPdc
            // 
            this.tbPdc.Location = new System.Drawing.Point(121, 19);
            this.tbPdc.Name = "tbPdc";
            this.tbPdc.Size = new System.Drawing.Size(247, 20);
            this.tbPdc.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(83, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "PDC:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Enabled = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helperToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 24);
            this.menuStrip1.TabIndex = 84;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helperToolStripMenuItem
            // 
            this.helperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callSignLookupToolStripMenuItem,
            this.aircraftLookupToolStripMenuItem,
            this.airportLookupToolStripMenuItem});
            this.helperToolStripMenuItem.Name = "helperToolStripMenuItem";
            this.helperToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.helperToolStripMenuItem.Text = "Tools";
            // 
            // callSignLookupToolStripMenuItem
            // 
            this.callSignLookupToolStripMenuItem.Name = "callSignLookupToolStripMenuItem";
            this.callSignLookupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.callSignLookupToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.callSignLookupToolStripMenuItem.Text = "Call Sign Lookup";
            this.callSignLookupToolStripMenuItem.Click += new System.EventHandler(this.callSignLookupToolStripMenuItem_Click);
            // 
            // aircraftLookupToolStripMenuItem
            // 
            this.aircraftLookupToolStripMenuItem.Name = "aircraftLookupToolStripMenuItem";
            this.aircraftLookupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.aircraftLookupToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.aircraftLookupToolStripMenuItem.Text = "Aircraft Lookup";
            this.aircraftLookupToolStripMenuItem.Click += new System.EventHandler(this.aircraftLookupToolStripMenuItem_Click);
            // 
            // airportLookupToolStripMenuItem
            // 
            this.airportLookupToolStripMenuItem.Name = "airportLookupToolStripMenuItem";
            this.airportLookupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.airportLookupToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.airportLookupToolStripMenuItem.Text = "Airport Lookup";
            this.airportLookupToolStripMenuItem.Click += new System.EventHandler(this.airportLookupToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(615, 167);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 85;
            this.label21.Text = "Departure ID:";
            // 
            // tbDepId
            // 
            this.tbDepId.Location = new System.Drawing.Point(618, 180);
            this.tbDepId.Name = "tbDepId";
            this.tbDepId.Size = new System.Drawing.Size(67, 20);
            this.tbDepId.TabIndex = 86;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.toolStripSeparator1,
            this.tsbCallsign,
            this.tsbAircraft,
            this.tsbAirport,
            this.toolStripSeparator2,
            this.tsbSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(709, 25);
            this.toolStrip1.TabIndex = 87;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::ATC_Helper.Properties.Resources.refresh;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "Refresh VatSim Data";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCallsign
            // 
            this.tsbCallsign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCallsign.Image = global::ATC_Helper.Properties.Resources.Radio;
            this.tsbCallsign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCallsign.Name = "tsbCallsign";
            this.tsbCallsign.Size = new System.Drawing.Size(23, 22);
            this.tsbCallsign.Text = "Load Callsign Lookup";
            this.tsbCallsign.Click += new System.EventHandler(this.tsbCallsign_Click);
            // 
            // tsbAircraft
            // 
            this.tsbAircraft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAircraft.Image = global::ATC_Helper.Properties.Resources.Airplane;
            this.tsbAircraft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAircraft.Name = "tsbAircraft";
            this.tsbAircraft.Size = new System.Drawing.Size(23, 22);
            this.tsbAircraft.Text = "Load Aircraft Lookup";
            this.tsbAircraft.Click += new System.EventHandler(this.tsbAircraft_Click);
            // 
            // tsbAirport
            // 
            this.tsbAirport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAirport.Image = global::ATC_Helper.Properties.Resources.airport;
            this.tsbAirport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAirport.Name = "tsbAirport";
            this.tsbAirport.Size = new System.Drawing.Size(23, 22);
            this.tsbAirport.Text = "Load Airport Lookup";
            this.tsbAirport.Click += new System.EventHandler(this.tsbAirport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSettings
            // 
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSettings.Image = global::ATC_Helper.Properties.Resources.Settings;
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(23, 22);
            this.tsbSettings.Text = "Load Settings";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // gbAirportInfo
            // 
            this.gbAirportInfo.Caption = "Airport Details";
            this.gbAirportInfo.ContainsTrashCan = false;
            this.gbAirportInfo.Controls.Add(this.dgvAirports);
            this.gbAirportInfo.Location = new System.Drawing.Point(12, 245);
            this.gbAirportInfo.Name = "gbAirportInfo";
            this.gbAirportInfo.Size = new System.Drawing.Size(577, 132);
            this.gbAirportInfo.TabIndex = 88;
            // 
            // dgvAirports
            // 
            this.dgvAirports.AllowUserToAddRows = false;
            this.dgvAirports.AllowUserToDeleteRows = false;
            this.dgvAirports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAirports.Location = new System.Drawing.Point(5, 25);
            this.dgvAirports.Name = "dgvAirports";
            this.dgvAirports.ReadOnly = true;
            this.dgvAirports.Size = new System.Drawing.Size(565, 90);
            this.dgvAirports.TabIndex = 89;
            // 
            // gbFlightplanDetails
            // 
            this.gbFlightplanDetails.Caption = "Detailed Flightplan";
            this.gbFlightplanDetails.ContainsTrashCan = false;
            this.gbFlightplanDetails.Controls.Add(this.dgvRouteInformation);
            this.gbFlightplanDetails.Location = new System.Drawing.Point(12, 384);
            this.gbFlightplanDetails.Name = "gbFlightplanDetails";
            this.gbFlightplanDetails.Size = new System.Drawing.Size(577, 250);
            this.gbFlightplanDetails.TabIndex = 89;
            // 
            // dgvRouteInformation
            // 
            this.dgvRouteInformation.AllowUserToAddRows = false;
            this.dgvRouteInformation.AllowUserToDeleteRows = false;
            this.dgvRouteInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRouteInformation.Location = new System.Drawing.Point(5, 25);
            this.dgvRouteInformation.Name = "dgvRouteInformation";
            this.dgvRouteInformation.ReadOnly = true;
            this.dgvRouteInformation.Size = new System.Drawing.Size(565, 210);
            this.dgvRouteInformation.TabIndex = 90;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnLoadFlightplan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(709, 881);
            this.Controls.Add(this.gbFlightplanDetails);
            this.Controls.Add(this.gbAirportInfo);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbClearanceDetails);
            this.Controls.Add(this.gbPdcCommands);
            this.Controls.Add(this.tbDepId);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnLoadFlightplan);
            this.Controls.Add(this.gbEntry);
            this.Controls.Add(this.cbGetFRC);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "ATC Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.gbEntry.ResumeLayout(false);
            this.gbEntry.PerformLayout();
            this.gbClearanceDetails.ResumeLayout(false);
            this.gbClearanceDetails.PerformLayout();
            this.gbPdcCommands.ResumeLayout(false);
            this.gbPdcCommands.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbAirportInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirports)).EndInit();
            this.gbFlightplanDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbDirectionOfFlight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRoute;
        private System.Windows.Forms.TextBox tbSquawk;
        private System.Windows.Forms.Label lblCruiseAlt;
        private System.Windows.Forms.TextBox tbCruiseAlt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbScratchpad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbAlternate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDepart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbArrive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCallsign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAcType;
        private System.Windows.Forms.ComboBox cbFlightRules;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbDOF;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbAltEvenOdd;
        private System.Windows.Forms.TextBox tbCS;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbPropType;
        private System.Windows.Forms.CheckBox cbIsHeavy;
        private System.Windows.Forms.Timer LastChange;
        private System.Windows.Forms.CheckBox cbGetFRC;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbAcInfo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.GroupBox gbEntry;
        private System.Windows.Forms.Button btnLoadFlightplan;
        private UIToolbox.CollapsibleGroupBox gbClearanceDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPreferedRW;
        private UIToolbox.CollapsibleGroupBox gbPdcCommands;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem callSignLookupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aircraftLookupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airportLookupToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbPdcNoDep;
        private System.Windows.Forms.TextBox tbPdcMe;
        private System.Windows.Forms.TextBox tbPdc;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbDepId;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbCallsign;
        private System.Windows.Forms.ToolStripButton tsbAircraft;
        private System.Windows.Forms.ToolStripButton tsbAirport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private UIToolbox.CollapsibleGroupBox gbAirportInfo;
        private System.Windows.Forms.DataGridView dgvAirports;
        private UIToolbox.CollapsibleGroupBox gbFlightplanDetails;
        private System.Windows.Forms.DataGridView dgvRouteInformation;
    }
}

