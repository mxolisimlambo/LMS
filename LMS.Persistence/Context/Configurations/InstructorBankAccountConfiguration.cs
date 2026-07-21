using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations;

public class InstructorBankAccountConfiguration
    : IEntityTypeConfiguration<InstructorBankAccount>
{
    public void Configure(
        EntityTypeBuilder<InstructorBankAccount> builder)
    {
        builder.ToTable("InstructorBankAccounts");

        builder.HasKey(x => x.InstructorBankAccountId);

        builder.Property(x => x.InstructorBankAccountId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.BankName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.AccountHolder)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.AccountNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.BranchCode)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.SwiftCode)
            .HasMaxLength(20);

        builder.Property(x => x.IsPrimary)
            .HasDefaultValue(false);

        builder.Property(x => x.Verified)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.IsPrimary);

        builder.HasIndex(x => x.Verified);

        builder.HasIndex(x => x.IsDeleted);
    }
}