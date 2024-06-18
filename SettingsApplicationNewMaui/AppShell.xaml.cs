using SettingsApplicationNewMaui.ViewModels;
using SettingsApplicationNewMaui.Views;

namespace SettingsApplicationNewMaui
{
    public partial class AppShell : Shell
    {
        public AppShell(ShellViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
