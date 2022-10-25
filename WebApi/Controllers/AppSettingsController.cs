using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using webapi.Mappers;

namespace webapi.Controllers {
    public class AppSettingsController : ApiController {

        [HttpGet("")]
        public IActionResult GetAllSettings() {
            var result = new List<AppSetting>() {
                new AppSetting() { ID = 1, Key = "Owner", Value = "ReGo"},
                new AppSetting() { ID = 2, Key = "IsDefault", Value = "Yes"}
            };

            return Ok(result.Select(s => s.ToDto()));
        }
    }
}
