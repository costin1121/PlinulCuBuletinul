using Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Runtime.CompilerServices;
//using OpenQA.Selenium.DevTools.V107.CSS;
using static System.Windows.Forms.LinkLabel;
using System.Reflection;
using System.Security.Policy;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using HtmlAgilityPack;
using System.Data;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Xml;
using System.IO;
using ExcelDataReader;
using LiteDB;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;
using WooCommerceNET.WooCommerce.v3.Extension;
using System.Net;
using Order = WooCommerceNET.WooCommerce.v3.Order;
using WCObject = WooCommerceNET.WooCommerce.v3.WCObject;
using WooCommerceNET.WooCommerce.v2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormAnimation;
using System.Drawing;

namespace PlinulCuBuletinul
{
	public class BotRaport
	{
		private string url_mol;
		private string username_mol;
		private string password_mol;
		private string URL_SITE;
		private string consummer_key;
		private string consummer_secret;


		public BotRaport(string urlMol, string usernameMol, string passwordMol, string urlSite, string consumerKey, string consumerSecret) 
		{
			this.url_mol = urlMol;
			this.username_mol = usernameMol;
			this.password_mol = passwordMol;
			this.URL_SITE = urlSite;
			this.consummer_key = consumerKey;
			this.consummer_secret = consumerSecret;

		}
		public void DeleteAllReports()
		{
			string[] directoryFiles = System.IO.Directory.GetFiles(@System.IO.Directory.GetCurrentDirectory(), "*.xlsx");
			foreach (string directoryFile in directoryFiles)
			{
				System.IO.File.Delete(directoryFile);
			}
		}

		public void ParseExcel(string fullPath)
		{
			
			using (var stream = File.Open(@fullPath, FileMode.Open, FileAccess.Read))
			{
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{
					DataSet dataSet = reader.AsDataSet(
						new ExcelDataSetConfiguration()
						{
							ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
							{
								UseHeaderRow = true,
							}
						});

					
					DataTable dataTable = dataSet.Tables[0];

					string ultimaStatie = "";
					double cantitate = 0;
					double valoare = 0;
					string articol = "";
					string dataAlimentare = "";
					string codCard = "";

					int client_wcID = 0;
					string numeClient = "";
					string prenumeClient = "";
					string adresaClient = "";
					string orasClient = "";
					string taraClient = "";
					string codPostalClient = "";
					string judetClient = "";
					string telefonClient = "";
					string emailClient = "";
					double totalConsum = 0;
					double actualConsum = 0;

					foreach (DataRow row in dataTable.Rows)
					{
						dataAlimentare = row["Data tranzacției"].ToString();
						codCard = row["Număr de înmatriculare"].ToString();
						articol = row["Articol"].ToString();
						ultimaStatie = row["Nume stație"].ToString();
						cantitate = (double)row["Cantitate"];
						valoare = (double)row["Valoare facturii"]; // de vazut daca e valoare sau valoarea facturii din excel

						List<BsonDocument> documentClient = Clienti.GetClientByCodCard(codCard);
						if(documentClient.Count() != 0)
						{
							//updatez total consum
							foreach (BsonDocument doc in documentClient)
							{
								client_wcID = (int)doc["woocommerce_id"].AsInt64;
								numeClient = doc["Nume"].AsString;
								prenumeClient = doc["Prenume"].AsString;
								adresaClient = doc["Adresa"].AsString;
								orasClient = doc["Oras"].AsString;
								taraClient = doc["Tara"].AsString;
								codPostalClient = doc["Cod_Postal"].AsString;
								judetClient = doc["Judet"].AsString;
								telefonClient = doc["Telefon"].AsString;
								emailClient = doc["email"].AsString;
								actualConsum = doc["TotalConsum"].AsDouble;
								totalConsum = actualConsum + cantitate;
		
								CreateOrder(client_wcID, numeClient, prenumeClient, adresaClient, taraClient,
											codPostalClient, judetClient, telefonClient, orasClient, totalConsum, cantitate, ultimaStatie,
											codCard, articol, dataAlimentare, emailClient, valoare);
							}
						}
						else
						{
							frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul cu cardul " + codCard + " nu a fost gasit in baza de date!\r\n";

						}
					}
				}
			}
		}

		public void CreateOrder(int clientWC_id, string numeClient, string prenumeClient, string adresaClient
									  , string taraClient, string codPostalClient, string judetClient, string telefonClient,string orasClient, double totalConsum
									  , double cantitate, string ultimaStatie, string codCard, string articol, string dataAlimentare, string emailClient, double valoareAlimentare)
		{
			try
			{
				RestAPI rest = new RestAPI(URL_SITE, consummer_key, consummer_secret);
				WCObject wc = new WCObject(rest);
				var billingAddress = new OrderBilling()
				{
					first_name = numeClient,
					last_name = prenumeClient,
					address_1 = adresaClient,
					city = orasClient,
					state = judetClient,
					postcode = codPostalClient,
					country = taraClient,
					email = emailClient,
					phone = telefonClient
				};
				var shippingAddress = new OrderShipping()
				{
					first_name = numeClient,
					last_name = prenumeClient,
					address_1 = adresaClient,
					city = orasClient,
					state = judetClient,
					postcode = codPostalClient,
					country = taraClient

				};
				var lineItem = new List<OrderLineItem>
			{
				new OrderLineItem()
				{
					product_id = 778,
					name = "Alimentare",
					price = (decimal?)cantitate,
					total = (decimal?)cantitate,
					quantity = 1
				}

			};
				var metaData = new List<OrderMeta>
			{
				new OrderMeta()
				{
					key = "benzinarie",
					value = ultimaStatie,
				},
				new OrderMeta()
				{
					key = "litri_alimentati",
					value = cantitate
				},
				new OrderMeta()
				{
					key = "serie_card",
					value = codCard
				},
				new OrderMeta()
				{
					key = "tip_conbustibil",
					value = articol
				},
				new OrderMeta()
				{
					key = "data_alimentari",
					value = dataAlimentare
				},
				new OrderMeta()
				{
					key = "total_alimentat",
					value = totalConsum
				}
			};
				var newOrder = new Order()
				{
					payment_method = "cod",
					payment_method_title = "Cash on Delivery",
					status = "processing",
					customer_id = (ulong?)clientWC_id,
					set_paid = true,
					billing = billingAddress,
					shipping = shippingAddress,
					line_items = lineItem,
					meta_data = metaData
				};
				var response = wc.Order.Add(newOrder).Result;
				//await wc.Order.Add(newOrder);
				if (response != null && response.id > 0)
				{
					// updatez campul total consum in baza de date
					Clienti.UpdateTotalConsumByCodCard(codCard, totalConsum);

					frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Comanda cu id-ul " + response.id +" a fost creata cu succes!"+ Environment.NewLine;

				} else
				{
					frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Eroare creare comanda..." + Environment.NewLine;
				}
			}
			catch (Exception ex)
			{
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Comanda nu a fost creata...Mesaj Original: " + ex.Message + Environment.NewLine;
			}
		}

		public void startBotRaport()
		{
			try
			{
				ChromeDriverService service = ChromeDriverService.CreateDefaultService();
				service.HideCommandPromptWindow = true;
				
				ChromeOptions options = new ChromeOptions();
				options.AddUserProfilePreference("download.default_directory", @System.IO.Directory.GetCurrentDirectory());
				options.AddUserProfilePreference("download.prompt_for_download", false);
				options.AddUserProfilePreference("disable-popup-blocking", "true");

				var driver = new ChromeDriver(service,options);

				Actions act = new Actions(driver);
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

				driver.Manage().Window.Maximize();

				driver.Navigate().GoToUrl(url_mol);

				IWebElement molPartenerChangeLanguage = driver.FindElement(By.Id("langDropdown"));
				IWebElement molPartenerChangeLanguageSelect = driver.FindElement(By.Id("langRo"));
				IWebElement molPartenerLoginUsername = driver.FindElement(By.Name("username"));
				IWebElement molPartenerLoginPassword = driver.FindElement(By.Name("password"));
				act.MoveToElement(molPartenerLoginUsername).Click().SendKeys(username_mol).Perform();
				act.MoveToElement(molPartenerLoginPassword).Click().SendKeys(password_mol).Perform();
				act.MoveToElement(molPartenerLoginPassword).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Autentificat cu succes pe site-ul Mol Partener!" + Environment.NewLine;

				driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/dashboard");
				Thread.Sleep(4000);
				//
				driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/reports");
				Thread.Sleep(4000);
				
				// pentru debug se comenteaza partea asta de aici urmatoarea linie pentru release se decomenteaza
				
				driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/reports/create");
				Thread.Sleep(4000);
				//se lanseaza raportul

				//tip raport
				IWebElement selectRaportType = driver.FindElement(By.Id("occ-select-reportType"));
				act.MoveToElement(selectRaportType).Click();
				act.MoveToElement(selectRaportType).Perform();
				
				IWebElement selectRaport = driver.FindElement(By.XPath("//*[@id=\"occ-select-reportType\"]/occ-select-block[2]/occ-select-block/occ-select-block[4]"));//wait.Until(drv => driver.FindElement(By.XPath("//*[@id=\"occ-select-cardType\"]/occ-select-block[2]/occ-select-block/occ-select-block[2]")));
				act.MoveToElement(selectRaport).Click();
				act.MoveToElement(selectRaport).Perform();

				//data tranzactii
				IWebElement selectDataTranzactiiType = driver.FindElement(By.Id("occ-select-10302_type-select-id"));
				act.MoveToElement(selectDataTranzactiiType).Click();
				act.MoveToElement(selectDataTranzactiiType).Perform();

				IWebElement selectZiuaAnterioara = driver.FindElement(By.XPath("//*[@id=\"occ-select-10302_type-select-id\"]/occ-select-block[2]/occ-select-block/occ-select-block[6]"));
				act.MoveToElement(selectZiuaAnterioara).Click();
				act.MoveToElement(selectZiuaAnterioara).Perform();

				//tipul contractului
				//occ-select-10313-select-id
				IWebElement selectTipContractType = driver.FindElement(By.Id("occ-select-10313-select-id"));
				act.MoveToElement(selectTipContractType).Click();
				act.MoveToElement(selectTipContractType).Perform();

				IWebElement selectTipContract = driver.FindElement(By.XPath("//*[@id=\"occ-select-10313-select-id\"]/occ-select-block[2]/occ-select-block/occ-select-block[3]"));
				act.MoveToElement(selectTipContract).Click();
				act.MoveToElement(selectTipContract).Perform();

				// apasa buton lansare raport
				IWebElement btnComanda = driver.FindElement(By.Id("buttonSearch"));
				act.MoveToElement(btnComanda).Click().Perform();
				
				// stau 5 secunde si revin la pagina de rapoarte
				Thread.Sleep(5000);
				// ma intorc in dashboard pentru ca refresh te intoarce mereu in dashboard si ca sa se vada raportul generat
				driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/dashboard");

				Thread.Sleep(4000);
				driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/reports");
				// pana aici deasupra sfarsit comentariu pentru debug				
				
				// incep sa parsez html
				HtmlDocument doc = new HtmlDocument();
				string linkRaport = "";
				bool isRaportGeneratNotOk = false;
				bool isRaportOk = false;
				while(true)
				{
					driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/reports");
					Thread.Sleep(4000);
					doc.LoadHtml(driver.PageSource);
					var rows = doc.DocumentNode.Descendants("tablebuilder-row");
					//iau doar primul rand pentru ca acolo este ultimul generat
					foreach (var row in rows)
					{
						//2117668
						var status = row.SelectSingleNode("//*[@id=\"container4\"]/public-report-filter/tablebuilder/div/div[2]/table/tbody/tablebuilder-row[1]/td[4]/span/span").InnerText.Trim();
						if(status == "OK")
						{
							// iau linkul si dau break
							linkRaport = row.SelectSingleNode("//*[@id=\"tablebuilder-link-report-show-name-103\"]").Attributes["href"].Value;
							isRaportOk = true;
						} 
						else if(status == "Nu au fost găsite date")
						{
							frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Raportul a fost generat, dar nu exista date!\r\n";
							isRaportGeneratNotOk = true;
							driver.Quit();
						}
						break;
					}
					if (isRaportOk || isRaportGeneratNotOk )
					{
						break;
					}
				}
				//continui doar daca raportul a fost generat ok
				if (isRaportOk)
				{
					//merg mai departe si continui la link-ul luat
					driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/" + linkRaport);
					//export-buttons-report-xls
					//apasa buton descarca raport
					IWebElement btnDescarcaRaport = driver.FindElement(By.Id("export-buttons-report-xls"));
					act.MoveToElement(btnDescarcaRaport).Click().Perform();
					string numeFisier = "";
					while(true)
					{
						string folderDownload = @System.IO.Directory.GetCurrentDirectory();
						FileInfo[] files = new DirectoryInfo(folderDownload).GetFiles("*.xlsx");
						if (files.Length > 0)
						{
							
							foreach (var file in files)
							{
								// iau numele fisierului cu tot cu calea
								numeFisier = file.FullName;
								break; // ies ca am gasit fisierul
							}
							// daca am gasit fisierul inchid tot si ies
							driver.Quit();
							frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Raportul a fost generat cu succes!\r\n";
							break;
							
						} 
						else
						{
							Thread.Sleep(4000);
						}
					}
					this.ParseExcel(numeFisier);
					this.DeleteAllReports();
					frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Fisierul a fost sters cu succes de pe disk!" + Environment.NewLine;
				}
			}
			catch (Exception e) 
			{
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + e.Message + Environment.NewLine;
			}	

		}
	}
}
