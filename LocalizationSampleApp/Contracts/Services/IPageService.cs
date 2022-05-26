using System;

namespace LocalizationSampleApp.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
