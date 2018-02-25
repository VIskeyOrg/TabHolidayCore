using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TabHolidayCore.Migrations
{
    public partial class UserMgmt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgencyTierLevels",
                columns: table => new
                {
                    AgencyTierLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyTierLevels", x => x.AgencyTierLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Extention = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    AgencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    AgencyTierLevelId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    TaxId = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.AgencyId);
                    table.ForeignKey(
                        name: "FK_Agencies_AgencyTierLevels_AgencyTierLevelId",
                        column: x => x.AgencyTierLevelId,
                        principalTable: "AgencyTierLevels",
                        principalColumn: "AgencyTierLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agencies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<string>(
                name: "ActualName",
                table: "AspNetUsers",
                type: "VARCHAR(200)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AgencyId",
                table: "AspNetUsers",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_AgencyTierLevelId",
                table: "Agencies",
                column: "AgencyTierLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_CountryId",
                table: "Agencies",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Agencies_AgencyId",
                table: "AspNetUsers",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "AgencyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Agencies_AgencyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AgencyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ActualName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "AgencyTierLevels");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
