using SettingsApplicationNewMaui.Localization;
using System.Globalization;

namespace SettingsApplicationNewMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LocalizationService.Instance.SetCulture(new CultureInfo("es"));
            MainPage = new AppShell();
        }
    }
}
