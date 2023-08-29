using System.ComponentModel.DataAnnotations;

namespace AppMaquina.Shared.DTO
{
    public class ClienteDTO
    {

        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El CUIL es Obligatorio")]
        public string CUIL { get; set; }
    }
}
