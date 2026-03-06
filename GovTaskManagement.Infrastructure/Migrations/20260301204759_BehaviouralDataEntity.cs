using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BehaviouralDataEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BehaviorWindows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvgMouseSpeed = table.Column<double>(type: "float", nullable: false),
                    StdMouseSpeed = table.Column<double>(type: "float", nullable: false),
                    MouseMoveCount = table.Column<int>(type: "int", nullable: false),
                    AvgMouseIdle = table.Column<double>(type: "float", nullable: false),
                    StdMouseIdle = table.Column<double>(type: "float", nullable: false),
                    AvgClickDuration = table.Column<double>(type: "float", nullable: false),
                    StdClickDuration = table.Column<double>(type: "float", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    AvgClickInterval = table.Column<double>(type: "float", nullable: false),
                    StdClickInterval = table.Column<double>(type: "float", nullable: false),
                    AvgDwell = table.Column<double>(type: "float", nullable: false),
                    StdDwell = table.Column<double>(type: "float", nullable: false),
                    AvgFlight = table.Column<double>(type: "float", nullable: false),
                    StdFlight = table.Column<double>(type: "float", nullable: false),
                    KeyEventCount = table.Column<int>(type: "int", nullable: false),
                    TypingRate = table.Column<double>(type: "float", nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BehaviorWindows", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BehaviorWindows");
        }
    }
}
