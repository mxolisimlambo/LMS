using LMS.Domain.Entities.Courses.Information;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Information;

public class CourseOutcomeConfiguration
    : IEntityTypeConfiguration<CourseOutcome>
{
    public void Configure(
        EntityTypeBuilder<CourseOutcome> builder)
    {
        builder.ToTable("CourseOutcomes");

        builder.HasKey(x => x.CourseOutcomeId);

        builder.Property(x => x.CourseOutcomeId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.Outcome)
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