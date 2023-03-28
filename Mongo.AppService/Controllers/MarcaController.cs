using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Mongo.AppService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MarcaController : ControllerBase
	{
		private readonly IMarcaUseCase _marcaUseCase;
		private readonly IMapper _mapper;

		public MarcaController(IMarcaUseCase marcaUseCase, IMapper mapper)
		{
			_marcaUseCase = marcaUseCase;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<List<InsertNewMarca>> Obtener_Listado_Marcas()
		{
			return await _marcaUseCase.ObtenerListaMarcas();
		}

		//[HttpGet("/ObtenerPorId/{id}")]
		//public async Task<Marca> Obtener_Marca_Id(string id)
		//{
		//	return await _marcaUseCase.ObtenerMarcaPorId(id);
		//}

		[HttpPost]
		public async Task<InsertNewMarca> Registrar_Marca([FromBody] InsertNewMarca command)
		{
			return await _marcaUseCase.AgregarMarca(command);
		}

		[HttpPut("/ActualizarMarca/{id}")]
		public async Task<Marca> Actualizar_Marca(string id, [FromBody] InsertNewMarca command)
		{
			return await _marcaUseCase.ActualizarMarca(id, _mapper.Map<Marca>(command));
		}

		[HttpDelete("/BorrarMarca/{id}")]
		public async Task<Marca> Borrar_Marca(string id)
		{
			return await _marcaUseCase.BorrarMarca(id);
		}
	}
}
