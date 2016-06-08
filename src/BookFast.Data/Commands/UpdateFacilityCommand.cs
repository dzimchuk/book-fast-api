using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Facility = BookFast.Contracts.Models.Facility;
using Microsoft.EntityFrameworkCore;

namespace BookFast.Data.Commands
{
    internal class UpdateFacilityCommand : ICommand<BookFastContext>
    {
        private readonly Facility facility;
        private readonly IFacilityMapper mapper;

        public UpdateFacilityCommand(Facility facility, IFacilityMapper mapper)
        {
            this.facility = facility;
            this.mapper = mapper;
        }

        public async Task ApplyAsync(BookFastContext model)
        {
            var existingFacility = await model.Facilities.FirstOrDefaultAsync(f => f.Id == facility.Id);
            if (existingFacility != null)
            {
                var dm = mapper.MapFrom(facility);

                existingFacility.Name = dm.Name;
                existingFacility.Description = dm.Description;
                existingFacility.StreetAddress = dm.StreetAddress;
                existingFacility.Latitude = dm.Latitude;
                existingFacility.Longitude = dm.Longitude;
                existingFacility.Owner = dm.Owner;
                existingFacility.AccommodationCount = dm.AccommodationCount;
                existingFacility.Images = dm.Images;

                await model.SaveChangesAsync();
            }
        }
    }
}