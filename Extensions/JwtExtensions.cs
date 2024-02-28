using System.Security.Claims;
using System.Security.Principal;

namespace Cola.CoreUtils.Extensions;

public static class JwtExtensions
{
    public static string? GetClaimValue(this IIdentity? identity,string valueType)
    {
        var valueObj = identity == null ? null : (identity as ClaimsIdentity)!.Claims.FirstOrDefault(x => x.Type == valueType);
        return valueObj?.Value;
    }
}