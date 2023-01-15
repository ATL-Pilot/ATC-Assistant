using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ExampleApplication
{
	/// <summary>
	/// Summary description for Group1.
	/// </summary>
	public class Group1 : UIToolbox.CollapsibleGroupBox
	{
		private System.Windows.Forms.Button button1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Group1()
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(48, 32);
			this.button1.Name = "button1";
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			// 
			// Group1
			// 
			this.Controls.Add(this.button1);
			this.Name = "Group1";
			this.Size = new System.Drawing.Size(136, 64);
			this.Controls.SetChildIndex(this.button1, 0);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
