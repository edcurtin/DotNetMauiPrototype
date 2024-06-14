using Microsoft.Maui;
using Microsoft.Maui.Controls;
using SettingsApplicationNewMaui.ViewModels;

namespace SettingsApplicationNewMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<ShellViewModel>();

            // Register your Shell
            services.AddSingleton<AppShell>();

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Resolve the Shell
            var shell = serviceProvider.GetRequiredService<AppShell>();

            // Set the main page with resolved Shell
            MainPage = shell;
        }
    }
}
