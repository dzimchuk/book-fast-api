using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace BookFast.Data.Migrations
{
    public partial class AccommodationCountField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Accommodation_Facility_FacilityId", table: "Accommodation");
            migrationBuilder.AddColumn<int>(
                name: "AccommodationCount",
                table: "Facility",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_Facility_FacilityId",
                table: "Accommodation",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Accommodation_Facility_FacilityId", table: "Accommodation");
            migrationBuilder.DropColumn(name: "AccommodationCount", table: "Facility");
            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_Facility_FacilityId",
                table: "Accommodation",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
