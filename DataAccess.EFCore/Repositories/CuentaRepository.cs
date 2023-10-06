using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class CuentaRepository : GenericRepository<Cuentum>, ICuentaRepository
    {

        public CuentaRepository(PichinchaContext context) : base(context)
        {
        }

        public Cuentum GetCuentabyNro(int nro)
        {

            Cuentum cuentaCorrecta = _context.Cuenta.SingleOrDefault(c => c.Numero == nro);

            return cuentaCorrecta;
        }
    }
}
