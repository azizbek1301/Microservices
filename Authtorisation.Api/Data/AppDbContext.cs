using Authtorisation.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Authtorisation.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source =sqldata;Initial Catalog=aaa;Persist Security Info=True;User ID =SA;Password=Numsey#2022;Connect Timeout = 30;Encrypt=False;TrustServerCertificate=True;Application Intent = ReadWrite;MultipleActiveResultSets=false;MultiSubnetFailover=True; Application Name=Ovit_Software;Pooling=True;");
        }
        public DbSet<User> Users { get; set; }
    }
}
