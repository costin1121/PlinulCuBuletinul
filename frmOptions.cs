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
			RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\PlinulCuBuletinul");
			key.SetValue("url_site", tbURL.Text);
			key.SetValue("consumer_key", tbConsumerKey.Text);
			key.SetValue("consumer_secret", tbConsumerSecret.Text);
			key.SetValue("url_mol", tbURLMol.Text);
			key.SetValue("username_mol", tbUsernameMol.Text);
			key.SetValue("password_mol", tbPassword.Text);
			key.SetValue("interval_trimitere", numericInterval.Value.ToString());
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

				tbURL.Text = url_site;
				tbConsumerKey.Text = consumer_key;
				tbConsumerSecret.Text = consumer_secret;
				tbURLMol.Text = url_mol;
				tbUsernameMol.Text = username_mol;
				tbPassword.Text = password_mol;
				numericInterval.Value = Convert.ToDecimal(interval_trimitere);
			}
		}
		private void btnExit_Click(object sender, EventArgs e)
		{
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
			if (SaveRegistryOptions()){
				MessageBox.Show("Optiunile au fost salvate cu succes!", "Plinul Cu Buletinul", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
