using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace data {
    internal class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext() { }

        public DbSet<AppSetting> AppSettings { get; set; }
    }
}
