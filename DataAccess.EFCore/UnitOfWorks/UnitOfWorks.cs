using DataAccess.EFCore.Repositories;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly PichinchaContext _context;
        public UnitOfWorks(PichinchaContext context)
        {
            _context = context;
            Persona = new PersonaRepository(_context);
            Cliente = new ClienteRepository(_context);
            Cuenta = new CuentaRepository(_context);
            Movimientos = new MovimientosRepository(_context);

        }

        public IPersonaRepository Persona { get; private set; }
        public IClienteRepository Cliente { get; private set; }
        public ICuentaRepository Cuenta { get; private set; }
        public IMovimientosRepository Movimientos { get; private set; }
  

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
