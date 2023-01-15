namespace ATC_Helper.Forms
{
    partial class frmCallSign
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
            this.tbFlight = new System.Windows.Forms.TextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbAirlineID = new System.Windows.Forms.TextBox();
            this.gbAirlineInformation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.tbCallsign = new System.Windows.Forms.TextBox();
            this.gbAirlineInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight:";
            // 
            // tbFlight
            // 
            this.tbFlight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbFlight.Location = new System.Drawing.Point(54, 10);
            this.tbFlight.Name = "tbFlight";
            this.tbFlight.Size = new System.Drawing.Size(100, 20);
            this.tbFlight.TabIndex = 1;
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(262, 13);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(75, 23);
            this.btnLookup.TabIndex = 2;
            this.btnLookup.Text = "Look Up";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(262, 43);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbAirlineID
            // 
            this.tbAirlineID.Enabled = false;
            this.tbAirlineID.Location = new System.Drawing.Point(64, 23);
            this.tbAirlineID.Name = "tbAirlineID";
            this.tbAirlineID.Size = new System.Drawing.Size(255, 20);
            this.tbAirlineID.TabIndex = 5;
            // 
            // gbAirlineInformation
            // 
            this.gbAirlineInformation.Controls.Add(this.label3);
            this.gbAirlineInformation.Controls.Add(this.tbCompany);
            this.gbAirlineInformation.Controls.Add(this.tbAirlineID);
            this.gbAirlineInformation.Controls.Add(this.label2);
            this.gbAirlineInformation.Controls.Add(this.label5);
            this.gbAirlineInformation.Controls.Add(this.label4);
            this.gbAirlineInformation.Controls.Add(this.tbCountry);
            this.gbAirlineInformation.Controls.Add(this.tbCallsign);
            this.gbAirlineInformation.Location = new System.Drawing.Point(16, 72);
            this.gbAirlineInformation.Name = "gbAirlineInformation";
            this.gbAirlineInformation.Size = new System.Drawing.Size(325, 139);
            this.gbAirlineInformation.TabIndex = 6;
            this.gbAirlineInformation.TabStop = false;
            this.gbAirlineInformation.Text = "Airline Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Company:";
            // 
            // tbCompany
            // 
            this.tbCompany.Enabled = false;
            this.tbCompany.Location = new System.Drawing.Point(64, 73);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(255, 20);
            this.tbCompany.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Country:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Callsign:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Airline ID:";
            // 
            // tbCountry
            // 
            this.tbCountry.Enabled = false;
            this.tbCountry.Location = new System.Drawing.Point(64, 99);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(255, 20);
            this.tbCountry.TabIndex = 12;
            // 
            // tbCallsign
            // 
            this.tbCallsign.Enabled = false;
            this.tbCallsign.Location = new System.Drawing.Point(64, 47);
            this.tbCallsign.Name = "tbCallsign";
            this.tbCallsign.Size = new System.Drawing.Size(255, 20);
            this.tbCallsign.TabIndex = 7;
            // 
            // frmCallSign
            // 
            this.AcceptButton = this.btnLookup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(344, 218);
            this.Controls.Add(this.gbAirlineInformation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.tbFlight);
            this.Controls.Add(this.label1);
            this.Name = "frmCallSign";
            this.Text = "Callsign Lookup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCallSign_FormClosing);
            this.Load += new System.EventHandler(this.frmCallSign_Load);
            this.gbAirlineInformation.ResumeLayout(false);
            this.gbAirlineInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFlight;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbAirlineID;
        private System.Windows.Forms.GroupBox gbAirlineInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.TextBox tbCallsign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}