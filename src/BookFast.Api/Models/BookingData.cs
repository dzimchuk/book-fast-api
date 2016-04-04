using System;
using System.ComponentModel.DataAnnotations;
using BookFast.Api.Validation;

namespace BookFast.Api.Models
{
    [DateRange(ErrorMessage = "End date should be greater than or equal to start date")]
    public class BookingData
    {
        public Guid AccommodationId { get; set; }

        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Start date cannot be in the past")]
        public DateTimeOffset FromDate { get; set; }

        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "End date cannot be in the past")]
        public DateTimeOffset ToDate { get; set; }
    }
}