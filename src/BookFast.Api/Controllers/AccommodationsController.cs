using System;
using System.Threading.Tasks;
using BookFast.Api.Models;
using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace BookFast.Api.Controllers
{
    [Authorize(Policy = "FacilityProviderOnly")]
    public class AccommodationsController : Controller
    {
        private readonly IAccommodationService service;
        private readonly IAccommodationMapper mapper;

        public AccommodationsController(IAccommodationService service, IAccommodationMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("api/facilities/{facilityId}/accommodations")]
        public async Task<IActionResult> List(Guid facilityId)
        {
            try
            {
                var accommodations = await service.ListAsync(facilityId);
                return new ObjectResult(mapper.MapFrom(accommodations));
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpGet("api/accommodations/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Find(Guid id)
        {
            try
            {
                var accommodation = await service.FindAsync(id);
                return new ObjectResult(mapper.MapFrom(accommodation));
            }
            catch (AccommodationNotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpPost("api/facilities/{facilityId}/accommodations")]
        public async Task<IActionResult> Create([FromRoute]Guid facilityId, [FromBody]AccommodationData accommodationData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var accommodation = await service.CreateAsync(facilityId, mapper.MapFrom(accommodationData));
                    return CreatedAtAction("Find", mapper.MapFrom(accommodation));
                }

                return HttpBadRequest();
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpPut("api/accommodations/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]AccommodationData accommodationData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var accommodation = await service.UpdateAsync(id, mapper.MapFrom(accommodationData));
                    return new ObjectResult(mapper.MapFrom(accommodation));
                }

                return HttpBadRequest();
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
            catch (AccommodationNotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpDelete("api/accommodations/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await service.DeleteAsync(id);
                return new NoContentResult();
            }
            catch (AccommodationNotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}