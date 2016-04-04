using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Models;

namespace BookFast.Business.Data
{
    public interface IFacilityDataSource
    {
        Task<List<Facility>> ListByOwnerAsync(string owner);
        Task<Facility> FindAsync(Guid facilityId);
        Task CreateAsync(Facility facility);
        Task UpdateAsync(Facility facility);
        Task<bool> ExistsAsync(Guid facilityId);
        Task DeleteAsync(Guid facilityId);
    }
}