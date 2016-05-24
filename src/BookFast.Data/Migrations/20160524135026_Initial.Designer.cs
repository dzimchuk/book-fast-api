using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BookFast.Data.Models;

namespace BookFast.Data.Migrations
{
    [DbContext(typeof(BookFastContext))]
    [Migration("20160524135026_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookFast.Data.Models.Accommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("FacilityId");

                    b.Property<string>("Name");

                    b.Property<int>("RoomCount");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("BookFast.Data.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccommodationId");

                    b.Property<DateTimeOffset?>("CanceledOn");

                    b.Property<DateTimeOffset?>("CheckedInOn");

                    b.Property<DateTimeOffset>("FromDate");

                    b.Property<DateTimeOffset>("ToDate");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookFast.Data.Models.Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccommodationCount");

                    b.Property<string>("Description");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.Property<string>("StreetAddress");

                    b.HasKey("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("BookFast.Data.Models.Accommodation", b =>
                {
                    b.HasOne("BookFast.Data.Models.Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookFast.Data.Models.Booking", b =>
                {
                    b.HasOne("BookFast.Data.Models.Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
