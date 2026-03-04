using Application.ViewModels.Author;
using Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace UI.Blazor.ComponentsLibrary.Components.Author;
public partial class AuthorTable
{
    [Inject] public ILogger<AuthorTable> Logger { get; set; } = null!;
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    [Inject] public DialogService DialogService { get; set; } = null!;
    [Parameter] public EventCallback<Guid> OnAuthorDelete { get; set; }
    [Parameter] public IEnumerable<AuthorViewModel>? AuthorsViewModels { get; set; }
    private ConfirmDialog? _confirmDialogComponent; //Referenz zur Componente
    private Guid _authorIdToDelete;

    private async Task ShowConfirmationModal(AuthorViewModel author)
    {
        Logger.LogInformation($"Author {author.Name} zum Löschen ausgewählt...");

        _authorIdToDelete = author.Id;

        //1. Version
        //if (await JsRuntime.InvokeAsync<bool>("myConfirm", $"Wollen Sie wirklich den Autor {author.Name} löschen?"))
        //{
        //    await OnAuthorDelete.InvokeAsync(author.Id);
        //}

        //2. Version via DialogService
        //if (await DialogService.ConfirmAsync($"Wollen Sie wirklich den Autor {author.Name} löschen (Dialog)?"))
        //{
        //    await OnAuthorDelete.InvokeAsync(author.Id);
        //}

        //3. Version als Componente
        _confirmDialogComponent?.Show($"Wollen Sie wirklich den Autor {author.Name} löschen?");

    }
    private async Task ConfirmDeleteClicked(bool isDelete)
    {
        await OnAuthorDelete.InvokeAsync(_authorIdToDelete);
    }
}
