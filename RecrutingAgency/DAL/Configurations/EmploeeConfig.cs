using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class EmploeeConfig : IEntityTypeConfiguration<Emploee>
    {
        public void Configure(EntityTypeBuilder<Emploee> builder)
        {
            builder.Property(profile => profile.FullName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(profile => profile.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(profile => profile.GitHub)
                .HasMaxLength(50);
        }
    }
}
