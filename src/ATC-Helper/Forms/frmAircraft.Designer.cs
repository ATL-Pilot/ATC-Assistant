namespace ATC_Helper.Forms
{
    partial class frmAircraft
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
            this.tbAcType = new System.Windows.Forms.TextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbSimplifiedEngineType = new System.Windows.Forms.TextBox();
            this.gbAirlineInformation = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbIsHeavy = new System.Windows.Forms.CheckBox();
            this.tbEngineType = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbWakeTurbulence = new System.Windows.Forms.TextBox();
            this.tbAircraftID = new System.Windows.Forms.TextBox();
            this.tbManufacturer = new System.Windows.Forms.TextBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tbTypeDesignator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEngineCount = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbAirlineInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aircraft Type:";
            // 
            // tbAcType
            // 
            this.tbAcType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAcType.Location = new System.Drawing.Point(89, 10);
            this.tbAcType.Name = "tbAcType";
            this.tbAcType.Size = new System.Drawing.Size(100, 20);
            this.tbAcType.TabIndex = 1;
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
            // tbSimplifiedEngineType
            // 
            this.tbSimplifiedEngineType.Enabled = false;
            this.tbSimplifiedEngineType.Location = new System.Drawing.Point(102, 179);
            this.tbSimplifiedEngineType.Name = "tbSimplifiedEngineType";
            this.tbSimplifiedEngineType.Size = new System.Drawing.Size(213, 20);
            this.tbSimplifiedEngineType.TabIndex = 5;
            // 
            // gbAirlineInformation
            // 
            this.gbAirlineInformation.Controls.Add(this.label11);
            this.gbAirlineInformation.Controls.Add(this.cbIsHeavy);
            this.gbAirlineInformation.Controls.Add(this.tbEngineType);
            this.gbAirlineInformation.Controls.Add(this.label10);
            this.gbAirlineInformation.Controls.Add(this.label9);
            this.gbAirlineInformation.Controls.Add(this.label8);
            this.gbAirlineInformation.Controls.Add(this.label7);
            this.gbAirlineInformation.Controls.Add(this.label6);
            this.gbAirlineInformation.Controls.Add(this.tbWakeTurbulence);
            this.gbAirlineInformation.Controls.Add(this.tbAircraftID);
            this.gbAirlineInformation.Controls.Add(this.tbManufacturer);
            this.gbAirlineInformation.Controls.Add(this.tbModel);
            this.gbAirlineInformation.Controls.Add(this.tbTypeDesignator);
            this.gbAirlineInformation.Controls.Add(this.label3);
            this.gbAirlineInformation.Controls.Add(this.tbDescription);
            this.gbAirlineInformation.Controls.Add(this.tbSimplifiedEngineType);
            this.gbAirlineInformation.Controls.Add(this.label2);
            this.gbAirlineInformation.Controls.Add(this.label5);
            this.gbAirlineInformation.Controls.Add(this.label4);
            this.gbAirlineInformation.Controls.Add(this.tbEngineCount);
            this.gbAirlineInformation.Location = new System.Drawing.Point(16, 72);
            this.gbAirlineInformation.Name = "gbAirlineInformation";
            this.gbAirlineInformation.Size = new System.Drawing.Size(325, 298);
            this.gbAirlineInformation.TabIndex = 6;
            this.gbAirlineInformation.TabStop = false;
            this.gbAirlineInformation.Text = "Aircraft Information";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Is Heavy";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbIsHeavy
            // 
            this.cbIsHeavy.AutoSize = true;
            this.cbIsHeavy.Enabled = false;
            this.cbIsHeavy.Location = new System.Drawing.Point(102, 267);
            this.cbIsHeavy.Name = "cbIsHeavy";
            this.cbIsHeavy.Size = new System.Drawing.Size(15, 14);
            this.cbIsHeavy.TabIndex = 30;
            this.cbIsHeavy.UseVisualStyleBackColor = true;
            // 
            // tbEngineType
            // 
            this.tbEngineType.Enabled = false;
            this.tbEngineType.Location = new System.Drawing.Point(102, 153);
            this.tbEngineType.Name = "tbEngineType";
            this.tbEngineType.Size = new System.Drawing.Size(213, 20);
            this.tbEngineType.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Engine Type:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 26);
            this.label9.TabIndex = 27;
            this.label9.Text = "Simplified Engine \r\nType:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Engine Count:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Wake Turbulence:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Description:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbWakeTurbulence
            // 
            this.tbWakeTurbulence.Enabled = false;
            this.tbWakeTurbulence.Location = new System.Drawing.Point(102, 240);
            this.tbWakeTurbulence.Name = "tbWakeTurbulence";
            this.tbWakeTurbulence.Size = new System.Drawing.Size(213, 20);
            this.tbWakeTurbulence.TabIndex = 7;
            // 
            // tbAircraftID
            // 
            this.tbAircraftID.Enabled = false;
            this.tbAircraftID.Location = new System.Drawing.Point(102, 23);
            this.tbAircraftID.Name = "tbAircraftID";
            this.tbAircraftID.Size = new System.Drawing.Size(213, 20);
            this.tbAircraftID.TabIndex = 23;
            // 
            // tbManufacturer
            // 
            this.tbManufacturer.Enabled = false;
            this.tbManufacturer.Location = new System.Drawing.Point(102, 49);
            this.tbManufacturer.Name = "tbManufacturer";
            this.tbManufacturer.Size = new System.Drawing.Size(213, 20);
            this.tbManufacturer.TabIndex = 22;
            // 
            // tbModel
            // 
            this.tbModel.Enabled = false;
            this.tbModel.Location = new System.Drawing.Point(102, 75);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(213, 20);
            this.tbModel.TabIndex = 21;
            // 
            // tbTypeDesignator
            // 
            this.tbTypeDesignator.Enabled = false;
            this.tbTypeDesignator.Location = new System.Drawing.Point(102, 101);
            this.tbTypeDesignator.Name = "tbTypeDesignator";
            this.tbTypeDesignator.Size = new System.Drawing.Size(213, 20);
            this.tbTypeDesignator.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Model:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDescription
            // 
            this.tbDescription.Enabled = false;
            this.tbDescription.Location = new System.Drawing.Point(102, 127);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(213, 20);
            this.tbDescription.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Type Designator:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Manufacturer:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Aircraft ID:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbEngineCount
            // 
            this.tbEngineCount.Enabled = false;
            this.tbEngineCount.Location = new System.Drawing.Point(102, 214);
            this.tbEngineCount.Name = "tbEngineCount";
            this.tbEngineCount.Size = new System.Drawing.Size(213, 20);
            this.tbEngineCount.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(169, 202);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 20);
            this.textBox1.TabIndex = 19;
            // 
            // frmAircraft
            // 
            this.AcceptButton = this.btnLookup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(344, 378);
            this.Controls.Add(this.gbAirlineInformation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.tbAcType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "frmAircraft";
            this.Text = "Aircraft Information Lookup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCallSign_FormClosing);
            this.Load += new System.EventHandler(this.frmAircraft_Load);
            this.gbAirlineInformation.ResumeLayout(false);
            this.gbAirlineInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAcType;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbSimplifiedEngineType;
        private System.Windows.Forms.GroupBox gbAirlineInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbEngineCount;
        private System.Windows.Forms.TextBox tbWakeTurbulence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAircraftID;
        private System.Windows.Forms.TextBox tbManufacturer;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.TextBox tbTypeDesignator;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbIsHeavy;
        private System.Windows.Forms.TextBox tbEngineType;
    }
}