using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using ApiTasks.Data;
using ApiTasks.Repositories;
using ApiTasks.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Adiciona serviços do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiTasks", Version = "v1" });
});

// Configurar MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string is not configured.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Adição dos repositórios para ID
builder.Services.AddScoped<CategoriaRepository>();

// Adição dos services para ID
builder.Services.AddScoped<CategoriaService>();

var app = builder.Build();

// Configura o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiTasks v1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();



