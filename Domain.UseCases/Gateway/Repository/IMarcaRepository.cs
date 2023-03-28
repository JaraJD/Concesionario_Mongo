using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Commands;

namespace Domain.UseCases.Gateway.Repository
{
	public interface IMarcaRepository
	{
		Task<InsertNewMarca> InsertMarcaAsync(InsertNewMarca marca);

		Task<List<InsertNewMarca>> GetAllMarcasAsync();

		//Task<Marca> GetMarcaByIdAsync(string idMarca);

		Task<Marca> PutMarcaAsync(string idMarca, Marca marca);

		Task<Marca> DeleteMarcaAsync(string idMarca);

	}
}
