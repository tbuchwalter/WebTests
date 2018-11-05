using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPoints.Migrations
{
    public partial class AddedAutitingInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GuidelineValues");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GuidelineValues");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Guidelines");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Guidelines");

            migrationBuilder.DropColumn(
                name: "CratedBy",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Builders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Builders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Builders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Associations");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "UserSubDivisions",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserSubDivisions",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Municipalities",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Municipalities",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "GuidelineValues",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "GuidelineValues",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Guidelines",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Guidelines",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Communities",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Communities",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Builders",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Associations",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Associations",
                newName: "CreationTime");

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "UserSubDivisions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "UserSubDivisions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Municipalities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Municipalities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Municipalities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Municipalities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Municipalities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "GuidelineValues",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GuidelineValues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GuidelineValues",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GuidelineValues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "GuidelineValues",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Guidelines",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Guidelines",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Guidelines",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Guidelines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Guidelines",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "GuidelineCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "GuidelineCategories",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GuidelineCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GuidelineCategories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GuidelineCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "GuidelineCategories",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "GuidelineCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "DraftTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "DraftTypes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "DraftTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "DraftTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DraftTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "DraftTypes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "DraftTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "CommunitySections",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "CommunitySections",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "CommunitySections",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "CommunitySections",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CommunitySections",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "CommunitySections",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "CommunitySections",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Communities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Communities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Communities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Communities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Communities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Builders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Builders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Builders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Builders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Builders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Builders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "BuilderPreferences",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "BuilderPreferences",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "BuilderPreferences",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "BuilderPreferences",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BuilderPreferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "BuilderPreferences",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "BuilderPreferences",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Associations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Addresses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "UserSubDivisions");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "UserSubDivisions");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "GuidelineValues");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GuidelineValues");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GuidelineValues");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GuidelineValues");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "GuidelineValues");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Guidelines");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Guidelines");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Guidelines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Guidelines");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Guidelines");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "GuidelineCategories");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "GuidelineCategories");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GuidelineCategories");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GuidelineCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GuidelineCategories");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "GuidelineCategories");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "GuidelineCategories");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "DraftTypes");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "DraftTypes");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "DraftTypes");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "DraftTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DraftTypes");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "DraftTypes");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "DraftTypes");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "CommunitySections");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "CommunitySections");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "CommunitySections");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "CommunitySections");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CommunitySections");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "CommunitySections");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "CommunitySections");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Builders");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Builders");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Builders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Builders");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Builders");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Builders");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "BuilderPreferences");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "BuilderPreferences");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "BuilderPreferences");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "BuilderPreferences");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BuilderPreferences");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "BuilderPreferences");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "BuilderPreferences");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "UserSubDivisions",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "UserSubDivisions",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "Municipalities",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Municipalities",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "GuidelineValues",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "GuidelineValues",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "Guidelines",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Guidelines",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "Communities",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Communities",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Builders",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "Associations",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Associations",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Municipalities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Municipalities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GuidelineValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "GuidelineValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Guidelines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Guidelines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CratedBy",
                table: "Communities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Communities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Builders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Builders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Builders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Associations",
                nullable: true);
        }
    }
}
