using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return Ok("API is working properly.");
        }
    }
}