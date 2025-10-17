using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableUserTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskEntityUser_Tasks_TasksId",
                table: "TaskEntityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskEntityUser_Users_UsersApiUserId",
                table: "TaskEntityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskEntityUser",
                table: "TaskEntityUser");

            migrationBuilder.RenameTable(
                name: "TaskEntityUser",
                newName: "Users-Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_TaskEntityUser_UsersApiUserId",
                table: "Users-Tasks",
                newName: "IX_Users-Tasks_UsersApiUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users-Tasks",
                table: "Users-Tasks",
                columns: new[] { "TasksId", "UsersApiUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users-Tasks_Tasks_TasksId",
                table: "Users-Tasks",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users-Tasks_Users_UsersApiUserId",
                table: "Users-Tasks",
                column: "UsersApiUserId",
                principalTable: "Users",
                principalColumn: "ApiUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users-Tasks_Tasks_TasksId",
                table: "Users-Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users-Tasks_Users_UsersApiUserId",
                table: "Users-Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users-Tasks",
                table: "Users-Tasks");

            migrationBuilder.RenameTable(
                name: "Users-Tasks",
                newName: "TaskEntityUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users-Tasks_UsersApiUserId",
                table: "TaskEntityUser",
                newName: "IX_TaskEntityUser_UsersApiUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskEntityUser",
                table: "TaskEntityUser",
                columns: new[] { "TasksId", "UsersApiUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEntityUser_Tasks_TasksId",
                table: "TaskEntityUser",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEntityUser_Users_UsersApiUserId",
                table: "TaskEntityUser",
                column: "UsersApiUserId",
                principalTable: "Users",
                principalColumn: "ApiUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
