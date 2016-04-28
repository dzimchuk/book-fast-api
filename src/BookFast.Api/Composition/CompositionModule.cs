using BookFast.Api.Controllers;
using BookFast.Api.Infrastructure;
using BookFast.Api.Mappers;
using BookFast.Api.Swagger;
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
            services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication:AzureAd"));

            services.AddMvc();

            RegisterAuthorizationPolicies(services);
            RegisterApplicationServices(services);
            RegisterMappers(services);

            services.AddSwashbuckle();
        }

        private static void RegisterAuthorizationPolicies(IServiceCollection services)
        {
            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("Facility.Write", config =>
                                                        {
                                                            config.RequireRole(InteractorRole.FacilityProvider.ToString(), InteractorRole.ImporterProcess.ToString());
                                                        });
                });
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            var provider = new SecurityContextProvider();
            services.AddInstance<ISecurityContextAcceptor>(provider);
            services.AddInstance<ISecurityContext>(provider);
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddScoped<IFacilityMapper, FacilityMapper>();
            services.AddScoped<IAccommodationMapper, AccommodationMapper>();
            services.AddScoped<IBookingMapper, BookingMapper>();
        }
    }
}