using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Models;

namespace BookFast.Business.Data
{
    public interface IBookingDataSource
    {
        Task CreateAsync(Booking booking);
        Task<List<Booking>> ListPendingAsync(string user);
        Task<Booking> FindAsync(Guid id);
        Task UpdateAsync(Booking booking);
    }
}