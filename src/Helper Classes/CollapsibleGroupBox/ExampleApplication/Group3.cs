using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ExampleApplication
{
	/// <summary>
	/// Summary description for Group3.
	/// </summary>
	public class Group3 : UIToolbox.CollapsibleGroupBox
	{
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton8;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Group3()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 3;
			this.radioButton1.Text = "radioButton1";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(16, 48);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 4;
			this.radioButton2.Text = "radioButton2";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(16, 72);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.TabIndex = 5;
			this.radioButton3.Text = "radioButton3";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(16, 96);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.TabIndex = 6;
			this.radioButton4.Text = "radioButton4";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(16, 120);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.TabIndex = 7;
			this.radioButton5.Text = "radioButton5";
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(16, 144);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.TabIndex = 8;
			this.radioButton6.Text = "radioButton6";
			// 
			// radioButton7
			// 
			this.radioButton7.Location = new System.Drawing.Point(16, 168);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.TabIndex = 9;
			this.radioButton7.Text = "radioButton7";
			// 
			// radioButton8
			// 
			this.radioButton8.Location = new System.Drawing.Point(16, 192);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.TabIndex = 10;
			this.radioButton8.Text = "radioButton8";
			// 
			// Group3
			// 
			this.Caption = "";
			this.ContainsTrashCan = false;
			this.Controls.Add(this.radioButton8);
			this.Controls.Add(this.radioButton7);
			this.Controls.Add(this.radioButton6);
			this.Controls.Add(this.radioButton5);
			this.Controls.Add(this.radioButton4);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Name = "Group3";
			this.Size = new System.Drawing.Size(144, 224);
			this.Controls.SetChildIndex(this.radioButton1, 0);
			this.Controls.SetChildIndex(this.radioButton2, 0);
			this.Controls.SetChildIndex(this.radioButton3, 0);
			this.Controls.SetChildIndex(this.radioButton4, 0);
			this.Controls.SetChildIndex(this.radioButton5, 0);
			this.Controls.SetChildIndex(this.radioButton6, 0);
			this.Controls.SetChildIndex(this.radioButton7, 0);
			this.Controls.SetChildIndex(this.radioButton8, 0);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
