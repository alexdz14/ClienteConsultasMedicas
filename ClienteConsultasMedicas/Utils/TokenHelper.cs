using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.IO;

namespace ClienteConsultasMedicas.Utils
{
    public static class TokenHelper
    {
        private static string? _jwtToken;
        private static string tokenPath = "token.txt";

        public static void SaveToken(string token)
        {
            _jwtToken = token;
            File.WriteAllText(tokenPath, token); 
        }

        public static string? GetToken()
        {
            if (_jwtToken != null) return _jwtToken;

            if (File.Exists(tokenPath))
            {
                _jwtToken = File.ReadAllText(tokenPath);
                return _jwtToken;
            }

            return null;
        }

        public static bool ExisteToken()
        {
            return File.Exists(tokenPath) && !string.IsNullOrWhiteSpace(File.ReadAllText(tokenPath));
        }

        public static string? GetRol()
        {
            var token = GetToken();
            if (token == null) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var rolClaim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role || c.Type == "role");
            return rolClaim?.Value;
        }

        public static string? GetId()
        {
            var token = GetToken();
            if (token == null) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var idClaim = jwt.Claims.FirstOrDefault(c => c.Type == "id" || c.Type == ClaimTypes.NameIdentifier);
            return idClaim?.Value;
        }

        public static string? GetNombre()
        {
            var token = GetToken();
            if (token == null) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var nombreClaim = jwt.Claims.FirstOrDefault(c => c.Type == "name" || c.Type == ClaimTypes.Name);
            return nombreClaim?.Value;
        }
    }
}
