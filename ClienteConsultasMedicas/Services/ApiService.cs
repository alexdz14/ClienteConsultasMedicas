using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClienteConsultasMedicas.Services
{
    public static class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string baseUrl = "https://localhost:7068/api";

        public static async Task<string?> LoginAsync(string usuario, string contrasena)
        {
            var loginData = new
            {
                usuario = usuario,
                contrasena = contrasena
            };

            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/usuarios/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var tokenObj = JsonConvert.DeserializeObject<LoginResponse>(responseBody);
                    return tokenObj?.token;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private class LoginResponse
        {
            public string token { get; set; } = string.Empty;
        }
    }
}
