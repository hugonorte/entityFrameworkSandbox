// using Microsoft.EntityFrameworkCore;

// namespace UserAuthApi.Data
// {
//     public class AppDbContext : DbContext
//     {
//         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//         {
//         }

//         public DbSet<User> Users { get; set; }
//     }

//     public class User
//     {
//         public int Id { get; set; }
//         public required string Username { get; set; }
//         public required string PasswordHash { get; set; }
//         public string? TwoFactorSecret { get; set; }
//         public bool IsTwoFactorEnabled { get; set; }
//     }
// }

using Microsoft.EntityFrameworkCore;
using UserAuthApi.Models;

namespace UserAuthApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Categoria> Categorias { get; set; } // ✅ Adicionado
        public DbSet<Tarefa> Tarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                base.OnModelCreating(modelBuilder);
            }
        }
        // (opcional) se você tiver criado a model Tarefa
    }
    

    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public string? TwoFactorSecret { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
    }
}
