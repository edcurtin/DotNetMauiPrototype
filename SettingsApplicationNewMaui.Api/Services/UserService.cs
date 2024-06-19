using SettingsApplicationNewMaui.Api.Contracts;
using SettingsApplicationNewMaui.Api.Model;

namespace SettingsApplicationNewMaui.Api.Services
{
    public class UserService : IUserService
    {
        // For simplicity, we're using a hardcoded list of users. In a real application, you would use a database.
        private List<User> _users = new List<User>
    {
        new User { Id = 1, Username = "test", Password = "password" }
    };

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            // Return null if user not found
            if (user == null)
                return null;

            // Authentication successful, return user details (without password)
            return new User { Id = user.Id, Username = user.Username };
        }
    }
}
