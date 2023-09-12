using System.ComponentModel.DataAnnotations;

namespace AplicacionCliente.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [Required (ErrorMessage ="El nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El Celular es obligatorio")]
        public string? Celular { get; set; }
        [Required(ErrorMessage = "El Rnc es obligatorio")]
        public string? Rnc { get; set; }
        [Required(ErrorMessage = "El Emial es obligatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "La Direccion es obligatorio")]
        public string? Direccion { get; set; }
    }
}
