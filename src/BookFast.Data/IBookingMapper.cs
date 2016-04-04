using BookFast.Contracts.Models;

namespace BookFast.Data
{
    public interface IBookingMapper
    {
        Models.Booking MapFrom(Booking booking);
    }
}