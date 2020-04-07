using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RollLogin.Data.Migrations
{
    public partial class Superman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodMag",
                columns: table => new
                {
                    FId = table.Column<string>(nullable: false),
                    Fcode = table.Column<string>(nullable: true),
                    FName = table.Column<string>(nullable: true),
                    FPrice = table.Column<float>(nullable: false),
                    FDisc = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Atri = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ODate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMag", x => x.FId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMag");
        }
    }
}
