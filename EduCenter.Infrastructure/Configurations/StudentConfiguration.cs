using EduCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCenter.Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Gender).IsRequired();




            builder.HasMany(x => x.StudentTeachers).WithOne(x => x.Student).HasForeignKey(x=>x.StudentId);
            builder.HasMany(x => x.StudentRooms).WithOne(x => x.Student).HasForeignKey(x=>x.StudentId);
        }
    }
}
