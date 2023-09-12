using AplicacionCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacionCliente.DAL
{
    public class Context: DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }

        public Context( DbContextOptions <Context> options): base(options) 
        { }
    }
}
