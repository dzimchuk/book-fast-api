using System.Collections.Generic;
using BookFast.Api.Models;
using BookFast.Api.Models.Representations;
using BookFast.Contracts.Models;

namespace BookFast.Api.Controllers
{
    public interface IAccommodationMapper
    {
        AccommodationRepresentation MapFrom(Accommodation accommodation);
        IEnumerable<AccommodationRepresentation> MapFrom(IEnumerable<Accommodation> accommodations);
        AccommodationDetails MapFrom(AccommodationData data);
    }
}