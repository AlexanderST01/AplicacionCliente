using AplicacionCliente.DAL;
using AplicacionCliente.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AplicacionCliente.BLL
{
    public class ClienteBLL
    {
        private Context _contexto;

        public ClienteBLL (Context contexto)
        {
            _contexto = contexto;
        }

        public bool Existe (int clienteId)
        {
            return _contexto.Clientes
                .Any( c => c.ClienteId == clienteId );
        }

        private bool Insertar (Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Cliente cliente)
        {
            _contexto.Entry(_contexto.Clientes.Find(cliente.ClienteId)!).State = EntityState.Modified;
            _contexto.Entry(cliente).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Guardar(Cliente cliente)
        {
            if (!Existe(cliente.ClienteId))
                return this.Insertar(cliente);
            else
                return this.Modificar(cliente);   
        }

        public bool Eliminar(Cliente cliente)
        {
            _contexto.Entry(_contexto.Clientes.Find(cliente.ClienteId)!)
            .State = EntityState.Detached;
            _contexto.Entry(cliente).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Cliente? Buscar(int clienteId)
        {
            return _contexto.Clientes
                .Where(c => c.ClienteId == clienteId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public Cliente? BuscarNombre(String? nombre)
        {
            return _contexto.Clientes
                .Where(b => b.Nombre == nombre)
                .AsNoTracking()
                .FirstOrDefault();
        }
        public Cliente? BuscarRnc(String? rnc)
        {
            return _contexto.Clientes
                .Where(b => b.Rnc == rnc)
                .AsNoTracking()
                .FirstOrDefault();
        }
        public List<Cliente> GetList(Expression<Func<Cliente, bool>> criterio)
        {
            return _contexto.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}

