using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers {

    /// <summary>
    /// Base class for all API controller of CoreGres project
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase {
    }
}
