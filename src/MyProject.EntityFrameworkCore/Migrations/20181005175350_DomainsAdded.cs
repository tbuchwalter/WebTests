using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPoints.Migrations
{
    public partial class DomainsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Zip = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DraftTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuidelineCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidelineCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PointOfContact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Associations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Builders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PointOfContact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Builders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PointOfContact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipalities_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guidelines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guidelines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guidelines_GuidelineCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "GuidelineCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    AssociationId = table.Column<int>(nullable: false),
                    MunicipalitiesId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CratedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communities_Associations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Associations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Communities_Municipalities_MunicipalitiesId",
                        column: x => x.MunicipalitiesId,
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuidelineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuidelineId = table.Column<int>(nullable: false),
                    DraftTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidelineTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuidelineTypes_DraftTypes_DraftTypeId",
                        column: x => x.DraftTypeId,
                        principalTable: "DraftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuidelineTypes_Guidelines_GuidelineId",
                        column: x => x.GuidelineId,
                        principalTable: "Guidelines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuidelineValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuidelineId = table.Column<int>(nullable: false),
                    ValueType = table.Column<int>(nullable: true),
                    NumericValue1 = table.Column<int>(nullable: true),
                    NumericValue2 = table.Column<int>(nullable: false),
                    TextValue = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    AttachmentRef = table.Column<string>(nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    TerminationDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    InactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidelineValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuidelineValues_Guidelines_GuidelineId",
                        column: x => x.GuidelineId,
                        principalTable: "Guidelines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunitySections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommunityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunitySections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunitySections_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MunicipalGuidelines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MunicipalitiesId = table.Column<int>(nullable: false),
                    GuidelineValuesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalGuidelines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MunicipalGuidelines_GuidelineValues_GuidelineValuesId",
                        column: x => x.GuidelineValuesId,
                        principalTable: "GuidelineValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MunicipalGuidelines_Municipalities_MunicipalitiesId",
                        column: x => x.MunicipalitiesId,
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssociationGuidelines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuidelineValuesId = table.Column<int>(nullable: false),
                    AssociationId = table.Column<int>(nullable: false),
                    CommunitySectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationGuidelines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssociationGuidelines_Associations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Associations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssociationGuidelines_CommunitySections_CommunitySectionId",
                        column: x => x.CommunitySectionId,
                        principalTable: "CommunitySections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssociationGuidelines_GuidelineValues_GuidelineValuesId",
                        column: x => x.GuidelineValuesId,
                        principalTable: "GuidelineValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuilderPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuilderId = table.Column<int>(nullable: false),
                    GuidelineValueId = table.Column<int>(nullable: false),
                    CommunityId = table.Column<int>(nullable: true),
                    SectionId = table.Column<int>(nullable: true),
                    Override = table.Column<bool>(nullable: false),
                    OverrideNotes = table.Column<string>(nullable: true),
                    OverrideDocReference = table.Column<string>(nullable: true),
                    OverrideDate = table.Column<DateTime>(nullable: true),
                    OverrideBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuilderPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuilderPreferences_Builders_BuilderId",
                        column: x => x.BuilderId,
                        principalTable: "Builders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuilderPreferences_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuilderPreferences_GuidelineValues_GuidelineValueId",
                        column: x => x.GuidelineValueId,
                        principalTable: "GuidelineValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuilderPreferences_CommunitySections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "CommunitySections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDivisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommunitySectionId = table.Column<int>(nullable: false),
                    BuildersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDivisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDivisions_Builders_BuildersId",
                        column: x => x.BuildersId,
                        principalTable: "Builders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubDivisions_CommunitySections_CommunitySectionId",
                        column: x => x.CommunitySectionId,
                        principalTable: "CommunitySections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSubDivisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubDivisionId = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubDivisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubDivisions_SubDivisions_SubDivisionId",
                        column: x => x.SubDivisionId,
                        principalTable: "SubDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSubDivisions_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociationGuidelines_AssociationId",
                table: "AssociationGuidelines",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationGuidelines_CommunitySectionId",
                table: "AssociationGuidelines",
                column: "CommunitySectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationGuidelines_GuidelineValuesId",
                table: "AssociationGuidelines",
                column: "GuidelineValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_AddressId",
                table: "Associations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BuilderPreferences_BuilderId",
                table: "BuilderPreferences",
                column: "BuilderId");

            migrationBuilder.CreateIndex(
                name: "IX_BuilderPreferences_CommunityId",
                table: "BuilderPreferences",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_BuilderPreferences_GuidelineValueId",
                table: "BuilderPreferences",
                column: "GuidelineValueId");

            migrationBuilder.CreateIndex(
                name: "IX_BuilderPreferences_SectionId",
                table: "BuilderPreferences",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Builders_AddressId",
                table: "Builders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_AssociationId",
                table: "Communities",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_MunicipalitiesId",
                table: "Communities",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunitySections_CommunityId",
                table: "CommunitySections",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Guidelines_CategoryId",
                table: "Guidelines",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidelineTypes_DraftTypeId",
                table: "GuidelineTypes",
                column: "DraftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidelineTypes_GuidelineId",
                table: "GuidelineTypes",
                column: "GuidelineId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidelineValues_GuidelineId",
                table: "GuidelineValues",
                column: "GuidelineId");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalGuidelines_GuidelineValuesId",
                table: "MunicipalGuidelines",
                column: "GuidelineValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalGuidelines_MunicipalitiesId",
                table: "MunicipalGuidelines",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_AddressId",
                table: "Municipalities",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDivisions_BuildersId",
                table: "SubDivisions",
                column: "BuildersId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDivisions_CommunitySectionId",
                table: "SubDivisions",
                column: "CommunitySectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubDivisions_SubDivisionId",
                table: "UserSubDivisions",
                column: "SubDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubDivisions_UserId",
                table: "UserSubDivisions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociationGuidelines");

            migrationBuilder.DropTable(
                name: "BuilderPreferences");

            migrationBuilder.DropTable(
                name: "GuidelineTypes");

            migrationBuilder.DropTable(
                name: "MunicipalGuidelines");

            migrationBuilder.DropTable(
                name: "UserSubDivisions");

            migrationBuilder.DropTable(
                name: "DraftTypes");

            migrationBuilder.DropTable(
                name: "GuidelineValues");

            migrationBuilder.DropTable(
                name: "SubDivisions");

            migrationBuilder.DropTable(
                name: "Guidelines");

            migrationBuilder.DropTable(
                name: "Builders");

            migrationBuilder.DropTable(
                name: "CommunitySections");

            migrationBuilder.DropTable(
                name: "GuidelineCategories");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
