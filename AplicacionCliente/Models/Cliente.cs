using System.ComponentModel.DataAnnotations;

namespace AplicacionCliente.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Rnc { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
