using data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApi {
    public static class ServiceCollectionExtensions {
        public static void AddUnitOfWork(this IServiceCollection services) {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddPostgreSQL(this IServiceCollection services, string connectionString) {
            services.AddDbContext<AppDbContext>(opt => {
                opt.UseNpgsql(connectionString);
            });
        }
    }
}
