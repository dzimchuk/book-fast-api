using AutoMapper;
using BookFast.Api.Controllers;
using BookFast.Api.Models.Representations;
using BookFast.Files.Contracts.Models;

namespace BookFast.Api.Mappers
{
    internal class FileAccessMapper : IFileAccessMapper
    {
        private static readonly IMapper Mapper;

        static FileAccessMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<FileAccessToken, FileAccessTokenRepresentation>();
            });

            mapperConfiguration.AssertConfigurationIsValid();
            Mapper = mapperConfiguration.CreateMapper();
        }

        public FileAccessTokenRepresentation MapFrom(FileAccessToken token)
        {
            return Mapper.Map<FileAccessTokenRepresentation>(token);
        }
    }
}
