using System.Collections.Generic;
using AutoMapper;
using BookFast.Api.Controllers;
using BookFast.Api.Models;
using BookFast.Api.Models.Representations;
using BookFast.Contracts.Models;

namespace BookFast.Api.Mappers
{
    internal class BookingMapper : IBookingMapper
    {
        private static readonly IMapper Mapper;

        static BookingMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
                                                              {
                                                                  configuration.CreateMap<BookingData, BookingDetails>();
                                                                  configuration.CreateMap<Booking, BookingRepresentation>()
                                                                               .ForMember(vm => vm.FromDate, config => config.MapFrom(m => m.Details.FromDate))
                                                                               .ForMember(vm => vm.ToDate, config => config.MapFrom(m => m.Details.ToDate));
                                                              });
            mapperConfiguration.AssertConfigurationIsValid();

            Mapper = mapperConfiguration.CreateMapper();
        }

        public BookingDetails MapFrom(BookingData data)
        {
            return Mapper.Map<BookingDetails>(data);
        }

        public IEnumerable<BookingRepresentation> MapFrom(IEnumerable<Booking> bookings)
        {
            return Mapper.Map<IEnumerable<BookingRepresentation>>(bookings);
        }

        public BookingRepresentation MapFrom(Booking booking)
        {
            return Mapper.Map<BookingRepresentation>(booking);
        }
    }
}