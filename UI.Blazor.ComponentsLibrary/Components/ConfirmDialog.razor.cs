using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using UI.Blazor.ComponentsLibrary.Components.Author;

namespace UI.Blazor.ComponentsLibrary.Components;
public partial class ConfirmDialog
{
    [Inject] public ILogger<AuthorTable> Logger { get; set; } = null!;
    [Parameter] public string ConfirmTitle { get; set; } = string.Empty;
    [Parameter] public string ConfirmMessage { get; set; } = "Sind sie sicher?";
    [Parameter] public EventCallback<bool> OnConfirmClicked { get; set; }
    private bool _showConfirm;

    public void Show()
    {
        _showConfirm = true;
    }

    public void Show(string message)
    {
        Logger.LogInformation("SHOW aufgerufen...");
        _showConfirm = true;
        ConfirmMessage = message;
        StateHasChanged();
    }
        
    private async Task OnConfirmChange(bool isDelete)
    {
        _showConfirm = false;

        if (isDelete)
        {
            await OnConfirmClicked.InvokeAsync(isDelete);
        }
    }
}
