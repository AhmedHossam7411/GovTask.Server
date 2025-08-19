using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccurateColumnNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Departments_DepartmentEntityId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DepartmentEntityId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DepartmentEntityId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "TaskDescription",
                table: "Tasks",
                newName: "Description");
            migrationBuilder.RenameColumn(
                  name: "TaskName",
                  table: "Tasks",
                  newName: "Name");
            migrationBuilder.RenameColumn(
                  name: "TaskDueDate",
                  table: "Tasks",
                  newName: "DueDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentEntityId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DepartmentEntityId",
                table: "Documents",
                column: "DepartmentEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Departments_DepartmentEntityId",
                table: "Documents",
                column: "DepartmentEntityId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameColumn(
            name: "Description",
            table: "Tasks",
            newName: "TaskDescription");
            migrationBuilder.RenameColumn(
                  name: "Name",
                  table: "Tasks",
                  newName: "TaskName");
            migrationBuilder.RenameColumn(
                  name: "DueDate",
                  table: "Tasks",
                  newName: "TaskDueDate");
        }
    }
}
