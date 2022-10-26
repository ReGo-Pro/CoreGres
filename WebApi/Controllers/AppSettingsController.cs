using data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using webapi.Mappers;
using webapi.ViewModels.AppSettings;
using Microsoft.AspNetCore.JsonPatch;

namespace webapi.Controllers {
    public class AppSettingsController : ApiController {
        private IUnitOfWork _uow;
        private ILogger _logger;

        public AppSettingsController(ILogger<AppSettingsController> logger, IUnitOfWork uow) {
            _uow = uow;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllSettings() {
            try {
                return Ok((await _uow.AppSettingsRepository.FindAllAsync()).Select(s => s.ToDto()));
            }
            catch (Exception e) {
                _logger.LogCritical(e.Message, e);
                return InternalServerError();
            }
        }

        [HttpGet("{key}", Name = "GetSetting")]
        public async Task<IActionResult> GetSetting(string key) {
            if (string.IsNullOrEmpty(key)) {
                return BadRequest();
            }

            try {
                var result = await _uow.AppSettingsRepository.GetByKeyAsync(key);

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
        public async Task<IActionResult> CreateNewAppSetting(AppSettingCreationViewModel dto) {
            if (dto == null || !ModelState.IsValid) {
                return BadRequest();
            }
            try {
                return await savePostedSetting(dto);
            }
            catch (Exception e) {
                _logger.LogCritical(e.Message, e);
                return InternalServerError();
            }
        }

        [HttpPatch("{key}")]
        public async Task<IActionResult> PartiallyUpdateAppSetting(string key, [FromBody] JsonPatchDocument<AppSettingUpdateViewModel> patchDoc) {
            try {
                var setting = await _uow.AppSettingsRepository.GetByKeyAsync(key);
                if (setting == null) {
                    return NotFound();
                }

                // This line is required because we do not get updateDto directly from request body
                var updateDto = new AppSettingUpdateViewModel();
                patchDoc.ApplyTo(updateDto, ModelState);

                if (!ModelState.IsValid) {
                    return BadRequest();
                }

                if (!TryValidateModel(updateDto)) {
                    return BadRequest();
                }

                updateDto.ApplyTo(setting);
                await _uow.CompleteAsync();
                return NoContent();
            }
            catch (Exception e) {
                _logger.LogCritical(e.Message, e);
                return InternalServerError();
            } 
        }

        private async Task<IActionResult> savePostedSetting(AppSettingCreationViewModel dto) {
            var appSetting = dto.ToModel();
            _uow.AppSettingsRepository.Add(appSetting);
            await _uow.CompleteAsync();
            // TODO: we get an exception here. See what's that all about
            return CreatedAtRoute("GetSetting", new { key = dto.Key }, appSetting);
        }
    }
}
