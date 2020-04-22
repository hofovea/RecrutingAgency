using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class EmployerConfig : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.Property(profile => profile.FullName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(profile => profile.Email)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
