using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;
using Mongo.DrivenAdapter.EntitiesMongo;

namespace Mongo.AppService.Automapper
{
	public class ConfigurationProfile :  Profile
	{
		public ConfigurationProfile()
		{
			CreateMap<InsertNewMarca, Marca>().ReverseMap();
			CreateMap<MarcaEntitie, Marca>().ReverseMap();
			CreateMap<MarcaEntitie, InsertNewMarca>().ReverseMap();

			CreateMap<InsertNewConcesionario, Domain.Entities.Entities.Concesionario>().ReverseMap();

			CreateMap<InsertNewAuto, Auto>().ReverseMap();

		}
	}
}
