using System;
using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Microsoft.Data.Entity;

namespace BookFast.Data.Queries
{
    internal class DoesFaciityExistQuery : IQuery<BookFastContext, bool>
    {
        private readonly Guid facilityId;

        public DoesFaciityExistQuery(Guid facilityId)
        {
            this.facilityId = facilityId;
        }

        public Task<bool> ExecuteAsync(BookFastContext model)
        {
            return model.Facilities.AnyAsync(f => f.Id == facilityId);
        }
    }
}