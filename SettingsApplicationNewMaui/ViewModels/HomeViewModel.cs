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
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string _greeting;
        private string _selectedLanguage;
        private IApplicationSettings _appSettings;

        public event PropertyChangedEventHandler PropertyChanged;

        public HomeViewModel(IApplicationSettings appSettings)
        {
            _appSettings = appSettings;
            var test = _appSettings.LanguageCultureCode;
        }
      

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
