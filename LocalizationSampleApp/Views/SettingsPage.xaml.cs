using LocalizationSampleApp.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace LocalizationSampleApp.Views
{
    // TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
    public sealed partial class SettingsPage : Page
    {
        public SettingsViewModel ViewModel { get; }

        public SettingsPage()
        {
            ViewModel = App.GetService<SettingsViewModel>();
            InitializeComponent();
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LanguageButton.Flyout.Hide();
        }
    }
}
