using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ClienteConsultasMedicas.Utils
{
    public static class TokenHelper
    {
        private static string? _jwtToken;

        public static void SaveToken(string token)
        {
            _jwtToken = token;
        }

        public static string? GetToken()
        {
            return _jwtToken;
        }

        public static string? GetRol()
        {
            if (_jwtToken == null) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(_jwtToken);

            var rolClaim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role || c.Type == "role");
            return rolClaim?.Value;
        }

        public static string? GetId()
        {
            if (_jwtToken == null) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(_jwtToken);

            var idClaim = jwt.Claims.FirstOrDefault(c => c.Type == "id" || c.Type == ClaimTypes.NameIdentifier);
            return idClaim?.Value;
        }

        public static string? GetNombre()
        {
            if (_jwtToken == null) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(_jwtToken);

            var nombreClaim = jwt.Claims.FirstOrDefault(c => c.Type == "name" || c.Type == ClaimTypes.Name);
            return nombreClaim?.Value;
        }
    }
}
