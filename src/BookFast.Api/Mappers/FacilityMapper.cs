using System.Collections.Generic;
using AutoMapper;
using BookFast.Api.Controllers;
using BookFast.Api.Models;
using BookFast.Api.Models.Representations;
using BookFast.Contracts.Models;

namespace BookFast.Api.Mappers
{
    internal class FacilityMapper : IFacilityMapper
    {
        private static readonly IMapper Mapper;

        static FacilityMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
                                                              {
                                                                  configuration.CreateMap<Facility, FacilityRepresentation>()
                                                                               .ForMember(vm => vm.Name, config => config.MapFrom(m => m.Details.Name))
                                                                               .ForMember(vm => vm.Description, config => config.MapFrom(m => m.Details.Description))
                                                                               .ForMember(vm => vm.StreetAddress, config => config.MapFrom(m => m.Details.StreetAddress))
                                                                               .ForMember(vm => vm.Latitude, config => config.MapFrom(m => m.Location.Latitude))
                                                                               .ForMember(vm => vm.Longitude, config => config.MapFrom(m => m.Location.Longitude));

                                                                  configuration.CreateMap<FacilityData, FacilityDetails>();
                                                              });
            mapperConfiguration.AssertConfigurationIsValid();

            Mapper = mapperConfiguration.CreateMapper();
        }

        public FacilityRepresentation MapFrom(Facility facility)
        {
            return Mapper.Map<FacilityRepresentation>(facility);
        }

        public IEnumerable<FacilityRepresentation> MapFrom(IEnumerable<Facility> facilities)
        {
            return Mapper.Map<IEnumerable<FacilityRepresentation>>(facilities);
        }

        public FacilityDetails MapFrom(FacilityData data)
        {
            return Mapper.Map<FacilityDetails>(data);
        }
    }
}