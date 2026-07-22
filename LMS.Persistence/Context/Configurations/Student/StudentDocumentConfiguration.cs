using LMS.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LMS.Persistence.Context.Configurations.Student;

public class StudentDocumentConfiguration
    : IEntityTypeConfiguration<StudentDocument>
{
    public void Configure(
        EntityTypeBuilder<StudentDocument> builder)
    {
        builder.ToTable("StudentDocuments");

        builder.HasKey(x => x.StudentDocumentId);

        builder.Property(x => x.StudentDocumentId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StudentProfileId)
            .IsRequired();

        builder.Property(x => x.DocumentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.FileName)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.OriginalFileName)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.FileExtension)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.ContentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.FilePath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.UploadedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsVerified)
            .HasDefaultValue(false);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.DocumentType);

        builder.HasIndex(x => x.IsVerified);

        builder.HasIndex(x => x.IsDeleted);
    }
}
