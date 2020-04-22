using System;
using System.Collections.Generic;
using System.Text;
using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<Education> Educations { get; set; }
        public DbSet<Emploee> Emploees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<EmploeeSkill> EmploeeSkills { get; set; }
        public DbSet<EmployerRequirement> EmployerRequirements { get; set; }

        public Context(DbContextOptions<Context> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region EmploeeAppUser configuration

            modelBuilder.Entity<EmploeeAppUser>()
                .HasOne(emploeeAppUser => emploeeAppUser.Emploee)
                .WithOne(emploee => emploee.EmploeeAppUser)
                .IsRequired();

            #endregion

            #region EmployerAppUser configuration

            modelBuilder.Entity<EmployerAppUser>()
                .HasOne(employerAppUser => employerAppUser.Employer)
                .WithOne(employer => employer.EmployerAppUser)
                .IsRequired();

            #endregion

            #region Emploee configuration

            modelBuilder.ApplyConfiguration(new EmploeeConfig());
            modelBuilder.Entity<Emploee>()
                .HasOne(profile => profile.EmploeeAppUser)
                .WithOne(appUser => appUser.Emploee)
                .HasForeignKey<EmploeeAppUser>(appUser => appUser.EmploeeId)
                .IsRequired();

            #endregion

            #region Employer configuration

            modelBuilder.ApplyConfiguration(new EmployerConfig());
            modelBuilder.Entity<Employer>()
                .HasOne(employer => employer.EmployerAppUser)
                .WithOne(appUser => appUser.Employer)
                .HasForeignKey<EmployerAppUser>(appUser => appUser.EmployerId)
                .IsRequired();

            #endregion

            #region Education configuration

            modelBuilder.ApplyConfiguration(new EducationConfig());
            modelBuilder.Entity<Emploee>()
                .HasMany(emploee => emploee.Educations)
                .WithOne(education => education.EmploeeProfile)
                .HasForeignKey(education => education.EmploeeId)
                .IsRequired();

            #endregion

            #region EmploeeSkill configuration

            modelBuilder.ApplyConfiguration(new EmploeeSkillConfig());
            modelBuilder.Entity<Skill>()
                .HasMany(skill => skill.EmploeeSkills)
                .WithOne(emploeeSkill => emploeeSkill.Skill)
                .HasForeignKey(emploeeSkill => emploeeSkill.SkillId)
                .IsRequired();
            modelBuilder.Entity<Emploee>()
                .HasMany(emploee => emploee.EmploeeSkills)
                .WithOne(emploeeSkill => emploeeSkill.Emploee)
                .HasForeignKey(emploeeSkill => emploeeSkill.EmploeeId)
                .IsRequired();

            #endregion

            #region EmployerRequirement configuration

            modelBuilder.ApplyConfiguration(new EmployerRequirementConfig());
            modelBuilder.Entity<Requirement>()
                .HasMany(requirement => requirement.EmployerRequirements)
                .WithOne(employerRequirement => employerRequirement.Requirement)
                .HasForeignKey(employerRequirement => employerRequirement.RequirementId)
                .IsRequired();
            modelBuilder.Entity<Employer>()
                .HasMany(employer => employer.Requirements)
                .WithOne(employerRequirement => employerRequirement.Employer)
                .HasForeignKey(employerRequirement => employerRequirement.EmployerId)
                .IsRequired();

            #endregion

            #region Project configuration

            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.Entity<Emploee>()
                .HasMany(emploee => emploee.Projects)
                .WithOne(project => project.Emploee)
                .HasForeignKey(project => project.EmploeeId)
                .IsRequired();

            #endregion

            #region Requirement configuration

            modelBuilder.ApplyConfiguration(new RequirementConfig());

            #endregion

            #region Skill configuration

            modelBuilder.ApplyConfiguration(new SkillConfig());

            #endregion

            #region WorkExperience configuration

            modelBuilder.ApplyConfiguration(new WorkExperienceConfig());
            modelBuilder.Entity<Emploee>()
                .HasMany(emploee => emploee.WorkExperiences)
                .WithOne(workExperience => workExperience.Emploee)
                .HasForeignKey(workExperience => workExperience.EmploeeId)
                .IsRequired();

            #endregion
        }
    }
}