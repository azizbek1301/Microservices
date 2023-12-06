﻿using EduCenter.Application.Abstarction;
using EduCenter.Domain.Entities;
using EduCenter.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EduCenter.Infrastructure.Peristance
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
            optionsBuilder.UseSqlServer("Data Source=sqldata;Initial Catalog=EduCenterDb;User Id=SA;Password=Numsey#2022;Persist Security Info=True;;TrustServerCertificate=true", builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
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
