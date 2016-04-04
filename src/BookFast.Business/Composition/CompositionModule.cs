using BookFast.Business.Services;
using BookFast.Contracts;
using BookFast.Contracts.Framework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookFast.Business.Composition
{
    public class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IAccommodationService, AccommodationService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IBookingService, BookingService>();
        }
    }
}