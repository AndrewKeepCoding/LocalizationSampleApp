using LocalizationSampleApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalizationSampleApp.Contracts.Services
{
    public interface ILocalizationService
    {
        List<LanguageItem> Languages { get; }

        LanguageItem GetCurrentLanguageItem();
        Task InitializeAsync();
        Task SetLanguageAsync(LanguageItem languageItem);
    }
}