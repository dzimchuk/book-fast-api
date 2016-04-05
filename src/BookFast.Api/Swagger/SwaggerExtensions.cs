using System.IO;
using System.Linq;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace BookFast.Api.Swagger
{
    internal static class SwaggerExtensions
    {
        public static void AddSwashbuckle(this IServiceCollection services)
        {
            var xmlDoc = GetXmlDocPath(services);

            services.AddSwaggerGen();
            services.ConfigureSwaggerSchema(options =>
                                            {
                                                options.DescribeAllEnumsAsStrings = true;
                                                if (xmlDoc != null)
                                                    options.ModelFilter(new Swashbuckle.SwaggerGen.XmlComments.ApplyXmlTypeComments(xmlDoc));
                                            });

            services.ConfigureSwaggerDocument(options =>
                                              {
                                                  options.SingleApiVersion(new Swashbuckle.SwaggerGen.Info
                                                                           {
                                                                               Title = "Book Fast API",
                                                                               Version = "v1"
                                                                           });
                                                  options.OperationFilter<DefaultContentTypeOperationFilter>();
                                                  if (xmlDoc != null)
                                                      options.OperationFilter(new Swashbuckle.SwaggerGen.XmlComments.ApplyXmlActionComments(xmlDoc));
                                              });
        }

        private static string GetXmlDocPath(IServiceCollection services)
        {
            string xmlDoc = null;
            var serviceProvider = services.BuildServiceProvider();
            var appEnv = serviceProvider.GetService<IApplicationEnvironment>();
            var hostEnv = serviceProvider.GetService<IHostingEnvironment>();

            if (hostEnv.IsDevelopment())
            {
                var solutionBasePath = GetSolutionBasePath(appEnv.ApplicationBasePath);
                var buildConfiguration = appEnv.Configuration;
                var frameworkIdentifier = appEnv.RuntimeFramework.Identifier;
                var frameworkVersion = appEnv.RuntimeFramework.Version.ToString().Replace(".", string.Empty);
                xmlDoc = $"{solutionBasePath}\\artifacts\\bin\\BookFast.Api\\{buildConfiguration}\\{frameworkIdentifier}{frameworkVersion}\\BookFast.Api.xml";
            }

            return xmlDoc;
        }

        private static string GetSolutionBasePath(string applicationBasePath)
        {
            var directory = new DirectoryInfo(applicationBasePath);
            do
            {
                if (directory.GetFiles("global.json", SearchOption.TopDirectoryOnly).Any())
                    return directory.FullName;

                directory = directory.Parent;
            } while (directory != null);

            return null;
        }
    }
}