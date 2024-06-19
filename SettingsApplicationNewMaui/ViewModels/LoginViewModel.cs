using SettingsApplicationNewMaui.BaseClasses;
using SettingsApplicationNewMaui.Interfaces;
using SettingsApplicationNewMaui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                    UpdateLoginCommand();

                }
            }
        }

        private void UpdateLoginCommand()
        {
            ((AsyncCommand)LoginCommand).RaiseCanExecuteChanged();
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
                    UpdateLoginCommand();
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

        private IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            LoginCommand = new AsyncCommand(OnLogin, CanLogin);
            _authService = authService;
        }

        private bool CanLogin()
        {
            if(!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password)) 
            {
                return true;
            }
            return false;
        }

        private async Task OnLogin()
        {
           var result = await _authService.AuthenticateAsync(Username, Password);
          
        }
    }
}
