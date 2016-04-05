﻿using BookFast.Api.Controllers;
using BookFast.Api.Infrastructure;
using BookFast.Api.Mappers;
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
            RegisterMappers(services);
            RegisterSwashbuckle(services);

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

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddScoped<IFacilityMapper, FacilityMapper>();
            services.AddScoped<IAccommodationMapper, AccommodationMapper>();
            services.AddScoped<IBookingMapper, BookingMapper>();
        }

        private static void RegisterSwashbuckle(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureSwaggerSchema(options =>
                                            {
                                                options.DescribeAllEnumsAsStrings = true;
                                            });

            services.ConfigureSwaggerDocument(options =>
                                              {
                                                  options.SingleApiVersion(new Swashbuckle.SwaggerGen.Info
                                                                           {
                                                                               Title = "Book Fast API",
                                                                               Version = "v1"
                                                                           });
                                                  options.OperationFilter<DefaultContentTypeOperationFilter>();
                                              });
        }
    }
}