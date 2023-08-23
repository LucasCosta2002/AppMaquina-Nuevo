using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMaquinaBD.Data.Entity
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        [MaxLength(60, ErrorMessage = "Solo se aceptan hasta 60 caracteres en el Nombre")]
        public string Nombre { get; set; } = "";
        public string Telefono { get; set; } = "";

        [Required(ErrorMessage = "El CUIL es Obligatorio")]
        [MaxLength(11, ErrorMessage = "El CUIL debe tener 11 caracteres")]
        public string CUIL { get; set; } = "";
        public List<Trabajo>? Trabajos { get; set; }
    }
}
