using Application.Contracts.Services;
using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using System.Collections;

namespace UI.Blazor.Components.Pages.Author;
public partial class OverviewReloaded
{
    [Inject] public ILogger<OverviewReloaded> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await GetAuthorsAsync();
    }

    private async Task GetAuthorsAsync()
    {
        AuthorsVm = await ServiceManager.AuthorService.GetAuthorsAsync();
    }

    private async Task DeleteAuthor(Guid authorId)    
    {
        Logger.LogInformation($"Author löschen aufgerufen mit Id {authorId}");

        try
        {
            ErrorMessage = string.Empty;

            var isDeleted = await ServiceManager.AuthorService.DeleteAuthorAsync(authorId);
            
            if (isDeleted)
            {
                await GetAuthorsAsync();
            }
            else
            {
                ErrorMessage = "funzt nicht";
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Fehler beim Löschen des Autors");
            ErrorMessage = ex.Message;
        }
    }
}
