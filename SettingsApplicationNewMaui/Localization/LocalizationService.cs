using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.Localization
{
    public class LocalizationService : INotifyPropertyChanged
    {
        private static LocalizationService _instance;
        private readonly ResourceManager _resourceManager;
        private CultureInfo _currentCulture;

        public static LocalizationService Instance => _instance ??= new LocalizationService();

        public event PropertyChangedEventHandler PropertyChanged;

        private LocalizationService()
        {
            _resourceManager = new ResourceManager("SettingsApplicationNewMaui.Resources.Strings.Strings", typeof(LocalizationService).Assembly);
            _currentCulture = CultureInfo.CurrentCulture;
        }

        public string this[string key] => _resourceManager.GetString(key, _currentCulture);

        public void SetCulture(CultureInfo culture)
        {
            _currentCulture = culture;
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            OnPropertyChanged(string.Empty); // Notify all properties
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

