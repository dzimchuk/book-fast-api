using BookFast.Api.Models.Representations;
using BookFast.Files.Contracts.Models;

namespace BookFast.Api.Controllers
{
    public interface IFileAccessMapper
    {
        FileAccessTokenRepresentation MapFrom(FileAccessToken token);
    }
}
