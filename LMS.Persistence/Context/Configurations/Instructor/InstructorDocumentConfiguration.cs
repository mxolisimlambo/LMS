using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Instructor;

public class InstructorDocumentConfiguration
    : IEntityTypeConfiguration<InstructorDocument>
{
    public void Configure(
        EntityTypeBuilder<InstructorDocument> builder)
    {
        builder.ToTable("InstructorDocuments");

        builder.HasKey(x => x.InstructorDocumentId);

        builder.Property(x => x.InstructorDocumentId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.DocumentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.FilePath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Verified)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.DocumentType);

        builder.HasIndex(x => x.Verified);

        builder.HasIndex(x => x.IsDeleted);
    }
}