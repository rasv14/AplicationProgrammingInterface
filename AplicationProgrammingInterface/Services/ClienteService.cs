using AplicationProgrammingInterface.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace AplicationProgrammingInterface.Services
{
    public class ClienteService : IEntidadesService<Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;


        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Cliente Registrar(Cliente datos)
        {
            try
            {

                _unitOfWork.Cliente.Add(datos);
                _unitOfWork.Complete();


                var cliente_creado = _unitOfWork.Cliente.GetById(datos.Id);
                return cliente_creado;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
