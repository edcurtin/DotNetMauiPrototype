using Microsoft.Maui;
using Microsoft.Maui.Controls;
using SettingsApplicationNewMaui.ViewModels;
using SettingsApplicationNewMaui.Views;

namespace SettingsApplicationNewMaui
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            // You can now use ServiceProvider to access registered services
            var shell = serviceProvider.GetService<AppShell>();
            MainPage = shell;
        }
    }
}
