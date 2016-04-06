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
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingService service;
        private readonly IBookingMapper mapper;

        public BookingController(IBookingService service, IBookingMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// List bookings by customer
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/bookings")]
        [SwaggerOperation("list-bookings")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<BookingRepresentation>))]
        public async Task<IEnumerable<BookingRepresentation>> List()
        {
            var bookings = await service.ListPendingAsync();
            return mapper.MapFrom(bookings);
        }

        /// <summary>
        /// Find booking by ID
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns></returns>
        [HttpGet("api/bookings/{id}")]
        [SwaggerOperation("find-booking")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(BookingRepresentation))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Booking not found")]
        public async Task<IActionResult> Find(Guid id)
        {
            try
            {
                var booking = await service.FindAsync(id);
                return Ok(mapper.MapFrom(booking));
            }
            catch (BookingNotFoundException)
            {
                return HttpNotFound();
            }
        }

        /// <summary>
        /// Book an accommodation
        /// </summary>
        /// <param name="accommodationId">Accommodation ID</param>
        /// <param name="bookingData">Booking details</param>
        /// <returns></returns>
        [HttpPost("api/accommodations/{accommodationId}/bookings")]
        [SwaggerOperation("create-booking")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.Created, Type = typeof(BookingRepresentation))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Accommodation not found")]
        public async Task<IActionResult> Create([FromRoute]Guid accommodationId, [FromBody]BookingData bookingData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var booking = await service.BookAsync(accommodationId, mapper.MapFrom(bookingData));
                    return CreatedAtAction("Find", mapper.MapFrom(booking));
                }

                return HttpBadRequest();
            }
            catch (AccommodationNotFoundException)
            {
                return HttpNotFound();
            }
        }

        /// <summary>
        /// Cancel booking
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns></returns>
        [HttpDelete("api/bookings/{id}")]
        [SwaggerOperation("delete-booking")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Attempt to cancel a booking of another user")]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Booking not found")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await service.CancelAsync(id);
                return new NoContentResult();
            }
            catch (BookingNotFoundException)
            {
                return HttpNotFound();
            }
            catch (UserMismatchException)
            {
                return HttpBadRequest();
            }
        }
    }
}