using AplicationProgrammingInterface.Clases;
using AplicationProgrammingInterface.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace AplicationProgrammingInterface.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ClienteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            try
            {
                var clientes = _unitOfWork.Cliente.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                // Capturamos la excepción y la registramos
                Console.WriteLine($"Error: {ex.Message}");

                // Devolvemos una respuesta 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno en el servidor.");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetClientebyId(string id)
        {
            try
            {
                var cliente = _unitOfWork.Cliente.GetClientebyId(new Guid(id));
                if (cliente == null) { return NotFound(); }

                return Ok(cliente);
            }

            catch (Exception ex)
            {
                // Capturamos la excepción y la registramos
                Console.WriteLine($"Error: {ex.Message}");

                // Devolvemos una respuesta 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno en el servidor.");
            }

        }


        [HttpGet("lanzar-excepcion")]
        public IActionResult LanzarExcepcion()
        {
            throw new ApplicationException("Se ha producido una excepción en la API REST.");
        }



        [HttpPost]
        public IActionResult RegistrarCliente(ObjCliente cliente)
        {

            try
            {



                var validator = new ClienteValidator();
                var validationResult = validator.Validate(cliente);

                if (validationResult.IsValid)
                {


                    var persona = new Persona
                    {
                        Id = Guid.NewGuid(),
                        Nombre = cliente.Nombres,
                        Genero = "-",
                        Edad = 0,
                        Identificacion = "-",
                        Direccion = cliente.Direccion,
                        Telefono = cliente.Telefono

                    };

                    var nuevo_cliente = new Cliente
                    {
                        Id = Guid.NewGuid(),
                        Contrasena = cliente.Contrasena,
                        Estado = cliente.Estado.ToString(),
                        IdPersona = persona.Id,
                        IdPersonaNavigation = persona
                    };

                    ClienteService cliente_service = new ClienteService(_unitOfWork);



                    var crear_cliente = cliente_service.Registrar(nuevo_cliente);

                    if (crear_cliente != null)
                    {
                        return Ok(crear_cliente);
                    }
                    else
                    {
                        return Problem(detail: "No se pudo crear el Cliente", statusCode: StatusCodes.Status500InternalServerError);

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
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno en el servidor.");
            }
        }


    }
}
