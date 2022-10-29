using data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");

string dbConnex = string.Empty;

if ((dbUser ?? dbPassword ?? dbName ?? dbHost) == null) {
    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    dbConnex = config.GetConnectionString("AppDbConnex");
}
else {
    dbConnex = $"Host={dbHost};Port=5432;User ID={dbUser};Password={dbPassword};Database={dbName};";
}

try {
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseNpgsql(dbConnex);
    using (var context = new AppDbContext(optionsBuilder.Options)) {
        if ((await context.Database.GetPendingMigrationsAsync()).Any()) {
            await context.Database.MigrateAsync();
            Console.WriteLine("All migrations are applied successfully.");
        }
        else {
            Console.WriteLine("No pending migrations found. The database is already up to date.");
        }
    }
}
catch (Exception ex) {
    // TOOD: log the exception
    Console.WriteLine(ex.Message);
    throw;
}