using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Models;

namespace API.Interface
{
    public interface IJwtProvider
    {
        string GetUserIdFromToken(string token);
        AuthenticatedResponse GetToken(List<Claim> claim);
    }
}