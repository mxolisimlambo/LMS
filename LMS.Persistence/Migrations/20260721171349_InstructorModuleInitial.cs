using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InstructorModuleInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstructorProfiles",
                columns: table => new
                {
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    InstructorNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProfessionalHeadline = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BannerImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    YearsExperience = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalReviews = table.Column<int>(type: "int", nullable: false),
                    TotalStudents = table.Column<int>(type: "int", nullable: false),
                    TotalCourses = table.Column<int>(type: "int", nullable: false),
                    TotalSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WalletBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VerificationStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorProfiles", x => x.InstructorProfileId);
                });

            migrationBuilder.CreateTable(
                name: "InstructorAddresses",
                columns: table => new
                {
                    InstructorAddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorAddresses", x => x.InstructorAddressId);
                    table.ForeignKey(
                        name: "FK_InstructorAddresses_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorApprovals",
                columns: table => new
                {
                    InstructorApprovalId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedByUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorApprovals", x => x.InstructorApprovalId);
                    table.ForeignKey(
                        name: "FK_InstructorApprovals_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorAvailabilities",
                columns: table => new
                {
                    InstructorAvailabilityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorAvailabilities", x => x.InstructorAvailabilityId);
                    table.ForeignKey(
                        name: "FK_InstructorAvailabilities_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorBankAccounts",
                columns: table => new
                {
                    InstructorBankAccountId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AccountHolder = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorBankAccounts", x => x.InstructorBankAccountId);
                    table.ForeignKey(
                        name: "FK_InstructorBankAccounts_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorCertifications",
                columns: table => new
                {
                    InstructorCertificationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    CertificationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IssuingOrganization = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CertificateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCertifications", x => x.InstructorCertificationId);
                    table.ForeignKey(
                        name: "FK_InstructorCertifications_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorDocuments",
                columns: table => new
                {
                    InstructorDocumentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorDocuments", x => x.InstructorDocumentId);
                    table.ForeignKey(
                        name: "FK_InstructorDocuments_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorExperiences",
                columns: table => new
                {
                    InstructorExperienceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorExperiences", x => x.InstructorExperienceId);
                    table.ForeignKey(
                        name: "FK_InstructorExperiences_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorNotificationPreferences",
                columns: table => new
                {
                    InstructorNotificationPreferenceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    EmailNotifications = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SmsNotifications = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PushNotifications = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorNotificationPreferences", x => x.InstructorNotificationPreferenceId);
                    table.ForeignKey(
                        name: "FK_InstructorNotificationPreferences_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorPreferences",
                columns: table => new
                {
                    InstructorPreferenceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorPreferences", x => x.InstructorPreferenceId);
                    table.ForeignKey(
                        name: "FK_InstructorPreferences_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorQualifications",
                columns: table => new
                {
                    InstructorQualificationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    QualificationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompletedYear = table.Column<int>(type: "int", nullable: false),
                    CertificateFile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorQualifications", x => x.InstructorQualificationId);
                    table.ForeignKey(
                        name: "FK_InstructorQualifications_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorSettings",
                columns: table => new
                {
                    InstructorSettingsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    AllowPublicProfile = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AllowCourseReviews = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ShowRevenue = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSettings", x => x.InstructorSettingsId);
                    table.ForeignKey(
                        name: "FK_InstructorSettings_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorSkills",
                columns: table => new
                {
                    InstructorSkillId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    YearsExperience = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSkills", x => x.InstructorSkillId);
                    table.ForeignKey(
                        name: "FK_InstructorSkills_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorSocialLinks",
                columns: table => new
                {
                    InstructorSocialLinkId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSocialLinks", x => x.InstructorSocialLinkId);
                    table.ForeignKey(
                        name: "FK_InstructorSocialLinks_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorSubscriptions",
                columns: table => new
                {
                    InstructorSubscriptionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    SubscriptionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthlyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutoRenew = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSubscriptions", x => x.InstructorSubscriptionId);
                    table.ForeignKey(
                        name: "FK_InstructorSubscriptions_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorTaxProfiles",
                columns: table => new
                {
                    InstructorTaxProfileId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VatNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorTaxProfiles", x => x.InstructorTaxProfileId);
                    table.ForeignKey(
                        name: "FK_InstructorTaxProfiles_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorVerifications",
                columns: table => new
                {
                    InstructorVerificationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VerifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    VerifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorVerifications", x => x.InstructorVerificationId);
                    table.ForeignKey(
                        name: "FK_InstructorVerifications_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorWallets",
                columns: table => new
                {
                    InstructorWalletId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PendingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalEarned = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalWithdrawn = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    LastPayoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorWallets", x => x.InstructorWalletId);
                    table.ForeignKey(
                        name: "FK_InstructorWallets_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAddresses_InstructorProfileId",
                table: "InstructorAddresses",
                column: "InstructorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAddresses_IsDeleted",
                table: "InstructorAddresses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorApprovals_ApprovalStatus",
                table: "InstructorApprovals",
                column: "ApprovalStatus");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorApprovals_InstructorProfileId",
                table: "InstructorApprovals",
                column: "InstructorProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorApprovals_IsDeleted",
                table: "InstructorApprovals",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAvailabilities_DayOfWeek",
                table: "InstructorAvailabilities",
                column: "DayOfWeek");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAvailabilities_InstructorProfileId",
                table: "InstructorAvailabilities",
                column: "InstructorProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAvailabilities_IsDeleted",
                table: "InstructorAvailabilities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorBankAccounts_InstructorProfileId",
                table: "InstructorBankAccounts",
                column: "InstructorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorBankAccounts_IsDeleted",
                table: "InstructorBankAccounts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorBankAccounts_IsPrimary",
                table: "InstructorBankAccounts",
                column: "IsPrimary");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorBankAccounts_Verified",
                table: "InstructorBankAccounts",
                column: "Verified");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCertifications_CertificationName",
                table: "InstructorCertifications",
                column: "CertificationName");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCertifications_InstructorProfileId",
                table: "InstructorCertifications",
                column: "InstructorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCertifications_IsDeleted",
                table: "InstructorCertifications",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorDocuments_DocumentType",
                table: "InstructorDocuments",
                column: "DocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorDocuments_InstructorProfileId",
                table: "InstructorDocuments",
                column: "InstructorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorDocuments_IsDeleted",
                table: "InstructorDocuments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorDocuments_Verified",
                table: "InstructorDocuments",
                column: "Verified");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorExperiences_Company",
                table: "InstructorExperiences",
                column: "Company");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorExperiences_InstructorProfileId",
                table: "InstructorExperiences",
                column: "InstructorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorExperiences_IsDeleted",
                table: "InstructorExperiences",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorNotificationPreferences_InstructorProfileId",
                table: "InstructorNotificationPreferences",
                column: "InstructorProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorPreferences_InstructorProfileId",
                table: "InstructorPreferences",
                column: "InstructorProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorProfiles_InstructorNumber",
                table: "InstructorProfiles",
                column: "InstructorNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorProfiles_IsDeleted",
                table: "InstructorProfiles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorProfiles_IsPremium",
                table: "InstructorProfiles",
                column: "IsPremium");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorProfiles_UserId",
                table: "InstructorProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorQualifications_CompletedYear",
                table: "InstructorQualifications",
                column: "CompletedYear");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorQualifications_InstructorProfileId",
                table: "InstructorQualifications",
                column: "InstructorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorQualifications_IsDeleted",
                table: "InstructorQualifications",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSettings_InstructorProfileId",
                table: "InstructorSettings",
                column: "InstructorProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSkills_InstructorProfileId",
                table: "InstructorSkills",
                column: "InstructorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSkills_IsDeleted",
                table: "InstructorSkills",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSkills_SkillName",
                table: "InstructorSkills",
                column: "SkillName");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSocialLinks_InstructorProfileId",
                table: "InstructorSocialLinks",
                column: "InstructorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSocialLinks_IsDeleted",
                table: "InstructorSocialLinks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSocialLinks_Platform",
                table: "InstructorSocialLinks",
                column: "Platform");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSubscriptions_InstructorProfileId",
                table: "InstructorSubscriptions",
                column: "InstructorProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSubscriptions_Status",
                table: "InstructorSubscriptions",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSubscriptions_SubscriptionType",
                table: "InstructorSubscriptions",
                column: "SubscriptionType");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTaxProfiles_InstructorProfileId",
                table: "InstructorTaxProfiles",
                column: "InstructorProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTaxProfiles_IsDeleted",
                table: "InstructorTaxProfiles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTaxProfiles_TaxNumber",
                table: "InstructorTaxProfiles",
                column: "TaxNumber");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTaxProfiles_TaxStatus",
                table: "InstructorTaxProfiles",
                column: "TaxStatus");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorVerifications_InstructorProfileId",
                table: "InstructorVerifications",
                column: "InstructorProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorVerifications_Status",
                table: "InstructorVerifications",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWallets_InstructorProfileId",
                table: "InstructorWallets",
                column: "InstructorProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWallets_IsDeleted",
                table: "InstructorWallets",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorAddresses");

            migrationBuilder.DropTable(
                name: "InstructorApprovals");

            migrationBuilder.DropTable(
                name: "InstructorAvailabilities");

            migrationBuilder.DropTable(
                name: "InstructorBankAccounts");

            migrationBuilder.DropTable(
                name: "InstructorCertifications");

            migrationBuilder.DropTable(
                name: "InstructorDocuments");

            migrationBuilder.DropTable(
                name: "InstructorExperiences");

            migrationBuilder.DropTable(
                name: "InstructorNotificationPreferences");

            migrationBuilder.DropTable(
                name: "InstructorPreferences");

            migrationBuilder.DropTable(
                name: "InstructorQualifications");

            migrationBuilder.DropTable(
                name: "InstructorSettings");

            migrationBuilder.DropTable(
                name: "InstructorSkills");

            migrationBuilder.DropTable(
                name: "InstructorSocialLinks");

            migrationBuilder.DropTable(
                name: "InstructorSubscriptions");

            migrationBuilder.DropTable(
                name: "InstructorTaxProfiles");

            migrationBuilder.DropTable(
                name: "InstructorVerifications");

            migrationBuilder.DropTable(
                name: "InstructorWallets");

            migrationBuilder.DropTable(
                name: "InstructorProfiles");
        }
    }
}
