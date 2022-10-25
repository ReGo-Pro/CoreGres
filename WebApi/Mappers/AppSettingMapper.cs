using Domain.Core;
using webapi.ViewModels.AppSettings;

// I might use AutoMapper instead
namespace webapi.Mappers {
    public static class AppSettingMapper {
        public static AppSettingViewModel ToDto(this AppSetting model) {
            return new AppSettingViewModel
            {
                ID = model.ID,
                Key = model.Key,
                Value = model.Value
            };
        }

        public static AppSetting ToModel(this AppSettingCreationViewModel dto) {
            return new AppSetting()
            {
                Key = dto.Key,
                Value = dto.Value
            };
        }
    }
}
