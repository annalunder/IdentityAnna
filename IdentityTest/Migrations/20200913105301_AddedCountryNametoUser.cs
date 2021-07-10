using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityTest.Migrations
{
    public partial class AddedCountryNametoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                schema: "Identity",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryName",
                schema: "Identity",
                table: "AspNetUsers");
        }
    }
}
