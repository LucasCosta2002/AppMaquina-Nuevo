using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMaquina.Shared.DTO
{
    public class TrabajoDTO
    {
        [Required(ErrorMessage = "La Fecha es Obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La cantidad de Hectareas es obligatoria")]
        public int Hectareas { get; set; }

        [Required(ErrorMessage = "El Agroquimico es Obligatorio")]
        public string Agroquimico { get; set; }
        public string Ubicacion { get; set; }
        public int MaquinistaId { get; set; }
        public MaquinistaDTO MaquinistaDTO { get; set; }
        public int ClienteId { get; set; }
        public ClienteDTO ClienteDTO { get; set; }
    }
}
