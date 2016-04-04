using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace BookFast.Data.Migrations
{
    public partial class BookingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Accommodation_Facility_FacilityId", table: "Accommodation");
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccommodationId = table.Column<Guid>(nullable: false),
                    FromDate = table.Column<DateTimeOffset>(nullable: false),
                    ToDate = table.Column<DateTimeOffset>(nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Accommodation_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
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
            migrationBuilder.DropTable("Booking");
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
