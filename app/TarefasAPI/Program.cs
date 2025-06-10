using Microsoft.EntityFrameworkCore;
using TarefasAPI.Data;
using TarefasAPI.Infrastructure;
using TarefasAPI.Repositories;
using TarefasAPI.Services;
using MySql.EntityFrameworkCore.Extensions; 
using MySql.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var dbConfig = new DatabaseConfiguration();

builder.Services.AddDbContext<TarefasApiContext>(
    options => options.UseMySQL(dbConfig.ConnectionString)
);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CategoriaService>();

var app = builder.Build();

// Teste de conexão com o banco
/* using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TarefasApiContext>();
    try
    {
        dbContext.Database.OpenConnection();
        dbContext.Database.CloseConnection();
        Console.WriteLine("Conexão com o banco de dados bem-sucedida!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
    }
} */

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

