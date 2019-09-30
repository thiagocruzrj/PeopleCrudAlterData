using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using People.Business.Interfaces;
using People.Business.Notifications;
using People.Business.Services;
using People.Data.Context;
using People.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace People.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<PersonDbContext>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<INotifier, Notifier>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            return services;
        }
    }
}
