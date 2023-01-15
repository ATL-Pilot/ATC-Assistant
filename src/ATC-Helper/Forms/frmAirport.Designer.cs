namespace ATC_Helper.Forms
{
    partial class frmAirport
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
            this.tbAirport = new System.Windows.Forms.TextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.gbAirlineInformation = new System.Windows.Forms.GroupBox();
            this.lblIsPseudo = new System.Windows.Forms.Label();
            this.cbIsPseudo = new System.Windows.Forms.CheckBox();
            this.cbSidRequired = new System.Windows.Forms.CheckBox();
            this.lblHasDeparturePlan = new System.Windows.Forms.Label();
            this.cbHasDeparturePlan = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSidRequired = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFir = new System.Windows.Forms.TextBox();
            this.tbAirportID = new System.Windows.Forms.TextBox();
            this.tbIataID = new System.Windows.Forms.TextBox();
            this.tbIcaoID = new System.Windows.Forms.TextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbAirlineInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Airport ID:";
            // 
            // tbAirport
            // 
            this.tbAirport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAirport.Location = new System.Drawing.Point(76, 29);
            this.tbAirport.Name = "tbAirport";
            this.tbAirport.Size = new System.Drawing.Size(100, 20);
            this.tbAirport.TabIndex = 1;
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
            // tbCountry
            // 
            this.tbCountry.Enabled = false;
            this.tbCountry.Location = new System.Drawing.Point(66, 153);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(249, 20);
            this.tbCountry.TabIndex = 5;
            // 
            // gbAirlineInformation
            // 
            this.gbAirlineInformation.Controls.Add(this.lblIsPseudo);
            this.gbAirlineInformation.Controls.Add(this.cbIsPseudo);
            this.gbAirlineInformation.Controls.Add(this.cbSidRequired);
            this.gbAirlineInformation.Controls.Add(this.lblHasDeparturePlan);
            this.gbAirlineInformation.Controls.Add(this.cbHasDeparturePlan);
            this.gbAirlineInformation.Controls.Add(this.label9);
            this.gbAirlineInformation.Controls.Add(this.lblSidRequired);
            this.gbAirlineInformation.Controls.Add(this.label7);
            this.gbAirlineInformation.Controls.Add(this.label6);
            this.gbAirlineInformation.Controls.Add(this.tbFir);
            this.gbAirlineInformation.Controls.Add(this.tbAirportID);
            this.gbAirlineInformation.Controls.Add(this.tbIataID);
            this.gbAirlineInformation.Controls.Add(this.tbIcaoID);
            this.gbAirlineInformation.Controls.Add(this.tbLocation);
            this.gbAirlineInformation.Controls.Add(this.label3);
            this.gbAirlineInformation.Controls.Add(this.tbName);
            this.gbAirlineInformation.Controls.Add(this.tbCountry);
            this.gbAirlineInformation.Controls.Add(this.label2);
            this.gbAirlineInformation.Controls.Add(this.label5);
            this.gbAirlineInformation.Controls.Add(this.label4);
            this.gbAirlineInformation.Enabled = false;
            this.gbAirlineInformation.Location = new System.Drawing.Point(16, 72);
            this.gbAirlineInformation.Name = "gbAirlineInformation";
            this.gbAirlineInformation.Size = new System.Drawing.Size(325, 264);
            this.gbAirlineInformation.TabIndex = 6;
            this.gbAirlineInformation.TabStop = false;
            this.gbAirlineInformation.Text = "Aircraft Information";
            // 
            // lblIsPseudo
            // 
            this.lblIsPseudo.AutoSize = true;
            this.lblIsPseudo.Location = new System.Drawing.Point(52, 239);
            this.lblIsPseudo.Name = "lblIsPseudo";
            this.lblIsPseudo.Size = new System.Drawing.Size(57, 13);
            this.lblIsPseudo.TabIndex = 34;
            this.lblIsPseudo.Text = "Is Pseudo:";
            this.lblIsPseudo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbIsPseudo
            // 
            this.cbIsPseudo.AutoSize = true;
            this.cbIsPseudo.Enabled = false;
            this.cbIsPseudo.Location = new System.Drawing.Point(115, 239);
            this.cbIsPseudo.Name = "cbIsPseudo";
            this.cbIsPseudo.Size = new System.Drawing.Size(15, 14);
            this.cbIsPseudo.TabIndex = 33;
            this.cbIsPseudo.UseVisualStyleBackColor = true;
            // 
            // cbSidRequired
            // 
            this.cbSidRequired.AutoSize = true;
            this.cbSidRequired.Enabled = false;
            this.cbSidRequired.Location = new System.Drawing.Point(230, 212);
            this.cbSidRequired.Name = "cbSidRequired";
            this.cbSidRequired.Size = new System.Drawing.Size(15, 14);
            this.cbSidRequired.TabIndex = 32;
            this.cbSidRequired.UseVisualStyleBackColor = true;
            // 
            // lblHasDeparturePlan
            // 
            this.lblHasDeparturePlan.AutoSize = true;
            this.lblHasDeparturePlan.Location = new System.Drawing.Point(6, 212);
            this.lblHasDeparturePlan.Name = "lblHasDeparturePlan";
            this.lblHasDeparturePlan.Size = new System.Drawing.Size(103, 13);
            this.lblHasDeparturePlan.TabIndex = 31;
            this.lblHasDeparturePlan.Text = "Has Departure Plan:";
            this.lblHasDeparturePlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbHasDeparturePlan
            // 
            this.cbHasDeparturePlan.AutoSize = true;
            this.cbHasDeparturePlan.Enabled = false;
            this.cbHasDeparturePlan.Location = new System.Drawing.Point(115, 212);
            this.cbHasDeparturePlan.Name = "cbHasDeparturePlan";
            this.cbHasDeparturePlan.Size = new System.Drawing.Size(15, 14);
            this.cbHasDeparturePlan.TabIndex = 30;
            this.cbHasDeparturePlan.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Country:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSidRequired
            // 
            this.lblSidRequired.AutoSize = true;
            this.lblSidRequired.Location = new System.Drawing.Point(150, 213);
            this.lblSidRequired.Name = "lblSidRequired";
            this.lblSidRequired.Size = new System.Drawing.Size(74, 13);
            this.lblSidRequired.TabIndex = 26;
            this.lblSidRequired.Text = "SID Required:";
            this.lblSidRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "FIR:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Name:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFir
            // 
            this.tbFir.Enabled = false;
            this.tbFir.Location = new System.Drawing.Point(66, 179);
            this.tbFir.Name = "tbFir";
            this.tbFir.Size = new System.Drawing.Size(250, 20);
            this.tbFir.TabIndex = 7;
            // 
            // tbAirportID
            // 
            this.tbAirportID.Enabled = false;
            this.tbAirportID.Location = new System.Drawing.Point(66, 23);
            this.tbAirportID.Name = "tbAirportID";
            this.tbAirportID.Size = new System.Drawing.Size(249, 20);
            this.tbAirportID.TabIndex = 23;
            // 
            // tbIataID
            // 
            this.tbIataID.Enabled = false;
            this.tbIataID.Location = new System.Drawing.Point(66, 49);
            this.tbIataID.Name = "tbIataID";
            this.tbIataID.Size = new System.Drawing.Size(249, 20);
            this.tbIataID.TabIndex = 22;
            // 
            // tbIcaoID
            // 
            this.tbIcaoID.Enabled = false;
            this.tbIcaoID.Location = new System.Drawing.Point(66, 75);
            this.tbIcaoID.Name = "tbIcaoID";
            this.tbIcaoID.Size = new System.Drawing.Size(249, 20);
            this.tbIcaoID.TabIndex = 21;
            // 
            // tbLocation
            // 
            this.tbLocation.Enabled = false;
            this.tbLocation.Location = new System.Drawing.Point(66, 101);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(249, 20);
            this.tbLocation.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "ICAO ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbName
            // 
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(66, 127);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(249, 20);
            this.tbName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Location:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "IATA ID:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Airport ID:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(169, 202);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 20);
            this.textBox1.TabIndex = 19;
            // 
            // frmAirport
            // 
            this.AcceptButton = this.btnLookup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(344, 343);
            this.Controls.Add(this.gbAirlineInformation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.tbAirport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "frmAirport";
            this.Text = "Airport Information Lookup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAirport_FormClosing);
            this.Load += new System.EventHandler(this.frmAirport_Load);
            this.gbAirlineInformation.ResumeLayout(false);
            this.gbAirlineInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAirport;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.GroupBox gbAirlineInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbFir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSidRequired;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAirportID;
        private System.Windows.Forms.TextBox tbIataID;
        private System.Windows.Forms.TextBox tbIcaoID;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblHasDeparturePlan;
        private System.Windows.Forms.CheckBox cbHasDeparturePlan;
        private System.Windows.Forms.CheckBox cbSidRequired;
        private System.Windows.Forms.CheckBox cbIsPseudo;
        private System.Windows.Forms.Label lblIsPseudo;
    }
}