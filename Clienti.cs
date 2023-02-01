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
		
		public Clienti(string Nume_Client, string Serie_Card, Double Suma_Card, DateTime Data_Creare_Card, string tip_card)
		{
			this.NumeClient= Nume_Client;
			this.SerieCard= Serie_Card;
			this.SumaCard = Suma_Card;
			this.DataCreareCard = Data_Creare_Card;
			this.TipCard= tip_card;
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

			
		
		public void SaveClient()
		{
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\" + "plinulcubuletinul.db"))
			{
				// Get a collection (or create, if doesn't exist)
				var clienti = db.GetCollection<Clienti>("clienti");
				var clientiInsert = new Clienti(this.NumeClient, this.SerieCard, this.SumaCard, this.DataCreareCard, this.TipCard);
				clienti.EnsureIndex(x => x.id, true);

				clienti.Insert(clientiInsert);
			}
		}

	}
}
