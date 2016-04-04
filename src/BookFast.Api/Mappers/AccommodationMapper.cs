using System.Collections.Generic;
using AutoMapper;
using BookFast.Api.Controllers;
using BookFast.Api.Models;
using BookFast.Api.Models.Representations;
using BookFast.Contracts.Models;

namespace BookFast.Api.Mappers
{
    internal class AccommodationMapper : IAccommodationMapper
    {
        private static readonly IMapper Mapper;

        static AccommodationMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
                                                              {
                                                                  configuration.CreateMap<Accommodation, AccommodationRepresentation>()
                                                                               .ForMember(vm => vm.Name, config => config.MapFrom(m => m.Details.Name))
                                                                               .ForMember(vm => vm.Description, config => config.MapFrom(m => m.Details.Description))
                                                                               .ForMember(vm => vm.RoomCount, config => config.MapFrom(m => m.Details.RoomCount));

                                                                  configuration.CreateMap<AccommodationData, AccommodationDetails>();
                                                              });
            mapperConfiguration.AssertConfigurationIsValid();

            Mapper = mapperConfiguration.CreateMapper();
        }

        public AccommodationRepresentation MapFrom(Accommodation accommodation)
        {
            return Mapper.Map<AccommodationRepresentation>(accommodation);
        }

        public IEnumerable<AccommodationRepresentation> MapFrom(IEnumerable<Accommodation> accommodations)
        {
            return Mapper.Map<IEnumerable<AccommodationRepresentation>>(accommodations);
        }

        public AccommodationDetails MapFrom(AccommodationData data)
        {
            return Mapper.Map<AccommodationDetails>(data);
        }
    }
}