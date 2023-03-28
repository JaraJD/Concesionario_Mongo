using Domain.Entities.Commands;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway;
using Domain.UseCases.Gateway.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.UseCases
{
	public class MarcaUseCase : IMarcaUseCase
	{

		private readonly IMarcaRepository _marcaRepository;

		public MarcaUseCase(IMarcaRepository marcaRepository) 
		{
			_marcaRepository = marcaRepository;
		}

		public async Task<Marca> ActualizarMarca(string idMarca, Marca marca)
		{
			return await _marcaRepository.PutMarcaAsync(idMarca, marca);
		}

		public async Task<InsertNewMarca> AgregarMarca(InsertNewMarca marca)
		{
			return await _marcaRepository.InsertMarcaAsync(marca);
		}

		public async Task<Marca> BorrarMarca(string idMarca)
		{
			return await _marcaRepository.DeleteMarcaAsync(idMarca);
		}

		public async Task<List<InsertNewMarca>> ObtenerListaMarcas()
		{
			return await _marcaRepository.GetAllMarcasAsync();
		}

		//public async Task<Marca> ObtenerMarcaPorId(string idMarca)
		//{
		//	return await _marcaRepository.GetMarcaByIdAsync(idMarca);
		//}
	}
}
