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

        public AppSetting? GetByKey(string key) {
            // TODO: we need a more consistent comparison here
            return Context.AppSettings.SingleOrDefault(s => s.Key == key);
        }

        protected override AppDbContext Context => base.Context as AppDbContext;
    }
}
