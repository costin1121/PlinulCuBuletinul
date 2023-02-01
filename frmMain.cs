﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PlinulCuBuletinul;
using Microsoft.Win32;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Threading;

namespace Dashboard
{
    public partial class frmMain : Form
    {
		static System.Timers.Timer timer;
		internal static frmMain main;
		internal string Log
		{
			get { return rtLog.Text.ToString(); }
			set { rtLog.AppendText(value); }
		}
		internal string UpdateClienti { 
			get 
			{ 
				return lbCountClienti.Text; 
			}
			set 
			{
				lbCountClienti.Text = value;
				lbCountClienti.Refresh();
				lbCountClienti.Update();
			} 
		}
		internal string UpdateSuma
		{
			get
			{
				return lbSuma.Text;
			}
			set
			{
				lbSuma.Text = value;
				lbSuma.Refresh();
				lbSuma.Update();

			}
		}
        public static string url_site;
        public static string consumer_key;
        public static string consumer_secret;
		public static string username_mol;
		public static string password_mol;
		public static string url_mol;
		public static string serieCard;
		public static string numarCard;
		
		private bool mouseDown;
		private Point lastLocation;

		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );

        public frmMain()
        {
            InitializeComponent();
			main = this;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashbord.Height;
            pnlNav.Top = btnDashbord.Top;
            pnlNav.Left = btnDashbord.Left;
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);
			CheckForIllegalCrossThreadCalls = false;
		}

		private static void RunTask(Object source, System.Timers.ElapsedEventArgs e)
		{
			int lastComandaID = LastComanda.GetLastIndexComandaID();
            wooCommerce wc = new wooCommerce(url_site,consumer_key, consumer_secret, username_mol ,password_mol, url_mol, lastComandaID, numarCard, serieCard);
			wc.getOrders();

		}
		public void UpdateClientiLabel()
		{
			lbCountClienti.Text = Clienti.GetCountClienti().ToString();
			lbCountClienti.Update();
		}

		public void UpdateClientiSuma()
		{
			lbSuma.Text = "LEI " + Clienti.GetSumaClienti().ToString();
			lbSuma.Update();
		}


		private void btnDashbord_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashbord.Height;
            pnlNav.Top = btnDashbord.Top;
            pnlNav.Left = btnDashbord.Left;
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);
        }


        private void btnsettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnsettings.Height;
            pnlNav.Top = btnsettings.Top;
            btnsettings.BackColor = Color.FromArgb(46, 51, 73);

            frmOptions optionsForm = new frmOptions();
            optionsForm.Show();
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        private void btnDashbord_Leave(object sender, EventArgs e)
        {
            btnDashbord.BackColor = Color.FromArgb(24, 30, 54);
        }



        private void btnsettings_Leave(object sender, EventArgs e)
        {
            btnsettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Aplicatia a fost pornita!" + "\r\n";
            url_site = GetUrlSite();
            consumer_key= GetConsumerKey();
            consumer_secret = GetConsumerSecret();
            username_mol = GetUsernameMol(); 
			password_mol = GetPasswordMol();
			url_mol	 = GetURLMol();
			int intervalVerificare = GetIntervalValue();
			serieCard = GetSerieCard();

			NumarGenerator ng = new NumarGenerator(numarCard);
			numarCard =  ng.GetLastNrCard();
			if (intervalVerificare < 2)
            {
				this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Intervalul de verificare este incorect!" + "\r\n";

			} 
            else if(url_site == "")
            {
				this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "URL-ul site-ului este null" + "\r\n";
			} 
            else if (consumer_key == "")
            {
				this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Consumer Key este null" + "\r\n";
			}
            else if (consumer_secret == "")
            {
				this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Consumer Secret este null" + "\r\n";
            }
			else if (username_mol == "")
			{
				this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Username-ul de utilizator Mol este null" + "\r\n";
			}
			else if(password_mol == "")
			{
				this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Parola de utilizator Mol este null" + "\r\n";
			}
			else if (url_mol == "")
			{
				this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "URL-ul Mol este null" + "\r\n";
			}
			else if (numarCard == "")
			{
				this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Numarul de card Mol este null" + "\r\n";

			}
			else if (serieCard == "")
			{
				this.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Seria de card Mol este nula" + "\r\n";

			}
			else
            {
                initTimer(intervalVerificare);
				UpdateClientiLabel();
				UpdateClientiSuma();
			}

		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
            this.WindowState= FormWindowState.Minimized;
		}
        private int GetIntervalValue() { 
        
            int intervalVerificare = 0;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
            string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
            if (key != null)
            {
				if (Registry.GetValue(keyName, "interval_trimitere", null) != null)
				{
					intervalVerificare = Convert.ToInt32(key.GetValue("interval_trimitere"));
				}
				key.Close();

			}
			return intervalVerificare;
        }

		public static int GetNextIntervalValue()
		{

			int intervalVerificare = 0;
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
			if (key != null)
			{
				if (Registry.GetValue(keyName, "interval_trimitere", null) != null)
				{
					intervalVerificare = Convert.ToInt32(key.GetValue("interval_trimitere"));
				}
				key.Close();
			}
			return intervalVerificare;
		}

		private string GetUrlSite()
        {
            string url_site = "";
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
			if (key != null)
			{
				if (Registry.GetValue(keyName, "url_site", null) != null)
				{
                    url_site = key.GetValue("url_site").ToString();
				}
				key.Close();
			}
			return url_site;
		}

        private string GetConsumerKey()
        {
			string consumer_key = "";
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
			if (key != null)
			{
				if (Registry.GetValue(keyName, "consumer_key", null) != null)
				{
					consumer_key = key.GetValue("consumer_key").ToString();
				}
				key.Close();
			}
			return consumer_key;
		}

		private string GetConsumerSecret()
		{
			string consumer_value = "";
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
			if (key != null)
			{
				if (Registry.GetValue(keyName, "consumer_secret", null) != null)
				{
					consumer_value = key.GetValue("consumer_secret").ToString();
				}
				key.Close();
			}
            
			return consumer_value;
		}

		private string GetUsernameMol()
		{
			string username = "";
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
			if (key != null)
			{
				if (Registry.GetValue(keyName, "username_mol", null) != null)
				{
					username = key.GetValue("username_mol").ToString();
				}
				key.Close();
			}
			return username;
		}

		private string GetPasswordMol()
		{
			string password = "";
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
			if (key != null)
			{
				if (Registry.GetValue(keyName, "password_mol", null) != null)
				{
					password = key.GetValue("password_mol").ToString();
				}
				key.Close();
			}
			return password;
		}

		private string GetURLMol()
		{
			string url = "";
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
			if (key != null)
			{
				if (Registry.GetValue(keyName, "url_mol", null) != null)
				{
					url = key.GetValue("url_mol").ToString();
				}
				key.Close();
			}
			return url;
		}

		private string GetSerieCard()
		{
			string serie_card = "";
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
			if (key != null)
			{
				if (Registry.GetValue(keyName, "serie_card", null) != null)
				{
					serie_card = key.GetValue("serie_card").ToString();
				}
				key.Close();
			}
			
			return serie_card;
		}


		public static void initTimer(int intervalVerificare)
		{
            timer = new Timer(intervalVerificare);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(RunTask);
			int interval = (intervalVerificare * 60) * 1000;
			timer.Interval = interval; //timer interval in mili seconds;
			DateTime newDate = DateTime.Now.AddMinutes(intervalVerificare);
			main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Urmatoarea verificare este la data:" + newDate.ToString("dd/MM/yyyy hh:mm:ss") + "\r\n";
			
			timer.Start();
			// de pus si in run task log la final
		}

		private void btnGolireLog_Click(object sender, EventArgs e)
		{
			rtLog.Clear();
		}

		private void btnVerificareManuala_Click(object sender, EventArgs e)
		{
			frmInputDate inputDate= new frmInputDate();
			if (timer != null)
			{
				timer.Stop();
				timer.Dispose();
			}

			inputDate.ShowDialog();
			if(inputDate.DialogResult == DialogResult.OK)
			{
				int interval_verificare = GetIntervalValue();
				if (interval_verificare > 0)
				{
					DateTime dataInceput = inputDate.dataInceput;
					DateTime dataSfarsit = inputDate.dataSfarsit;
					main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Inceput generare carduri manual..." + "\r\n";

					int lastComandaID = LastComanda.GetLastIndexComandaID();
					wooCommerce wc = new wooCommerce(url_site, consumer_key, consumer_secret, username_mol, password_mol, url_mol, lastComandaID, numarCard, serieCard);
					wc.getOrderByDate(dataInceput, dataSfarsit);




					//timer.Start();
					initTimer(interval_verificare);
					//DateTime newDate = DateTime.Now.AddMinutes(interval_verificare);
					//main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Urmatoarea verificare este la data:" + newDate.ToString("dd/MM/yyyy hh:mm:ss") + "\r\n";
				}
				else
				{
					main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Intervalul de verificare nu este setat!" + "\r\n";

				}
			}
		}

		private void frmMain_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDown = true;
			lastLocation = e.Location;
		}

		private void frmMain_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				this.Location = new Point(
					(this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

				this.Update();
			}

		}

		private void frmMain_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDown = false;
		}
	}
}
