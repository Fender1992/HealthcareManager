using HealthcareManager.Services;
using Microsoft.JSInterop;
using System.Threading.Tasks;

public class JsInteropService
{
    private readonly IJSRuntime _jsRuntime;

    public JsInteropService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync(DotNetObjectReference<AppEventHandler> dotNetHelper)
    {
        await _jsRuntime.InvokeVoidAsync("setDotNetHelper", dotNetHelper);
    }
}
