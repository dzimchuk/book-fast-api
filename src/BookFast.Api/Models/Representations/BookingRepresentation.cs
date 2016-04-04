using System;
using System.ComponentModel.DataAnnotations;

namespace BookFast.Api.Models.Representations
{
    public class BookingRepresentation
    {
        public Guid Id { get; set; }
        public Guid AccommodationId { get; set; }
        public string AccommodationName { get; set; }
        public Guid FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string StreetAddress { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
    }
}