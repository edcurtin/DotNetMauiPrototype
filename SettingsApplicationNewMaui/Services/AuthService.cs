using SettingsApplicationNewMaui.DTO;
using SettingsApplicationNewMaui.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SettingsApplicationNewMaui.Services
{
    public class AuthService : IAuthService
    {
        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var loginDto = new { Username = username, Password = password };
            var json = JsonSerializer.Serialize(loginDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7199/api/Auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent);
                return tokenResponse?.token;
            }

            return null;
        }
    }
}
