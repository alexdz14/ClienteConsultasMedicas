using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Utils;
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
                email = usuario,
                password = contrasena
            };

            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/usuarios/login", content);

                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var tokenObj = JsonConvert.DeserializeObject<LoginResponse>(responseBody);
                    return tokenObj?.token;
                }
                else
                {
                    MessageBox.Show($"Error al iniciar sesión.\nCódigo: {response.StatusCode}\nRespuesta: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
                return null;
            }
        }


        public static async Task<List<Cita>> GetCitasPorMedicoAsync(string medicoId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/citas/medico/{medicoId}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Cita>>(json) ?? new List<Cita>();
            }

            return new List<Cita>();
        }

        public static async Task<bool> RegistrarConsultaAsync(Consulta consulta)
        {
            var json = JsonConvert.SerializeObject(consulta);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/consultas");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());
            request.Content = content;

            var response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public static async Task<List<ConsultaHistorial>> ObtenerHistorialPorPacienteAsync(string pacienteId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/consultas/paciente/{pacienteId}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ConsultaHistorial>>(json) ?? new List<ConsultaHistorial>();
            }

            return new List<ConsultaHistorial>();
        }

        public static async Task<bool> RegistrarPacienteAsync(Paciente paciente)
        {
            var json = JsonConvert.SerializeObject(paciente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/pacientes");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());
            request.Content = content;

            var response = await client.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<Paciente>> ObtenerTodosPacientesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/pacientes");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());

            var response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<Paciente>>(json) ?? new List<Paciente>()
                : new List<Paciente>();
        }

        public static async Task<bool> ActualizarPacienteAsync(Paciente paciente)
        {
            var json = JsonConvert.SerializeObject(paciente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}/pacientes/{paciente.id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());
            request.Content = content;

            var response = await client.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> EliminarPacienteAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/pacientes/{id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());

            var response = await client.SendAsync(request);
            return response.IsSuccessStatusCode;
        }


        public static async Task<bool> RegistrarCitaAsync(CitaNueva cita)
        {
            var json = JsonConvert.SerializeObject(cita, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss",
                NullValueHandling = NullValueHandling.Ignore
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/citas");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());
            request.Content = content;

            var response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public static async Task<List<CitaResumen>> ObtenerTodasCitasAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/citas");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());

            var response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<CitaResumen>>(json) ?? new List<CitaResumen>()
                : new List<CitaResumen>();
        }

        public static async Task<bool> CancelarCitaAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/citas/{id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());

            var response = await client.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<PacienteItem>> ObtenerPacientesAsync()
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/pacientes");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());

                var response = await client.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode
                    ? JsonConvert.DeserializeObject<List<PacienteItem>>(json) ?? new List<PacienteItem>()
                    : new List<PacienteItem>();
            }

        public static async Task<List<MedicoItem>> ObtenerMedicosAsync()
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/usuarios/medicos");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenHelper.GetToken());

                var response = await client.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode
                    ? JsonConvert.DeserializeObject<List<MedicoItem>>(json) ?? new List<MedicoItem>()
                    : new List<MedicoItem>();
            }

        private class LoginResponse
        {
            public string token { get; set; } = string.Empty;
        }
    }
}
