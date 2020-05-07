using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class JobPosingConfig : IEntityTypeConfiguration<JobPosting>
    {
        public void Configure(EntityTypeBuilder<JobPosting> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);
            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(x => x.Payment)
                .IsRequired();
        }
    }
}
