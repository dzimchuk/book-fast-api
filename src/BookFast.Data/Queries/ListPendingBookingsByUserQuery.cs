using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Booking = BookFast.Contracts.Models.Booking;
using System.Linq;
using BookFast.Contracts.Models;
using Microsoft.Data.Entity;

namespace BookFast.Data.Queries
{
    internal class ListPendingBookingsByUserQuery : IQuery<BookFastContext, List<Booking>>
    {
        private readonly string user;

        public ListPendingBookingsByUserQuery(string user)
        {
            this.user = user;
        }

        public Task<List<Booking>> ExecuteAsync(BookFastContext model)
        {
            return (from b in model.Bookings
                    where b.User.Equals(user, StringComparison.OrdinalIgnoreCase) &&
                          b.CanceledOn == null && b.CheckedInOn == null
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
                               StreetAddress = b.Accommodation.Facility.StreetAddress
                           }).ToListAsync();
        }
    }
}