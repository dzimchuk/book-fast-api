using System.Collections.Generic;
using BookFast.Contracts.Models;

namespace BookFast.Data
{
    public interface IAccommodationMapper
    {
        Accommodation MapFrom(Models.Accommodation accommodation);
        IEnumerable<Accommodation> MapFrom(IEnumerable<Models.Accommodation> accommodations);
        Models.Accommodation MapFrom(Accommodation accommodation);
    }
}