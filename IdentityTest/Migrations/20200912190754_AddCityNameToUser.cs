using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityTest.Migrations
{
    public partial class AddCityNameToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                schema: "Identity",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                schema: "Identity",
                table: "AspNetUsers");
        }
    }
}
