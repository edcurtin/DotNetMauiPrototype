﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.Interfaces
{
    public interface IAuthService
    {
        public Task<string> AuthenticateAsync(string username, string password);
    }
}
