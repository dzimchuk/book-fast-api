using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookFast.Contracts.Framework
{
    public interface ICompositionModule
    {
        void AddServices(IServiceCollection services, IConfiguration configuration);
    }
}