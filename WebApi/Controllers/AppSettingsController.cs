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
        public async Task<IActionResult> GetAllSettings() {
            try {
                return Ok((await _uow.AppSettingsRepository.FindAllAsync()).Select(s => s.ToDto()));
            }
            catch (Exception e) {
                // TODO: Log exception
                return InternalServerError();
            }
        }

        [HttpGet("{key}", Name = "GetSetting")]
        public IActionResult GetSetting(string key) {
            if (string.IsNullOrEmpty(key)) {
                return BadRequest();
            }

            try {
                var result = _uow.AppSettingsRepository.GetByKey(key);

                if (result == null) {
                    return NotFound();
                }

                return Ok(result.ToDto());
            }
            catch (Exception e) {
                // TODO: log exception
                return InternalServerError();
            }
        }

        [HttpPost("")]
        public IActionResult CreateNewAppSetting(AppSettingCreationViewModel dto) {
            if (dto == null || !ModelState.IsValid) {
                return BadRequest();
            }
            try {
                return savePostedSetting(dto);
            }
            catch (Exception e) {
                // TODO: log exception
                return InternalServerError();
            }
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
