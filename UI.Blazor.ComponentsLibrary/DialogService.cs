using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JSInterop;

namespace UI.Blazor.ComponentsLibrary;

public class DialogService(IJSRuntime jsRuntime) : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask = new(() =>
        jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/UI.Blazor.ComponentsLibrary/js/dialog.js")
            .AsTask());

    public async Task<bool> ConfirmAsync(string message)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("myConfirm", message);
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}