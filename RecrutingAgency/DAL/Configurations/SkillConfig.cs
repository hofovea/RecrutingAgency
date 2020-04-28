using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class SkillConfig : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(64);
            builder
                .Property(p => p.Description)
                .HasMaxLength(512);

            //Skill with UserToSkill
            builder
                .HasMany(skill => skill.UserSkills)
                .WithOne(userToSkill => userToSkill.Skill)
                .HasForeignKey(userToSkill => userToSkill.SkillId)
                .IsRequired();
        }
    }
}
