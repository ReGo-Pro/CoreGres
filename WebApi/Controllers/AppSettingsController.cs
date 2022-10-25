using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using webapi.Mappers;

namespace webapi.Controllers {
    public class AppSettingsController : ApiController {
        List<AppSetting> settings = new List<AppSetting>() {
            new AppSetting() { ID = 1, Key = "Owner", Value = "ReGo"},
            new AppSetting() { ID = 2, Key = "IsDefault", Value = "Yes"}
        };

        [HttpGet("")]
        public IActionResult GetAllSettings() {
            return Ok(settings.Select(s => s.ToDto()));
        }

        [HttpGet("{key}")]
        public IActionResult GetSetting(string key) {
            if (string.IsNullOrEmpty(key)) {
                return BadRequest();
            }

            var result = settings.Where(s => s.Key.Equals(key, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
            
            if (result == null) {
                return NotFound();
            }

            return Ok(result.ToDto());
        }
    }
}
