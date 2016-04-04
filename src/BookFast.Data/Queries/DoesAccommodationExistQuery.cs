using System;
using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Microsoft.Data.Entity;

namespace BookFast.Data.Queries
{
    internal class DoesAccommodationExistQuery : IQuery<BookFastContext, bool>
    {
        private readonly Guid accommodationId;

        public DoesAccommodationExistQuery(Guid accommodationId)
        {
            this.accommodationId = accommodationId;
        }

        public Task<bool> ExecuteAsync(BookFastContext model)
        {
            return model.Accommodations.AnyAsync(a => a.Id == accommodationId);
        }
    }
}