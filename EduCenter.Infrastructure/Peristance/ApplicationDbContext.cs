using EduCenter.Application.Abstarction;
using EduCenter.Domain.Entities;
using EduCenter.Infrastructure.Configurations;
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

        public DbSet<StudentRoom> StudentRoom { get; set; }
        public DbSet<StudentTeacher> StudentTeacher { get;set; }
        public DbSet<GroupRoom> GroupRoom { get; set; }


/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        }
*/

    }
}
