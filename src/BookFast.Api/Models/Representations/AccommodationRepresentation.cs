using System;

namespace BookFast.Api.Models.Representations
{
    public class AccommodationRepresentation
    {
        public Guid Id { get; set; }
        public Guid FacilityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomCount { get; set; }
    }
}