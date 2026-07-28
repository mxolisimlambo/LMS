using LMS.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Payments;

public class InvoiceConfiguration
    : IEntityTypeConfiguration<Invoice>
{
    public void Configure(
        EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");

        builder.HasKey(x => x.InvoiceId);

        builder.Property(x => x.InvoiceId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InvoiceNumber)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.InvoiceNumber)
            .IsUnique();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.BillingName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.BillingEmail)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.BillingPhoneNumber)
            .HasMaxLength(50);

        builder.Property(x => x.BillingAddress)
            .HasMaxLength(500);

        builder.Property(x => x.CompanyName)
            .HasMaxLength(200);

        builder.Property(x => x.TaxNumber)
            .HasMaxLength(100);

        builder.Property(x => x.PdfPath)
            .HasMaxLength(500);

        builder.Property(x => x.SubTotal)
            .HasPrecision(18, 2);

        builder.Property(x => x.DiscountAmount)
            .HasPrecision(18, 2);

        builder.Property(x => x.TaxAmount)
            .HasPrecision(18, 2);

        builder.Property(x => x.TotalAmount)
            .HasPrecision(18, 2);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsPaid)
            .HasDefaultValue(false);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.PaymentId);

        builder.HasIndex(x => x.StudentProfileId);

        builder.HasIndex(x => x.InvoiceDate);

        builder.HasIndex(x => x.IsDeleted);

        builder.HasOne(x => x.Payment)
            .WithOne(x => x.Invoice)
            .HasForeignKey<Invoice>(x => x.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.StudentProfile)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
