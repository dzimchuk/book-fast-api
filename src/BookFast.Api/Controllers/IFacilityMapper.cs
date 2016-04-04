using System.Collections.Generic;
using BookFast.Api.Models;
using BookFast.Api.Models.Representations;
using BookFast.Contracts.Models;

namespace BookFast.Api.Controllers
{
    public interface IFacilityMapper
    {
        FacilityRepresentation MapFrom(Facility facility);
        IEnumerable<FacilityRepresentation> MapFrom(IEnumerable<Facility> facilities);
        FacilityDetails MapFrom(FacilityData data);
    }
}