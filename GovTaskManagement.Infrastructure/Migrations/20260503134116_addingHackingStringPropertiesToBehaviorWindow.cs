using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingHackingStringPropertiesToBehaviorWindow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetectedPatterns",
                table: "BehaviorWindows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HackingStringDetected",
                table: "BehaviorWindows",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetectedPatterns",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "HackingStringDetected",
                table: "BehaviorWindows");
        }
    }
}
