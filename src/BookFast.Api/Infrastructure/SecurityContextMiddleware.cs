using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace BookFast.Api.Infrastructure
{
    internal class SecurityContextMiddleware
    {
        private readonly RequestDelegate next;

        public SecurityContextMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ISecurityContextAcceptor acceptor)
        {
            acceptor.Principal = context.User;
            await next(context);
            acceptor.Principal = null;
        }
    }
}