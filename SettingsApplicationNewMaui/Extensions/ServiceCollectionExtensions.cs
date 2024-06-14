using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// AddView - Extension method that registers a view as a singleton and hooks up its DataContext via IoC.
        /// </summary>
        /// <typeparam name="TView">The view type.</typeparam>
        /// <typeparam name="TViewModel">The view model type.</typeparam>
        /// <param name="services">The service collection.</param>
        public static void AddView<TView, TViewModel>(this IServiceCollection services)
            where TView : ContentPage, new()
            where TViewModel : class
        {
            services.AddSingleton<TView>(serviceProvider => new TView
            {
                BindingContext = serviceProvider.GetRequiredService<TViewModel>()
            });

            // Register the view model as well
            services.AddSingleton<TViewModel>();
        }
    }
}
