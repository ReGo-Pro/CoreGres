using Microsoft.EntityFrameworkCore;

namespace data {
    internal class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
