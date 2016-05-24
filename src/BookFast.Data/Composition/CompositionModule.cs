using BookFast.Business.Data;
using BookFast.Contracts.Framework;
using BookFast.Data.Mappers;
using BookFast.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BookFast.Data.Composition
{
    public class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookFastContext>(options => options.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddScoped<IFacilityDataSource, FacilityDataSource>();
            services.AddScoped<IAccommodationDataSource, AccommodationDataSource>();
            services.AddScoped<IBookingDataSource, BookingDataSource>();

            services.AddScoped<IFacilityMapper, FacilityMapper>();
            services.AddScoped<IAccommodationMapper, AccommodationMapper>();
            services.AddScoped<IBookingMapper, BookingMapper>();
        }
    }
}