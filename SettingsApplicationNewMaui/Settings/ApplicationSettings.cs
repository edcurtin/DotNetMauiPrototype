using Microsoft.Extensions.Configuration;
using SettingsApplicationNewMaui.Interfaces;

namespace SettingsApplicationNewMaui.Settings
{
    public class ApplicationSettings : IApplicationSettings
    {
         public ApplicationSettings()
        {
         
        }

        public string LanguageCultureCode { get; set; }
    }
}
