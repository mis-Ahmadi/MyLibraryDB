using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Backend.API.Migrations
{
    /// <inheritdoc />
    public partial class FixName1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titel",
                table: "Books",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "Titel");
        }
    }
}
