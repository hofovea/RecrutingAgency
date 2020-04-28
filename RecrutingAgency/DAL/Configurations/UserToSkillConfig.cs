using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class UserToSkillConfig : IEntityTypeConfiguration<UserToSkill>
    {
        public void Configure(EntityTypeBuilder<UserToSkill> builder)
        {
            builder
                .HasKey(p => new { EmploeeId = p.UserId, p.SkillId });
            builder
                .Property(x => x.KnowledgeLevel)
                .IsRequired();
        }
    }
}
