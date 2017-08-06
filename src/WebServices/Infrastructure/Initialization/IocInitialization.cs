using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Ddws.Application.Common.Mapping;
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
                            scan.AddAllTypesOf(typeof(IMapper<,>));
                        });

                    config.Populate(services);
                });

            Debug.WriteLine(container.WhatDidIScan());
            var result = container.GetInstance<IServiceProvider>();
            return result;
        }
    }
}