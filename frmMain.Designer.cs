﻿namespace Dashboard
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVerificareManuala = new System.Windows.Forms.Button();
            this.btnGolireLog = new System.Windows.Forms.Button();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnsettings = new System.Windows.Forms.Button();
            this.btnDashbord = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbltitle = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbCountClienti = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbSuma = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.timerRunTask = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.inchidereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnVerificareManuala);
            this.panel1.Controls.Add(this.btnGolireLog);
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnsettings);
            this.panel1.Controls.Add(this.btnDashbord);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 716);
            this.panel1.TabIndex = 0;
            // 
            // btnVerificareManuala
            // 
            this.btnVerificareManuala.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVerificareManuala.FlatAppearance.BorderSize = 0;
            this.btnVerificareManuala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificareManuala.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificareManuala.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnVerificareManuala.Image = global::PlinulCuBuletinul.Properties.Resources.check;
            this.btnVerificareManuala.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerificareManuala.Location = new System.Drawing.Point(0, 282);
            this.btnVerificareManuala.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerificareManuala.Name = "btnVerificareManuala";
            this.btnVerificareManuala.Size = new System.Drawing.Size(248, 46);
            this.btnVerificareManuala.TabIndex = 2;
            this.btnVerificareManuala.Text = "Verificare Manuala";
            this.btnVerificareManuala.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnVerificareManuala.UseVisualStyleBackColor = true;
            this.btnVerificareManuala.Click += new System.EventHandler(this.btnVerificareManuala_Click);
            // 
            // btnGolireLog
            // 
            this.btnGolireLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGolireLog.FlatAppearance.BorderSize = 0;
            this.btnGolireLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGolireLog.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGolireLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnGolireLog.Image = global::PlinulCuBuletinul.Properties.Resources.icons8_remove_25;
            this.btnGolireLog.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGolireLog.Location = new System.Drawing.Point(0, 236);
            this.btnGolireLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnGolireLog.Name = "btnGolireLog";
            this.btnGolireLog.Size = new System.Drawing.Size(248, 46);
            this.btnGolireLog.TabIndex = 3;
            this.btnGolireLog.Text = "Golire Log";
            this.btnGolireLog.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGolireLog.UseVisualStyleBackColor = true;
            this.btnGolireLog.Click += new System.EventHandler(this.btnGolireLog_Click);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 238);
            this.pnlNav.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(4, 123);
            this.pnlNav.TabIndex = 2;
            // 
            // btnsettings
            // 
            this.btnsettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnsettings.FlatAppearance.BorderSize = 0;
            this.btnsettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsettings.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnsettings.Image = global::PlinulCuBuletinul.Properties.Resources.settings;
            this.btnsettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsettings.Location = new System.Drawing.Point(0, 670);
            this.btnsettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnsettings.Name = "btnsettings";
            this.btnsettings.Size = new System.Drawing.Size(248, 46);
            this.btnsettings.TabIndex = 5;
            this.btnsettings.Text = "Setari";
            this.btnsettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnsettings.UseVisualStyleBackColor = true;
            this.btnsettings.Click += new System.EventHandler(this.btnsettings_Click);
            this.btnsettings.Leave += new System.EventHandler(this.btnsettings_Leave);
            // 
            // btnDashbord
            // 
            this.btnDashbord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashbord.FlatAppearance.BorderSize = 0;
            this.btnDashbord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashbord.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashbord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDashbord.Image = global::PlinulCuBuletinul.Properties.Resources.home;
            this.btnDashbord.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDashbord.Location = new System.Drawing.Point(0, 190);
            this.btnDashbord.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashbord.Name = "btnDashbord";
            this.btnDashbord.Size = new System.Drawing.Size(248, 46);
            this.btnDashbord.TabIndex = 1;
            this.btnDashbord.Text = "Acasa";
            this.btnDashbord.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDashbord.UseVisualStyleBackColor = true;
            this.btnDashbord.Click += new System.EventHandler(this.btnDashbord_Click);
            this.btnDashbord.Leave += new System.EventHandler(this.btnDashbord_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 190);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PlinulCuBuletinul.Properties.Resources.Untitled_11;
            this.pictureBox1.Location = new System.Drawing.Point(91, 51);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1172, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(263, 28);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(309, 39);
            this.lbltitle.TabIndex = 10;
            this.lbltitle.Text = "Plinul cu Buletinul";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel7.Controls.Add(this.rtLog);
            this.panel7.Location = new System.Drawing.Point(270, 301);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(929, 367);
            this.panel7.TabIndex = 14;
            // 
            // rtLog
            // 
            this.rtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.rtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtLog.ForeColor = System.Drawing.SystemColors.Window;
            this.rtLog.Location = new System.Drawing.Point(0, 4);
            this.rtLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtLog.Name = "rtLog";
            this.rtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtLog.Size = new System.Drawing.Size(921, 359);
            this.rtLog.TabIndex = 1;
            this.rtLog.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(264, 262);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 32);
            this.label14.TabIndex = 0;
            this.label14.Text = "Log";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.lbCountClienti);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(725, 98);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(389, 160);
            this.panel5.TabIndex = 17;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PlinulCuBuletinul.Properties.Resources.downloads;
            this.pictureBox3.Location = new System.Drawing.Point(213, 27);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(89, 82);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // lbCountClienti
            // 
            this.lbCountClienti.AutoSize = true;
            this.lbCountClienti.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountClienti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(226)))), ((int)(((byte)(178)))));
            this.lbCountClienti.Location = new System.Drawing.Point(23, 70);
            this.lbCountClienti.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCountClienti.Name = "lbCountClienti";
            this.lbCountClienti.Size = new System.Drawing.Size(37, 39);
            this.lbCountClienti.TabIndex = 1;
            this.lbCountClienti.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(24, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 32);
            this.label9.TabIndex = 0;
            this.label9.Text = "Total Aplicari";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.lbSuma);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(275, 98);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(389, 160);
            this.panel4.TabIndex = 18;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PlinulCuBuletinul.Properties.Resources.money_bag;
            this.pictureBox2.Location = new System.Drawing.Point(229, 27);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(85, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lbSuma
            // 
            this.lbSuma.AutoSize = true;
            this.lbSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSuma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lbSuma.Location = new System.Drawing.Point(23, 70);
            this.lbSuma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSuma.Name = "lbSuma";
            this.lbSuma.Size = new System.Drawing.Size(101, 39);
            this.lbSuma.TabIndex = 1;
            this.lbSuma.Text = "LEI 0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(24, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Sume";
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1145, 28);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(33, 31);
            this.btnMinimize.TabIndex = 19;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Visible = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inchidereToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(211, 56);
            // 
            // inchidereToolStripMenuItem
            // 
            this.inchidereToolStripMenuItem.Name = "inchidereToolStripMenuItem";
            this.inchidereToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.inchidereToolStripMenuItem.Text = "Inchidere";
            this.inchidereToolStripMenuItem.Click += new System.EventHandler(this.inchidereToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1225, 716);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plinul cu Buletinul";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDashbord;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnsettings;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbCountClienti;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbSuma;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RichTextBox rtLog;
		private System.Windows.Forms.Button btnMinimize;
		private System.Windows.Forms.Timer timerRunTask;
		private System.Windows.Forms.Button btnGolireLog;
		private System.Windows.Forms.Button btnVerificareManuala;
		private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem inchidereToolStripMenuItem;
    }
}

