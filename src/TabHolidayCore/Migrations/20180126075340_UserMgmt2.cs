using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TabHolidayCore.Migrations
{
    public partial class UserMgmt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Agencies_AgencyId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AgencyId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Agencies_AgencyId",
                table: "AspNetUsers",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "AgencyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Agencies_AgencyId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AgencyId",
                table: "AspNetUsers",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Agencies_AgencyId",
                table: "AspNetUsers",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "AgencyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
