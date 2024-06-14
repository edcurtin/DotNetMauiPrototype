using SettingsApplicationNewMaui.BaseClasses;
using SettingsApplicationNewMaui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SettingsApplicationNewMaui.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string username;
        private string password;
        private string errorMessage;

        public string Username
        {
            get => username;
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
            Username = "Ed was here";
            OnPropertyChanged(nameof(Username));
        }

        private async void OnLogin()
        {
            // Replace with your authentication logic
            if (Username == "admin" && Password == "password")
            {
                ErrorMessage = string.Empty;
                // Navigate to the next page or do something else
                await Shell.Current.GoToAsync(nameof(HomeView));
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
        }
    }
}
