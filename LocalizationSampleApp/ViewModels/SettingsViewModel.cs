using System;
using System.Collections.Generic;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using LocalizationSampleApp.Contracts.Services;
using LocalizationSampleApp.Helpers;
using LocalizationSampleApp.Models;
using Microsoft.UI.Xaml;

using Windows.ApplicationModel;

namespace LocalizationSampleApp.ViewModels
{
    public class SettingsViewModel : ObservableRecipient
    {
        private readonly ILocalizationService _localizationService;

        private LanguageItem _selectedLanguage;
        public LanguageItem SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (SetProperty(ref _selectedLanguage, value) is true)
                {
                    OnSelectedLanguageChanged(value);
                }
            }
        }

        private void OnSelectedLanguageChanged(LanguageItem value)
        {
            _localizationService.SetLanguageAsync(value);
            IsLocalizationChanged = true;
        }

        private bool _isLocalizationChanged;
        public bool IsLocalizationChanged
        {
            get { return _isLocalizationChanged; }
            set { SetProperty(ref _isLocalizationChanged, value); }
        }

        private List<LanguageItem> _availableLanguages;
        public List<LanguageItem> AvailableLanguages
        {
            get { return _availableLanguages; }
            set { SetProperty(ref _availableLanguages, value); }
        }

        private readonly IThemeSelectorService _themeSelectorService;
        private ElementTheme _elementTheme;

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { SetProperty(ref _elementTheme, value); }
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }

            set { SetProperty(ref _versionDescription, value); }
        }

        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            if (ElementTheme != param)
                            {
                                ElementTheme = param;
                                await _themeSelectorService.SetThemeAsync(param);
                            }
                        });
                }

                return _switchThemeCommand;
            }
        }

        public SettingsViewModel(ILocalizationService localizationService, IThemeSelectorService themeSelectorService)
        {
            _localizationService = localizationService;
            AvailableLanguages = _localizationService.Languages;
            SelectedLanguage = _localizationService.GetCurrentLanguageItem();
            IsLocalizationChanged = false;

            _themeSelectorService = themeSelectorService;
            _elementTheme = _themeSelectorService.Theme;
            VersionDescription = GetVersionDescription();
        }

        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var version = Package.Current.Id.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
