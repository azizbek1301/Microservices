using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Sport.DataApplication.Abstraction;
using Sport.Domain.Entities;

namespace Sport.Infrastructure.Peristance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            try
            {
                if (databaseCreator is null)
                {
                    throw new Exception("Database Not Found!");
                }

                if (!databaseCreator.CanConnect())
                    databaseCreator.CreateAsync();

                if (!databaseCreator.HasTables())
                    databaseCreator.CreateTablesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=sqldata;Initial Catalog=footballDb;User Id=SA;Password=Numsey#2022;Persist Security Info=True;;TrustServerCertificate=true", builder =>
            //{
            //    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            //});
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
