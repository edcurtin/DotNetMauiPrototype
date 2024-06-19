using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SettingsApplicationNewMaui.ViewModels
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        public ICommand NavigateToContactPage { get; }

        public ICommand NavigateToLoginPage { get; }

        public ShellViewModel()
        {
            foreach (var route in Routes.RouteTypeMap)
            {
                Routing.RegisterRoute(route.Key, route.Value);
            }

            NavigateToContactPage = new Command(async () =>
            {
                await Shell.Current.GoToAsync(Routes.ContactView);
            });

            NavigateToLoginPage = new Command(async () =>
            {
                await Shell.Current.GoToAsync(Routes.LoginView);
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
