using LiteDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PlinulCuBuletinul
{
	public class Clienti
	{
		public int id { get; set; }
		public string NumeClient { get; set; }
		public string SerieCard { get; set; }
		public Double SumaCard { get; set; }
		public DateTime DataCreareCard { get; set; }
		public string TipCard { get; set; }
		public int woocommerce_id { get; set; }
		public string Nume { get; set; }
		public string Prenume { get; set; }
		public string Adresa { get; set; }
		public string Oras { get; set; }
		public string Tara { get; set; }
		public string Cod_Postal { get; set; }
		public string Judet { get; set; }

		public string email { get; set; }

		public string Telefon { get; set; }

		public double TotalConsum { get; set; }


		public Clienti(string Nume_Client, string Serie_Card, Double Suma_Card, DateTime Data_Creare_Card
			, string tip_card, int wc_id, string FirstName, string LastName
			, string Address, string City, string State, string PostCode, string Country, string Phone, double total_consum, string emailClient)
		{
			this.NumeClient = Nume_Client;
			this.SerieCard = Serie_Card;
			this.SumaCard = Suma_Card;
			this.DataCreareCard = Data_Creare_Card;
			this.TipCard = tip_card;
			this.woocommerce_id = wc_id;
			this.Nume = FirstName;
			this.Prenume = LastName;
			this.Adresa = Address;
			this.Oras = City;
			this.Tara = Country;
			this.Cod_Postal = PostCode;
			this.Judet = State;
			this.Telefon = Phone;
			this.TotalConsum = total_consum;
			this.email = emailClient;
		}

		public static int GetCountClienti()
		{
			int countClienti = 0;
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\" + "plinulcubuletinul.db"))
			{
				// Get a collection (or create, if doesn't exist)
				var clienti = db.GetCollection<Clienti>("clienti");
				countClienti = clienti.Count();
			}
				return countClienti;
		}

		public static double GetSumaClienti()
		{
			double sumaClienti = 0;
			
			
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\" + "plinulcubuletinul.db"))
			{
				// Get a collection (or create, if doesn't exist)
				var clienti = db.GetCollection("clienti");
				clienti.EnsureIndex("id");
				
				var result = clienti.FindAll();
				if (result.Count() != 0)
				{
					foreach (BsonDocument item in result)
					{
						sumaClienti += item["SumaCard"];

					}
				}
			}
			return sumaClienti;
		}

		public static List<BsonDocument> GetClientByCodCard(string codCard)
		{
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\" + "plinulcubuletinul.db"))
			{
				var collection = db.GetCollection("clienti");
				var query = Query.EQ("SerieCard", codCard);
				var result = collection.Find(query);

				return result.ToList();
			}
		}

		public static BsonDocument GetClientByWcID(int wcID)
		{
			BsonDocument clienti = null;
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\" + "plinulcubuletinul.db"))
			{
				var collection = db.GetCollection("clienti");
				clienti = collection.FindOne(Query.EQ("woocommerce_id", wcID));

				return clienti;
			}
		}

		public static void UpdateTotalConsumByCodCard(string codCard, double totalConsum)
		{
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\" + "plinulcubuletinul.db"))
			{
				var collection = db.GetCollection("clienti");

				var documents = collection.Find(Query.EQ("SerieCard", codCard));

				foreach (var document in documents)
				{
					document["totalConsum"] = totalConsum;
					collection.Update(document);
				}
			}
		}

			
		
		public void SaveClient()
		{
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\" + "plinulcubuletinul.db"))
			{
				// Get a collection (or create, if doesn't exist)
				var clienti = db.GetCollection<Clienti>("clienti");
				var clientiInsert = new Clienti(this.NumeClient, this.SerieCard, this.SumaCard, this.DataCreareCard
												, this.TipCard, this.woocommerce_id, this.Nume, this.Prenume,this.Adresa
												,this.Oras, this.Judet, this.Cod_Postal, this.Tara, this.Telefon, this.TotalConsum, this.email);
				clienti.EnsureIndex(x => x.id, true);

				clienti.Insert(clientiInsert);
			}
		}

	}
}
