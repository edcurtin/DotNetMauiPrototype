using SettingsApplicationNewMaui.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.Services
{
    public class AuthService : IAuthService
    {
        public async Task<bool> IsAuthenticated()
        {
            return false;
        }
    }
}
