using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using BookFast.Contracts.Models;

namespace BookFast.Business.Services
{
    internal class FacilityService : IFacilityService
    {
        private readonly IFacilityDataSource dataSource;
        private readonly ISecurityContext securityContext;

        public FacilityService(IFacilityDataSource dataSource, ISecurityContext securityContext)
        {
            this.dataSource = dataSource;
            this.securityContext = securityContext;
        }

        public Task<List<Facility>> ListAsync()
        {
            return dataSource.ListByOwnerAsync(securityContext.GetCurrentTenant());
        }

        public async Task<Facility> FindAsync(Guid facilityId)
        {
            var facility = await dataSource.FindAsync(facilityId);
            if (facility == null)
                throw new FacilityNotFoundException(facilityId);

            return facility;
        }

        public async Task<Facility> CreateAsync(FacilityDetails details)
        {
            var facility = new Facility
                           {
                               Id = Guid.NewGuid(),
                               Details = details,
                               Location = new Location(),
                               Owner = securityContext.GetCurrentTenant()
                           };

            await dataSource.CreateAsync(facility);
            return facility;
        }

        public async Task<Facility> UpdateAsync(Guid facilityId, FacilityDetails details)
        {
            var facility = await dataSource.FindAsync(facilityId);
            if (facility == null)
                throw new FacilityNotFoundException(facilityId);

            facility.Details = details;
            await dataSource.UpdateAsync(facility);

            return facility;
        }

        public async Task DeleteAsync(Guid facilityId)
        {
            if (!await dataSource.ExistsAsync(facilityId))
                throw new FacilityNotFoundException(facilityId);

            await dataSource.DeleteAsync(facilityId);
        }

        public async Task CheckFacilityAsync(Guid facilityId)
        {
            if (!await dataSource.ExistsAsync(facilityId))
                throw new FacilityNotFoundException(facilityId);
        }

        public async Task IncrementAccommodationCountAsync(Guid facilityId)
        {
            var facility = await FindAsync(facilityId);

            facility.AccommodationCount++;
            await dataSource.UpdateAsync(facility);
        }

        public async Task DecrementAccommodationCountAsync(Guid facilityId)
        {
            var facility = await FindAsync(facilityId);

            facility.AccommodationCount--;
            await dataSource.UpdateAsync(facility);
        }
    }
}