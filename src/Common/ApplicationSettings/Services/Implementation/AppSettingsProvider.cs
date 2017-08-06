using Microsoft.Extensions.Options;
using Mmu.Ddws.Common.ApplicationSettings.Models;

namespace Mmu.Ddws.Common.ApplicationSettings.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _appSettingsOptions;

        public AppSettingsProvider(IOptions<AppSettings> appSettingsOptions)
        {
            _appSettingsOptions = appSettingsOptions;
        }

        public AppSettings GetAppSettings()
        {
            return _appSettingsOptions.Value;
        }
    }
}