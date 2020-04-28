using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class UserToRequirementConfig : IEntityTypeConfiguration<UserToRequirement>
    {
        public void Configure(EntityTypeBuilder<UserToRequirement> builder)
        {
            builder
                .HasKey(p => new { EmployerId = p.UserId, p.RequirementId });
            builder
                .Property(x => x.MinimumKnowledgeLevel)
                .IsRequired();
        }
    }
}
