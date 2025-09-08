using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovTaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correctDocumentNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "documentName",
                table: "Documents",
                newName: "Name");
            migrationBuilder.RenameColumn(
                  name: "documentDescription",
                  table: "Documents",
                  newName: "Description");
            migrationBuilder.RenameColumn(
                  name: "documentUploadDate",
                  table: "Documents",
                  newName: "UploadDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
               name: "Name",
               table: "Documents",
               newName: "documentName");
            migrationBuilder.RenameColumn(
                  name: "Description",
                  table: "Documents",
                  newName: "documentDescription");
            migrationBuilder.RenameColumn(
                  name: "UploadDate",
                  table: "Documents",
                  newName: "documentUploadDate");
        }
    }
}
