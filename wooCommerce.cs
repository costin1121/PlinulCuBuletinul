using Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;
using WooCommerceNET.WooCommerce.v3.Extension;
using System.Collections.Generic;


namespace PlinulCuBuletinul
{
	public class wooCommerce
	{
		private string URL_SITE;
		private string consummer_key;
		private string consummer_secret;
		private string data_Inceput;
		private string data_Sfarsit;
		//public static List<Order> orders = new List<Order>();

		public wooCommerce(string url, string consummerKey, string consummerSecret, string dataInceput, string dataSfarsit)
		{
			this.URL_SITE = url;
			this.consummer_key = consummerKey;
			this.consummer_secret = consummerSecret;
			this.data_Inceput = dataInceput;
			this.data_Sfarsit = dataSfarsit;
		}

		public async void getOrders()
		{
			try
			{
				RestAPI rest = new RestAPI(URL_SITE, consummer_key, consummer_secret);
				WCObject wc = new WCObject(rest);
				var orders = await wc.Order.GetAll();
				// functiile de selenium apelate de aici si nu din main


			}
			catch(Exception ex)
			{
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + ex.Message + Environment.NewLine;
			}

		}

	}
}
