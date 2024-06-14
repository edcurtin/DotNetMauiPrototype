using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SettingsApplicationNewMaui.Extensions;
using SettingsApplicationNewMaui.Interfaces;
using SettingsApplicationNewMaui.Localization;
using SettingsApplicationNewMaui.Settings;
using SettingsApplicationNewMaui.ViewModels;
using SettingsApplicationNewMaui.Views;
using System.Globalization;

namespace SettingsApplicationNewMaui
{
    /// <summary>
    /// MauiProgram
    /// </summary>
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
            builder.Configuration.GetSection("ApplicationSettings").Bind(appSettings);

            // Register ApplicationSettings as a singleton service
            services.AddSingleton<IApplicationSettings>(appSettings);
            
            // ioc register view models and veiws 
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddView<HomeView, HomeViewModel>();
            services.AddView<SettingsView, SettingsViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var mauiApp = builder.Build();
            
            var settings = mauiApp.Services.GetRequiredService<IApplicationSettings>();

            // set startup culture code to english
            LocalizationService.Instance.SetCulture(new CultureInfo(settings.LanguageCultureCode));

            return mauiApp;
        }
    }
}
