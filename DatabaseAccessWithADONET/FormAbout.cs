using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DatabaseAccessWithADONET
{
	/// <summary>
	/// Summary description for FormAbout.
	/// </summary>
	public class FormAbout : System.Windows.Forms.Form
	{
	  private System.Windows.Forms.Label label1;
	  private System.Windows.Forms.Button pbtOK;
	  private System.Windows.Forms.Label label3;
	  private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAbout()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		  System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAbout));
		  this.label1 = new System.Windows.Forms.Label();
		  this.pbtOK = new System.Windows.Forms.Button();
		  this.label3 = new System.Windows.Forms.Label();
		  this.pictureBox1 = new System.Windows.Forms.PictureBox();
		  this.SuspendLayout();
		  // 
		  // label1
		  // 
		  this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		  this.label1.Location = new System.Drawing.Point(72, 16);
		  this.label1.Name = "label1";
		  this.label1.Size = new System.Drawing.Size(136, 16);
		  this.label1.TabIndex = 1;
		  this.label1.Text = "Using ADO.NET Database 1";
		  // 
		  // pbtOK
		  // 
		  this.pbtOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
		  this.pbtOK.Location = new System.Drawing.Point(144, 64);
		  this.pbtOK.Name = "pbtOK";
		  this.pbtOK.Size = new System.Drawing.Size(48, 23);
		  this.pbtOK.TabIndex = 3;
		  this.pbtOK.Text = "OK";
		  this.pbtOK.Click += new System.EventHandler(this.pbtOK_Click);
		  // 
		  // label3
		  // 
		  this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		  this.label3.Location = new System.Drawing.Point(72, 32);
		  this.label3.Name = "label3";
		  this.label3.Size = new System.Drawing.Size(144, 32);
		  this.label3.TabIndex = 5;
		  this.label3.Text = "This application was developed by Hüseyin Altindag  2004";
		  // 
		  // pictureBox1
		  // 
		  this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
		  this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		  this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
		  this.pictureBox1.Location = new System.Drawing.Point(8, 8);
		  this.pictureBox1.Name = "pictureBox1";
		  this.pictureBox1.Size = new System.Drawing.Size(64, 80);
		  this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
		  this.pictureBox1.TabIndex = 6;
		  this.pictureBox1.TabStop = false;
		  // 
		  // FormAbout
		  // 
		  this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		  this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(255)));
		  this.ClientSize = new System.Drawing.Size(206, 97);
		  this.Controls.Add(this.pictureBox1);
		  this.Controls.Add(this.label3);
		  this.Controls.Add(this.pbtOK);
		  this.Controls.Add(this.label1);
		  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		  this.MaximizeBox = false;
		  this.MinimizeBox = false;
		  this.Name = "FormAbout";
		  this.Text = "About Form";
		  this.ResumeLayout(false);

		}
		#endregion

	  private void pbtOK_Click(object sender, System.EventArgs e)
	  {
		  this.Close();
	  }	  
	 
	}
}
