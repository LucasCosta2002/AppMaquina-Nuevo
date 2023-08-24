using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMaquinaBD.Data.Entity
{
    public class Maquinista
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        [MaxLength(60, ErrorMessage = "Solo se aceptan hasta 60 caracteres en el Nombre")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El DNI es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el DNI")]

        public string DNI { get; set; }

        [Required(ErrorMessage = "El Email es Obligatorio")]
        [MaxLength(60, ErrorMessage = "Solo se aceptan hasta 60 caracteres en el Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "El Telefono es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el Telefono")]
        public string Telefono { get; set; } = "";
        
        [Required(ErrorMessage = "La contraseña es Obligatoria")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; }

        public List<Trabajo>? Trabajos { get; set; }
    }
}
