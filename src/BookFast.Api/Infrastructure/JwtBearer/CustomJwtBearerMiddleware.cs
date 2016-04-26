using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.JwtBearer;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;

namespace BookFast.Api.Infrastructure.JwtBearer
{
    internal class CustomJwtBearerMiddleware : JwtBearerMiddleware
    {
        public CustomJwtBearerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IUrlEncoder encoder, JwtBearerOptions options) : base(next, loggerFactory, encoder, options)
        {
        }

        protected override AuthenticationHandler<JwtBearerOptions> CreateHandler()
        {
            return new ImprovedJwtBearerHandler();
        }
    }
}