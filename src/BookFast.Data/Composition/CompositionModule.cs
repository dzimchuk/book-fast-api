using BookFast.Business.Data;
using BookFast.Contracts.Framework;
using BookFast.Data.Mappers;
using BookFast.Data.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BookFast.Data.Composition
{
    public class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            var efBuilder = new EntityFrameworkServicesBuilder(services);
            efBuilder.AddDbContext<BookFastContext>(options => options.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddScoped<IFacilityDataSource, FacilityDataSource>();
            services.AddScoped<IAccommodationDataSource, AccommodationDataSource>();
            services.AddScoped<IBookingDataSource, BookingDataSource>();

            services.AddScoped<IFacilityMapper, FacilityMapper>();
            services.AddScoped<IAccommodationMapper, AccommodationMapper>();
            services.AddScoped<IBookingMapper, BookingMapper>();
        }
    }
}