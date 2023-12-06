using EduCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCenter.Infrastructure.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClassNumber).IsRequired();
            builder.Property(x => x.StudentCount).IsRequired();
        


            builder.HasOne(x => x.School).WithMany(x => x.Groups).HasForeignKey(x => x.SchoolId);


            builder.HasMany(x => x.GroupRooms).WithOne(x => x.Group).HasForeignKey(x=>x.GroupId);
        }
    }
}
