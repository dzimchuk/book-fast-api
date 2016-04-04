using System.Collections.Generic;
using BookFast.Contracts.Search;

namespace BookFast.Search
{
    public interface ISearchResultMapper
    {
        IList<SearchResult> MapFrom(IList<Microsoft.Azure.Search.Models.SearchResult> results);
        IList<SuggestResult> MapFrom(IList<Microsoft.Azure.Search.Models.SuggestResult> results);

    }
}