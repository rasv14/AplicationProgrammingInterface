using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {

        IPersonaRepository Persona { get; }
        IClienteRepository Cliente { get; }

        ICuentaRepository Cuenta { get; }

        IMovimientosRepository Movimientos { get; }


        int Complete();

    }
}
