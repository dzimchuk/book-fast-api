using Microsoft.Extensions.Options;

namespace BookFast.Api.Infrastructure.Authentication
{
    public class AuthenticationOptions : IOptions<AuthenticationOptions>
    {
        public string Instance { get; set; }
        public string TenantId { get; set; }
        public string Audience { get; set; }

        public string Authority => $"{Instance}{TenantId}";

        public AuthenticationOptions Value => this;
    }
}