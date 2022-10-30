
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetTokenValidation();
    }
}
