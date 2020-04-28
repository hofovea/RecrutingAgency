using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class WorkExperienceConfig : IEntityTypeConfiguration<WorkExperience>
    {
        public void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            builder
                .Property(x => x.Company)
                .IsRequired()
                .HasMaxLength(64);
            builder
                .Property(x => x.Position)
                .IsRequired()
                .HasMaxLength(64);
            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(1024);
            builder
                .Property(x => x.EntryDate)
                .HasColumnType("date");
            builder
                .Property(x => x.CloseDate)
                .HasColumnType("date");
        }
    }
}