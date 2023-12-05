using EduCenter.Application.Abstarction;
using EduCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Infrastructure.Peristance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<School> School { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }





    }
}
