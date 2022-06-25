namespace Catalogo_Blazor.Client.Interfaces.Services;

public interface IAuthorizeService
{
    Task Login(string token);
    Task Logout();
}
