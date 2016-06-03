namespace BookFast.Files.Contracts.Models
{
    public class FileAccessToken
    {
        public AccessPermission AccessPermission { get; set; }
        public string Value { get; set; }
        public string FileName { get; set; }
    }
}
