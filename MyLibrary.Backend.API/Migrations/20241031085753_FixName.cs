using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Backend.API.Migrations
{
    /// <inheritdoc />
    public partial class FixName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Members_MemerId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_MemerId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "MemerId",
                table: "Borrows");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_MemberId",
                table: "Borrows",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Members_MemberId",
                table: "Borrows",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Members_MemberId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_MemberId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Borrows");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MemerId",
                table: "Borrows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_MemerId",
                table: "Borrows",
                column: "MemerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Members_MemerId",
                table: "Borrows",
                column: "MemerId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
