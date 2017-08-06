using Microsoft.AspNetCore.Builder;
using Mmu.Ddws.WebServices.Infrastructure.Middlewares;

namespace Mmu.Ddws.WebServices.Infrastructure.Initialization
{
    internal static class AppInitialization
    {
        internal static void InitializeApplication(IApplicationBuilder app)
        {
            InitializeMiddlewares(app);
        }

        private static void InitializeMiddlewares(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}