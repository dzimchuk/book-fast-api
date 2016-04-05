using Swashbuckle.SwaggerGen;

namespace BookFast.Api.Infrastructure
{
    internal class DefaultContentTypeOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Produces.Clear();
            operation.Produces.Add("application/json");
        }
    }
}