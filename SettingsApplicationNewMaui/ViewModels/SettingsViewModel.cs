using SettingsApplicationNewMaui.Interfaces;
using SettingsApplicationNewMaui.Localization;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SettingsApplicationNewMaui.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string _selectedLanguage;
        private IApplicationSettings _appSettings;
        private IUserSettingsService _userSettingsService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public SettingsViewModel(IApplicationSettings appSettings, IUserSettingsService userSettings)
        {
            _appSettings = appSettings;
            _userSettingsService = userSettings;
            ChangeLanguageCommand = new Command(ChangeLanguage);
            AvailableLanguages = new List<string> { "English", "Español" };
        }
        public List<string> AvailableLanguages { get; }

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged();
                    ChangeLanguage();
                }
            }
        }

        private void ChangeLanguage()
        {
            var cultureCode = SelectedLanguage == "English" ? "en" : "es";
            _appSettings.LanguageCultureCode = cultureCode;
            LocalizationService.Instance.SetCulture(new CultureInfo(cultureCode));
        }


        public ICommand ChangeLanguageCommand { get; }


        private string _selectedTheme;
        public string SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (_selectedTheme != value)
                {
                    _selectedTheme = value;
                    OnPropertyChanged(); // Notify UI of property change
                }
            }
        }



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
