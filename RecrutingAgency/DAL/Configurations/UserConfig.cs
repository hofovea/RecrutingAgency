using DAL.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(profile => profile.FullName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(profile => profile.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(profile => profile.Age)
                .IsRequired();
            builder
                .Property(profile => profile.GitHub)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(profile => profile.Phone)
                .HasMaxLength(50);
            builder
                .Property(profile => profile.ImageProfileUrl)
                .HasMaxLength(50);
            builder
                .Property(profile => profile.Address)
                .HasMaxLength(50);

            //User with UserToRole
            builder
                .HasMany(user => user.Roles)
                .WithOne(userToRole => userToRole.User)
                .HasForeignKey(userToRole => userToRole.UserId)
                .IsRequired();
            //User with Education
            builder
                .HasMany(user => user.Educations)
                .WithOne(education => education.User)
                .HasForeignKey(education => education.UserId)
                .IsRequired();
            //User with UserToSkill
            builder
                .HasMany(user => user.UserSkills)
                .WithOne(userSkill => userSkill.User)
                .HasForeignKey(userSkill => userSkill.UserId)
                .IsRequired();
            //User with UserToRequirement
            builder
                .HasMany(user => user.UserRequirements)
                .WithOne(userRequirement => userRequirement.User)
                .HasForeignKey(employerRequirement => employerRequirement.UserId)
                .IsRequired();
            //User with Project
            builder
                .HasMany(user => user.Projects)
                .WithOne(project => project.User)
                .HasForeignKey(project => project.UserId)
                .IsRequired();
            //User with WorkExperience
            builder
                .HasMany(user => user.WorkExperiences)
                .WithOne(workExperience => workExperience.User)
                .HasForeignKey(workExperience => workExperience.UserId)
                .IsRequired();
        }
    }
}
