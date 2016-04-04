using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using BookFast.Contracts.Framework;
using BookFast.Data.Models;
using Microsoft.Data.Entity;
using Facility = BookFast.Contracts.Models.Facility;

namespace BookFast.Data.Queries
{
    internal class ListFacilitiesByOwnerQuery : IQuery<BookFastContext, List<Facility>>
    {
        private readonly string owner;
        private readonly IFacilityMapper mapper;

        public ListFacilitiesByOwnerQuery(string owner, IFacilityMapper mapper)
        {
            this.owner = owner;
            this.mapper = mapper;
        }

        public async Task<List<Facility>> ExecuteAsync(BookFastContext model)
        {
            var facilities = await (from f in model.Facilities
                                    where f.Owner.Equals(owner, StringComparison.OrdinalIgnoreCase)
                                    select f).ToListAsync();

            return mapper.MapFrom(facilities).ToList();
        }
    }
}