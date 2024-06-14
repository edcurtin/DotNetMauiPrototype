using SettingsApplicationNewMaui.Interfaces;
using SettingsApplicationNewMaui.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SettingsApplicationNewMaui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _greeting;
        private string _selectedLanguage;
        private IApplicationSettings _appSettings;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(IApplicationSettings appSettings)
        {
            _appSettings = appSettings;
            Greeting = _appSettings.Setting1;
            ChangeLanguageCommand = new Command(ChangeLanguage);
            AvailableLanguages = new List<string> { "English", "Español" };
        }

        private void ChangeLanguage()
        {
            var cultureCode = SelectedLanguage == "English" ? "en" : "es";
            LocalizationService.Instance.SetCulture(new CultureInfo(cultureCode));
        }

        public string Greeting
        {
            get => _greeting;
            set
            {
                if (_greeting != value)
                {
                    _greeting = value;
                    OnPropertyChanged();
                }
            }
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


        public ICommand ChangeLanguageCommand { get; }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
