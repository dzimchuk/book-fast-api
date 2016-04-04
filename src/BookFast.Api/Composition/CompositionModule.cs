using BookFast.Api.Infrastructure;
using BookFast.Business;
using BookFast.Contracts.Framework;
using BookFast.Contracts.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookFast.Api.Composition
{
    internal class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc();

            RegisterAuthorizationPolicies(services);
            RegisterApplicationServices(services);

            services.AddInstance(configuration);
        }

        private static void RegisterAuthorizationPolicies(IServiceCollection services)
        {
            services.AddAuthorization(
                options => options.AddPolicy("FacilityProviderOnly", config => config.RequireClaim(BookFastClaimTypes.InteractorRole, InteractorRole.FacilityProvider.ToString())));
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            var provider = new SecurityContextProvider();
            services.AddInstance<ISecurityContextAcceptor>(provider);
            services.AddInstance<ISecurityContext>(provider);
        }
    }
}