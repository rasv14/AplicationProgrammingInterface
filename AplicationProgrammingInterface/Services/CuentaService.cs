using AplicationProgrammingInterface.Helpers;
using AplicationProgrammingInterface.Interfaces;
using DataAccess.EFCore.UnitOfWorks;
using Domain.Interfaces;
using Domain.Models;

namespace AplicationProgrammingInterface.Services
{
    public class CuentaService : IEntidadesService<Cuentum>
    {
        private readonly IUnitOfWork _unitOfWork;


        public CuentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Cuentum Actualizar(Cuentum datos)
        {
            throw new NotImplementedException();
        }


        public Cuentum ActualizarPorMovimiento(Movimiento datos)
        {
            try
            {
                var cuenta = _unitOfWork.Cuenta.GetById(datos.IdCuenta);

                if (datos.Tipo == EnumTipoCuentas.Retiro.GetDescription())
                {

                    cuenta.Saldo = cuenta.Saldo + datos.Valor;
                }
                else
                {
                    cuenta.Saldo = cuenta.Saldo + datos.Valor;
                }


                _unitOfWork.Cuenta.Update(cuenta);
                _unitOfWork.Complete();
                var cuenta_actualizada = _unitOfWork.Cuenta.GetById(cuenta.Id);
                return cuenta_actualizada;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }


        public Cuentum Registrar(Cuentum datos)
        {
            try
            {


                _unitOfWork.Cuenta.Add(datos);
                _unitOfWork.Complete();


                var cuenta_creada = _unitOfWork.Cuenta.GetById(datos.Id);

                return cuenta_creada;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
