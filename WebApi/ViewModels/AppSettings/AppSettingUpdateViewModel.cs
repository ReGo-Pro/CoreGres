using System.ComponentModel.DataAnnotations;

namespace webapi.ViewModels.AppSettings {
    public class AppSettingUpdateViewModel {
        [Required]
        [MaxLength(256)]
        public string Value { get; set; }
    }
}
