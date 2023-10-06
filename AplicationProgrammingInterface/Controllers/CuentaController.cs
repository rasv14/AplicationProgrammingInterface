using AplicationProgrammingInterface.Clases;
using AplicationProgrammingInterface.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplicationProgrammingInterface.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CuentaController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CuentaController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAllCuentas()
        {
            try
            {
                var cuentas = _unitOfWork.Cuenta.GetAll();
                return Ok(cuentas);
            }
            catch (Exception ex)
            {
                // Capturamos la excepción y la registramos
                Console.WriteLine($"Error: {ex.Message}");

                // Devolvemos una respuesta 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno en el servidor.");
            }

        }




        [HttpPost]
        public IActionResult RegistrarCuenta(ObjCuenta cuenta)
        {

            try
            {



                var validator = new CuentaValidator();
                var validationResult = validator.Validate(cuenta);

                if (validationResult.IsValid)
                {




                    var nuevo_cuenta= new Cuentum
                    {
                        Id = Guid.NewGuid(),
                        Numero= cuenta.Numero,
                        Tipo = cuenta.Tipo,
                        SaldoInicial = cuenta.SaldoInicial,
                        Estado = cuenta.Estado.ToString(),
                        IdCliente= cuenta.IdCliente
                    };




                    CuentaService cuenta_service = new CuentaService(_unitOfWork);



                    var crear_cuenta= cuenta_service.Registrar(nuevo_cuenta);

                    if (crear_cuenta != null)
                    {
                        return Ok(crear_cuenta);
                    }
                    else
                    {
                        return Problem(detail: "No se pudo crear la Cuenta", statusCode: StatusCodes.Status500InternalServerError);

                    }




                }
                else
                {
                    // Los datos no son válidos, muestra los mensajes de error.
                    List<string> lista_validaciones = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                        lista_validaciones.Add(error.ErrorMessage);
                    }

                    return Problem(detail: string.Join(",", new List<string>(lista_validaciones).ToArray()), statusCode: StatusCodes.Status400BadRequest);
                }





            }

            catch (Exception ex)
            {
                // Capturamos la excepción y la registramos
                Console.WriteLine($"Error: {ex.Message}");

               
                // Devolvemos una respuesta 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
