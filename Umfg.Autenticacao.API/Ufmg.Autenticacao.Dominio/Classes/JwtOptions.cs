using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufmg.Autenticacao.Dominio.Classes
{
    public sealed class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audiance { get; set; } = string.Empty;
        public string SecurityKey { get; set; } = string.Empty;
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}