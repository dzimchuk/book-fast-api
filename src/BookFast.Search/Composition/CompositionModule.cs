using System;
using BookFast.Business;
using BookFast.Business.Data;
using BookFast.Contracts.Framework;
using BookFast.Search.Mappers;
using Microsoft.Azure.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.OptionsModel;

namespace BookFast.Search.Composition
{
    public class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SearchOptions>(configuration.GetSection("Search"));

            services.AddScoped(provider => CreateSearchIndexClient(provider, true));
            services.AddScoped<ISearchIndexer, SearchIndexer>();

            services.AddScoped<ISearchResultMapper, SearchResultMapper>();
            services.AddScoped<ISearchDataSource>(provider => new SearchAdapter(CreateSearchIndexClient(provider, false), provider.GetService<ISearchResultMapper>()));
        }

        private static ISearchIndexClient CreateSearchIndexClient(IServiceProvider provider, bool useAdminKey)
        { 
            var options = provider.GetService<IOptions<SearchOptions>>(); 
            return new SearchIndexClient(options.Value.ServiceName, 
                options.Value.IndexName, new SearchCredentials(useAdminKey? options.Value.AdminKey : options.Value.QueryKey)); 
        }
    }
}