using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Data.Commands;
using BookFast.Data.Models;
using BookFast.Data.Queries;
using Facility = BookFast.Contracts.Models.Facility;

namespace BookFast.Data
{
    internal class FacilityDataSource : IFacilityDataSource
    {
        private readonly BookFastContext context;
        private readonly IFacilityMapper mapper;

        public FacilityDataSource(BookFastContext context, IFacilityMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<List<Facility>> ListByOwnerAsync(string owner)
        {
            var query = new ListFacilitiesByOwnerQuery(owner, mapper);
            return query.ExecuteAsync(context);
        }

        public Task<Facility> FindAsync(Guid facilityId)
        {
            var query = new FindFacilityQuery(facilityId, mapper);
            return query.ExecuteAsync(context);
        }

        public Task CreateAsync(Facility facility)
        {
            var command = new CreateFacilityCommand(facility, mapper);
            return command.ApplyAsync(context);
        }

        public Task UpdateAsync(Facility facility)
        {
            var command = new UpdateFacilityCommand(facility);
            return command.ApplyAsync(context);
        }

        public Task<bool> ExistsAsync(Guid facilityId)
        {
            var query = new DoesFaciityExistQuery(facilityId);
            return query.ExecuteAsync(context);
        }

        public Task DeleteAsync(Guid facilityId)
        {
            var command = new DeleteFacilityCommand(facilityId);
            return command.ApplyAsync(context);
        }
    }
}