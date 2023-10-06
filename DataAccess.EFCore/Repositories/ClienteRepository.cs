using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {

        public ClienteRepository(PichinchaContext context) : base(context)
        {
        }

        public IEnumerable<Cliente> GetClientebyId(Guid id)
        {

            var result = (from cli in _context.Clientes
                          join per in _context.Personas
                          on cli.IdPersona equals per.Id
                          where cli.Id == id
                          select new Cliente
                          {
                              Id = cli.Id,
                              Contrasena = cli.Contrasena,
                              Estado = cli.Estado,
                              IdPersona= per.Id,
                              IdPersonaNavigation = new Persona() { Id = per.Id, Nombre = per.Nombre , Direccion = per.Direccion, Telefono = per.Telefono},
                         
                          }
                           
                          );

            return result;
        }
    }
}
