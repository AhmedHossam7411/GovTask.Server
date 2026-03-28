using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingNewBehavioralProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvgPreClickSpeed",
                table: "BehaviorWindows",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ClickRate",
                table: "BehaviorWindows",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MouseMoveRate",
                table: "BehaviorWindows",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StdPreClickSpeed",
                table: "BehaviorWindows",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgPreClickSpeed",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "ClickRate",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "MouseMoveRate",
                table: "BehaviorWindows");

            migrationBuilder.DropColumn(
                name: "StdPreClickSpeed",
                table: "BehaviorWindows");
        }
    }
}
