using System.Security.Claims;

namespace BookFast.Api.Infrastructure
{
    internal interface ISecurityContextAcceptor
    {
        ClaimsPrincipal Principal { set; }
    }
}