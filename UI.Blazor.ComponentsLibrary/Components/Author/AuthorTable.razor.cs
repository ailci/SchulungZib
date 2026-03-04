using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace UI.Blazor.ComponentsLibrary.Components.Author;
public partial class AuthorTable
{
    [Inject] public ILogger<AuthorTable> Logger { get; set; } = null!;
    [Parameter] public EventCallback<Guid> OnAuthorDelete { get; set; }
    [Parameter] public IEnumerable<AuthorViewModel>? AuthorsViewModels { get; set; }

    private async Task ShowConfirmationModal(AuthorViewModel author)
    {
        Logger.LogInformation($"Author {author.Name} zum Löschen ausgewählt...");

        //TODO: Dialog Feld
        await OnAuthorDelete.InvokeAsync(author.Id);
    }
}
