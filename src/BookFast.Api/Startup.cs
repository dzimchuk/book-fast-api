using System.Collections.Generic;
using System.Threading.Tasks;
using BookFast.Api.Infrastructure;
using BookFast.Api.Infrastructure.JwtBearer;
using BookFast.Contracts.Framework;
using Microsoft.AspNet.Authentication.JwtBearer;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using AuthenticationOptions = BookFast.Api.Infrastructure.AuthenticationOptions;

namespace BookFast.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        private IConfigurationRoot Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var modules = new List<ICompositionModule>
                          {
                              new Composition.CompositionModule(),
                              new Business.Composition.CompositionModule(),
                              new Data.Composition.CompositionModule()
                          };

#if DNX451
            modules.Add(new Search.Composition.CompositionModule());
#endif

            foreach (var module in modules)
            {
                module.AddServices(services, Configuration);
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IOptions<AuthenticationOptions> authOptions)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            var jwtBearerOptions = new JwtBearerOptions
                                   {
                                       AutomaticAuthenticate = true,
                                       AutomaticChallenge = true,
                                       Authority = authOptions.Value.Authority,
                                       Audience = authOptions.Value.Audience,

                                       Events = new JwtBearerEvents
                                                {
                                                    OnAuthenticationFailed = ctx =>
                                                                             {
                                                                                 ctx.SkipToNextMiddleware();
                                                                                 return Task.FromResult(0);
                                                                             }
                                                }
                                   };
            app.UseMiddleware<CustomJwtBearerMiddleware>(jwtBearerOptions);

            app.UseSecurityContext();
            app.UseMvc();

            app.UseSwaggerGen();
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
