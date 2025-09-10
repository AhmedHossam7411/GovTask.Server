using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCreatorIdToTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "creatorId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_creatorId",
                table: "Tasks",
                column: "creatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_creatorId",
                table: "Tasks",
                column: "creatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_creatorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_creatorId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "creatorId",
                table: "Tasks");
        }
    }
}
