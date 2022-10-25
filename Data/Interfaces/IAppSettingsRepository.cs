using Domain.Core;

namespace data.Interfaces {
    public interface IAppSettingsRepository : IRepository<AppSetting, int> {
        AppSetting? GetByKey(string key);
    }
}
