using System;
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
        public static string url_site;
        public static string consumer_key;
        public static string consumer_secret;


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
            //main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Rulez functia!" + "\r\n";
            
            wooCommerce wc = new wooCommerce(url_site,consumer_key, consumer_secret, "", "");
            wc.getOrders();


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
            int intervalVerificare = GetIntervalValue();
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
            else
            {
                initTimer(intervalVerificare);
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

			}
            key.Close();
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

			}
            key.Close();
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

			}
            key.Close();
			return consumer_value;
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
		}


	}
}
