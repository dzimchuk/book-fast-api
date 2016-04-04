using AutoMapper;
using BookFast.Contracts.Models;

namespace BookFast.Data.Mappers
{
    internal class BookingMapper : IBookingMapper
    {
        private static readonly IMapper Mapper;

        static BookingMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
                                                              {
                                                                  configuration.CreateMap<Booking, Models.Booking>()
                                                                               .ForMember(storeModel => storeModel.FromDate, config => config.MapFrom(m => m.Details.FromDate))
                                                                               .ForMember(storeModel => storeModel.ToDate, config => config.MapFrom(m => m.Details.ToDate))
                                                                               .ForMember(storeModel => storeModel.Accommodation, config => config.Ignore());
                                                              });
            mapperConfiguration.AssertConfigurationIsValid();

            Mapper = mapperConfiguration.CreateMapper();
        }

        public Models.Booking MapFrom(Booking booking)
        {
            return Mapper.Map<Models.Booking>(booking);
        }
    }
}