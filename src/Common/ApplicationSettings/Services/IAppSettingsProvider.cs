using Mmu.Ddws.Common.ApplicationSettings.Models;

namespace Mmu.Ddws.Common.ApplicationSettings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings GetAppSettings();
    }
}