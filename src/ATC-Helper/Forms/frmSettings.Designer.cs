namespace ATC_Helper.Forms
{
    partial class frmSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPdc = new System.Windows.Forms.TextBox();
            this.tbPdcMe = new System.Windows.Forms.TextBox();
            this.tbPdcNoDep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbPDC = new System.Windows.Forms.GroupBox();
            this.gbSections = new System.Windows.Forms.GroupBox();
            this.cbClearanceDetails = new System.Windows.Forms.CheckBox();
            this.cbAirportDetails = new System.Windows.Forms.CheckBox();
            this.cbDetailedFlightPlan = new System.Windows.Forms.CheckBox();
            this.cbPDC = new System.Windows.Forms.CheckBox();
            this.cbWindowsLocation = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbPDC.SuspendLayout();
            this.gbSections.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PDC:";
            // 
            // tbPdc
            // 
            this.tbPdc.Location = new System.Drawing.Point(125, 19);
            this.tbPdc.Name = "tbPdc";
            this.tbPdc.Size = new System.Drawing.Size(247, 20);
            this.tbPdc.TabIndex = 1;
            this.tbPdc.Text = ".pdcclt";
            // 
            // tbPdcMe
            // 
            this.tbPdcMe.Location = new System.Drawing.Point(125, 72);
            this.tbPdcMe.Name = "tbPdcMe";
            this.tbPdcMe.Size = new System.Drawing.Size(247, 20);
            this.tbPdcMe.TabIndex = 2;
            this.tbPdcMe.Text = ".pdccltme";
            // 
            // tbPdcNoDep
            // 
            this.tbPdcNoDep.Location = new System.Drawing.Point(125, 46);
            this.tbPdcNoDep.Name = "tbPdcNoDep";
            this.tbPdcNoDep.Size = new System.Drawing.Size(247, 20);
            this.tbPdcNoDep.TabIndex = 3;
            this.tbPdcNoDep.Text = ".pdccltd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Me as Departure PDC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "No Departure PDC:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(238, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(319, 259);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbPDC
            // 
            this.gbPDC.Controls.Add(this.tbPdc);
            this.gbPDC.Controls.Add(this.label1);
            this.gbPDC.Controls.Add(this.tbPdcMe);
            this.gbPDC.Controls.Add(this.label3);
            this.gbPDC.Controls.Add(this.tbPdcNoDep);
            this.gbPDC.Controls.Add(this.label2);
            this.gbPDC.Location = new System.Drawing.Point(13, 145);
            this.gbPDC.Name = "gbPDC";
            this.gbPDC.Size = new System.Drawing.Size(381, 108);
            this.gbPDC.TabIndex = 8;
            this.gbPDC.TabStop = false;
            this.gbPDC.Text = "PDC Information";
            // 
            // gbSections
            // 
            this.gbSections.Controls.Add(this.cbPDC);
            this.gbSections.Controls.Add(this.cbClearanceDetails);
            this.gbSections.Controls.Add(this.cbAirportDetails);
            this.gbSections.Controls.Add(this.cbDetailedFlightPlan);
            this.gbSections.Location = new System.Drawing.Point(13, 13);
            this.gbSections.Name = "gbSections";
            this.gbSections.Size = new System.Drawing.Size(381, 70);
            this.gbSections.TabIndex = 9;
            this.gbSections.TabStop = false;
            this.gbSections.Text = "Section Visability";
            // 
            // cbClearanceDetails
            // 
            this.cbClearanceDetails.AutoSize = true;
            this.cbClearanceDetails.Location = new System.Drawing.Point(5, 42);
            this.cbClearanceDetails.Name = "cbClearanceDetails";
            this.cbClearanceDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbClearanceDetails.Size = new System.Drawing.Size(152, 17);
            this.cbClearanceDetails.TabIndex = 2;
            this.cbClearanceDetails.Text = "Collapse Clearance Details";
            this.cbClearanceDetails.UseVisualStyleBackColor = true;
            // 
            // cbAirportDetails
            // 
            this.cbAirportDetails.AutoSize = true;
            this.cbAirportDetails.Location = new System.Drawing.Point(23, 19);
            this.cbAirportDetails.Name = "cbAirportDetails";
            this.cbAirportDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbAirportDetails.Size = new System.Drawing.Size(134, 17);
            this.cbAirportDetails.TabIndex = 1;
            this.cbAirportDetails.Text = "Collapse Airport Details";
            this.cbAirportDetails.UseVisualStyleBackColor = true;
            // 
            // cbDetailedFlightPlan
            // 
            this.cbDetailedFlightPlan.AutoSize = true;
            this.cbDetailedFlightPlan.Location = new System.Drawing.Point(223, 19);
            this.cbDetailedFlightPlan.Name = "cbDetailedFlightPlan";
            this.cbDetailedFlightPlan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDetailedFlightPlan.Size = new System.Drawing.Size(149, 17);
            this.cbDetailedFlightPlan.TabIndex = 0;
            this.cbDetailedFlightPlan.Text = "Collapse Flightplan Details";
            this.cbDetailedFlightPlan.UseVisualStyleBackColor = true;
            // 
            // cbPDC
            // 
            this.cbPDC.AutoSize = true;
            this.cbPDC.Location = new System.Drawing.Point(226, 42);
            this.cbPDC.Name = "cbPDC";
            this.cbPDC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPDC.Size = new System.Drawing.Size(146, 17);
            this.cbPDC.TabIndex = 3;
            this.cbPDC.Text = "Collapse PDC Commands";
            this.cbPDC.UseVisualStyleBackColor = true;
            // 
            // cbWindowsLocation
            // 
            this.cbWindowsLocation.AutoSize = true;
            this.cbWindowsLocation.Location = new System.Drawing.Point(8, 19);
            this.cbWindowsLocation.Name = "cbWindowsLocation";
            this.cbWindowsLocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbWindowsLocation.Size = new System.Drawing.Size(168, 17);
            this.cbWindowsLocation.TabIndex = 4;
            this.cbWindowsLocation.Text = "Remember Window Locations";
            this.cbWindowsLocation.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbWindowsLocation);
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 50);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Misc. ";
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(408, 296);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSections);
            this.Controls.Add(this.gbPDC);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.gbPDC.ResumeLayout(false);
            this.gbPDC.PerformLayout();
            this.gbSections.ResumeLayout(false);
            this.gbSections.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPdc;
        private System.Windows.Forms.TextBox tbPdcMe;
        private System.Windows.Forms.TextBox tbPdcNoDep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbPDC;
        private System.Windows.Forms.GroupBox gbSections;
        private System.Windows.Forms.CheckBox cbAirportDetails;
        private System.Windows.Forms.CheckBox cbDetailedFlightPlan;
        private System.Windows.Forms.CheckBox cbClearanceDetails;
        private System.Windows.Forms.CheckBox cbPDC;
        private System.Windows.Forms.CheckBox cbWindowsLocation;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}