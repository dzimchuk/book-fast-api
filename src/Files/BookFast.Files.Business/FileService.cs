using BookFast.Files.Contracts;
using System;
using System.Threading.Tasks;
using BookFast.Files.Contracts.Models;
using BookFast.Contracts;
using System.IO;

namespace BookFast.Files.Business
{
    internal class FileService : IFileService
    {
        private readonly IAccessTokenProvider tokenProvider;
        private readonly IFacilityService facilityService;
        private readonly IAccommodationService accommodationService;

        private const double TokenExpirationTime = 20;

        public FileService(IAccessTokenProvider tokenProvider, IFacilityService facilityService, IAccommodationService accommodationService)
        {
            this.tokenProvider = tokenProvider;
            this.facilityService = facilityService;
            this.accommodationService = accommodationService;
        }

        public async Task<FileAccessToken> IssueAccommodationImageUploadTokenAsync(Guid accommodationId, string originalFileName)
        {
            var accommodation = await accommodationService.FindAsync(accommodationId);

            var fileName = GenerateName(originalFileName);
            var path = ConstructPath(accommodation.FacilityId, accommodation.Id, fileName);
            return await IssueImageUploadTokenAsync(fileName, path);
        }

        public async Task<FileAccessToken> IssueFacilityImageUploadTokenAsync(Guid facilityId, string originalFileName)
        {
            await facilityService.CheckFacilityAsync(facilityId);

            var fileName = GenerateName(originalFileName);
            var path = ConstructPath(facilityId, fileName);
            return await IssueImageUploadTokenAsync(fileName, path);
        }

        private async Task<FileAccessToken> IssueImageUploadTokenAsync(string fileName, string path)
        {
            var token = await tokenProvider.GetFileAccessTokenAsync(path, AccessPermission.Write, DateTimeOffset.Now.AddMinutes(TokenExpirationTime));
            return new FileAccessToken
            {
                AccessPermission = AccessPermission.Write,
                FileName = fileName,
                Value = token
            };
        }   

        private string GenerateName(string originalFileName)
        {
            var extension = Path.GetExtension(originalFileName);
            if (string.IsNullOrWhiteSpace(extension))
            {
                extension = ".jpg";
            }

            return $"{Path.GetRandomFileName()}{extension}";
        }

        private string ConstructPath(Guid facilityId, Guid accommodationId, string fileName) => $"{facilityId}/{accommodationId}/{fileName}";

        private string ConstructPath(Guid facilityId, string fileName) => $"{facilityId}/{fileName}";
    }
}
