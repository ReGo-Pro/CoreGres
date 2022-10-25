using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers {

    /// <summary>
    /// Base class for all API controller of CoreGres project
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase {
        protected virtual string ServerErrorMessage { get; set; }
        public ApiController() {
            ServerErrorMessage = "Something went wrong. Plase try again later or contact site admin.";
        }

        [NonAction]
        public IActionResult InternalServerError(string? message = null) {
            return StatusCode(StatusCodes.Status500InternalServerError, message ?? ServerErrorMessage);
        }
    }
}
