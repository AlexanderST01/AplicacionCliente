using AplicacionCliente.DAL;
using AplicacionCliente.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AplicacionCliente.BLL
{
    public class ClientesBLL
    {
        private Context _contexto;

        public ClientesBLL (Context contexto)
        {
            _contexto = contexto;
        }

        public bool Existe (int clienteId)
        {
            return _contexto.Clientes
                .Any( c => c.ClienteId == clienteId );
        }

        private bool Insertar (Clientes cliente)
        {
            _contexto.Clientes.Add(cliente);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Clientes cliente)
        {
            _contexto.Entry(_contexto.Clientes.Find(cliente.ClienteId)!).State = EntityState.Modified;
            _contexto.Entry(cliente).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
                return this.Insertar(cliente);
            else
                return this.Modificar(cliente);   
        }

        public bool Eliminar(Clientes cliente)
        {
            _contexto.Entry(_contexto.Clientes.Find(cliente.ClienteId)!)
            .State = EntityState.Detached;
            _contexto.Entry(cliente).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Clientes? Buscar(int clienteId)
        {
            return _contexto.Clientes
                .Where(c => c.ClienteId == clienteId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public Clientes? BuscarNombre(String? nombre)
        {
            return _contexto.Clientes
                .Where(b => b.Nombre == nombre)
                .AsNoTracking()
                .FirstOrDefault();
        }
        public Clientes? BuscarRnc(String? rnc)
        {
            return _contexto.Clientes
                .Where(b => b.Rnc == rnc)
                .AsNoTracking()
                .FirstOrDefault();
        }
        public List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            return _contexto.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}

