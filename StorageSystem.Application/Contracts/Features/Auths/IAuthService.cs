using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.Features.Auths
{
    public interface IAuthService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims, DateTime expireAt);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
