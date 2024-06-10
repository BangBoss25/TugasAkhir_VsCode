using System.Security.Claims;

namespace TugasAkhir_VsCode.Data.Helper;

public static class DataIdentity
{
    public static string getUsername(this ClaimsPrincipal user)
    {
        #pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (user.Identity.IsAuthenticated)
            return user.Claims.FirstOrDefault(u => u.Type == "Username")?.Value ?? string.Empty;
        #pragma warning restore CS8602 // Dereference of a possibly null reference.

        return string.Empty;
    }

    public static string GetRole(this ClaimsPrincipal user)
    {
        #pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (user.Identity.IsAuthenticated)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "Role")?.Value ?? string.Empty;
        }
        #pragma warning restore CS8602 // Dereference of a possibly null reference.
        return string.Empty;
    }

}