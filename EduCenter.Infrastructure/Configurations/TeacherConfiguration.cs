using EduCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCenter.Infrastructure.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.TeacherId);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Role).IsRequired();


            builder.HasMany(x => x.StudentTeachers).WithOne(x => x.Teacher).HasForeignKey(x=>x.TeacherId);
        }
    }
}
