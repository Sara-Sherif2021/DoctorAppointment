using Appointment.Booking;
using Appointment.Booking.Cases;
using Appointment.Booking.EntityFrameworkCore;
using Appointment.Booking.Share;
using Appointment.Management;
using Doctor.Appointment.Helpers;
using Doctor.Appointment.Notification;
using Doctor.Availability;
using Doctor.Availability.EntityFrameworkCore;
using Doctor.Availability.Share;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
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
    typeof(AbpStudioClientAspNetCoreModule),
    typeof(AvailabilityApplicationModule),
    typeof(AvailabilityEntityFrameworkCoreModule),
    typeof(BookingApplicationModule),
    typeof(BookingEntityFrameworkCoreModule),
    typeof(AvailabilityShareModule),
    typeof(NotificationApplicationModule),
    typeof(ManagementApplicationModule),
    typeof(BookingShareModule)
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

        Configure<AbpAntiForgeryOptions>(options =>
        {
            options.TokenCookie.Expiration = TimeSpan.FromDays(365);
            options.AutoValidateIgnoredHttpMethods.Add("POST");
            options.AutoValidateIgnoredHttpMethods.Add("PUT");
            options.AutoValidateIgnoredHttpMethods.Add("Delete");
        });

        context.Services.AddTransient<Availability.Share.Interfaces.ISlotIntegration, Availability.Services.SlotIntegrationService>();
        context.Services.AddTransient<Doctor.Appointment.Share.Services.INotificationService, Doctor.Appointment.Share.Services.NotificationService>();
        context.Services.AddTransient<IUpcomingAppointment, UpcomingAppointment>();
        context.Services.AddTransient<IUpdateAppointmentStatus, UpdateAppointmentStatus>();

        ConfigureAutoMapper(context);
        ConfigureSwagger(context.Services, configuration);
        ConfigureAutoApiControllers();
    }

    private void ConfigureAutoApiControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(AppointmentModule).Assembly);
            options.ConventionalControllers.Create(typeof(AvailabilityApplicationModule).Assembly);
            options.ConventionalControllers.Create(typeof(BookingApplicationModule).Assembly);
            options.ConventionalControllers.Create(typeof(ManagementApplicationModule).Assembly);
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

        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
