namespace PlinulCuBuletinul
{
	partial class frmInputDate
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			this.btnExit = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lbltitle = new System.Windows.Forms.Label();
			this.dtDataInceput = new System.Windows.Forms.DateTimePicker();
			this.dtDataSfarsit = new System.Windows.Forms.DateTimePicker();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnExit
			// 
			this.btnExit.FlatAppearance.BorderSize = 0;
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.ForeColor = System.Drawing.Color.White;
			this.btnExit.Location = new System.Drawing.Point(569, 23);
			this.btnExit.Margin = new System.Windows.Forms.Padding(4);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(33, 31);
			this.btnExit.TabIndex = 14;
			this.btnExit.Text = "X";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnOk.FlatAppearance.BorderSize = 0;
			this.btnOk.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
			this.btnOk.Image = global::PlinulCuBuletinul.Properties.Resources.symbol_check_icon;
			this.btnOk.Location = new System.Drawing.Point(511, 288);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(90, 36);
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "Ok";
			this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(146, 139);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			label1.Size = new System.Drawing.Size(123, 28);
			label1.TabIndex = 23;
			label1.Text = "Data Inceput";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(157, 195);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			label2.Size = new System.Drawing.Size(112, 28);
			label2.TabIndex = 24;
			label2.Text = "Data Sfarsit";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbltitle
			// 
			this.lbltitle.AutoSize = true;
			this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
			this.lbltitle.Location = new System.Drawing.Point(13, 23);
			this.lbltitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbltitle.Name = "lbltitle";
			this.lbltitle.Size = new System.Drawing.Size(260, 39);
			this.lbltitle.TabIndex = 25;
			this.lbltitle.Text = "Selectare Date";
			// 
			// dtDataInceput
			// 
			this.dtDataInceput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtDataInceput.Location = new System.Drawing.Point(276, 144);
			this.dtDataInceput.Name = "dtDataInceput";
			this.dtDataInceput.Size = new System.Drawing.Size(200, 22);
			this.dtDataInceput.TabIndex = 26;
			// 
			// dtDataSfarsit
			// 
			this.dtDataSfarsit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtDataSfarsit.Location = new System.Drawing.Point(276, 201);
			this.dtDataSfarsit.Name = "dtDataSfarsit";
			this.dtDataSfarsit.Size = new System.Drawing.Size(200, 22);
			this.dtDataSfarsit.TabIndex = 27;
			// 
			// frmInputDate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
			this.ClientSize = new System.Drawing.Size(614, 337);
			this.Controls.Add(this.dtDataSfarsit);
			this.Controls.Add(this.dtDataInceput);
			this.Controls.Add(this.lbltitle);
			this.Controls.Add(label2);
			this.Controls.Add(label1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnExit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmInputDate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmInputDate";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lbltitle;
		private System.Windows.Forms.DateTimePicker dtDataInceput;
		private System.Windows.Forms.DateTimePicker dtDataSfarsit;
	}
}