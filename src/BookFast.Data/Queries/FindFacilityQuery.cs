using System;
using System.Threading.Tasks;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Microsoft.Data.Entity;
using Facility = BookFast.Contracts.Models.Facility;

namespace BookFast.Data.Queries
{
    internal class FindFacilityQuery : IQuery<BookFastContext, Facility>
    {
        private readonly Guid facilityId;
        private readonly IFacilityMapper mapper;

        public FindFacilityQuery(Guid facilityId, IFacilityMapper mapper)
        {
            this.facilityId = facilityId;
            this.mapper = mapper;
        }

        public async Task<Facility> ExecuteAsync(BookFastContext model)
        {
            var facility = await model.Facilities.FirstOrDefaultAsync(f => f.Id == facilityId);
            return facility != null ? mapper.MapFrom(facility) : null;
        }
    }
}