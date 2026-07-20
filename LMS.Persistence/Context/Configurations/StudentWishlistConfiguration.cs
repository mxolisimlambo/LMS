using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class StudentWishlistConfiguration
    : IEntityTypeConfiguration<StudentWishlist>
{
    public void Configure(
        EntityTypeBuilder<StudentWishlist> builder)
    {
        builder.ToTable("StudentWishlists");

        builder.HasKey(x => x.StudentWishlistId);

        builder.Property(x => x.StudentWishlistId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.CourseId)
            .IsRequired();

        builder.Property(x => x.AddedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.CourseId);

        builder.HasIndex(x => x.IsDeleted);

        builder.HasIndex(x => new
        {
            x.StudentProfileId,
            x.CourseId
        }).IsUnique();
    }
}