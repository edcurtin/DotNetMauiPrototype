﻿using SettingsApplicationNewMaui.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.Settings
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string Setting1 { get; set; }
        public string Setting2 { get; set; }
    }
}