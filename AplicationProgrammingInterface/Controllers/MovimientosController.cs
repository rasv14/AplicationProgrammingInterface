using AplicationProgrammingInterface.Clases;
using AplicationProgrammingInterface.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplicationProgrammingInterface.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovimientosController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;

        public MovimientosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetAllMovimientos()
        {
            try
            {
                var movimientos = _unitOfWork.Movimientos.GetAll();
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                // Capturamos la excepción y la registramos
                Console.WriteLine($"Error: {ex.Message}");

                // Devolvemos una respuesta 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno en el servidor.");
            }

        }


        [HttpGet]
        public IActionResult GetMovimientosbyFechasUsuario(string id_usuario , string fecha_inicio, string fecha_fin)
        {
            try
            {
                var movimientos = _unitOfWork.Movimientos.GetMovimientosbyFechaUsuario(new Guid(id_usuario), fecha_inicio,fecha_fin);
                return Ok(movimientos);
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
        public IActionResult RegistrarMovimiento(ObjMovimientos movimiento)
        {

            try
            {



                var validator = new MovimientosValidator();
                var validationResult = validator.Validate(movimiento);

                if (validationResult.IsValid)
                {

                    var validator_bd = new MovimientosValidator(_unitOfWork);
                    if (!validator_bd.ValidarRegistro(movimiento))
                    { return Problem(detail: "El movimiento no es valido", statusCode: StatusCodes.Status400BadRequest); }

                    MovimientosService movimiento_service = new MovimientosService(_unitOfWork);
                    CuentaService cuenta_service = new CuentaService(_unitOfWork);

                    var cuenta = _unitOfWork.Cuenta.GetCuentabyNro(movimiento.NumeroCuenta);
                    var nuevo_movimiento = new Movimiento
                    {
                        Id = Guid.NewGuid(),
                        Fecha = DateTime.Now,
                        Tipo = movimiento.Tipo,
                        Valor = movimiento.Valor,
                        Saldo = cuenta.Saldo,
                        IdCuenta = cuenta.Id


                    };

                    var crear_movimiento = movimiento_service.Registrar(nuevo_movimiento);
                 

                    if (crear_movimiento != null)
                    {
                        return Ok(crear_movimiento);
                    }
                    else {
                        return Problem(detail: "No se pudo crear el movimiento", statusCode: StatusCodes.Status500InternalServerError);

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
