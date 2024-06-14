using SettingsApplicationNewMaui.Localization;
using System.Globalization;

namespace SettingsApplicationNewMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
