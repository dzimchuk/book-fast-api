using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace BookFast.Data.Migrations
{
    public partial class FacilityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RoomCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodation_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Accommodation");
            migrationBuilder.DropTable("Facility");
        }
    }
}
