using SettingsApplicationNewMaui.Views;

namespace SettingsApplicationNewMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register Routes
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
        }
    }
}
