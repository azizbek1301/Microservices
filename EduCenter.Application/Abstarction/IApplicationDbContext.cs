using EduCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.Abstarction
{
    public interface IApplicationDbContext
    {
        public DbSet<School> School { get; set; }
        public DbSet<Group> Group { get; set; }
        
        public DbSet<Room> Room { get; set; }
        public DbSet<Student> Student { get; set; }
        
        public DbSet<Teacher> Teacher { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
