using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shop_category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(nullable: true),
                    Rating = table.Column<decimal>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    SiteLink = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shop_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "shop_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            
            migrationBuilder.InsertData(
                table: "shop_category",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 1, "Supermarket" },
                    { 2, "Petrol station" },
                    { 3, "Toy shop" }
                });

            migrationBuilder.InsertData(
                table: "shop",
                columns: new[] { "Id", "CategoryId", "Rating", "Address", "SiteLink" },
                values: new object[,]
                {
                    { 1, 1, 4.2, "test address", "site.com" }
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_shop_CategoryId",
                table: "shop",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Summary");
        }
    }
}
