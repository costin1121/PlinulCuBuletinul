﻿using Dashboard;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;
using WooCommerceNET.WooCommerce.v3.Extension;


namespace PlinulCuBuletinul
{
	public class wooCommerce
	{
		private string URL_SITE;
		private string consummer_key;
		private string consummer_secret;
		private string username_mol;
		private string password_mol;
		private string url_mol;
		private int last_id;
		private string numar_card;
		private string serie_card;
		//public static List<Order> orders = new List<Order>();

		public wooCommerce(string url, string consummerKey, string consummerSecret, string usernameMol, string passwordMol, string urlMol, int lastID, string numarCard, string serieCard)
		{
			this.URL_SITE = url;
			this.consummer_key = consummerKey;
			this.consummer_secret = consummerSecret;
			this.username_mol = usernameMol;
			this.password_mol = passwordMol;
			this.url_mol = urlMol;
			this.last_id = lastID;
			this.numar_card = numarCard;
			this.serie_card = serieCard;
		}

		public async void LaunchRaport()
		{
			try
			{
				BotRaport botRaportDriver = new BotRaport(this.url_mol, this.username_mol, this.password_mol, this.URL_SITE, this.consummer_key, this.consummer_secret);
				//am dat drumul la generarea raportului
				await Task.Run(botRaportDriver.startBotRaport);
			}
			catch(Exception ex)
			{
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + ex.Message + Environment.NewLine;

			}
		}

		public async void getOrderByDate(DateTime dataInceput, DateTime dataSfarsit)
		{
			try
			{
				Bot botDriver = new Bot(this.url_mol, this.username_mol, this.password_mol);
				RestAPI rest = new RestAPI(URL_SITE, consummer_key, consummer_secret);
				WCObject wc = new WCObject(rest);
				string status = "";
				float totalComandat = 0;
				string clientNume = "";
				string clientPrenume = "";
				string adresa1 = "";
				string adresa2 = "";
				string oras = "";
				string judet = "";
				string codPostal = "";
				string tara = "";
				string email = "";
				string telefon = "";
				string paymentMethod = "";
				string date_creare = "";
				string fullName = "";
				string fullSerie = "";
				int wc_id = 0;
				double total_consum = 0;
				bool isComandaOk = true;
				bool isCashout = false;
				int newID = 0;
				int nrComenziAcceptate = 0;
				int intNrCard = Convert.ToInt32(this.numar_card);
				string numar_serie = this.numar_card + this.serie_card;
				string utcDataInceput = dataInceput.ToString("yyyy-MM-ddT00:00:00");
				string utcDataSfarsit = dataSfarsit.ToString("yyyy-MM-ddT23:59:59");
				int pageNum = 1;
				while (true)
				{
					var page = pageNum.ToString();
					var orders = await wc.Order.GetAll(new Dictionary<string, string>() {
				{ "status", "completed" },//cancelled debug
				{ "order" , "asc" },
				{ "page", page },
				{ "per_page", "99" }, 
				{ "before" , utcDataSfarsit },
				{ "after" , utcDataInceput }, });
					if (orders.Count == 0) {
						frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Nu exista documente de generat!" + "\r\n";
						break; 
					}
					if (orders.Count < 99)
					{
						foreach (var order in orders)
						{
							isComandaOk = true;
							newID = (int)order.id;
							if (this.last_id < newID)
							{
								totalComandat = (float)order.total;
								clientNume = order.billing.first_name;
								clientPrenume = order.billing.last_name;
								adresa1 = order.billing.address_1;
								adresa2 = order.billing.address_2;
								oras = order.billing.city;
								judet = order.billing.state;
								codPostal = order.billing.postcode;
								tara = order.billing.country;
								email = order.billing.email;
								telefon = order.billing.phone;
								paymentMethod = order.payment_method_title;
								date_creare = order.date_created.ToString();
								wc_id = (int)order.customer_id;
								var line_items = order.line_items;
								foreach (var item in line_items)
								{
									if (item.product_id == 4927)
									{
										isCashout = true;
										break;
									}

									if (item.sku != "")
									{
										isComandaOk= false;
										break;
									}
								}

								if (isComandaOk == true)
								{
									nrComenziAcceptate++;
									if (isCashout == true)
									{
										//pentru clientii care sunt cu cashout
										var client = Clienti.GetClientByWcID(wc_id);
										if (client != null)
										{
											botDriver.SaveDetailsFromSite(totalComandat, client["Nume"].AsString, client["Prenume"].AsString, client["Adresa"].AsString, "", client["Oras"].AsString, client["Judet"].AsString, client["Cod_Postal"].AsString, client["Tara"].AsString, client["Email"].AsString, client["Telefon"].AsString, "", client["SerieCard"].AsString);
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + client["NumeClient"].AsString + " a fost identificat cu success in baza de date! Alimentare card in curs...." + "\r\n";
											await Task.Run(botDriver.startBotAlimentareCard);
											LastComanda lc = new LastComanda(newID);
											lc.SaveLastIndexComanda(newID);
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "ID-ul ultimei comenzi a fost salvat cu succes!" + "\r\n";
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Alimentarea cardului pentru clientul " + client["NumeClient"].AsString + " a fost finalizata cu success!" + "\r\n";
										}
										else
										{
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul cu id-ul " + wc_id + " nu a fost gasit in baza de date" + "\r\n";
										}
									}
									else
									{
										DateTime tmpDataCreare = DateTime.Parse(date_creare, null, DateTimeStyles.RoundtripKind);
										botDriver.SaveDetailsFromSite(totalComandat, clientNume, clientPrenume, adresa1, adresa2, oras, judet, codPostal, tara, email, telefon, paymentMethod, numar_serie);
										//
										//botDriver.startBot();
										await Task.Run(botDriver.startBotCardNou);
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + clientNume + " " + clientPrenume + " cu cardul " + numar_serie + " a fost adaugat cu succes!" + "\r\n";
										intNrCard++;
										this.numar_card = intNrCard.ToString().PadLeft(5, '0');
										NumarGenerator ng = new NumarGenerator(this.numar_card);
										ng.SaveLastNrCard(this.numar_card);
										numar_serie = this.numar_card + this.serie_card;
										LastComanda lc = new LastComanda(newID);
										lc.SaveLastIndexComanda(newID);
										// ultima data salvam clientul in baza
										fullName = clientNume + " " + clientPrenume;
										fullSerie = this.numar_card + this.serie_card;
										Clienti client = new Clienti(fullName, fullSerie, totalComandat, tmpDataCreare
																	, paymentMethod, wc_id, clientNume, clientPrenume, adresa1
																	, oras, judet, codPostal, tara, telefon, total_consum, email);
										client.SaveClient();
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + fullName + " a fost salvat cu success!" + "\r\n";
										frmMain.main.UpdateClienti = Clienti.GetCountClienti().ToString();
										frmMain.main.UpdateSuma = "LEI " + Clienti.GetSumaClienti().ToString();
									}
								}
							}

						}// ies
						break;
					}
					else
					{
						foreach (var order in orders)
						{
							isComandaOk = true;
							newID = (int)order.id;
							if (this.last_id < newID)
							{
								totalComandat = (float)order.total;
								clientNume = order.billing.first_name;
								clientPrenume = order.billing.last_name;
								adresa1 = order.billing.address_1;
								adresa2 = order.billing.address_2;
								oras = order.billing.city;
								judet = order.billing.state;
								codPostal = order.billing.postcode;
								tara = order.billing.country;
								email = order.billing.email;
								telefon = order.billing.phone;
								paymentMethod = order.payment_method_title;
								date_creare = order.date_created.ToString();
								wc_id = (int)order.customer_id;
								var line_items = order.line_items;
								foreach (var item in line_items)
								{
									if (item.product_id == 4927)
									{
										isCashout = true;
										break;
									}

									if (item.sku != "")
									{
										isComandaOk = false;
										break;
									}
								}
								if (isComandaOk == true)
								{
									nrComenziAcceptate++;
									if (isCashout == true)
									{
										//pentru clientii care sunt cu cashout
										var client = Clienti.GetClientByWcID(wc_id);
										if (client != null)
										{
											botDriver.SaveDetailsFromSite(totalComandat, client["Nume"].AsString, client["Prenume"].AsString, client["Adresa"].AsString, "", client["Oras"].AsString, client["Judet"].AsString, client["Cod_Postal"].AsString, client["Tara"].AsString, client["Email"].AsString, client["Telefon"].AsString, "", client["SerieCard"].AsString);
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + client["NumeClient"].AsString + " a fost identificat cu success in baza de date! Alimentare card in curs...." + "\r\n";
											await Task.Run(botDriver.startBotAlimentareCard);
											LastComanda lc = new LastComanda(newID);
											lc.SaveLastIndexComanda(newID);
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "ID-ul ultimei comenzi a fost salvat cu succes!" + "\r\n";
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Alimentarea cardului pentru clientul " + client["NumeClient"].AsString + " a fost finalizata cu success!" + "\r\n";
										}
										else
										{
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul cu id-ul " + wc_id + " nu a fost gasit in baza de date" + "\r\n";
										}

									}
									else
									{
										DateTime tmpDataCreare = DateTime.Parse(date_creare, null, DateTimeStyles.RoundtripKind);
										botDriver.SaveDetailsFromSite(totalComandat, clientNume, clientPrenume, adresa1, adresa2, oras, judet, codPostal, tara, email, telefon, paymentMethod, numar_serie);
										await Task.Run(botDriver.startBotCardNou);
										//botDriver.startBot();
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + clientNume + " " + clientPrenume + " cu cardul " + numar_serie + " a fost adaugat cu succes!" + "\r\n";
										intNrCard++;
										this.numar_card = intNrCard.ToString().PadLeft(5, '0');
										NumarGenerator ng = new NumarGenerator(this.numar_card);
										ng.SaveLastNrCard(this.numar_card);
										numar_serie = this.numar_card + this.serie_card;
										LastComanda lc = new LastComanda(newID);
										lc.SaveLastIndexComanda(newID);
										// ultima data salvam clientul in baza
										fullName = clientNume + " " + clientPrenume;
										fullSerie = this.numar_card + this.serie_card;
										Clienti client = new Clienti(fullName, fullSerie, totalComandat, tmpDataCreare, paymentMethod
																	 , wc_id, clientNume, clientPrenume, adresa1, oras, judet, codPostal
																	 , tara, telefon, total_consum, email);
										client.SaveClient();
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + fullName + " a fost salvat cu success!" + "\r\n";
										frmMain.main.UpdateClienti = Clienti.GetCountClienti().ToString();
										frmMain.main.UpdateSuma = "LEI " + Clienti.GetSumaClienti().ToString();
									}
								}
							}
						}// increment
						pageNum++;
					}
				}
				//pus sa scrie in log in caz ca nu sunt comenzi
				if (nrComenziAcceptate == 0)
				{
					frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Nu exista comenzi noi de generat!\r\n";
				}

			}
			catch (Exception ex)
			{
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + ex.Message + Environment.NewLine;
			}

		}

		public async void getOrders()
		{
			try
			{
				Bot botDriver = new Bot(this.url_mol, this.username_mol, this.password_mol);
				RestAPI rest = new RestAPI(URL_SITE, consummer_key, consummer_secret);
				WCObject wc = new WCObject(rest);
				string status = "";
				float totalComandat = 0;
				string clientNume = "";
				string clientPrenume = "";
				string adresa1 = "";
				string adresa2 = "";
				string oras = "";
				string judet = "";
				string codPostal = "";
				string tara = "";
				string email = "";
				string telefon = "";
				string paymentMethod = "";
				string date_creare = "";
				string fullName = "";
				string fullSerie = "";
				int wc_id = 0;
				double total_consum = 0;
				bool isComandaOk = true;
				bool isCashout = false;
				int newID = 0;
				int nrComenziAcceptate = 0;
				int intNrCard = Convert.ToInt32(this.numar_card);
				string numar_serie = this.numar_card + this.serie_card;

				int pageNum = 1;
				while (true)
				{
					var page = pageNum.ToString();
					var orders = await wc.Order.GetAll(new Dictionary<string, string>() {
				{ "status", "completed" },//cancelled
				{ "order" , "asc" },
				{ "page", page },
				{ "per_page", "99" }, });
					
					if (orders.Count == 0)
					{
						frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Nu exista documente de generat!" + "\r\n";
						break;
					}

					if (orders.Count < 99)
					{
						foreach (var order in orders)
						{
							isComandaOk = true;
							newID = (int)order.id;
							if (this.last_id < newID)
							{
								totalComandat = (float)order.total;
								clientNume = order.billing.first_name;
								clientPrenume = order.billing.last_name;
								adresa1 = order.billing.address_1;
								adresa2 = order.billing.address_2;
								oras = order.billing.city;
								judet = order.billing.state;
								codPostal = order.billing.postcode;
								tara = order.billing.country;
								email = order.billing.email;
								telefon = order.billing.phone;
								paymentMethod = order.payment_method_title;
								date_creare = order.date_created.ToString();
								wc_id = (int)order.customer_id;
								var line_items = order.line_items;
								foreach(var item in line_items)
								{
									if (item.product_id == 4927)
									{
										isCashout = true;
										break;
									}

									if (item.sku != "")
									{
										isComandaOk = false;
										break;
									}
									
								}
								if (isComandaOk == true)
								{
									nrComenziAcceptate++;// pentru a contoriza comenzile acceptate care au venit
									if (isCashout == true)
									{
										//pentru clientii care sunt cu cashout
										var client = Clienti.GetClientByWcID(wc_id);
										if (client != null)
										{
											botDriver.SaveDetailsFromSite(totalComandat, client["Nume"].AsString, client["Prenume"].AsString, client["Adresa"].AsString, "", client["Oras"].AsString, client["Judet"].AsString, client["Cod_Postal"].AsString, client["Tara"].AsString, client["Email"].AsString, client["Telefon"].AsString, "", client["SerieCard"].AsString);
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul "+ client["NumeClient"].AsString + " a fost identificat cu success in baza de date! Alimentare card in curs...." + "\r\n";
											await Task.Run(botDriver.startBotAlimentareCard);
											LastComanda lc = new LastComanda(newID);
											lc.SaveLastIndexComanda(newID);
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "ID-ul ultimei comenzi a fost salvat cu succes!" + "\r\n";
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Alimentarea cardului pentru clientul " + client["NumeClient"].AsString + " a fost finalizata cu success!" + "\r\n";
										}
										else
										{
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul cu id-ul " + wc_id + " nu a fost gasit in baza de date" + "\r\n";
										}
									}
									else
									{
										DateTime tmpDataCreare = DateTime.Parse(date_creare, null, DateTimeStyles.RoundtripKind);
										botDriver.SaveDetailsFromSite(totalComandat, clientNume, clientPrenume, adresa1, adresa2, oras, judet, codPostal, tara, email, telefon, paymentMethod, numar_serie);
										//
										await Task.Run(botDriver.startBotCardNou);// dat parametru aici daca e card nou sau alimentare
																				  //botDriver.startBot();
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + clientNume + " " + clientPrenume + " cu cardul " + numar_serie + " a fost adaugat cu succes!" + "\r\n";
										intNrCard++;
										this.numar_card = intNrCard.ToString().PadLeft(5, '0');
										NumarGenerator ng = new NumarGenerator(this.numar_card);
										ng.SaveLastNrCard(this.numar_card);
										numar_serie = this.numar_card + this.serie_card;
										LastComanda lc = new LastComanda(newID);
										lc.SaveLastIndexComanda(newID);
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Numarul cardului si ID-ul ultimei comenzi a fost salvata cu succes!" + "\r\n";
										// ultima data salvam clientul in baza
										fullName = clientNume + " " + clientPrenume;
										fullSerie = this.numar_card + this.serie_card;
										Clienti client = new Clienti(fullName, fullSerie, totalComandat, tmpDataCreare, paymentMethod
																	, wc_id, clientNume, clientPrenume, adresa1
																	, oras, judet, codPostal, tara, telefon, total_consum, email);
										client.SaveClient();
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + fullName + " a fost salvat cu success!" + "\r\n";
										frmMain.main.UpdateClienti = Clienti.GetCountClienti().ToString();
										frmMain.main.UpdateSuma = "LEI " + Clienti.GetSumaClienti().ToString();
									}
								}
							}

						}// ies
						break;
					} 
					else
					{
						foreach (var order in orders)
						{
							isComandaOk = true;
							newID = (int)order.id;
							if (this.last_id < newID)
							{
								totalComandat = (float)order.total;
								clientNume = order.billing.first_name;
								clientPrenume = order.billing.last_name;
								adresa1 = order.billing.address_1;
								adresa2 = order.billing.address_2;
								oras = order.billing.city;
								judet = order.billing.state;
								codPostal = order.billing.postcode;
								tara = order.billing.country;
								email = order.billing.email;
								telefon = order.billing.phone;
								paymentMethod = order.payment_method_title;
								date_creare = order.date_created.ToString();
								wc_id = (int)order.customer_id;
								var line_items = order.line_items;
								foreach (var item in line_items)
								{
									if (item.product_id == 4927)
									{
										isCashout = true;
										break;// daca am gasit articolul cu id-ul asta stiu ca au fost scosi banii
									}

									if (item.sku != "")
									{
										isComandaOk = false;
										break;
									}
								}
								if (isComandaOk == true){
									nrComenziAcceptate++;
									if (isCashout == true)
									{
										//pentru clientii care sunt cu cashout
										var client = Clienti.GetClientByWcID(wc_id);
										if (client != null)
										{
											botDriver.SaveDetailsFromSite(totalComandat, client["Nume"].AsString, client["Prenume"].AsString, client["Adresa"].AsString, "", client["Oras"].AsString, client["Judet"].AsString, client["Cod_Postal"].AsString, client["Tara"].AsString, client["Email"].AsString, client["Telefon"].AsString, "", client["SerieCard"].AsString);
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + client["NumeClient"].AsString + " a fost identificat cu success in baza de date! Alimentare card in curs...." + "\r\n";
											await Task.Run(botDriver.startBotAlimentareCard);
											LastComanda lc = new LastComanda(newID);
											lc.SaveLastIndexComanda(newID);
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "ID-ul ultimei comenzi a fost salvat cu succes!" + "\r\n";
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Alimentarea cardului pentru clientul " + client["NumeClient"].AsString + " a fost finalizata cu success!" + "\r\n";
										}
										else
										{
											frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul cu id-ul " + wc_id + " nu a fost gasit in baza de date" + "\r\n";
										}

									}
									else
									{
										DateTime tmpDataCreare = DateTime.Parse(date_creare, null, DateTimeStyles.RoundtripKind);
										botDriver.SaveDetailsFromSite(totalComandat, clientNume, clientPrenume, adresa1, adresa2, oras, judet, codPostal, tara, email, telefon, paymentMethod, numar_serie);
										await Task.Run(botDriver.startBotCardNou);
										//botDriver.startBot();
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + clientNume + " " + clientPrenume + " cu cardul " + numar_serie + " a fost adaugat cu succes!" + "\r\n";
										intNrCard++;
										this.numar_card = intNrCard.ToString().PadLeft(5, '0');
										NumarGenerator ng = new NumarGenerator(this.numar_card);
										ng.SaveLastNrCard(this.numar_card);
										numar_serie = this.numar_card + this.serie_card;
										LastComanda lc = new LastComanda(newID);
										lc.SaveLastIndexComanda(newID);
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Numarul cardului si ID-ul ultimei comenzi a fost salvata cu succes!" + "\r\n";
										fullName = clientNume + " " + clientPrenume;
										Clienti client = new Clienti(fullName, numar_serie, totalComandat, tmpDataCreare, paymentMethod
																	, wc_id, clientNume, clientPrenume, adresa1, oras, judet
																	, codPostal, tara, telefon, total_consum, email);
										client.SaveClient();
										frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Clientul " + fullName + " a fost salvat cu success!" + "\r\n";
										frmMain.main.UpdateClienti = Clienti.GetCountClienti().ToString();
										frmMain.main.UpdateSuma = "LEI " + Clienti.GetSumaClienti().ToString();
									}
								}
							}

						}// increment
						pageNum++;
					}
				}
				//pus sa scrie in log in caz ca nu sunt comenzi
				if(nrComenziAcceptate == 0)
				{
					frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Nu exista comenzi noi de generat!\r\n";

				}
				// pus ca sa scrie in log dupa ce termina
				int interval_verificare = frmMain.GetNextIntervalValue();
				DateTime newDate = DateTime.Now.AddMinutes(interval_verificare);
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + "Urmatoarea verificare este la data:" + newDate.ToString("dd/MM/yyyy hh:mm:ss") + "\r\n";
			}
			catch (Exception ex)
			{
				frmMain.main.Log = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "] - " + ex.Message + Environment.NewLine;
			}
		}

	}
}
