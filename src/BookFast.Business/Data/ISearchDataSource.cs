using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Contracts.Search;

namespace BookFast.Business.Data
{
    public interface ISearchDataSource
    {
        Task<IList<SearchResult>> SearchAsync(string searchText, int page);
        Task<IList<SuggestResult>> SuggestAsync(string searchText);
    }
}