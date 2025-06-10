namespace TarefasAPI.Infrastructure;
using DotNetEnv;

public class DatabaseConfiguration
{
    public string ConnectionString { get; }

    public DatabaseConfiguration()
    {
        // Carregar variáveis do .env usando DotNetEnv
        DotNetEnv.Env.Load();

        var host = DotNetEnv.Env.GetString("DB_HOST", "localhost");
        var port = DotNetEnv.Env.GetString("DB_PORT", "3306");
        var database = DotNetEnv.Env.GetString("DB_DATABASE") 
            ?? throw new InvalidOperationException("DB_DATABASE não está definido no .env");
        var user = DotNetEnv.Env.GetString("DB_USER") 
            ?? throw new InvalidOperationException("DB_USER não está definido no .env");
        var password = DotNetEnv.Env.GetString("DB_PASSWORD") 
            ?? throw new InvalidOperationException("DB_PASSWORD não está definido no .env");

        ConnectionString = $"Server={host};Port={port};Database={database};User={user};Password={password};";
    }
}