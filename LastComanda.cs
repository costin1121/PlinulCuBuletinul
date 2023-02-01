using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace PlinulCuBuletinul
{
	public class LastComanda
	{

		public int id { get; set; }
		public int ComandaLastID { get; set; }

		public LastComanda(int _comandaLastID)
		{
			ComandaLastID = _comandaLastID;
		}

		public void SaveLastIndexComanda(int Comandaid)
		{
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\"+ "plinulcubuletinul.db"))
			{
				// Get a collection (or create, if doesn't exist)
				var colIndex = db.GetCollection<LastComanda>("application_index_lastComanda");
				var lastComandaID = new LastComanda(ComandaLastID = Comandaid);
				colIndex.EnsureIndex(x => x.ComandaLastID, true);

				if (colIndex.Count() != 0)
				{
					var lastComanda = colIndex.FindAll().First();
					lastComanda.ComandaLastID = Comandaid;
					colIndex.Update(lastComanda);
				}
				else
				{
					var lastComanda = new LastComanda(ComandaLastID = Comandaid);
					colIndex.Insert(lastComanda);
				}


			}
		}
		public static int GetLastIndexComandaID()
		{
			int lastComandaID = -1;
			using (var db = new LiteDatabase(@System.IO.Directory.GetCurrentDirectory() + "\\" + "plinulcubuletinul.db"))
			{
				// Get a collection (or create, if doesn't exist)
				var colIndex = db.GetCollection<LastComanda>("application_index_lastComanda");
				if (colIndex.Count() != 0)
				{
					var tmpLastComandaID = colIndex.FindAll().First();
					lastComandaID = tmpLastComandaID.ComandaLastID;
				}

				return lastComandaID;

			}


		}

	}
}
