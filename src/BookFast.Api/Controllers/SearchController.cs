using System.Threading.Tasks;
using BookFast.Contracts;
using Microsoft.AspNet.Mvc;

namespace BookFast.Api.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService service;

        public SearchController(ISearchService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery]string searchText, [FromQuery]int page = 1)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return HttpBadRequest();

            if (page < 1)
                return HttpBadRequest();

            var searchResults = await service.SearchAsync(searchText, page);
            return new ObjectResult(searchResults);
        }
    }
}