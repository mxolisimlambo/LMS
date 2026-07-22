using LMS.Domain.Entities.Courses.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.InstructorCourse.Catalog;

public class CourseWishlistConfiguration
    : IEntityTypeConfiguration<CourseWishlist>
{
    public void Configure(
        EntityTypeBuilder<CourseWishlist> builder)
    {
        builder.ToTable("CourseWishlists");

        builder.HasKey(x => x.CourseWishlistId);

        builder.Property(x => x.CourseWishlistId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.AddedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => new
        {
            x.CourseId,
            x.StudentProfileId
        }).IsUnique();

        builder.HasIndex(x => x.IsDeleted);
    }
}