using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class RequirementConfig : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(p => p.Description)
                .HasMaxLength(500);

            //Requirement with UserToRequirement
            builder
                .HasMany(requirement => requirement.UserRequirements)
                .WithOne(employerRequirement => employerRequirement.Requirement)
                .HasForeignKey(employerRequirement => employerRequirement.RequirementId)
                .IsRequired();
        }
    }
}
