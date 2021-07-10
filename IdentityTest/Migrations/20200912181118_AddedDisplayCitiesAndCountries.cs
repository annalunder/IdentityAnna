using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityTest.Migrations
{
    public partial class AddedDisplayCitiesAndCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisplayCities",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisplayCountries",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayCountries", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "DisplayCities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Stockholm" },
                    { 2, "Varberg" },
                    { 3, "London" },
                    { 4, "Bergen" },
                    { 5, "Lerum" },
                    { 6, "New York" },
                    { 7, "Kiruna" },
                    { 8, "Miami" },
                    { 9, "Oslo" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "DisplayCountries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sweden" },
                    { 2, "England" },
                    { 3, "Norway" },
                    { 4, "USA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisplayCities",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DisplayCountries",
                schema: "Identity");
        }
    }
}
