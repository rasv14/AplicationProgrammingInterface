using Domain.Models;
using Domain.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMovimientosRepository : IGenericRepository<Movimiento>
    {

        IEnumerable<ReporteMovimientosFechaUsuario> GetMovimientosbyFechaUsuario(Guid id, string fecha);
    }
}
