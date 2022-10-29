using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace data {
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext> {
        public AppDbContext CreateDbContext(string[] args) {
            var designDbConnex = "User ID=root;Password=123456;Host=localhost;Port=5432;Database=CoreGres;";
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(designDbConnex);
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
