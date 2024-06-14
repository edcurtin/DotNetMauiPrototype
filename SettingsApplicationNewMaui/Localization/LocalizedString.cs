using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.Localization
{
    public class LocalizedString : BindableObject
    {
        public static readonly BindableProperty ResourceKeyProperty =
            BindableProperty.Create(nameof(ResourceKey), typeof(string), typeof(LocalizedString), propertyChanged: OnResourceKeyChanged);

        public string ResourceKey
        {
            get => (string)GetValue(ResourceKeyProperty);
            set => SetValue(ResourceKeyProperty, value);
        }

        public string Value => LocalizationService.Instance[ResourceKey];

        private static void OnResourceKeyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is LocalizedString localizedString)
            {
                LocalizationService.Instance.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == string.Empty || args.PropertyName == newValue.ToString())
                    {
                        localizedString.OnPropertyChanged(nameof(Value));
                    }
                };
            }
        }
    }
}
