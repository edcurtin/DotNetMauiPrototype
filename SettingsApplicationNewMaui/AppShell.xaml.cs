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

            // Register Routes
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
            Routing.RegisterRoute(nameof(ContactView), typeof(ContactView));
            Routing.RegisterRoute(nameof(LoadingView), typeof(LoadingView));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(ProfileView), typeof(ProfileView));

        }
    }
}
