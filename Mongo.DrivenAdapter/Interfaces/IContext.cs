using Mongo.DrivenAdapter.EntitiesMongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.DrivenAdapter.Interfaces
{
	public interface IContext
	{
		public IMongoCollection<MarcaEntitie> Marcas { get; }
	}
}
