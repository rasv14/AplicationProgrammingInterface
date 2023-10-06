using AplicationProgrammingInterface.Interfaces;
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


        public Movimiento Registrar(Movimiento datos)
        {
            try
            {
                _unitOfWork.Movimientos.Add(datos);
                _unitOfWork.Complete();
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
