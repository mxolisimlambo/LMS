using LMS.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Context.Configurations.Instructor;

public class InstructorWalletConfiguration
    : IEntityTypeConfiguration<InstructorWallet>
{
    public void Configure(
        EntityTypeBuilder<InstructorWallet> builder)
    {
        builder.ToTable("InstructorWallets");

        builder.HasKey(x => x.InstructorWalletId);

        builder.Property(x => x.InstructorWalletId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InstructorProfileId)
            .IsRequired();

        builder.Property(x => x.CurrentBalance)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);

        builder.Property(x => x.PendingBalance)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);

        builder.Property(x => x.TotalEarned)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);

        builder.Property(x => x.TotalWithdrawn)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0m);

        builder.Property(x => x.LastPayoutDate);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.InstructorProfileId);

        builder.HasIndex(x => x.IsDeleted);
    }
}