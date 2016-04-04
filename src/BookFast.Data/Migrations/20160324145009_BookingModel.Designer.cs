using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BookFast.Data.Models;

namespace BookFast.Data.Migrations
{
    [DbContext(typeof(BookFastContext))]
    [Migration("20160324145009_BookingModel")]
    partial class BookingModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
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
                });

            modelBuilder.Entity("BookFast.Data.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccommodationId");

                    b.Property<DateTimeOffset>("FromDate");

                    b.Property<DateTimeOffset>("ToDate");

                    b.Property<string>("User");

                    b.HasKey("Id");
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
                });

            modelBuilder.Entity("BookFast.Data.Models.Accommodation", b =>
                {
                    b.HasOne("BookFast.Data.Models.Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId");
                });

            modelBuilder.Entity("BookFast.Data.Models.Booking", b =>
                {
                    b.HasOne("BookFast.Data.Models.Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId");
                });
        }
    }
}
