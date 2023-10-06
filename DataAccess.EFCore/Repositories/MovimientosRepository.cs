using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class MovimientosRepository : GenericRepository<Movimiento>, IMovimientosRepository
    {
        public MovimientosRepository(PichinchaContext context) : base(context)
        {
        }
    }
}
