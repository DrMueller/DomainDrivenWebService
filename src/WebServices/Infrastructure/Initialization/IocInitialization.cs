using System;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Ddws.Common.ServiceProvisioning;
using StructureMap;

namespace Mmu.Ddws.WebServices.Infrastructure.Initialization
{
    internal static class IocInitialization
    {
        internal static IServiceProvider InitializeIoc(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(
                config =>
                {
                    config.Scan(
                        scan =>
                        {
                            scan.AssembliesFromApplicationBaseDirectory();
                            scan.LookForRegistries();
                            scan.WithDefaultConventions();
                        });

                    config.Populate(services);
                });

            var result = container.GetInstance<IServiceProvider>();

            var provisioningService = result.GetService<IProvisioningService>();
            ProvisioningServiceSingleton.Initialize(provisioningService);
            return result;
        }
    }
}