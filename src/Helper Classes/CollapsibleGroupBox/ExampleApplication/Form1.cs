using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ExampleApplication
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private UIToolbox.CollapseBox collapseBox1;
		private UIToolbox.CollapsibleGroupBox collapsibleGroupBox1;
		private UIToolbox.ExpandingPanel expandingPanel1;
		private UIToolbox.ImageButton imageButton1;
		private ExampleApplication.Group1 group11;
		private ExampleApplication.Group2 group21;
		private ExampleApplication.Group3 group31;
		private ExampleApplication.Group4 group41;
		private UIToolbox.ExpandingPanel expandingPanel2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			expandingPanel1.AddGroup(new Group1());


			//expandingPanel1.AddGroup(new Group2());
			Group2 group2 = new Group2();
			group2.IsCollapsed = true;
			expandingPanel1.AddGroup(group2);

			
			expandingPanel1.AddGroup(new Group3());
			expandingPanel1.AddGroup(new Group4());
			expandingPanel1.AddGroup(new Group1());

			expandingPanel2.AddGroup(new Group1());
			expandingPanel2.AddGroup(new Group2());
			expandingPanel2.AddGroup(new Group3());
			expandingPanel2.AddGroup(new Group4());
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.collapseBox1 = new UIToolbox.CollapseBox();
			this.collapsibleGroupBox1 = new UIToolbox.CollapsibleGroupBox();
			this.expandingPanel1 = new UIToolbox.ExpandingPanel();
			this.imageButton1 = new UIToolbox.ImageButton();
			this.group11 = new ExampleApplication.Group1();
			this.group21 = new ExampleApplication.Group2();
			this.group31 = new ExampleApplication.Group3();
			this.group41 = new ExampleApplication.Group4();
			this.expandingPanel2 = new UIToolbox.ExpandingPanel();
			this.SuspendLayout();
			// 
			// collapseBox1
			// 
			this.collapseBox1.Location = new System.Drawing.Point(32, 16);
			this.collapseBox1.Name = "collapseBox1";
			this.collapseBox1.Size = new System.Drawing.Size(24, 24);
			this.collapseBox1.TabIndex = 0;
			this.collapseBox1.Text = "collapseBox1";
			// 
			// collapsibleGroupBox1
			// 
			this.collapsibleGroupBox1.Caption = null;
			this.collapsibleGroupBox1.Location = new System.Drawing.Point(24, 112);
			this.collapsibleGroupBox1.Name = "collapsibleGroupBox1";
			this.collapsibleGroupBox1.Size = new System.Drawing.Size(128, 72);
			this.collapsibleGroupBox1.TabIndex = 1;
			// 
			// expandingPanel1
			// 
			this.expandingPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.expandingPanel1.Location = new System.Drawing.Point(392, 24);
			this.expandingPanel1.Name = "expandingPanel1";
			this.expandingPanel1.Size = new System.Drawing.Size(192, 184);
			this.expandingPanel1.TabIndex = 2;
			// 
			// imageButton1
			// 
			this.imageButton1.Location = new System.Drawing.Point(40, 64);
			this.imageButton1.Name = "imageButton1";
			this.imageButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("imageButton1.NormalImage")));
			this.imageButton1.PressedImage = ((System.Drawing.Image)(resources.GetObject("imageButton1.PressedImage")));
			this.imageButton1.Size = new System.Drawing.Size(16, 16);
			this.imageButton1.TabIndex = 3;
			this.imageButton1.Text = "imageButton1";
			// 
			// group11
			// 
			this.group11.Caption = null;
			this.group11.Location = new System.Drawing.Point(24, 256);
			this.group11.Name = "group11";
			this.group11.Size = new System.Drawing.Size(136, 64);
			this.group11.TabIndex = 4;
			// 
			// group21
			// 
			this.group21.Caption = "2nd Group";
			this.group21.Location = new System.Drawing.Point(24, 344);
			this.group21.Name = "group21";
			this.group21.Size = new System.Drawing.Size(144, 104);
			this.group21.TabIndex = 5;
			// 
			// group31
			// 
			this.group31.ContainsTrashCan = false;
			this.group31.Location = new System.Drawing.Point(184, 16);
			this.group31.Name = "group31";
			this.group31.Size = new System.Drawing.Size(144, 224);
			this.group31.TabIndex = 1;
			// 
			// group41
			// 
			this.group41.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.group41.Caption = "Dual";
			this.group41.ContainsTrashCan = false;
			this.group41.Location = new System.Drawing.Point(184, 256);
			this.group41.Name = "group41";
			this.group41.Size = new System.Drawing.Size(160, 192);
			this.group41.TabIndex = 0;
			// 
			// expandingPanel2
			// 
			this.expandingPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.expandingPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.expandingPanel2.Location = new System.Drawing.Point(392, 224);
			this.expandingPanel2.Name = "expandingPanel2";
			this.expandingPanel2.Size = new System.Drawing.Size(192, 184);
			this.expandingPanel2.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 454);
			this.Controls.Add(this.expandingPanel2);
			this.Controls.Add(this.group41);
			this.Controls.Add(this.group31);
			this.Controls.Add(this.group21);
			this.Controls.Add(this.group11);
			this.Controls.Add(this.imageButton1);
			this.Controls.Add(this.expandingPanel1);
			this.Controls.Add(this.collapsibleGroupBox1);
			this.Controls.Add(this.collapseBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
