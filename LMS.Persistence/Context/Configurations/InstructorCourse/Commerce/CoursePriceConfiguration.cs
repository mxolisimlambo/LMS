using LMS.Domain.Entities.Courses.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Commerce;

public class CoursePriceConfiguration
    : IEntityTypeConfiguration<CoursePrice>
{
    public void Configure(
        EntityTypeBuilder<CoursePrice> builder)
    {
        builder.ToTable("CoursePrices");

        builder.HasKey(x => x.CoursePriceId);

        builder.Property(x => x.CoursePriceId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.OriginalPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.CurrencyCode)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.TaxPercentage)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.IncludesTax)
            .HasDefaultValue(false);

        builder.Property(x => x.IsFree)
            .HasDefaultValue(false);

        builder.Property(x => x.EffectiveFrom)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId)
            .IsUnique();

        builder.HasIndex(x => x.CurrencyCode);

        builder.HasIndex(x => x.IsFree);

        builder.HasIndex(x => x.IsDeleted);
    }
}