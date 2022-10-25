using data.Interfaces;
using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using webapi.Mappers;

namespace webapi.Controllers {
    public class AppSettingsController : ApiController {
        public IUnitOfWork _uow;

        public AppSettingsController(IUnitOfWork uow) {
            _uow = uow;
        }

        [HttpGet("")]
        public IActionResult GetAllSettings() {
            return Ok(_uow.AppSettingsRepository.FindAll().Select(s => s.ToDto()));
        }

        [HttpGet("{key}")]
        public IActionResult GetSetting(string key) {
            if (string.IsNullOrEmpty(key)) {
                return BadRequest();
            }

            var result = _uow.AppSettingsRepository.GetByKey(key);
            
            if (result == null) {
                return NotFound();
            }

            return Ok(result.ToDto());
        }
    }
}
