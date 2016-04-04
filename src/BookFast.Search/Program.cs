using System;
using Microsoft.Azure.Search;
using Microsoft.Extensions.Configuration;

namespace BookFast.Search
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("provision", StringComparison.OrdinalIgnoreCase))
            {
                Provision();
            }
        }

        private static void Provision()
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets();

            var configuration = builder.Build();
            var searchServiceClient = new SearchServiceClient(configuration["search:serviceName"], new SearchCredentials(configuration["search:adminKey"]));

            var index = new BookFastIndex(searchServiceClient, configuration);
            index.ProvisionAsync().Wait();
        }
    }
}
