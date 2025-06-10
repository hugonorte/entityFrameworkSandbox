namespace TarefasAPI.Data;

using TarefasAPI.Models;
using Microsoft.EntityFrameworkCore;

public class TarefasApiContext : DbContext
{
    public TarefasApiContext(DbContextOptions<TarefasApiContext> options)
        : base(options)
    {
    }

    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Tarefa>().ToTable("Tarefa");
    // }
}