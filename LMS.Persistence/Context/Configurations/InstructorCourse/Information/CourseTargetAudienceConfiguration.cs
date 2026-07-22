using LMS.Domain.Entities.Courses.Information;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Information;

public class CourseTargetAudienceConfiguration
    : IEntityTypeConfiguration<CourseTargetAudience>
{
    public void Configure(
        EntityTypeBuilder<CourseTargetAudience> builder)
    {
        builder.ToTable("CourseTargetAudiences");

        builder.HasKey(x => x.CourseTargetAudienceId);

        builder.Property(x => x.CourseTargetAudienceId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.Audience)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .HasDefaultValue(0);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.DisplayOrder);

        builder.HasIndex(x => x.IsDeleted);
    }
}