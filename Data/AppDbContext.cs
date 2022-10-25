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
        public static void ApplyMigrations(string connectionString) {
            DbContextOptionsBuilder<AppDbContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(connectionString);
            using (var context = new AppDbContext(optionsBuilder.Options)) {
                if (context.Database.GetPendingMigrations().Any()) {
                    context.Database.Migrate();
                }
            }
        }

        public DbSet<AppSetting> AppSettings { get; set; }
    }
}
