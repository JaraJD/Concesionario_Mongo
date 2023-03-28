using Domain.Entities.Commands;
using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Gateway
{
	public interface IMarcaUseCase
	{
		Task<InsertNewMarca> AgregarMarca(InsertNewMarca marca);

		Task<List<InsertNewMarca>> ObtenerListaMarcas();

		//Task<Marca> ObtenerMarcaPorId(string idMarca);

		Task<Marca> ActualizarMarca(string idMarca, Marca marca);

		Task<Marca> BorrarMarca(string idMarca);
	}
}
