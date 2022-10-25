using Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers {
    public class AppSettingsController : ApiController {

        [HttpGet("")]
        public IActionResult GetAllSettings() {
            return Ok(new List<AppSetting>()
            {
                new AppSetting() { ID = 1, Key = "Owner", Value = "ReGo"},
                new AppSetting() { ID = 2, Key = "IsDefault", Value = "Yes"}
            });
        }
    }
}
