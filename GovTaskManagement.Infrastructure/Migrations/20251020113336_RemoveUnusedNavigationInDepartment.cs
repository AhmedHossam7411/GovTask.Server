using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedNavigationInDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_ApiUserId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Tasks_TaskEntityId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ApiUserId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_TaskEntityId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ApiUserId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "TaskEntityId",
                table: "Departments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiUserId",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskEntityId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ApiUserId",
                table: "Departments",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_TaskEntityId",
                table: "Departments",
                column: "TaskEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_ApiUserId",
                table: "Departments",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Tasks_TaskEntityId",
                table: "Departments",
                column: "TaskEntityId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
