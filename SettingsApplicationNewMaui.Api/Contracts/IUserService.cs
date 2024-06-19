using SettingsApplicationNewMaui.Api.Model;

namespace SettingsApplicationNewMaui.Api.Contracts
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
