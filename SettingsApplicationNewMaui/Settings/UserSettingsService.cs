using SettingsApplicationNewMaui.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.Settings
{
    internal class UserSettingsService : IUserSettingsService
    {
        private const string ThemeKey = "Theme";

        public required string Theme
        {
            get;
            set;
        }
    }
}
