using System.Collections.Generic;
using BookFast.Api.Models;
using BookFast.Api.Models.Representations;
using BookFast.Contracts.Models;

namespace BookFast.Api.Controllers
{
    public interface IBookingMapper
    {
        BookingDetails MapFrom(BookingData data);
        IEnumerable<BookingRepresentation> MapFrom(IEnumerable<Booking> bookings);
        BookingRepresentation MapFrom(Booking booking);
    }
}