using BookFast.Contracts.Framework;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookFast.Files.Business;

namespace BookFast.Files.Data.Composition
{
    public class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureStorageOptions>(configuration.GetSection("Azure:Storage"));
            services.AddScoped<IAccessTokenProvider, AccessTokenProvider>();
        }
    }
}
