using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace BookFast.Data.Migrations
{
    public partial class UpdatedBookingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Accommodation_Facility_FacilityId", table: "Accommodation");
            migrationBuilder.DropForeignKey(name: "FK_Booking_Accommodation_AccommodationId", table: "Booking");
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CanceledOn",
                table: "Booking",
                nullable: true);
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CheckedInOn",
                table: "Booking",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_Facility_FacilityId",
                table: "Accommodation",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Accommodation_AccommodationId",
                table: "Booking",
                column: "AccommodationId",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Accommodation_Facility_FacilityId", table: "Accommodation");
            migrationBuilder.DropForeignKey(name: "FK_Booking_Accommodation_AccommodationId", table: "Booking");
            migrationBuilder.DropColumn(name: "CanceledOn", table: "Booking");
            migrationBuilder.DropColumn(name: "CheckedInOn", table: "Booking");
            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_Facility_FacilityId",
                table: "Accommodation",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Accommodation_AccommodationId",
                table: "Booking",
                column: "AccommodationId",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
