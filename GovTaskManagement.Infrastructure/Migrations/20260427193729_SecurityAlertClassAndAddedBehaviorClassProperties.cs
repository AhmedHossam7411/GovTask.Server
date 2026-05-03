using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecurityAlertClassAndAddedBehaviorClassProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvgScrollSpeed",
                table: "BehaviorWindows",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HardwareConcurrency",
                table: "BehaviorWindows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "BehaviorWindows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "BehaviorWindows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "BehaviorWindows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenResolution",
                table: "BehaviorWindows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScrollEventCount",
                table: "BehaviorWindows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "BehaviorWindows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                table: "BehaviorWindows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SecurityAlerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    BehaviorWindowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityAlerts_BehaviorWindows_BehaviorWindowId",
                        column: x => x.BehaviorWindowId,
                        principalTable: "BehaviorWindows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAlerts_BehaviorWindowId",
                table: "SecurityAlerts",
                column: "BehaviorWindowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityAlerts");

            migrationBuilder.DropColumn(
                name: "AvgScrollSpeed",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "HardwareConcurrency",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "ScreenResolution",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "ScrollEventCount",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "UserAgent",
                table: "BehaviorWindows");
        }
    }
}
