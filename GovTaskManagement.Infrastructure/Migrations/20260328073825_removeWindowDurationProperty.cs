using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeWindowDurationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WindowDuration",
                table: "BehaviorWindows");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WindowDuration",
                table: "BehaviorWindows",
                type: "int",
                nullable: true);
        }
    }
}
