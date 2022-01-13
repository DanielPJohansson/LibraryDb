using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDbWebApi.Migrations
{
    public partial class name_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_LibraryBooks_BookId",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Loans",
                newName: "LibraryBookId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                newName: "IX_Loans_LibraryBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_LibraryBooks_LibraryBookId",
                table: "Loans",
                column: "LibraryBookId",
                principalTable: "LibraryBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_LibraryBooks_LibraryBookId",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "LibraryBookId",
                table: "Loans",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_LibraryBookId",
                table: "Loans",
                newName: "IX_Loans_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_LibraryBooks_BookId",
                table: "Loans",
                column: "BookId",
                principalTable: "LibraryBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
