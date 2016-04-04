using System;

namespace BookFast.Api.Models.Representations
{
    public class FacilityRepresentation
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string StreetAddress { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public int AccommodationCount { get; set; }
    }
}