using System;
using System.Collections.Generic;
using System.Text;
using DAL.Configurations;
using DAL.Entities;
using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DAL.EF
{
    public class Context : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserToRole,
        IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Education> Educations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<UserToSkill> UserSkills { get; set; }
        public DbSet<UserToRequirement> UserRequirements { get; set; }

        public Context(DbContextOptions<Context> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyConfiguration(new EducationConfig());

            modelBuilder.ApplyConfiguration(new UserToSkillConfig());

            modelBuilder.ApplyConfiguration(new UserToRequirementConfig());

            modelBuilder.ApplyConfiguration(new ProjectConfig());

            modelBuilder.ApplyConfiguration(new RequirementConfig());

            modelBuilder.ApplyConfiguration(new SkillConfig());

            modelBuilder.ApplyConfiguration(new WorkExperienceConfig());
        }
    }
}