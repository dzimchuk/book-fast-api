using BookFast.Files.Contracts.Models;

namespace BookFast.Api.Models.Representations
{
    public class FileAccessTokenRepresentation
    {
        public AccessPermission AccessPermission { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
    }
}
