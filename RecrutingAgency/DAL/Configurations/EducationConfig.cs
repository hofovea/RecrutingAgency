using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class EducationConfig : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.Property(x => x.NameInstitution).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Level).IsRequired().HasMaxLength(20);
            builder.Property(x => x.EntryDate).HasColumnType("date");
            builder.Property(x => x.CloseDate).HasColumnType("date");
        }
    }
}