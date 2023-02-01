using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlinulCuBuletinul
{
	public class NumarGenerator
	{
		public int id { get; set; }
		public string nrCard { get; set; }

		public NumarGenerator(string _nrCard)
		{
			this.nrCard = _nrCard;
		}
		public void SaveLastNrCard(string numarCard)
		{
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory()+ "\\" + "plinulcubuletinul.db"))
			{
				// Get a collection (or create, if doesn't exist)
				var colIndex = db.GetCollection<NumarGenerator>("application_index_numar_card");
				colIndex.EnsureIndex(x => x.nrCard, true);
				
				if (colIndex.Count() != 0)
				{
					var lastNrCard = colIndex.FindAll().First();
					lastNrCard.nrCard = numarCard;
					colIndex.Update(lastNrCard);
				}
				else
				{
					var lastNrCard = new NumarGenerator(nrCard = numarCard);
					colIndex.Insert(lastNrCard);
				}

			}
		}
		public string GetLastNrCard()
		{
			string lastNrCard = "";
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\" + "plinulcubuletinul.db"))
			{
				// Get a collection (or create, if doesn't exist)
				var colIndex  = db.GetCollection<NumarGenerator>("application_index_numar_card");
				if (colIndex.Count() != 0)
				{
					var tmplastNrCard = colIndex.FindAll().First();
					lastNrCard = tmplastNrCard.nrCard;
				} 
			
				return lastNrCard;

			}


		}


	}
}
