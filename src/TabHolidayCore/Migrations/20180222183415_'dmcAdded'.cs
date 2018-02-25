using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TabHolidayCore.Migrations
{
    public partial class dmcAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccountTypes",
                columns: table => new
                {
                    BankAccountTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountTypes", x => x.BankAccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DMCs",
                columns: table => new
                {
                    DMCId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    FaxNumber = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    OfficeNumber = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    TaxNumber = table.Column<string>(type: "VARCHAR(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMCs", x => x.DMCId);
                    table.ForeignKey(
                        name: "FK_DMCs_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DMCOfficialTypes",
                columns: table => new
                {
                    DMCOfficialTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMCOfficialTypes", x => x.DMCOfficialTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    BankDetailId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountHolderName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    AccountNumber = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    BankAccountTypeId = table.Column<int>(nullable: false),
                    BranchName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DMCId = table.Column<long>(nullable: true),
                    IBANCode = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    IFSCCode = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    MICRNumber = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    RoutingNumber = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    SwiftCode = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.BankDetailId);
                    table.ForeignKey(
                        name: "FK_BankDetails_BankAccountTypes_BankAccountTypeId",
                        column: x => x.BankAccountTypeId,
                        principalTable: "BankAccountTypes",
                        principalColumn: "BankAccountTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankDetails_DMCs_DMCId",
                        column: x => x.DMCId,
                        principalTable: "DMCs",
                        principalColumn: "DMCId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DMCOfficial",
                columns: table => new
                {
                    DMCOfficialId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DMCId = table.Column<long>(nullable: true),
                    DMCOfficialTypeId = table.Column<int>(nullable: false),
                    EmailId = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMCOfficial", x => x.DMCOfficialId);
                    table.ForeignKey(
                        name: "FK_DMCOfficial_DMCs_DMCId",
                        column: x => x.DMCId,
                        principalTable: "DMCs",
                        principalColumn: "DMCId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMCOfficial_DMCOfficialTypes_DMCOfficialTypeId",
                        column: x => x.DMCOfficialTypeId,
                        principalTable: "DMCOfficialTypes",
                        principalColumn: "DMCOfficialTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_BankAccountTypeId",
                table: "BankDetails",
                column: "BankAccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_DMCId",
                table: "BankDetails",
                column: "DMCId");

            migrationBuilder.CreateIndex(
                name: "IX_DMCs_CountryId",
                table: "DMCs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DMCOfficial_DMCId",
                table: "DMCOfficial",
                column: "DMCId");

            migrationBuilder.CreateIndex(
                name: "IX_DMCOfficial_DMCOfficialTypeId",
                table: "DMCOfficial",
                column: "DMCOfficialTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "DMCOfficial");

            migrationBuilder.DropTable(
                name: "BankAccountTypes");

            migrationBuilder.DropTable(
                name: "DMCs");

            migrationBuilder.DropTable(
                name: "DMCOfficialTypes");
        }
    }
}
