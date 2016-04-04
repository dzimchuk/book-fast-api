using System;
using System.Linq;
using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Contracts.Models;
using BookFast.Data.Models;
using Booking = BookFast.Contracts.Models.Booking;
using Microsoft.Data.Entity;

namespace BookFast.Data.Queries
{
    internal class FindBookingQuery : IQuery<BookFastContext, Booking>
    {
        private readonly Guid id;

        public FindBookingQuery(Guid id)
        {
            this.id = id;
        }

        public Task<Booking> ExecuteAsync(BookFastContext model)
        {
            return (from b in model.Bookings
                    where b.Id == id
                    select new Booking
                           {
                               Id = b.Id,
                               AccommodationId = b.AccommodationId,
                               User = b.User,
                               Details = new BookingDetails
                                         {
                                             FromDate = b.FromDate,
                                             ToDate = b.ToDate
                                         },
                               AccommodationName = b.Accommodation.Name,
                               FacilityId = b.Accommodation.FacilityId,
                               FacilityName = b.Accommodation.Facility.Name,
                               StreetAddress = b.Accommodation.Facility.StreetAddress,
                               CanceledOn = b.CanceledOn,
                               CheckedInOn = b.CheckedInOn
                           }).FirstOrDefaultAsync();
        }
    }
}