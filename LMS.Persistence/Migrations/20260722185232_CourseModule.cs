using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CourseModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    CourseCategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.CourseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CourseLanguages",
                columns: table => new
                {
                    CourseLanguageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLanguages", x => x.CourseLanguageId);
                });

            migrationBuilder.CreateTable(
                name: "CourseLevels",
                columns: table => new
                {
                    CourseLevelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLevels", x => x.CourseLevelId);
                });

            migrationBuilder.CreateTable(
                name: "CourseStatuses",
                columns: table => new
                {
                    CourseStatusId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStatuses", x => x.CourseStatusId);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubCategories",
                columns: table => new
                {
                    CourseSubCategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubCategories", x => x.CourseSubCategoryId);
                    table.ForeignKey(
                        name: "FK_CourseSubCategories_CourseCategories_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "CourseCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    CourseCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CourseSubCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CourseLevelId = table.Column<long>(type: "bigint", nullable: false),
                    CourseLanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CourseStatusId = table.Column<long>(type: "bigint", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PreviewVideo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimatedStudyHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumStudents = table.Column<int>(type: "int", nullable: false),
                    MinimumStudents = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "CourseCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_CourseLanguages_CourseLanguageId",
                        column: x => x.CourseLanguageId,
                        principalTable: "CourseLanguages",
                        principalColumn: "CourseLanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_CourseLevels_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "CourseLevels",
                        principalColumn: "CourseLevelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_CourseStatuses_CourseStatusId",
                        column: x => x.CourseStatusId,
                        principalTable: "CourseStatuses",
                        principalColumn: "CourseStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_CourseSubCategories_CourseSubCategoryId",
                        column: x => x.CourseSubCategoryId,
                        principalTable: "CourseSubCategories",
                        principalColumn: "CourseSubCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_InstructorProfiles_InstructorProfileId",
                        column: x => x.InstructorProfileId,
                        principalTable: "InstructorProfiles",
                        principalColumn: "InstructorProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseAnnouncements",
                columns: table => new
                {
                    CourseAnnouncementId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    NotifyStudentsByEmail = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NotifyStudentsInApp = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAnnouncements", x => x.CourseAnnouncementId);
                    table.ForeignKey(
                        name: "FK_CourseAnnouncements_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseApprovals",
                columns: table => new
                {
                    CourseApprovalId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    RejectedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ReviewComments = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseApprovals", x => x.CourseApprovalId);
                    table.ForeignKey(
                        name: "FK_CourseApprovals_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseCoupons",
                columns: table => new
                {
                    CourseCouponId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumUsage = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsedCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCoupons", x => x.CourseCouponId);
                    table.ForeignKey(
                        name: "FK_CourseCoupons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseDiscounts",
                columns: table => new
                {
                    CourseDiscountId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    DiscountName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDiscounts", x => x.CourseDiscountId);
                    table.ForeignKey(
                        name: "FK_CourseDiscounts_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseFAQs",
                columns: table => new
                {
                    CourseFAQId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFAQs", x => x.CourseFAQId);
                    table.ForeignKey(
                        name: "FK_CourseFAQs_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseModules",
                columns: table => new
                {
                    CourseModuleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModules", x => x.CourseModuleId);
                    table.ForeignKey(
                        name: "FK_CourseModules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseOutcomes",
                columns: table => new
                {
                    CourseOutcomeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOutcomes", x => x.CourseOutcomeId);
                    table.ForeignKey(
                        name: "FK_CourseOutcomes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoursePrices",
                columns: table => new
                {
                    CoursePriceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncludesTax = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePrices", x => x.CoursePriceId);
                    table.ForeignKey(
                        name: "FK_CoursePrices_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePublishing",
                columns: table => new
                {
                    CoursePublishingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UnpublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AllowEnrollment = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AllowPreview = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePublishing", x => x.CoursePublishingId);
                    table.ForeignKey(
                        name: "FK_CoursePublishing_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseRatings",
                columns: table => new
                {
                    CourseRatingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    IsVerifiedPurchase = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRatings", x => x.CourseRatingId);
                    table.ForeignKey(
                        name: "FK_CourseRatings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseRatings_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseRequirements",
                columns: table => new
                {
                    CourseRequirementId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Requirement = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRequirements", x => x.CourseRequirementId);
                    table.ForeignKey(
                        name: "FK_CourseRequirements_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseReviews",
                columns: table => new
                {
                    CourseReviewId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    ReviewTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Review = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    IsRecommended = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseReviews", x => x.CourseReviewId);
                    table.ForeignKey(
                        name: "FK_CourseReviews_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseReviews_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStatistics",
                columns: table => new
                {
                    CourseStatisticsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    TotalViews = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalEnrollments = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalCompletions = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalReviews = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalWishlist = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStatistics", x => x.CourseStatisticsId);
                    table.ForeignKey(
                        name: "FK_CourseStatistics_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTags",
                columns: table => new
                {
                    CourseTagId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTags", x => x.CourseTagId);
                    table.ForeignKey(
                        name: "FK_CourseTags_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTargetAudiences",
                columns: table => new
                {
                    CourseTargetAudienceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Audience = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTargetAudiences", x => x.CourseTargetAudienceId);
                    table.ForeignKey(
                        name: "FK_CourseTargetAudiences_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseViews",
                columns: table => new
                {
                    CourseViewId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OperatingSystem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ViewedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseViews", x => x.CourseViewId);
                    table.ForeignKey(
                        name: "FK_CourseViews_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseViews_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId");
                });

            migrationBuilder.CreateTable(
                name: "CourseVisibility",
                columns: table => new
                {
                    CourseVisibilityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsUnlisted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FeaturedOnHomepage = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AllowSearchEngineIndexing = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    VisibleInMarketplace = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseVisibility", x => x.CourseVisibilityId);
                    table.ForeignKey(
                        name: "FK_CourseVisibility_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseWishlists",
                columns: table => new
                {
                    CourseWishlistId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    StudentProfileId = table.Column<long>(type: "bigint", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseWishlists", x => x.CourseWishlistId);
                    table.ForeignKey(
                        name: "FK_CourseWishlists_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseWishlists_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseLessons",
                columns: table => new
                {
                    CourseLessonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseModuleId = table.Column<long>(type: "bigint", nullable: false),
                    LessonTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DurationMinutes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPreview = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLessons", x => x.CourseLessonId);
                    table.ForeignKey(
                        name: "FK_CourseLessons_CourseModules_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalTable: "CourseModules",
                        principalColumn: "CourseModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseAttachments",
                columns: table => new
                {
                    CourseAttachmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseLessonId = table.Column<long>(type: "bigint", nullable: false),
                    AttachmentTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAttachments", x => x.CourseAttachmentId);
                    table.ForeignKey(
                        name: "FK_CourseAttachments_CourseLessons_CourseLessonId",
                        column: x => x.CourseLessonId,
                        principalTable: "CourseLessons",
                        principalColumn: "CourseLessonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseDocuments",
                columns: table => new
                {
                    CourseDocumentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseLessonId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    IsDownloadable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDocuments", x => x.CourseDocumentId);
                    table.ForeignKey(
                        name: "FK_CourseDocuments_CourseLessons_CourseLessonId",
                        column: x => x.CourseLessonId,
                        principalTable: "CourseLessons",
                        principalColumn: "CourseLessonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseResources",
                columns: table => new
                {
                    CourseResourceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    ResourceName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ResourceUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CourseLessonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResources", x => x.CourseResourceId);
                    table.ForeignKey(
                        name: "FK_CourseResources_CourseLessons_CourseLessonId",
                        column: x => x.CourseLessonId,
                        principalTable: "CourseLessons",
                        principalColumn: "CourseLessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseVideos",
                columns: table => new
                {
                    CourseVideoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseLessonId = table.Column<long>(type: "bigint", nullable: false),
                    VideoTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DurationMinutes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    IsDownloadable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseVideos", x => x.CourseVideoId);
                    table.ForeignKey(
                        name: "FK_CourseVideos_CourseLessons_CourseLessonId",
                        column: x => x.CourseLessonId,
                        principalTable: "CourseLessons",
                        principalColumn: "CourseLessonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAnnouncements_CourseId",
                table: "CourseAnnouncements",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAnnouncements_IsDeleted",
                table: "CourseAnnouncements",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAnnouncements_PublishDate",
                table: "CourseAnnouncements",
                column: "PublishDate");

            migrationBuilder.CreateIndex(
                name: "IX_CourseApprovals_ApprovalStatus",
                table: "CourseApprovals",
                column: "ApprovalStatus");

            migrationBuilder.CreateIndex(
                name: "IX_CourseApprovals_CourseId",
                table: "CourseApprovals",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseApprovals_IsDeleted",
                table: "CourseApprovals",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttachments_CourseLessonId",
                table: "CourseAttachments",
                column: "CourseLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttachments_FileType",
                table: "CourseAttachments",
                column: "FileType");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttachments_IsDeleted",
                table: "CourseAttachments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_CategoryName",
                table: "CourseCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_DisplayOrder",
                table: "CourseCategories",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_IsActive",
                table: "CourseCategories",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_IsDeleted",
                table: "CourseCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCoupons_CouponCode",
                table: "CourseCoupons",
                column: "CouponCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseCoupons_CourseId",
                table: "CourseCoupons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCoupons_IsActive",
                table: "CourseCoupons",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCoupons_IsDeleted",
                table: "CourseCoupons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscounts_CourseId",
                table: "CourseDiscounts",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscounts_DiscountName",
                table: "CourseDiscounts",
                column: "DiscountName");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscounts_IsActive",
                table: "CourseDiscounts",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscounts_IsDeleted",
                table: "CourseDiscounts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDocuments_CourseLessonId",
                table: "CourseDocuments",
                column: "CourseLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDocuments_FileType",
                table: "CourseDocuments",
                column: "FileType");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDocuments_IsDeleted",
                table: "CourseDocuments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDocuments_IsDownloadable",
                table: "CourseDocuments",
                column: "IsDownloadable");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFAQs_CourseId",
                table: "CourseFAQs",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFAQs_DisplayOrder",
                table: "CourseFAQs",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFAQs_IsDeleted",
                table: "CourseFAQs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLanguages_IsActive",
                table: "CourseLanguages",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLanguages_IsDeleted",
                table: "CourseLanguages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLanguages_LanguageCode",
                table: "CourseLanguages",
                column: "LanguageCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseLanguages_LanguageName",
                table: "CourseLanguages",
                column: "LanguageName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseLessons_CourseModuleId",
                table: "CourseLessons",
                column: "CourseModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLessons_DisplayOrder",
                table: "CourseLessons",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLessons_IsDeleted",
                table: "CourseLessons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLessons_IsPreview",
                table: "CourseLessons",
                column: "IsPreview");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLessons_IsPublished",
                table: "CourseLessons",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLevels_DisplayOrder",
                table: "CourseLevels",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLevels_IsActive",
                table: "CourseLevels",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLevels_IsDeleted",
                table: "CourseLevels",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLevels_LevelName",
                table: "CourseLevels",
                column: "LevelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseModules_CourseId",
                table: "CourseModules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModules_DisplayOrder",
                table: "CourseModules",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModules_IsDeleted",
                table: "CourseModules",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModules_IsPublished",
                table: "CourseModules",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOutcomes_CourseId",
                table: "CourseOutcomes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOutcomes_DisplayOrder",
                table: "CourseOutcomes",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOutcomes_IsDeleted",
                table: "CourseOutcomes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrices_CourseId",
                table: "CoursePrices",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrices_CurrencyCode",
                table: "CoursePrices",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrices_IsDeleted",
                table: "CoursePrices",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrices_IsFree",
                table: "CoursePrices",
                column: "IsFree");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePublishing_AllowEnrollment",
                table: "CoursePublishing",
                column: "AllowEnrollment");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePublishing_CourseId",
                table: "CoursePublishing",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePublishing_IsDeleted",
                table: "CoursePublishing",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePublishing_IsPublished",
                table: "CoursePublishing",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRatings_CourseId",
                table: "CourseRatings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRatings_CourseId_StudentProfileId",
                table: "CourseRatings",
                columns: new[] { "CourseId", "StudentProfileId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseRatings_IsDeleted",
                table: "CourseRatings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRatings_IsVerifiedPurchase",
                table: "CourseRatings",
                column: "IsVerifiedPurchase");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRatings_StudentProfileId",
                table: "CourseRatings",
                column: "StudentProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRequirements_CourseId",
                table: "CourseRequirements",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRequirements_DisplayOrder",
                table: "CourseRequirements",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRequirements_IsDeleted",
                table: "CourseRequirements",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResources_CourseId",
                table: "CourseResources",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResources_CourseLessonId",
                table: "CourseResources",
                column: "CourseLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResources_DisplayOrder",
                table: "CourseResources",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResources_IsDeleted",
                table: "CourseResources",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReviews_CourseId",
                table: "CourseReviews",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReviews_CourseId_StudentProfileId",
                table: "CourseReviews",
                columns: new[] { "CourseId", "StudentProfileId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseReviews_IsApproved",
                table: "CourseReviews",
                column: "IsApproved");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReviews_IsDeleted",
                table: "CourseReviews",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReviews_StudentProfileId",
                table: "CourseReviews",
                column: "StudentProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCategoryId",
                table: "Courses",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCode",
                table: "Courses",
                column: "CourseCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseLanguageId",
                table: "Courses",
                column: "CourseLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseLevelId",
                table: "Courses",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseStatusId",
                table: "Courses",
                column: "CourseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseSubCategoryId",
                table: "Courses",
                column: "CourseSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorProfileId",
                table: "Courses",
                column: "InstructorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IsDeleted",
                table: "Courses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IsFeatured",
                table: "Courses",
                column: "IsFeatured");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IsPremium",
                table: "Courses",
                column: "IsPremium");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IsPublished",
                table: "Courses",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStatistics_CourseId",
                table: "CourseStatistics",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseStatistics_IsDeleted",
                table: "CourseStatistics",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStatuses_IsActive",
                table: "CourseStatuses",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStatuses_IsDeleted",
                table: "CourseStatuses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStatuses_StatusName",
                table: "CourseStatuses",
                column: "StatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubCategories_CourseCategoryId",
                table: "CourseSubCategories",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubCategories_CourseCategoryId_SubCategoryName",
                table: "CourseSubCategories",
                columns: new[] { "CourseCategoryId", "SubCategoryName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubCategories_DisplayOrder",
                table: "CourseSubCategories",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubCategories_IsActive",
                table: "CourseSubCategories",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubCategories_IsDeleted",
                table: "CourseSubCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTags_CourseId",
                table: "CourseTags",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTags_CourseId_TagName",
                table: "CourseTags",
                columns: new[] { "CourseId", "TagName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseTags_IsDeleted",
                table: "CourseTags",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTargetAudiences_CourseId",
                table: "CourseTargetAudiences",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTargetAudiences_DisplayOrder",
                table: "CourseTargetAudiences",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTargetAudiences_IsDeleted",
                table: "CourseTargetAudiences",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVideos_CourseLessonId",
                table: "CourseVideos",
                column: "CourseLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVideos_IsDeleted",
                table: "CourseVideos",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVideos_IsDownloadable",
                table: "CourseVideos",
                column: "IsDownloadable");

            migrationBuilder.CreateIndex(
                name: "IX_CourseViews_CourseId",
                table: "CourseViews",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseViews_IsDeleted",
                table: "CourseViews",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseViews_StudentProfileId",
                table: "CourseViews",
                column: "StudentProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseViews_ViewedDate",
                table: "CourseViews",
                column: "ViewedDate");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVisibility_CourseId",
                table: "CourseVisibility",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseVisibility_FeaturedOnHomepage",
                table: "CourseVisibility",
                column: "FeaturedOnHomepage");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVisibility_IsDeleted",
                table: "CourseVisibility",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVisibility_IsPrivate",
                table: "CourseVisibility",
                column: "IsPrivate");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVisibility_IsPublic",
                table: "CourseVisibility",
                column: "IsPublic");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVisibility_IsUnlisted",
                table: "CourseVisibility",
                column: "IsUnlisted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVisibility_VisibleInMarketplace",
                table: "CourseVisibility",
                column: "VisibleInMarketplace");

            migrationBuilder.CreateIndex(
                name: "IX_CourseWishlists_CourseId",
                table: "CourseWishlists",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseWishlists_CourseId_StudentProfileId",
                table: "CourseWishlists",
                columns: new[] { "CourseId", "StudentProfileId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseWishlists_IsDeleted",
                table: "CourseWishlists",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseWishlists_StudentProfileId",
                table: "CourseWishlists",
                column: "StudentProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAnnouncements");

            migrationBuilder.DropTable(
                name: "CourseApprovals");

            migrationBuilder.DropTable(
                name: "CourseAttachments");

            migrationBuilder.DropTable(
                name: "CourseCoupons");

            migrationBuilder.DropTable(
                name: "CourseDiscounts");

            migrationBuilder.DropTable(
                name: "CourseDocuments");

            migrationBuilder.DropTable(
                name: "CourseFAQs");

            migrationBuilder.DropTable(
                name: "CourseOutcomes");

            migrationBuilder.DropTable(
                name: "CoursePrices");

            migrationBuilder.DropTable(
                name: "CoursePublishing");

            migrationBuilder.DropTable(
                name: "CourseRatings");

            migrationBuilder.DropTable(
                name: "CourseRequirements");

            migrationBuilder.DropTable(
                name: "CourseResources");

            migrationBuilder.DropTable(
                name: "CourseReviews");

            migrationBuilder.DropTable(
                name: "CourseStatistics");

            migrationBuilder.DropTable(
                name: "CourseTags");

            migrationBuilder.DropTable(
                name: "CourseTargetAudiences");

            migrationBuilder.DropTable(
                name: "CourseVideos");

            migrationBuilder.DropTable(
                name: "CourseViews");

            migrationBuilder.DropTable(
                name: "CourseVisibility");

            migrationBuilder.DropTable(
                name: "CourseWishlists");

            migrationBuilder.DropTable(
                name: "CourseLessons");

            migrationBuilder.DropTable(
                name: "CourseModules");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseLanguages");

            migrationBuilder.DropTable(
                name: "CourseLevels");

            migrationBuilder.DropTable(
                name: "CourseStatuses");

            migrationBuilder.DropTable(
                name: "CourseSubCategories");

            migrationBuilder.DropTable(
                name: "CourseCategories");
        }
    }
}
