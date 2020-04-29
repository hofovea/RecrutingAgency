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
                .Property(user => user.FullName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(user => user.Age)
                .IsRequired();
            builder
                .Property(user => user.GitHub)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(user => user.PhoneNumber)
                .HasMaxLength(50);

            //User with UserToRole
            builder
                .HasMany(user => user.Roles)
                .WithOne(userToRole => userToRole.User)
                .HasForeignKey(userToRole => userToRole.UserId)
                .IsRequired();
            //User with JobPosting
            builder
                .HasMany(user => user.JobPostings)
                .WithOne(job => job.Employer)
                .HasForeignKey(job => job.EmployerId)
                .IsRequired();
            //User with User
            builder
                .HasMany(user => user.Recruits)
                .WithOne(recruit => recruit.Employer)
                .HasForeignKey(recruit => recruit.EmployerId);
        }
    }
}
