using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Ddws.Common.ApplicationSettings.Models;

namespace Mmu.Ddws.WebServices.Infrastructure.Initialization
{
    internal static class ServiceInitialization
    {
        internal static IServiceProvider InitializeServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            InitializeAppSettings(services, configuration);
            InitializeCors(services);

            var result = IocInitialization.InitializeIoc(services);
            return result;
        }

        private static void InitializeAppSettings(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(AppSettings.SectionName));
            services.AddSingleton(configuration);
        }

        private static void InitializeCors(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "All",
                        builder =>
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials());
                });
        }
    }
}