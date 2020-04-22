using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class EmploeeSkillConfig : IEntityTypeConfiguration<EmploeeSkill>
    {
        public void Configure(EntityTypeBuilder<EmploeeSkill> builder)
        {
            builder.HasKey(p => new { p.EmploeeId, p.SkillId });
            builder.Property(x => x.KnowledgeLevel).IsRequired();
        }
    }
}
