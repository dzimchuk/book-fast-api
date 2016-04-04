using System;
using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Microsoft.Data.Entity;

namespace BookFast.Data.Commands
{
    internal class DeleteFacilityCommand : ICommand<BookFastContext>
    {
        private readonly Guid facilityId;

        public DeleteFacilityCommand(Guid facilityId)
        {
            this.facilityId = facilityId;
        }

        public async Task ApplyAsync(BookFastContext model)
        {
            var facility = await model.Facilities.FirstOrDefaultAsync(f => f.Id == facilityId);
            if (facility != null)
            {
                model.Facilities.Remove(facility);
                await model.SaveChangesAsync();
            }
        }
    }
}