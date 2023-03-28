using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Commands
{
	public class InsertNewMarca
	{
		[Required(ErrorMessage = "Nombre de la marca es requerido")]
		public string Nombre_marca { get; set; }
		public string Calidad { get; set; }
		public string Nacionalidad { get; set; }
	}
}
