using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Doctor.Availability.Helpers
{
    public class CustomSwaggerFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //remove paths those start with /api/abp prefix
            swaggerDoc.Paths
                   .Where(x =>
                          x.Key.StartsWith("/api/abp")
                       || x.Key.StartsWith("/api/account")
                       || x.Key.StartsWith("/api/setting-management")
                       || x.Key.StartsWith("/api/feature-management")
                       || x.Key.StartsWith("/api/permission-management")
                       || x.Key.StartsWith("/api/multi-tenancy")
                       || x.Key.StartsWith("/api/identity"))
                   .ToList()
                   .ForEach(x => swaggerDoc.Paths.Remove(x.Key));

            //remove Schemas those start with volo.abp prefix
            swaggerDoc.Components.Schemas
                   .Where(x =>
                          x.Key.StartsWith("Volo.Abp")
                      && !x.Key.StartsWith("Volo.Abp.Http.RemoteService")
                         )
                   .ToList()
                   .ForEach(x => swaggerDoc.Components.Schemas.Remove(x.Key));

        }
    }
}
