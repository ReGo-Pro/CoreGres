using data.Interfaces;
using Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories {
    public class AppSettingsRepository : Repository<AppSetting, int>, IAppSettingsRepository {
        public AppSettingsRepository(AppDbContext context) : base(context) { }

        public async Task<AppSetting?> GetByKeyAsync(string key) {
            // TODO: we need a more consistent comparison here
            return await Context.AppSettings.SingleOrDefaultAsync(s => s.Key == key);
        }

        protected override AppDbContext Context => base.Context as AppDbContext;
    }
}
