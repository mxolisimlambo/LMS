using LMS.Domain.Entities.Courses.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Commerce;

public class CourseDiscountConfiguration
    : IEntityTypeConfiguration<CourseDiscount>
{
    public void Configure(
        EntityTypeBuilder<CourseDiscount> builder)
    {
        builder.ToTable("CourseDiscounts");

        builder.HasKey(x => x.CourseDiscountId);

        builder.Property(x => x.CourseDiscountId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.DiscountName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.DiscountPercentage)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.DiscountAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.DiscountName);

        builder.HasIndex(x => x.IsActive);

        builder.HasIndex(x => x.IsDeleted);
    }
}