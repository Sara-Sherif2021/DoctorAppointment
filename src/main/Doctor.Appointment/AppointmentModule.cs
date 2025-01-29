using Doctor.Appointment.Helpers;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using Volo.Abp.Studio.Client.AspNetCore;
using Volo.Abp.Swashbuckle;

namespace Doctor.Appointment;

[DependsOn(
    // ABP Framework packages
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpCachingModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpStudioClientAspNetCoreModule)

)]
[DependsOn(
   // typeof(AvailabilityHttpApiModule)
)]
public class AppointmentModule : AbpModule
{
    /* Single point to enable/disable multi-tenancy */

    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();
       
        ConfigureAutoMapper(context);
        ConfigureSwagger(context.Services, configuration);
        ConfigureAutoApiControllers();
    }

    private void ConfigureAutoApiControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(AppointmentModule).Assembly);
        });
    }

    private void ConfigureSwagger(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAbpSwaggerGen(          
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Appointment API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                options.DocumentFilter<CustomSwaggerFilter>();
            });
    }

    private void ConfigureAutoMapper(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AppointmentModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            /* Uncomment `validate: true` if you want to enable the Configuration Validation feature.
             * See AutoMapper's documentation to learn what it is:
             * https://docs.automapper.org/en/stable/Configuration-validation.html
             */
            options.AddMaps<AppointmentModule>(/* validate: true */);
        });
    }


    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }


        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseCorrelationId();
        app.UseAbpStudioLink();
        app.UseRouting();
        app.UseCors();

        app.UseUnitOfWork();

        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Appointment API");
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
