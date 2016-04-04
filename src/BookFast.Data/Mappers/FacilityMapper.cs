using System.Collections.Generic;
using AutoMapper;
using BookFast.Contracts.Models;

namespace BookFast.Data.Mappers
{
    internal class FacilityMapper : IFacilityMapper
    {
        private static readonly IMapper Mapper;

        static FacilityMapper()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
                                                              {
                                                                  config.CreateMap<Facility, Models.Facility>()
                                                                        .ForMember(dm => dm.Name, c => c.MapFrom(m => m.Details.Name))
                                                                        .ForMember(dm => dm.Description, c => c.MapFrom(m => m.Details.Description))
                                                                        .ForMember(dm => dm.StreetAddress, c => c.MapFrom(m => m.Details.StreetAddress))
                                                                        .ForMember(dm => dm.Latitude, c => c.MapFrom(m => m.Location.Latitude))
                                                                        .ForMember(dm => dm.Longitude, c => c.MapFrom(m => m.Location.Longitude))
                                                                        .ForMember(dm => dm.Accommodations, c => c.Ignore())
                                                                        .ReverseMap()
                                                                        .ConvertUsing(dm => new Facility
                                                                                            {
                                                                                                Id = dm.Id,
                                                                                                Owner = dm.Owner,
                                                                                                Details = new FacilityDetails
                                                                                                          {
                                                                                                              Name = dm.Name,
                                                                                                              Description = dm.Description,
                                                                                                              StreetAddress = dm.StreetAddress
                                                                                                          },
                                                                                                Location = new Location
                                                                                                           {
                                                                                                               Latitude = dm.Latitude,
                                                                                                               Longitude = dm.Longitude
                                                                                                           },
                                                                                                AccommodationCount = dm.AccommodationCount
                                                                                            });
                                                              });
            mapperConfiguration.AssertConfigurationIsValid();

            Mapper = mapperConfiguration.CreateMapper();
        }

        public Facility MapFrom(Models.Facility facility)
        {
            return Mapper.Map<Facility>(facility);
        }

        public IEnumerable<Facility> MapFrom(IEnumerable<Models.Facility> facilities)
        {
            return Mapper.Map<IEnumerable<Facility>>(facilities);
        } 

        public Models.Facility MapFrom(Facility facility)
        {
            return Mapper.Map<Models.Facility>(facility);
        }
    }
}