using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SearchTest
{
	/// <summary>
	/// Summary description for RecordLimits.
	/// </summary>
	public class RecordLimits : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.NumericUpDown txtCount;
		private System.Windows.Forms.Label lblStartRecord;
		internal System.Windows.Forms.NumericUpDown txtStartAt;
		private System.Windows.Forms.Label lblNumRecsReturned;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RecordLimits()
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
			this.lblNumRecsReturned = new System.Windows.Forms.Label();
			this.txtCount = new System.Windows.Forms.NumericUpDown();
			this.lblStartRecord = new System.Windows.Forms.Label();
			this.txtStartAt = new System.Windows.Forms.NumericUpDown();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.txtCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStartAt)).BeginInit();
			this.SuspendLayout();
			// 
			// lblNumRecsReturned
			// 
			this.lblNumRecsReturned.Location = new System.Drawing.Point(0, 32);
			this.lblNumRecsReturned.Name = "lblNumRecsReturned";
			this.lblNumRecsReturned.Size = new System.Drawing.Size(184, 24);
			this.lblNumRecsReturned.TabIndex = 6;
			this.lblNumRecsReturned.Text = "Max Number of Records Returned:";
			this.lblNumRecsReturned.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCount
			// 
			this.txtCount.Location = new System.Drawing.Point(184, 32);
			this.txtCount.Maximum = new System.Decimal(new int[] {
																	 500000,
																	 0,
																	 0,
																	 0});
			this.txtCount.Minimum = new System.Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
			this.txtCount.Name = "txtCount";
			this.txtCount.Size = new System.Drawing.Size(72, 20);
			this.txtCount.TabIndex = 7;
			this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCount.Value = new System.Decimal(new int[] {
																   1000,
																   0,
																   0,
																   0});
			// 
			// lblStartRecord
			// 
			this.lblStartRecord.Location = new System.Drawing.Point(0, 8);
			this.lblStartRecord.Name = "lblStartRecord";
			this.lblStartRecord.Size = new System.Drawing.Size(184, 24);
			this.lblStartRecord.TabIndex = 4;
			this.lblStartRecord.Text = "Start Record:";
			this.lblStartRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtStartAt
			// 
			this.txtStartAt.Location = new System.Drawing.Point(184, 8);
			this.txtStartAt.Maximum = new System.Decimal(new int[] {
																	   500000,
																	   0,
																	   0,
																	   0});
			this.txtStartAt.Minimum = new System.Decimal(new int[] {
																	   1,
																	   0,
																	   0,
																	   0});
			this.txtStartAt.Name = "txtStartAt";
			this.txtStartAt.Size = new System.Drawing.Size(72, 20);
			this.txtStartAt.TabIndex = 5;
			this.txtStartAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtStartAt.Value = new System.Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(56, 64);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(136, 64);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			// 
			// RecordLimits
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(266, 96);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblNumRecsReturned);
			this.Controls.Add(this.txtCount);
			this.Controls.Add(this.lblStartRecord);
			this.Controls.Add(this.txtStartAt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RecordLimits";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Record Limits";
			((System.ComponentModel.ISupportInitialize)(this.txtCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStartAt)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
