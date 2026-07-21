using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorSocialLinkConfiguration
    : IEntityTypeConfiguration<InstructorSocialLink>
{
    public void Configure(
        EntityTypeBuilder<InstructorSocialLink> builder)
    {
        builder.ToTable("InstructorSocialLinks");

        builder.HasKey(x => x.InstructorSocialLinkId);

        builder.Property(x => x.InstructorSocialLinkId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.Platform)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Url)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.Platform);

        builder.HasIndex(x => x.IsDeleted);
    }
}