using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reportes
{
    public class ReporteMovimientosFechaUsuario
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }

        public int NumeroCuenta { get; set; }

        public string Tipo { get; set; }

        public double SaldoInicial { get; set; }


        public string Estado { get; set; }


        public double Movimiento { get; set; }


        public double SaldoDisponible { get; set; }
    }
}
