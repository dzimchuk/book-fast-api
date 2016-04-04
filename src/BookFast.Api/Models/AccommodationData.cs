using System;
using System.ComponentModel.DataAnnotations;

namespace BookFast.Api.Models
{
    public class AccommodationData
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, 20)]
        public int RoomCount { get; set; }
    }
}