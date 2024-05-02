using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BruShop.Web.Api.Migrations
{
    public partial class tets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "aprelev_user");

            migrationBuilder.CreateTable(
                name: "Articles",
                schema: "aprelev_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    PathToImg = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "aprelev_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PathToImg = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                schema: "aprelev_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Author = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles",
                schema: "aprelev_user");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "aprelev_user");

            migrationBuilder.DropTable(
                name: "Reviews",
                schema: "aprelev_user");
        }
    }
}
