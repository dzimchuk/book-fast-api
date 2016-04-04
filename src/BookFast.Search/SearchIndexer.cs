using System;
using System.Threading.Tasks;
using BookFast.Business;
using BookFast.Contracts.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;

namespace BookFast.Search
{
    internal class SearchIndexer : ISearchIndexer
    {
        private readonly ISearchIndexClient client;

        public SearchIndexer(ISearchIndexClient client)
        {
            this.client = client;
        }

        public Task IndexAccommodationAsync(Accommodation accommodation, Facility facility)
        {
            var action = IndexAction.MergeOrUpload(CreateDocument(accommodation, facility));
            return client.Documents.IndexAsync(new IndexBatch(new[] { action }));
        }

        public Task DeleteAccommodationIndexAsync(Guid accommodationId)
        {
            var action = IndexAction.Delete(new Document { { "Id", accommodationId } });
            return client.Documents.IndexAsync(new IndexBatch(new[] { action }));
        }

        private static Document CreateDocument(Accommodation accommodation, Facility facility)
        {
            return new Document
                   {
                       { "Id", accommodation.Id },
                       { "FacilityId", accommodation.FacilityId },
                       { "Name", accommodation.Details.Name },
                       { "Description", accommodation.Details.Description },
                       { "FacilityName", facility.Details.Name },
                       { "FacilityDescription", facility.Details.Description },
                       { "Location", CreateGeographyPoint(facility.Location) },
                       { "RoomCount", accommodation.Details.RoomCount }
                   };
        }

        private static GeographyPoint CreateGeographyPoint(Location location)
        {
            if (location != null && location.Latitude != null && location.Longitude != null)
                return GeographyPoint.Create(location.Latitude.Value, location.Longitude.Value);

            return null;
        }
    }
}