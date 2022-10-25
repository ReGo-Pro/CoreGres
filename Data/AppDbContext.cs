using data.EntityConfigurations;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new AppSettingEntityConfiguration());
        }

        // TODO: Think about this (where should it be?)
        public static async Task ApplyMigrationsAsync(string connectionString) {
            DbContextOptionsBuilder<AppDbContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(connectionString);
            using (var context = new AppDbContext(optionsBuilder.Options)) {
                if ((await context.Database.GetPendingMigrationsAsync()).Any()) {
                    await context.Database.MigrateAsync();
                }
            }
        }

        public DbSet<AppSetting> AppSettings { get; set; }
    }
}
