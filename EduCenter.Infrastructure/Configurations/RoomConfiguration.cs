using EduCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCenter.Infrastructure.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StudentRooms).IsRequired();
            builder.Property(x => x.RoomNumber).IsRequired();

            builder.HasMany(x=>x.Groups).WithOne(x=>x.Room).HasForeignKey(x=>x.RoomId);
        }
    }
}
