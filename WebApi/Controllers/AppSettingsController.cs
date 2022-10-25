using data.Interfaces;
using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using webapi.Mappers;
using webapi.ViewModels.AppSettings;

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

        [HttpGet("{key}", Name = "GetSetting")]
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

        [HttpPost("")]
        public IActionResult CreateNewAppSetting(AppSettingCreationViewModel dto) {
            if (dto == null || !ModelState.IsValid) {
                return BadRequest();
            }
            return savePostedSetting(dto);
        }

        private IActionResult savePostedSetting(AppSettingCreationViewModel dto) {
            var appSetting = dto.ToModel();
            _uow.AppSettingsRepository.Add(appSetting);
            _uow.Complete();
            // TODO: we get an exception here. See what's that all about
            return CreatedAtRoute("GetSetting", new { key = dto.Key }, appSetting);
        }
    }
}
