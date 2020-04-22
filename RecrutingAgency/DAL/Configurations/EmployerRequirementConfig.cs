using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class EmployerRequirementConfig : IEntityTypeConfiguration<EmployerRequirement>
    {
        public void Configure(EntityTypeBuilder<EmployerRequirement> builder)
        {
            builder.HasKey(p => new { p.EmployerId, p.RequirementId });
            builder.Property(x => x.MinimumKnowledgeLevel).IsRequired();
        }
    }
}
