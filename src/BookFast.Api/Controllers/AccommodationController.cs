using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Api.Models;
using BookFast.Api.Models.Representations;
using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

namespace BookFast.Api.Controllers
{
    [Authorize(Policy = "FacilityProviderOnly")]
    public class AccommodationController : Controller
    {
        private readonly IAccommodationService service;
        private readonly IAccommodationMapper mapper;

        public AccommodationController(IAccommodationService service, IAccommodationMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("api/facilities/{facilityId}/accommodations")]
        [SwaggerOperation("list-accommodations")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<AccommodationRepresentation>))]
        public async Task<IActionResult> List(Guid facilityId)
        {
            try
            {
                var accommodations = await service.ListAsync(facilityId);
                return Ok(mapper.MapFrom(accommodations));
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpGet("api/accommodations/{id}")]
        [SwaggerOperation("find-accommodation")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(AccommodationRepresentation))]
        [AllowAnonymous]
        public async Task<IActionResult> Find(Guid id)
        {
            try
            {
                var accommodation = await service.FindAsync(id);
                return Ok(mapper.MapFrom(accommodation));
            }
            catch (AccommodationNotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpPost("api/facilities/{facilityId}/accommodations")]
        [SwaggerOperation("create-accommodation")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.Created, Type = typeof(AccommodationRepresentation))]
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
        [SwaggerOperation("update-accommodation")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(AccommodationRepresentation))]
        public async Task<IActionResult> Update(Guid id, [FromBody]AccommodationData accommodationData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var accommodation = await service.UpdateAsync(id, mapper.MapFrom(accommodationData));
                    return Ok(mapper.MapFrom(accommodation));
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
        [SwaggerOperation("delete-accommodation")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
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