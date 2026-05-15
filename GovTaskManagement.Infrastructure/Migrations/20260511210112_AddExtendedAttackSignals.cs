using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExtendedAttackSignals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AbnormalInputDetected",
                table: "BehaviorWindows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DevToolsDetected",
                table: "BehaviorWindows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DevToolsShortcutCount",
                table: "BehaviorWindows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PasteCount",
                table: "BehaviorWindows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SuspiciousPasteDetected",
                table: "BehaviorWindows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UnauthorizedAttempts",
                table: "BehaviorWindows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbnormalInputDetected",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "DevToolsDetected",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "DevToolsShortcutCount",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "PasteCount",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "SuspiciousPasteDetected",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "UnauthorizedAttempts",
                table: "BehaviorWindows");
        }
    }
}
