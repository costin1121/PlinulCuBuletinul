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
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace PlinulCuBuletinul
{
	public class Bot
	{
		private string url_mol;
		private string username_mol;
		private string password_mol;

		private float totalComandat;
		private string clientNume;
		private string clientPrenume;
		private string adresa1;
		private string adresa2;
		private string oras;
		private string judet;
		private string codPostal;
		private string tara;
		private string email;
		private string telefon;
		private string paymentMethod;
		private string numar_serie;


		public Bot(string urlMol,string usernameMol, string passwordMol) 
		{
			this.url_mol = urlMol;
			this.username_mol = usernameMol;
			this.password_mol = passwordMol;
		}

		public void SaveDetailsFromSite(float total_comandat, string client_nume, string client_prenume, 
		string adresa_1, string adresa_2, string oras_client, string judet_client, string cod_postal, 
		string tara_client, string email_client, string telefon_client, string PaymentMethod_Client, string numarSerie)
		{
			this.totalComandat = total_comandat;
			this.clientNume = client_nume;
			this.clientPrenume= client_prenume;
			this.adresa1= adresa_1;
			this.adresa2= adresa_2;
			this.oras= oras_client;
			this.judet= judet_client;
			this.codPostal= cod_postal;
			this.tara= tara_client;
			this.email= email_client;
			this.telefon= telefon_client;
			this.paymentMethod = PaymentMethod_Client;
			this.numar_serie = numarSerie;
		}

		public void startBotAlimentareCard()
		{
			ChromeDriverService service = ChromeDriverService.CreateDefaultService();
			service.HideCommandPromptWindow = true;
			var driver = new ChromeDriver(service);

			Actions act = new Actions(driver);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
			//string url = "https://b2b.mol.hu/openam/UI/Logout?goto=https://b2bpartnerportal.com/pp/login?lang=ro";

			driver.Manage().Window.Maximize();

			driver.Navigate().GoToUrl(url_mol);

			//WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
			IWebElement molPartenerChangeLanguage = driver.FindElement(By.Id("langDropdown"));
			IWebElement molPartenerChangeLanguageSelect = driver.FindElement(By.Id("langRo"));
			IWebElement molPartenerLoginUsername = driver.FindElement(By.Name("username"));
			IWebElement molPartenerLoginPassword = driver.FindElement(By.Name("password"));
			act.MoveToElement(molPartenerLoginUsername).Click().SendKeys(username_mol).Perform();
			act.MoveToElement(molPartenerLoginPassword).Click().SendKeys(password_mol).Perform();
			act.MoveToElement(molPartenerLoginPassword).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
			//molPartenerLoginUsername.SendKeys(username_mol);
			//molPartenerLoginPassword.SendKeys(password_mol);
			//molPartenerLoginPassword.SendKeys(OpenQA.Selenium.Keys.Enter);
			frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Autentificat cu succes pe site-ul Mol Partener!" + Environment.NewLine;

			driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/dashboard");
			Thread.Sleep(4000);

			driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/card-management");

			IWebElement cardName = driver.FindElement(By.Id("cardComplexSearch"));
			cardName.Clear();
			act.MoveToElement(cardName).Click().SendKeys(this.numar_serie).Perform();

			//buttonSearch
			IWebElement btnSearch = driver.FindElement(By.Id("buttonSearch"));
			act.MoveToElement(btnSearch).Click().Perform();

			frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Card identificat cu success in sistemul MOL!" + Environment.NewLine;

			Thread.Sleep(4000);

			//am apasat butonul de editare
			IWebElement btnEditLimita = driver.FindElement(By.Id("card-detail-current-usage-edit"));
			act.MoveToElement(btnEditLimita).Click().Perform();

			////card-detail-current-usage-input-dailyLimit
			IWebElement editLimita = driver.FindElement(By.XPath("//*[@id=\"undefined-currency-input\"]"));
			act.MoveToElement(editLimita).Click().Perform(); // dau click

			
			var valoareActuala = editLimita.GetAttribute("value").Replace("RON", "");
			var limitaNoua = Convert.ToDouble(valoareActuala) + this.totalComandat;
			
			
			IWebElement limitaActualaZilnica = driver.FindElement(By.Id("card-detail-current-usage-input-dailyLimit"));
			act.MoveToElement(limitaActualaZilnica).DoubleClick().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(limitaNoua.ToString()).Perform();
			Thread.Sleep(1000);

			IWebElement limitaActualaSaptamanala = driver.FindElement(By.Id("card-detail-current-usage-input-weeklyLimit"));
			act.MoveToElement(limitaActualaSaptamanala).DoubleClick().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(limitaNoua.ToString()).Perform();
			Thread.Sleep(1000);

			IWebElement limitaActualaLunara = driver.FindElement(By.Id("card-detail-current-usage-input-monthlyLimit"));
			act.MoveToElement(limitaActualaLunara).DoubleClick().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(limitaNoua.ToString()).Perform();
			Thread.Sleep(1000);

			IWebElement limitaActualaTrimestriala = driver.FindElement(By.Id("card-detail-current-usage-input-quarterlyLimit"));
			act.MoveToElement(limitaActualaTrimestriala).DoubleClick().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(limitaNoua.ToString()).Perform();
			Thread.Sleep(1000);

			IWebElement limitaActualaAnuala = driver.FindElement(By.Id("card-detail-current-usage-input-yearlyLimit"));
			act.MoveToElement(limitaActualaAnuala).DoubleClick().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(limitaNoua.ToString()).Perform();
			Thread.Sleep(1000);
			
			IWebElement btnSalveaza = driver.FindElement(By.Id("card-detail-current-usage-save"));
			act.MoveToElement(btnSalveaza).Click().Perform();

			Thread.Sleep(4000);
			driver.Quit();
		}

		public void startBotCardNou()
		{
			try
			{
				ChromeDriverService service = ChromeDriverService.CreateDefaultService();
				service.HideCommandPromptWindow = true;
				var driver = new ChromeDriver(service);
				
				Actions act = new Actions(driver);
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
				//string url = "https://b2b.mol.hu/openam/UI/Logout?goto=https://b2bpartnerportal.com/pp/login?lang=ro";
				
				driver.Manage().Window.Maximize();

				driver.Navigate().GoToUrl(url_mol);
				
				//WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
				IWebElement molPartenerChangeLanguage = driver.FindElement(By.Id("langDropdown"));
				IWebElement molPartenerChangeLanguageSelect = driver.FindElement(By.Id("langRo"));
				IWebElement molPartenerLoginUsername = driver.FindElement(By.Name("username"));
				IWebElement molPartenerLoginPassword = driver.FindElement(By.Name("password"));
				act.MoveToElement(molPartenerLoginUsername).Click().SendKeys(username_mol).Perform();
				act.MoveToElement(molPartenerLoginPassword).Click().SendKeys(password_mol).Perform();
				act.MoveToElement(molPartenerLoginPassword).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
				//molPartenerLoginUsername.SendKeys(username_mol);
				//molPartenerLoginPassword.SendKeys(password_mol);
				//molPartenerLoginPassword.SendKeys(OpenQA.Selenium.Keys.Enter);
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Autentificat cu succes pe site-ul Mol Partener!" + Environment.NewLine;
				
				driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/dashboard");
				Thread.Sleep(4000);
				driver.Navigate().GoToUrl("https://b2bpartnerportal.com/occ/#/card-management/order/detail/CARD_ORDER");

				


				IWebElement selectCard = driver.FindElement(By.Id("occ-select-cardType"));//wait.Until(drv =>  driver.FindElement(By.Id("occ-select-cardType")));
				act.MoveToElement(selectCard).Click();
				act.MoveToElement(selectCard).Perform();
				//selectCard.Click();


				IWebElement selectCardType = driver.FindElement(By.XPath("//*[@id=\"occ-select-cardType\"]/occ-select-block[2]/occ-select-block/occ-select-block[2]"));//wait.Until(drv => driver.FindElement(By.XPath("//*[@id=\"occ-select-cardType\"]/occ-select-block[2]/occ-select-block/occ-select-block[2]")));
				act.MoveToElement(selectCardType).Click();
				act.MoveToElement(selectCardType).Perform();

				//selectCardType.Click();


				IWebElement selectCombustibil = driver.FindElement(By.Id("occ-select-cardCategory"));
				act.MoveToElement(selectCombustibil).Click();
				act.MoveToElement(selectCombustibil).Perform();
				//selectCombustibil.Click();


				IWebElement selectCombustibilType = driver.FindElement(By.XPath("//*[@id=\"occ-select-cardCategory\"]/occ-select-block[2]/occ-select-block/occ-select-block[2]"));
				act.MoveToElement(selectCombustibilType).Click();
				act.MoveToElement(selectCombustibilType).Perform();

				//selectCombustibilType.Click();


				IWebElement cardName = driver.FindElement(By.Id("cardName-input"));
				cardName.Clear();
				act.MoveToElement(cardName).Click().SendKeys(this.clientNume + " " + this.clientPrenume).Perform();

				//cardName.Clear();
				//act.MoveToElement(cardName).SendKeys(this.clientNume + " " + this.clientPrenume);
				//act.MoveToElement(cardName).Perform();
				//cardName.SendKeys(this.clientNume + " " + this.clientPrenume);

				IWebElement cardNumber = driver.FindElement(By.Id("licencePlate-input-special"));
				act.MoveToElement(cardNumber).Click();
				act.MoveToElement(cardNumber).SendKeys(this.numar_serie);
				act.MoveToElement(cardNumber).Perform();
				//cardNumber.Click();// de vazut aici daca merge fara click
				//cardNumber.SendKeys(this.numar_serie);
				
				
				//occ-select-postageFlag
				IWebElement livrare = driver.FindElement(By.Id("occ-select-postageFlag"));
				act.MoveToElement(livrare).Click();
				act.MoveToElement(livrare).Perform();

				//livrare.Click();


				IWebElement livrareType = driver.FindElement(By.XPath("//*[@id=\"occ-select-postageFlag\"]/occ-select-block[2]/occ-select-block/occ-select-block[2]"));
				act.MoveToElement(livrareType).Click();
				act.MoveToElement(livrareType).Perform();

				//livrareType.Click();

				//occ-select-lubricant
				IWebElement lubrifiant = driver.FindElement(By.Id("occ-select-lubricant"));
				act.MoveToElement(lubrifiant).Click();
				act.MoveToElement(lubrifiant).Perform();

				//lubrifiant.Click();

				IWebElement lubrifiantType = driver.FindElement(By.XPath("//*[@id=\"occ-select-lubricant\"]/occ-select-block[2]/occ-select-block/occ-select-block[5]"));
				act.MoveToElement(lubrifiantType).Click();
				act.MoveToElement(lubrifiantType).Perform();

				//lubrifiantType.Click();


				//occ-select-service
				IWebElement servicii = driver.FindElement(By.Id("occ-select-service"));
				act.MoveToElement(servicii).Click();
				act.MoveToElement(servicii).Perform();

				//servicii.Click();


				IWebElement serviciiType = driver.FindElement(By.XPath("//*[@id=\"occ-select-service\"]/occ-select-block[2]/occ-select-block/occ-select-block[4]"));
				act.MoveToElement(serviciiType).Click();
				act.MoveToElement(serviciiType).Perform();

				//serviciiType.Click();


				//occ-select-careProducts
				IWebElement ingrijire = driver.FindElement(By.Id("occ-select-careProducts"));
				act.MoveToElement(ingrijire).Click();
				act.MoveToElement(ingrijire).Perform();

				//ingrijire.Click();

				IWebElement ingrijireType = driver.FindElement(By.XPath("//*[@id=\"occ-select-careProducts\"]/occ-select-block[2]/occ-select-block/occ-select-block[4]"));
				act.MoveToElement(ingrijireType).Click();
				act.MoveToElement(ingrijireType).Perform();

				//ingrijireType.Click();


				//occ - select - shopProducts
				IWebElement shopProducts = driver.FindElement(By.Id("occ-select-shopProducts"));
				
				act.MoveToElement(shopProducts).Click();
				act.MoveToElement(shopProducts).Perform();
				
				
				//shopProducts.Click();
				IWebElement shopProductsType = driver.FindElement(By.XPath("//*[@id=\"occ-select-shopProducts\"]/occ-select-block[2]/occ-select-block/occ-select-block[5]"));
				shopProductsType.Click();
				Thread.Sleep(1000);
				//act.MoveToElement(shopProductsType).Click();
				//act.MoveToElement(shopProductsType).Perform();

				//shopProductsType.Click();
				IWebElement sumaLunara = driver.FindElement(By.Id("occ-currency-monthlyLimit-currency-input"));
				//sumaLunara.Clear();
				act.MoveToElement(sumaLunara).Click().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(this.totalComandat.ToString()).Perform();


				IWebElement sumaZilnica = driver.FindElement(By.Id("occ-currency-dailyLimit-currency-input"));
				//sumaZilnica.Clear();
				act.MoveToElement(sumaZilnica).Click().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(this.totalComandat.ToString()).Perform();

				IWebElement sumaSaptamanala = driver.FindElement(By.Id("occ-currency-weeklyLimit-currency-input"));
				//sumaSaptamanala.Clear();
				act.MoveToElement(sumaSaptamanala).Click().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(this.totalComandat.ToString()).Perform();


				IWebElement sumaTrimestriala = driver.FindElement(By.Id("occ-currency-quarterlyLimit-currency-input"));
				//sumaTrimestriala.Clear();
				act.MoveToElement(sumaTrimestriala).Click().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(this.totalComandat.ToString()).Perform();

				IWebElement sumaAnuala = driver.FindElement(By.Id("occ-currency-yearlyLimit-currency-input"));
				//sumaAnuala.Clear();
				act.MoveToElement(sumaAnuala).Click().SendKeys(OpenQA.Selenium.Keys.Backspace).SendKeys(this.totalComandat.ToString()).Perform();

				//
				IWebElement btnComanda = driver.FindElement(By.Id("order-immediately-btn"));
				act.MoveToElement(btnComanda).Click().Perform();
				//btnComanda.Click();
				Thread.Sleep(4000);

				//confirmdialog-cardOrder-confirm-orderImmediately-yes
				IWebElement btnComandaConfirm = driver.FindElement(By.Id("confirmdialog-cardOrder-confirm-orderImmediately-yes"));
				act.MoveToElement(btnComandaConfirm).Click().Perform();

				// debug apasa butonul cancel
				//IWebElement btnComandaConfirmNO = driver.FindElement(By.Id("confirmdialog-cardOrder-confirm-orderImmediately-no"));
				//act.MoveToElement(btnComandaConfirmNO).Click().Perform();

				Thread.Sleep(4000);
				driver.Quit();

			}
			catch (Exception e)
			{
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + e.Message + Environment.NewLine;
			}

		}
	}
}
