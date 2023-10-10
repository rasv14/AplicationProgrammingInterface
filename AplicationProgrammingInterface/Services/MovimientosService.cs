using AplicationProgrammingInterface.Helpers;
using AplicationProgrammingInterface.Interfaces;
using DataAccess.EFCore.UnitOfWorks;
using Domain.Interfaces;
using Domain.Models;

namespace AplicationProgrammingInterface.Services
{
    public class MovimientosService : IEntidadesService<Movimiento>
    {

        private readonly IUnitOfWork _unitOfWork;
        


        public MovimientosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Movimiento Actualizar(Movimiento datos)
        {
            throw new NotImplementedException();
        }

        public Movimiento Registrar(Movimiento datos)
        {
            try
            {

                 datos.Valor = datos.Tipo == EnumTipoCuentas.Retiro.GetDescription() ? datos.Valor * -1 : datos.Valor;
                _unitOfWork.Movimientos.Add(datos);
                _unitOfWork.Complete();
                CuentaService cuenta_service = new CuentaService(_unitOfWork);
                Cuentum cuenta_actualizada =  cuenta_service.ActualizarPorMovimiento(datos);
                
                var movimiento_creada = _unitOfWork.Movimientos.GetById(datos.Id);
                return movimiento_creada;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
