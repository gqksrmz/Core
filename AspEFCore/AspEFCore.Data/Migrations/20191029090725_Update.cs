using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspEFCore.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cityCompanies_Cities_CityId",
                table: "cityCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_cityCompanies_Company_CompanyId",
                table: "cityCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cityCompanies",
                table: "cityCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "cityCompanies",
                newName: "CityCompanies");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_cityCompanies_CompanyId",
                table: "CityCompanies",
                newName: "IX_CityCompanies_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityCompanies",
                table: "CityCompanies",
                columns: new[] { "CityId", "CompanyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Mayors",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mayors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mayors_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mayors_CityId",
                table: "Mayors",
                column: "CityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CityCompanies_Cities_CityId",
                table: "CityCompanies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityCompanies_Companies_CompanyId",
                table: "CityCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityCompanies_Cities_CityId",
                table: "CityCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_CityCompanies_Companies_CompanyId",
                table: "CityCompanies");

            migrationBuilder.DropTable(
                name: "Mayors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityCompanies",
                table: "CityCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "CityCompanies",
                newName: "cityCompanies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_CityCompanies_CompanyId",
                table: "cityCompanies",
                newName: "IX_cityCompanies_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cityCompanies",
                table: "cityCompanies",
                columns: new[] { "CityId", "CompanyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cityCompanies_Cities_CityId",
                table: "cityCompanies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cityCompanies_Company_CompanyId",
                table: "cityCompanies",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
