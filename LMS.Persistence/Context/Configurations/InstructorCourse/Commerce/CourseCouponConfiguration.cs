using LMS.Domain.Entities.Courses.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Commerce;

public class CourseCouponConfiguration
    : IEntityTypeConfiguration<CourseCoupon>
{
    public void Configure(
        EntityTypeBuilder<CourseCoupon> builder)
    {
        builder.ToTable("CourseCoupons");

        builder.HasKey(x => x.CourseCouponId);

        builder.Property(x => x.CourseCouponId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.CouponCode)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.DiscountPercentage)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.DiscountAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.MaximumUsage)
            .HasDefaultValue(0);

        builder.Property(x => x.UsedCount)
            .HasDefaultValue(0);

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

        builder.HasIndex(x => x.CouponCode)
            .IsUnique();

        builder.HasIndex(x => x.IsActive);

        builder.HasIndex(x => x.IsDeleted);
    }
}