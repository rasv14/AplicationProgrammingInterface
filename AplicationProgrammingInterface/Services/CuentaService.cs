using AplicationProgrammingInterface.Interfaces;
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
