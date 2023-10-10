using Domain.Interfaces;
using Domain.Models;
using Domain.Reportes;
using System;
using System.Collections.Generic;
using System.Globalization;
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



        public IEnumerable<ReporteMovimientosFechaUsuario>  GetMovimientosbyFechaUsuario(Guid id_usuario, string fecha)
        {
            DateTime fechadt = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var result = (from mov in _context.Movimientos
                          join cuen in _context.Cuenta
                          on mov.IdCuenta equals cuen.Id
                          join cli in _context.Clientes
                          on cuen.IdCliente equals cli.Id
                          join per in _context.Personas
                          on cli.IdPersona equals per.Id

                          where cli.Id == id_usuario && mov.Fecha.Date == fechadt
                          select new ReporteMovimientosFechaUsuario
                          {
                              Fecha = mov.Fecha,
                              Cliente= per.Nombre,
                              NumeroCuenta = cuen.Numero,
                              Tipo = cuen.Tipo,
                              SaldoInicial = (double)mov.Saldo,
                              Estado= cuen.Estado,
                              Movimiento = (double)mov.Valor,
                              SaldoDisponible = (double)cuen.Saldo

                          }

                    );
                  
            return result;
        }
    }
}
