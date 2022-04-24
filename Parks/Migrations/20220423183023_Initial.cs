using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    State = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Country = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "City", "Country", "Name", "Size", "State" },
                values: new object[,]
                {
                    { 1, "", "Namibia", "Etosha National Park", 8600, "" },
                    { 2, "", "USA", "Grand Canyon National Park", 1904, "Arizona" },
                    { 3, "", "India", "Jim Corbett National Park", 201, "Uttarakhand" },
                    { 4, "", "South Africa", "Kruger National Park", 7512, "" },
                    { 5, "", "Italy", "Dolomiti Bellunesi National Park", 1, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
