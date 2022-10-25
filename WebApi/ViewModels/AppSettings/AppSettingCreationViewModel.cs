using System.ComponentModel.DataAnnotations;

namespace webapi.ViewModels.AppSettings {
    // TODO: I might use FluentValidation for these
    public class AppSettingCreationViewModel {
        [Required]
        [MaxLength(256)]
        public string Key { get; set; }

        [Required]
        [MaxLength(256)]
        public string Value { get; set; }
    }
}
