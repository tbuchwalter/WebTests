using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPoints.Migrations
{
    public partial class AddPassivable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "GuidelineValues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BuilderPreferences",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "GuidelineValues");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BuilderPreferences");
        }
    }
}
