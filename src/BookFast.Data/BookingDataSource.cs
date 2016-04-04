using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Data.Commands;
using BookFast.Data.Models;
using BookFast.Data.Queries;
using Booking = BookFast.Contracts.Models.Booking;

namespace BookFast.Data
{
    internal class BookingDataSource : IBookingDataSource
    {
        private readonly BookFastContext context;
        private readonly IBookingMapper mapper;

        public BookingDataSource(BookFastContext context, IBookingMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task CreateAsync(Booking booking)
        {
            var command = new CreateBookingCommand(booking, mapper);
            return command.ApplyAsync(context);
        }

        public Task<List<Booking>> ListPendingAsync(string user)
        {
            var query = new ListPendingBookingsByUserQuery(user);
            return query.ExecuteAsync(context);
        }

        public Task<Booking> FindAsync(Guid id)
        {
            var query = new FindBookingQuery(id);
            return query.ExecuteAsync(context);
        }

        public Task UpdateAsync(Booking booking)
        {
            var command = new UpdateBookingCommand(booking);
            return command.ApplyAsync(context);
        }
    }
}