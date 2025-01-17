﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using SettingsApplicationNewMaui.Extensions;
using SettingsApplicationNewMaui.Interfaces;
using SettingsApplicationNewMaui.Localization;
using SettingsApplicationNewMaui.Services;
using SettingsApplicationNewMaui.Settings;
using SettingsApplicationNewMaui.ViewModels;
using SettingsApplicationNewMaui.Views;
using System.Globalization;
using System.Reflection;

namespace SettingsApplicationNewMaui
{
    /// <summary>
    /// MauiProgram
    /// </summary>
    [epj.RouteGenerator.AutoRoutes("View")]
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

            // Load appsettings.json
            //using var appsettingsStream = Assembly
            //    .GetExecutingAssembly()
            //    .GetManifestResourceStream("SettingsApplicationNewMaui.appsettings.json");

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("SettingsApplicationNewMaui.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            // Add configuration to the builder
            builder.Configuration.AddConfiguration(config);

            // Bind the AppSettings section to the AppSettings class
            var appSettings = new ApplicationSettings();
            builder.Configuration.GetSection("ApplicationSettings").Bind(appSettings);

            // Register ApplicationSettings as a singleton service
            services.AddSingleton<IApplicationSettings>(appSettings);

            services.AddSingleton<ShellViewModel>();
            services.AddSingleton<AppShell>();

            // Interface to implementation
            services.AddSingleton<IUserSettingsService, UserSettingsService>();
            services.AddSingleton<IAuthService, AuthService>();

            // ioc register view models and veiws 
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddView<HomeView, HomeViewModel>();
            services.AddView<SettingsView, SettingsViewModel>();
            services.AddView<ContactView, ContactViewModel>();
            services.AddView<ProfileView, ProfileViewModel>();
            services.AddView<LoginView, LoginViewModel>();
            services.AddView<LoadingView, LoginViewModel>();
           

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
