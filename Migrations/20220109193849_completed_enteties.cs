using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDbWebApi.Migrations
{
    public partial class completed_enteties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoanCardNumber",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBorrowed",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanCardNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsBorrowed",
                table: "Books");
        }
    }
}
