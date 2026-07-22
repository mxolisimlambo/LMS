using LMS.Domain.Entities.Courses.Information;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Information;

public class CourseFAQConfiguration
    : IEntityTypeConfiguration<CourseFAQ>
{
    public void Configure(
        EntityTypeBuilder<CourseFAQ> builder)
    {
        builder.ToTable("CourseFAQs");

        builder.HasKey(x => x.CourseFAQId);

        builder.Property(x => x.CourseFAQId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.Question)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Answer)
            .HasMaxLength(4000)
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