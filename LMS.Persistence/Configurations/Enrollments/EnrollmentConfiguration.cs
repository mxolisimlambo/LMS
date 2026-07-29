using LMS.Domain.Entities.Enrollments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Configurations.Enrollments;

public class EnrollmentConfiguration
: IEntityTypeConfiguration<Enrollment>
{
public void Configure(
EntityTypeBuilder<Enrollment> builder)
{
// ======================================================
// PRIMARY KEY
// ======================================================

    builder.HasKey(x => x.EnrollmentId);

    // ======================================================
    // ENROLMENT STATUS
    // ======================================================

    builder.Property(x => x.EnrollmentStatus)
        .IsRequired()
        .HasMaxLength(50)
        .HasDefaultValue("Active");

    // ======================================================
    // ENROLMENT AND ACCESS DATES
    // ======================================================

    builder.Property(x => x.EnrolledDate)
        .IsRequired();

    builder.Property(x => x.AccessStartDate)
        .IsRequired(false);

    builder.Property(x => x.AccessEndDate)
        .IsRequired(false);

    // ======================================================
    // STUDENT LEARNING PROGRESS
    // ======================================================

    builder.Property(x => x.ProgressPercentage)
        .HasColumnType("decimal(5,2)")
        .HasDefaultValue(0m);

    builder.Property(x => x.LastAccessedDate)
        .IsRequired(false);

    builder.Property(x => x.CompletedDate)
        .IsRequired(false);

    // ======================================================
    // CERTIFICATE
    // ======================================================

    builder.Property(x => x.IsCertificateEligible)
        .HasDefaultValue(false);

    // ======================================================
    // AUDIT AND SOFT DELETE
    // ======================================================

    builder.Property(x => x.UpdatedDate)
        .IsRequired(false);

    builder.Property(x => x.IsDeleted)
        .HasDefaultValue(false);

    // ======================================================
    // INDEXES
    // ======================================================

    builder.HasIndex(x => x.StudentProfileId);

    builder.HasIndex(x => x.CourseId);

    builder.HasIndex(x => x.OrderItemId)
        .IsUnique();

    builder.HasIndex(x => x.EnrollmentStatus);

    builder.HasIndex(x => x.EnrolledDate);

    // Prevent a student from having duplicate
    // enrolment records for the same course.

    builder.HasIndex(x => new
    {
        x.StudentProfileId,
        x.CourseId
    })
    .IsUnique();

    // ======================================================
    // STUDENT PROFILE RELATIONSHIP
    // ======================================================

    builder.HasOne(x => x.StudentProfile)
        .WithMany(x => x.Enrollments)
        .HasForeignKey(x => x.StudentProfileId)
        .OnDelete(DeleteBehavior.Restrict);

    // ======================================================
    // COURSE RELATIONSHIP
    // ======================================================

    builder.HasOne(x => x.Course)
        .WithMany(x => x.Enrollments)
        .HasForeignKey(x => x.CourseId)
        .OnDelete(DeleteBehavior.Restrict);

        // ======================================================
        // ORDER ITEM RELATIONSHIP
        // ======================================================

      
    builder.HasOne(x => x.OrderItem)
            .WithOne(x => x.Enrollment)
            .HasForeignKey<Enrollment>(x => x.OrderItemId)
            .OnDelete(DeleteBehavior.Restrict);
}

}
