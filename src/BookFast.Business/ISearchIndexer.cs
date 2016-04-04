using System;
using System.Threading.Tasks;
using BookFast.Contracts.Models;

namespace BookFast.Business
{
    public interface ISearchIndexer
    {
        Task IndexAccommodationAsync(Accommodation accommodation, Facility facility);
        Task DeleteAccommodationIndexAsync(Guid accommodationId);
    }
}