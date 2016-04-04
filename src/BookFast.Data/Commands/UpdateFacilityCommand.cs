using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Microsoft.Data.Entity;
using Facility = BookFast.Contracts.Models.Facility;

namespace BookFast.Data.Commands
{
    internal class UpdateFacilityCommand : ICommand<BookFastContext>
    {
        private readonly Facility facility;

        public UpdateFacilityCommand(Facility facility)
        {
            this.facility = facility;
        }

        public async Task ApplyAsync(BookFastContext model)
        {
            var existingFacility = await model.Facilities.FirstOrDefaultAsync(f => f.Id == facility.Id);
            if (existingFacility != null)
            {
                existingFacility.Name = facility.Details.Name;
                existingFacility.Description = facility.Details.Description;
                existingFacility.StreetAddress = facility.Details.StreetAddress;
                existingFacility.Latitude = facility.Location.Latitude;
                existingFacility.Longitude = facility.Location.Longitude;
                existingFacility.Owner = facility.Owner;
                existingFacility.AccommodationCount = facility.AccommodationCount;

                await model.SaveChangesAsync();
            }
        }
    }
}