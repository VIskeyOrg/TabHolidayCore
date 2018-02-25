using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TabHolidayCore.Migrations
{
    public partial class agencyowner2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgencyOwnerId",
                table: "Agencies");

            migrationBuilder.AddColumn<bool>(
                name: "IsAgencyOwner",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAgencyOwner",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<long>(
                name: "AgencyOwnerId",
                table: "Agencies",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
