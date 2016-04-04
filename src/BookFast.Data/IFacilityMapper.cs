using System.Collections.Generic;
using BookFast.Contracts.Models;

namespace BookFast.Data
{
    public interface IFacilityMapper
    {
        Facility MapFrom(Models.Facility facility);
        IEnumerable<Facility> MapFrom(IEnumerable<Models.Facility> facilities);
        Models.Facility MapFrom(Facility facility);
    }
}