using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AplicationProgrammingInterface.Controllers
{

    public class ExcepcionController : Controller
    {
        private readonly ILogger<ExcepcionController> _logger;


        public ExcepcionController(ILogger<ExcepcionController> logger)
        {
            _logger = logger;
        }


        [HttpGet, Route("/error")]
        public IActionResult ManejarExcepcion()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exceptionFeature != null)
            {
                _logger.LogError($"Error: {exceptionFeature.Error}");

                
                return Problem(detail: exceptionFeature.Error.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
