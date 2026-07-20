using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StudentModuleInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    TimeZoneId = table.Column<int>(type: "int", nullable: true),
                    PreferredLanguageId = table.Column<int>(type: "int", nullable: true),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.StudentProfileId);
                });

            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                columns: table => new
                {
                    StudentAddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => x.StudentAddressId);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentDocuments",
                columns: table => new
                {
                    StudentDocumentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    VerifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDocuments", x => x.StudentDocumentId);
                    table.ForeignKey(
                        name: "FK_StudentDocuments_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentEmergencyContacts",
                columns: table => new
                {
                    StudentEmergencyContactId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AlternativePhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEmergencyContacts", x => x.StudentEmergencyContactId);
                    table.ForeignKey(
                        name: "FK_StudentEmergencyContacts_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentNotificationPreferences",
                columns: table => new
                {
                    StudentNotificationPreferenceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    CourseAnnouncements = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AssignmentReminders = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    QuizReminders = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PaymentNotifications = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CertificateNotifications = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    InstructorMessages = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MarketingNotifications = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNotificationPreferences", x => x.StudentNotificationPreferenceId);
                    table.ForeignKey(
                        name: "FK_StudentNotificationPreferences_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPreferences",
                columns: table => new
                {
                    StudentPreferenceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailNotifications = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SmsNotifications = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PushNotifications = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MarketingEmails = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MarketingSms = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPreferences", x => x.StudentPreferenceId);
                    table.ForeignKey(
                        name: "FK_StudentPreferences_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSettings",
                columns: table => new
                {
                    StudentSettingsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    ProfileVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ShowEmail = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ShowPhoneNumber = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AllowPublicProfile = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AllowDirectMessages = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RememberLastLogin = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSettings", x => x.StudentSettingsId);
                    table.ForeignKey(
                        name: "FK_StudentSettings_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubscriptions",
                columns: table => new
                {
                    StudentSubscriptionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    SubscriptionPlanId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AutoRenew = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PaymentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubscriptions", x => x.StudentSubscriptionId);
                    table.ForeignKey(
                        name: "FK_StudentSubscriptions_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentWishlists",
                columns: table => new
                {
                    StudentWishlistId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentWishlists", x => x.StudentWishlistId);
                    table.ForeignKey(
                        name: "FK_StudentWishlists_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_CountryId",
                table: "StudentAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_IsDeleted",
                table: "StudentAddresses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_IsPrimary",
                table: "StudentAddresses",
                column: "IsPrimary");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_StudentProfileId",
                table: "StudentAddresses",
                column: "StudentProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDocuments_DocumentType",
                table: "StudentDocuments",
                column: "DocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDocuments_IsDeleted",
                table: "StudentDocuments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDocuments_IsVerified",
                table: "StudentDocuments",
                column: "IsVerified");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDocuments_StudentProfileId",
                table: "StudentDocuments",
                column: "StudentProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmergencyContacts_IsDeleted",
                table: "StudentEmergencyContacts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmergencyContacts_IsPrimary",
                table: "StudentEmergencyContacts",
                column: "IsPrimary");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmergencyContacts_StudentProfileId",
                table: "StudentEmergencyContacts",
                column: "StudentProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNotificationPreferences_IsDeleted",
                table: "StudentNotificationPreferences",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNotificationPreferences_StudentProfileId",
                table: "StudentNotificationPreferences",
                column: "StudentProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentPreferences_IsDeleted",
                table: "StudentPreferences",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPreferences_StudentProfileId",
                table: "StudentPreferences",
                column: "StudentProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_IsDeleted",
                table: "StudentProfiles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_IsPremium",
                table: "StudentProfiles",
                column: "IsPremium");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_StudentNumber",
                table: "StudentProfiles",
                column: "StudentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_UserId",
                table: "StudentProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSettings_IsDeleted",
                table: "StudentSettings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSettings_StudentProfileId",
                table: "StudentSettings",
                column: "StudentProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubscriptions_IsActive",
                table: "StudentSubscriptions",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubscriptions_IsDeleted",
                table: "StudentSubscriptions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubscriptions_PaymentId",
                table: "StudentSubscriptions",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubscriptions_StudentProfileId",
                table: "StudentSubscriptions",
                column: "StudentProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubscriptions_SubscriptionPlanId",
                table: "StudentSubscriptions",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlists_CourseId",
                table: "StudentWishlists",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlists_IsDeleted",
                table: "StudentWishlists",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlists_StudentProfileId",
                table: "StudentWishlists",
                column: "StudentProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlists_StudentProfileId_CourseId",
                table: "StudentWishlists",
                columns: new[] { "StudentProfileId", "CourseId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAddresses");

            migrationBuilder.DropTable(
                name: "StudentDocuments");

            migrationBuilder.DropTable(
                name: "StudentEmergencyContacts");

            migrationBuilder.DropTable(
                name: "StudentNotificationPreferences");

            migrationBuilder.DropTable(
                name: "StudentPreferences");

            migrationBuilder.DropTable(
                name: "StudentSettings");

            migrationBuilder.DropTable(
                name: "StudentSubscriptions");

            migrationBuilder.DropTable(
                name: "StudentWishlists");

            migrationBuilder.DropTable(
                name: "StudentProfiles");
        }
    }
}
