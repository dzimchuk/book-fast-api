using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Microsoft.Data.Entity;
using Booking = BookFast.Contracts.Models.Booking;

namespace BookFast.Data.Commands
{
    internal class UpdateBookingCommand : ICommand<BookFastContext>
    {
        private readonly Booking booking;

        public UpdateBookingCommand(Booking booking)
        {
            this.booking = booking;
        }

        public async Task ApplyAsync(BookFastContext model)
        {
            var existingBooking = await model.Bookings.FirstOrDefaultAsync(b => b.Id == booking.Id);
            if (existingBooking != null)
            {
                existingBooking.CanceledOn = booking.CanceledOn;
                existingBooking.CheckedInOn = booking.CheckedInOn;

                await model.SaveChangesAsync();
            }
        }
    }
}