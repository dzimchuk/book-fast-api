using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Search;

namespace BookFast.Contracts
{
    public interface ISearchService
    {
        Task<IList<SearchResult>> SearchAsync(string searchText, int page);
        Task<IList<SuggestResult>> SuggestAsync(string searchText);
    }
}