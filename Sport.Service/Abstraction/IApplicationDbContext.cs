using Microsoft.EntityFrameworkCore;
using Sport.Domain.Entities;


namespace Sport.DataApplication.Abstraction
{
    public interface IApplicationDbContext
    {
        public DbSet<Team> Teamlar { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Order> Orders { get; set; }

       
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
