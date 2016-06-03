using BookFast.Files.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookFast.Files.Contracts.Models;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace BookFast.Files.Data
{
    internal class AccessTokenProvider : IAccessTokenProvider
    {
        private readonly AzureStorageOptions storageOptions;
        private readonly Regex regexAccountName = new Regex(@"AccountName=(?<name>[^;]+);*", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private readonly Regex regexAccountKey = new Regex(@"AccountKey=(?<key>[^;]+);*", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public AccessTokenProvider(IOptions<AzureStorageOptions> storageOptions)
        {
            this.storageOptions = storageOptions.Value;
        }

        public Task<string> GetFileAccessTokenAsync(string path, AccessPermission permission, DateTimeOffset expirationTime)
        {
            throw new NotImplementedException();
        }

        private string GetCanonicalName(string path) => $"/blob/{"AccountName"}/{storageOptions.ImageContainer}/{path.Replace('\\', '/')}";

        private string AccountName => regexAccountName.Match(storageOptions.ConnectionString).Groups["name"].Value;
        private string AccountKey => regexAccountName.Match(storageOptions.ConnectionString).Groups["key"].Value;
    }
}
