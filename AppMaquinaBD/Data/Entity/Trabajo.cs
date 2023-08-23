using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMaquinaBD.Data.Entity
{
    public class Trabajo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La Fecha es Obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La cantidad de Hectareas es obligatoria")]
        public int Hectareas { get; set; }

        [Required(ErrorMessage = "El Agroquimico es Obligatorio")]
        public string Agroquimico { get; set; }
        public string Ubicacion { get; set; }

        [Required]
        public int MaquinistaId { get; set; }
        public Maquinista Maquinista { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int MaquinaId { get; set; }
        public Maquina Maquina { get; set; }
    }
}

