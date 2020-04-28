using System;
using System.Collections.Generic;
using System.Text;
using DAL.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //Role with UserToRole
            builder
                .HasMany(role => role.UserRoles)
                .WithOne(userToRole => userToRole.Role)
                .HasForeignKey(userToRole => userToRole.RoleId)
                .IsRequired();
        }
    }
}
