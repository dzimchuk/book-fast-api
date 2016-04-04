using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Api.Models;
using BookFast.Api.Models.Representations;
using BookFast.Contracts;
using BookFast.Contracts.Exceptions;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace BookFast.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "FacilityProviderOnly")]
    public class FacilitiesController : Controller
    {
        private readonly IFacilityService facilityService;
        private readonly IFacilityMapper facilityMapper;

        public FacilitiesController(IFacilityService facilityService, IFacilityMapper facilityMapper)
        {
            this.facilityService = facilityService;
            this.facilityMapper = facilityMapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FacilityRepresentation>> List()
        {
            var facilities = await facilityService.ListAsync();
            return facilityMapper.MapFrom(facilities);
        }
        
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Find(Guid id)
        {
            try
            {
                var facility = await facilityService.FindAsync(id);
                return new ObjectResult(facilityMapper.MapFrom(facility));
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]FacilityData facilityData)
        {
            if (ModelState.IsValid)
            {
                var facility = await facilityService.CreateAsync(facilityMapper.MapFrom(facilityData));
                return CreatedAtAction("Find", facilityMapper.MapFrom(facility));
            }

            return HttpBadRequest();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]FacilityData facilityData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var facility = await facilityService.UpdateAsync(id, facilityMapper.MapFrom(facilityData));
                    return new ObjectResult(facilityMapper.MapFrom(facility));
                }

                return HttpBadRequest();
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await facilityService.DeleteAsync(id);
                return new NoContentResult();
            }
            catch (FacilityNotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}