using SettingsApplicationNewMaui.BaseClasses;
using SettingsApplicationNewMaui.Interfaces;
using SettingsApplicationNewMaui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.ViewModels
{
    public class LoadingViewModel : ViewModelBase
    {
        private IAuthService _authService;

        public LoadingViewModel(IAuthService authService)
        {
            _authService = authService;
            
        }

    }
}
