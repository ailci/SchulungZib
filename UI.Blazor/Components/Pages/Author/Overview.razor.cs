using Application.Contracts.Services;
using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using System.Collections;

namespace UI.Blazor.Components.Pages.Author;
public partial class Overview
{
    [Inject] public ILogger<Overview> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }

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
            var isDeleted = await ServiceManager.AuthorService.DeleteAuthorAsync(authorId);

            if (isDeleted)
            {
                await GetAuthorsAsync();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Fehler beim Löschen des Autors");
        }
    }
}
