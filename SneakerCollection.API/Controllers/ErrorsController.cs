using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SneakerCollection.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem(detail: exception?.Message);
        }
    }
}
