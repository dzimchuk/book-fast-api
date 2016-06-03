using BookFast.Files.Contracts.Models;
using System;
using System.Threading.Tasks;

namespace BookFast.Files.Business
{
    public interface IAccessTokenProvider
    {
        Task<string> GetFileAccessTokenAsync(string path, AccessPermission permission, DateTimeOffset expirationTime);
    }
}
