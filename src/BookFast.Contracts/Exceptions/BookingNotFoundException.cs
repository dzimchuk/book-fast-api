using System;

namespace BookFast.Contracts.Exceptions
{
    public class BookingNotFoundException : Exception
    {
        public Guid BookingId { get; }

        public BookingNotFoundException(Guid bookingId)
        {
            BookingId = bookingId;
        }
    }
}