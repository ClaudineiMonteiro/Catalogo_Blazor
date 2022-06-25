using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Catalogo_Blazor.Client.Auth;

public class DemoAuthStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var usuario = new ClaimsIdentity(new List<Claim>()
        {
            new Claim("Chave", "Valor"),
            new Claim(ClaimTypes.Name, "Claudinei Monteiro"),
            new Claim(ClaimTypes.Role, "Admin")
        },
        "demo");
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuario)));
    }
}
