using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Mongo.DrivenAdapter.EntitiesMongo;
using Mongo.DrivenAdapter.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.DrivenAdapter.Repositories
{
	public class MarcaRepository : IMarcaRepository
	{
		private readonly IMongoCollection<MarcaEntitie> mongoCollection;
		private readonly IMapper _mapper;

		public MarcaRepository(IContext context, IMapper mapper)
		{
			mongoCollection = context.Marcas;
			_mapper = mapper;
		}

		public async Task<Marca> DeleteMarcaAsync(string idMarca)
		{
			var filter = Builders<MarcaEntitie>.Filter.Eq(m => m.Id_Mongo, idMarca);
			var marca = await mongoCollection.Find(filter).FirstOrDefaultAsync();

			if(marca == null)
			{
				throw new Exception("El Id ingresado es incorrecto. ");
			}

			marca.IsDeleted = true;
			var updateResult = await mongoCollection.ReplaceOneAsync(filter, marca);
			
			return _mapper.Map<Marca>(marca);
		}

		public async Task<List<InsertNewMarca>> GetAllMarcasAsync()
		{
			var marcas = await mongoCollection.FindAsync(Builders<MarcaEntitie>.Filter.Eq("IsDeleted", false));
			var listaMarcas = marcas.ToEnumerable().Select(marca => _mapper.Map<InsertNewMarca>(marca)).ToList();
			return listaMarcas;
		}

		//public async Task<Marca> GetMarcaByIdAsync(string idMarca)
		//{
		//	var filter = Builders<MarcaEntitie>.Filter.Eq(marca => marca.Id_Mongo, idMarca);
		//	var marca = await mongoCollection.Find(filter).FirstOrDefaultAsync();
		//	return _mapper.Map<Marca>(marca);
		//}

		public async Task<InsertNewMarca> InsertMarcaAsync(InsertNewMarca marca)
		{
			if(marca == null)
			{
				throw new Exception("Datos erroneos. ");
			}
			var insertMarca = _mapper.Map<MarcaEntitie>(marca);
			insertMarca.IsDeleted = false;
			await mongoCollection.InsertOneAsync(insertMarca);
			return marca;
		}

		public async Task<Marca> PutMarcaAsync(string idMarca, Marca marca)
		{
			var filter = Builders<MarcaEntitie>.Filter.Eq(marca => marca.Id_Mongo, idMarca);
			var marcaToUpdate = await mongoCollection.Find(filter).FirstOrDefaultAsync();

			if (marcaToUpdate == null)
			{
				throw new Exception($"Marca con id {idMarca} no encontrada.");
			}

			marcaToUpdate.Nombre_marca = marca.Nombre_marca;
			var updateResult = await mongoCollection.ReplaceOneAsync(filter, marcaToUpdate);

			if (updateResult.ModifiedCount == 0)
			{
				throw new Exception($"No se pudo actualizar la marca con id {idMarca}.");
			}

			return marca;
		}
	}
}
