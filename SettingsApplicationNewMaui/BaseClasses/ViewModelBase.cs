﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.BaseClasses
{
        public abstract class ViewModelBase : INotifyPropertyChanged
        {
            public virtual void OnPropertyChanged([CallerMemberName] string? property = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

            public event PropertyChangedEventHandler? PropertyChanged;
        }
}
