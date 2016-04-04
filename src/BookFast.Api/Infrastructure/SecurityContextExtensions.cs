using Microsoft.AspNet.Builder;

namespace BookFast.Api.Infrastructure
{
    internal static class SecurityContextExtensions
    {
        public static void UseSecurityContext(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<SecurityContextMiddleware>();
        } 
    }
}