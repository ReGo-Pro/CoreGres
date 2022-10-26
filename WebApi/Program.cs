using data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using webapi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddNewtonsoftJson();  // This replaces the default System.Text.Json-based input and output
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnex = builder.Configuration.GetConnectionString("AppDbConnex");
builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseNpgsql(dbConnex);
});
await AppDbContext.ApplyMigrationsAsync(dbConnex);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapDefaultControllerRoute();
app.Run();