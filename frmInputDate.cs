using Dashboard;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlinulCuBuletinul
{
	public partial class frmInputDate : Form
	{

		public DateTime dataInceput;
		public DateTime dataSfarsit;
		
		public frmInputDate()
		{
			InitializeComponent();
		}
		private int GetIntervalValue()
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


		private void btnExit_Click(object sender, EventArgs e)
		{
			int intervalValue = GetIntervalValue();
			if (intervalValue > 0)
			{
				frmMain.initTimer(intervalValue);
			}
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			dataInceput = dtDataInceput.Value;
			dataSfarsit = dtDataSfarsit.Value;
			this.DialogResult = DialogResult.OK;
		}
	}
}
