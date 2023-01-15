using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ExampleApplication
{
	/// <summary>
	/// Summary description for Group2.
	/// </summary>
	public class Group2 : UIToolbox.CollapsibleGroupBox
	{
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Group2()
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
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(16, 24);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "checkBox1";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(16, 48);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.TabIndex = 4;
			this.checkBox2.Text = "checkBox2";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(16, 72);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.TabIndex = 5;
			this.checkBox3.Text = "checkBox3";
			// 
			// Group2
			// 
			this.Caption = "2nd Group";
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Name = "Group2";
			this.Size = new System.Drawing.Size(144, 104);
			this.Controls.SetChildIndex(this.checkBox1, 0);
			this.Controls.SetChildIndex(this.checkBox2, 0);
			this.Controls.SetChildIndex(this.checkBox3, 0);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
