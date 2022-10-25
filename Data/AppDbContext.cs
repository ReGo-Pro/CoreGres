using data.EntityConfigurations;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace data {
    internal class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new AppSettingEntityConfiguration());
        }

        public DbSet<AppSetting> AppSettings { get; set; }
    }
}
