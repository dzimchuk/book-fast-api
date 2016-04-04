using System;
using BookFast.Business;
using BookFast.Business.Data;
using BookFast.Contracts.Framework;
using BookFast.Search.Mappers;
using Microsoft.Azure.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookFast.Search.Composition
{
    public class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(provider => CreateSearchIndexClient(provider, "search:adminKey"));
            services.AddScoped<ISearchIndexer, SearchIndexer>();

            services.AddScoped<ISearchResultMapper, SearchResultMapper>();
            services.AddScoped<ISearchDataSource>(provider => new SearchAdapter(CreateSearchIndexClient(provider, "search:queryKey"), provider.GetService<ISearchResultMapper>()));
        }

        private static ISearchIndexClient CreateSearchIndexClient(IServiceProvider provider, string apiKey)
        { 
            var configuration = provider.GetService<IConfiguration>(); 
            return new SearchIndexClient(configuration["search:serviceName"], 
                configuration["search:indexName"], new SearchCredentials(configuration[apiKey])); 
        }
    }
}