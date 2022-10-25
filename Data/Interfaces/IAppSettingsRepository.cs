using Domain.Core;

namespace data.Interfaces {
    public interface IAppSettingsRepository : IRepository<AppSetting, int> {
        Task<AppSetting?> GetByKeyAsync(string key);
    }
}
