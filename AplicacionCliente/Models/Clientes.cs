using System.ComponentModel.DataAnnotations;

namespace AplicacionCliente.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [Required (ErrorMessage ="El nombre es obligatorio")]
        [StringLength(40, ErrorMessage = "El compo Nombre supera los 40 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        [StringLength(12, ErrorMessage = "El compo Telefono supera los 12 caracteres")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El Celular es obligatorio")]
        [StringLength(12, ErrorMessage = "El compo Celular supera los 12 caracteres")]
        public string? Celular { get; set; }
        [Required(ErrorMessage = "El Rnc es obligatorio")]
        [StringLength(11, ErrorMessage = "El compo  Rnc supera los 11 caracteres")]
        public string? Rnc { get; set; }
        [Required(ErrorMessage = "El Emial es obligatorio")]
        [StringLength(60, ErrorMessage = "El compo Email supera los 60 caracteres")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "La Direccion es obligatorio")]
        [StringLength(80, ErrorMessage = "El compo Direccion supera los 80 caracteres")]
        public string? Direccion { get; set; }
    }
}
