using Microsoft.JSInterop;

namespace Catalogo_Blazor.Client.Utils;

public static class IJSRunTimeExtensions
{
    public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content) 
        => js.InvokeAsync<object>("localStorage.setItem", key, content);
    
    public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
        => js.InvokeAsync<string>("localStorage.getItem", key);

    public static ValueTask<object> removeItem(this IJSRuntime js, string key)
        => js.InvokeAsync<object>("localStorage.removeItem", key);
}
