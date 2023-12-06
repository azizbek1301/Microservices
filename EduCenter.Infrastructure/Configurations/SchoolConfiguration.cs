using EduCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCenter.Infrastructure.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Email).IsRequired();


            builder.HasMany(x => x.Teachers).WithOne(x => x.School);
        }
    }
}
