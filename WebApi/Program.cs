using data;
using Microsoft.EntityFrameworkCore;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddNewtonsoftJson();  // This replaces the default System.Text.Json-based input and output
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
// TODO: Add NLog

var dbConnex = builder.Configuration.GetConnectionString("AppDbConnex");
builder.Services.AddPostgreSQL(dbConnex);
await AppDbContext.ApplyMigrationsAsync(dbConnex);

builder.Services.AddUnitOfWork();

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