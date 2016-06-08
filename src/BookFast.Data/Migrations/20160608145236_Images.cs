using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookFast.Data.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Facilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Accommodations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Accommodations");
        }
    }
}
