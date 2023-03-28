using Mongo.DrivenAdapter.EntitiesMongo;
using Mongo.DrivenAdapter.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.DrivenAdapter
{
	public class Context :  IContext
	{
		private readonly IMongoDatabase _database;

		public Context(string stringConnection, string DBname)
		{
			MongoClient cliente = new MongoClient(stringConnection);
			_database = cliente.GetDatabase(DBname);
		}

		public IMongoCollection<MarcaEntitie> Marcas => _database.GetCollection<MarcaEntitie>("marcas");
	}
}
