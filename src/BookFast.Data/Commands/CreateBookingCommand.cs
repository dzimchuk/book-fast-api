using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Booking = BookFast.Contracts.Models.Booking;

namespace BookFast.Data.Commands
{
    internal class CreateBookingCommand : ICommand<BookFastContext>
    {
        private readonly Booking booking;
        private readonly IBookingMapper mapper;

        public CreateBookingCommand(Booking booking, IBookingMapper mapper)
        {
            this.booking = booking;
            this.mapper = mapper;
        }

        public Task ApplyAsync(BookFastContext model)
        {
            model.Bookings.Add(mapper.MapFrom(booking));
            return model.SaveChangesAsync();
        }
    }
}