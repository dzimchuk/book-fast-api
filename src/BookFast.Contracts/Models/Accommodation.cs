using System;

namespace BookFast.Contracts.Models
{
    public class Accommodation
    {
        public Guid Id { get; set; }
        public Guid FacilityId { get; set; }
        public AccommodationDetails Details { get; set; }
    }
}