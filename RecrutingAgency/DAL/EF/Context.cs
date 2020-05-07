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
        public DbSet<JobPosting> JobPostings { get; set; }

        public Context(DbContextOptions<Context> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyConfiguration(new JobPosingConfig());
        }
    }
}