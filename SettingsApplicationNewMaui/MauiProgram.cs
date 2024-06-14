using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SettingsApplicationNewMaui.Extensions;
using SettingsApplicationNewMaui.Interfaces;
using SettingsApplicationNewMaui.Settings;
using SettingsApplicationNewMaui.ViewModels;
using SettingsApplicationNewMaui.Views;
using System.Globalization;
using System.Resources;

namespace SettingsApplicationNewMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            var services = builder.Services;
            
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
            // Add this line to set up configuration
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Bind the AppSettings section to the AppSettings class
            var appSettings = new ApplicationSettings();
            builder.Configuration.GetSection("AppSettings").Bind(appSettings);

            // Register ApplicationSettings as a singleton service
            services.AddSingleton<IApplicationSettings>(appSettings);
            services.AddSingleton<MainViewModel>();
            services.AddView<MainView, MainViewModel>();
           

#if DEBUG
            builder.Logging.AddDebug();
#endif
            SetCulture("en");
            return builder.Build();
        }

        private static void SetCulture(string cultureCode)
        {
            // Get user's preferred culture or default to device culture
            var userCulture = new CultureInfo(cultureCode);
            CultureInfo.CurrentCulture = userCulture;
            CultureInfo.CurrentUICulture = userCulture;
            // Update resources
            var resourceManager = new ResourceManager("SettingsApplicationNewMaui.Resources.Strings.Strings", typeof(App).Assembly);
        }
    }
}
