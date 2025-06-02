using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using UserAuthApi.Data;

namespace UserAuthApi.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=UserAuthDb;user=root;password=123456",
                new MySqlServerVersion(new Version(8, 0, 34))
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
