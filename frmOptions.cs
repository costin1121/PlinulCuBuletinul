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
		private bool SaveRegistryOptions()
		{
			if (tbURL.Text == ""){
				MessageBox.Show("URL-ul site-ului nu a fost completat!");
				return false;
				
			}
			if (tbConsumerKey.Text == "") {
				MessageBox.Show("Consumer Key-ul nu a fost completat!");
				return false;
			}
			if (tbConsumerSecret.Text == ""){

				MessageBox.Show("Consumer Secret nu a fost completat!");
				return false;
			}
			
			if (tbURLMol.Text == "")
			{
				MessageBox.Show("URL site-ului Mol trebuie completat!");
				return false;
			}
			
			if (tbUsernameMol.Text == "")
			{
				MessageBox.Show("Username-ul de autentificare pe site-ul Mol trebuie completat!");	
				return false; 

			}
			if (tbPassword.Text == "")
			{
				MessageBox.Show("Parola de autentificare pe site-ul Mol trebuie completata!");
				return false;
			}
			RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\PlinulCuBuletinul");
			key.SetValue("url_site", tbURL.Text);
			key.SetValue("consumer_key", tbConsumerKey.Text);
			key.SetValue("consumer_secret", tbConsumerSecret.Text);
			key.SetValue("url_mol", tbURLMol.Text);
			key.SetValue("username_mol", tbUsernameMol.Text);
			key.SetValue("password_mol", tbPassword.Text);
			key.Close();
			return true;
		}

		private void LoadRegistryOptions()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PlinulCuBuletinul");
			if (key != null)
			{

				url_site = key.GetValue("url_site").ToString();
				consumer_key = key.GetValue("consumer_key").ToString();
				consumer_secret = key.GetValue("consumer_secret").ToString();
				url_mol = key.GetValue("url_mol").ToString();
				username_mol = key.GetValue("username_mol").ToString();
				password_mol = key.GetValue("password_mol").ToString();
		
				tbURL.Text = url_site;
				tbConsumerKey.Text = consumer_key;
				tbConsumerSecret.Text = consumer_secret;
				tbURLMol.Text = url_mol;
				tbUsernameMol.Text = username_mol;
				tbPassword.Text = password_mol;
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
				MessageBox.Show("Optiunile au fost salvate cu succes!");
				this.Close();
			}
		}

		private void frmOptions_Shown(object sender, EventArgs e)
		{
			//LoadRegistryOptions()
		}
	}
}
