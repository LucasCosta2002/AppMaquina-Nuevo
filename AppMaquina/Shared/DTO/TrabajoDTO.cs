using System.ComponentModel.DataAnnotations;

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
        public int ClienteId { get; set; }
    }
}
