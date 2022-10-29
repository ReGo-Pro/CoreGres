using data;
using Microsoft.EntityFrameworkCore;

var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "root";
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "123456";
var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "CoreGres";
var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";

var connectionString = $"Host={dbHost};Port=5432;User ID={dbUser};Password={dbPassword};Database={dbName};";

try {
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseNpgsql(connectionString);
    using (var context = new AppDbContext(optionsBuilder.Options)) {
        if ((await context.Database.GetPendingMigrationsAsync()).Any()) {
            await context.Database.MigrateAsync();
        }
    }
}
catch (Exception ex) {
    // TOOD: log the exception
    Console.WriteLine(ex.Message);
    throw;
}