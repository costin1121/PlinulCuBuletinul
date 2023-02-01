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
	public partial class frmOptions : Form
	{
		public frmOptions()
		{
			InitializeComponent();
		}
		public string url_site;
		public string consumer_key;
		public string consumer_secret;
		public string url_mol;
		public string username_mol;
		public string password_mol;
		public string interval_trimitere;
		public string serie_card;
		private bool SaveRegistryOptions()
		{
			if (tbURL.Text == ""){
				MessageBox.Show("URL-ul site-ului nu a fost completat!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
				
			}
			if (tbConsumerKey.Text == "") {
				MessageBox.Show("Consumer Key-ul nu a fost completat!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (tbConsumerSecret.Text == ""){

				MessageBox.Show("Consumer Secret nu a fost completat!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			
			if (tbURLMol.Text == "")
			{
				MessageBox.Show("URL site-ului Mol trebuie completat!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			
			if (tbUsernameMol.Text == "")
			{
				MessageBox.Show("Username-ul de autentificare pe site-ul Mol trebuie completat!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Warning);	
				return false; 

			}
			if (tbPassword.Text == "")
			{
				MessageBox.Show("Parola de autentificare pe site-ul Mol trebuie completata!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (tbNrCard.Text == "")
			{
				MessageBox.Show("Numarul de card initial trebuie completat!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if(tbSerieCard.Text == "")
			{
				MessageBox.Show("Seria de card initiala trebuie completata!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;

			}


			RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\PlinulCuBuletinul");
			key.SetValue("url_site", tbURL.Text);
			key.SetValue("consumer_key", tbConsumerKey.Text);
			key.SetValue("consumer_secret", tbConsumerSecret.Text);
			key.SetValue("url_mol", tbURLMol.Text);
			key.SetValue("username_mol", tbUsernameMol.Text);
			key.SetValue("password_mol", tbPassword.Text);
			key.SetValue("interval_trimitere", numericInterval.Value.ToString());
			key.SetValue("serie_card", tbSerieCard.Text);
			key.Close();
			return true;
		}

		private void LoadRegistryOptions()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			string keyName = @"HKEY_CURRENT_USER\SOFTWARE\PlinulCuBuletinul";
			if (key != null)
			{
				if (Registry.GetValue(keyName, "url_site", null) != null)
				{
					url_site = key.GetValue("url_site").ToString();
				}
				else
				{
					url_site = "";
				}
				if (Registry.GetValue(keyName, "consumer_key", null) != null)
				{
					consumer_key = key.GetValue("consumer_key").ToString();
				}
				else
				{
					consumer_key = "";
				}
				if (Registry.GetValue(keyName, "consumer_secret", null) != null)
				{
					consumer_secret = key.GetValue("consumer_secret").ToString();
				}
				else
				{
					consumer_secret = "";
				}
				if (Registry.GetValue(keyName, "url_mol", null) != null)
				{
					url_mol = key.GetValue("url_mol").ToString();
				}
				else
				{
					url_mol = "";

				}
				if (Registry.GetValue(keyName, "username_mol", null) != null)
				{
					username_mol = key.GetValue("username_mol").ToString();
				}
				else
				{
					username_mol = "";
				}
				if (Registry.GetValue(keyName, "password_mol", null) != null)
				{
					password_mol = key.GetValue("password_mol").ToString();
				}
				else
				{
					password_mol = "";
				}
				if (Registry.GetValue(keyName, "interval_trimitere", null) != null)
				{
					interval_trimitere = key.GetValue("interval_trimitere").ToString();
				}
				else
				{
					interval_trimitere = "2";
				}
				if (Registry.GetValue(keyName, "serie_card", null) != null)
				{
					serie_card = key.GetValue("serie_card").ToString();
				}
				else
				{
					serie_card = "";
				}

				tbURL.Text = url_site;
				tbConsumerKey.Text = consumer_key;
				tbConsumerSecret.Text = consumer_secret;
				tbURLMol.Text = url_mol;
				tbUsernameMol.Text = username_mol;
				tbPassword.Text = password_mol;
				numericInterval.Value = Convert.ToDecimal(interval_trimitere);
				NumarGenerator ng = new NumarGenerator("");
				tbNrCard.Text = ng.GetLastNrCard();
				tbSerieCard.Text = serie_card;
				key.Close();
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			if (interval_trimitere != null)
			{
				frmMain.initTimer(Convert.ToInt32(interval_trimitere));
			}
			this.Close();
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void frmOptions_Load(object sender, EventArgs e)
		{
			LoadRegistryOptions();

		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			int newValue = 2;
			if (SaveRegistryOptions()){
				//MessageBox.Show("Optiunile au fost salvate cu succes!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Information);
				frmMain.url_site = tbURL.Text;
				frmMain.consumer_secret = tbConsumerSecret.Text;
				frmMain.consumer_key= tbConsumerKey.Text;
				frmMain.username_mol = tbUsernameMol.Text;
				frmMain.password_mol = tbPassword.Text;
				frmMain.url_mol= tbURLMol.Text;
				newValue = Convert.ToInt32(numericInterval.Value);
				frmMain.serieCard = tbSerieCard.Text;
				frmMain.numarCard = tbNrCard.Text;
				NumarGenerator ng = new NumarGenerator(frmMain.numarCard);
				ng.SaveLastNrCard(frmMain.numarCard);
				
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Optiunile au fost salvate cu success!" + Environment.NewLine;
				frmMain.initTimer(newValue);

				this.Close();
			}
		}


		private void frmOptions_Shown(object sender, EventArgs e)
		{
			//LoadRegistryOptions()
		}


		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}
	}
}
