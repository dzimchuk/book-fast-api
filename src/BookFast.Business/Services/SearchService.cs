using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Business.Data;
using BookFast.Contracts;
using BookFast.Contracts.Search;

namespace BookFast.Business.Services
{
    internal class SearchService : ISearchService
    {
        private readonly ISearchDataSource dataSource;

        public SearchService(ISearchDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public Task<IList<SearchResult>> SearchAsync(string searchText, int page)
        {
            return dataSource.SearchAsync(searchText, page);
        }

        public Task<IList<SuggestResult>> SuggestAsync(string searchText)
        {
            return dataSource.SuggestAsync(searchText);
        }
    }
}