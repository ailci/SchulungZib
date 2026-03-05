using Application.Contracts.Services;
using Application.Utilities;
using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace UI.Blazor.Components.Pages.Author;
public partial class AuthorNew
{
    [Inject] public ILogger<AuthorNew> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    [Inject] public NavigationManager NavManager { get; set; } = null!;
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }

    protected override void OnInitialized() => AuthorForCreateVm ??= new() { Name = "", Description = "" };

    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }
    private async Task HandleValidSubmit(EditContext args)
    {
        //Logger.LogInformation($"AuthorForCreateVm => {AuthorForCreateVm?.LogAsJson()}");

        try
        {
            var newAuthor = await ServiceManager.AuthorService.AddAuthorAsync(AuthorForCreateVm!);

            if (newAuthor is not null)
            {
                NavManager.NavigateTo("/authors/overviewreloaded");
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    private void OnInputFileChange(InputFileChangeEventArgs args)
    {
        //Logger.LogInformation($"SelectedFile => {args.File.LogAsJson()}");
        AuthorForCreateVm!.Photo = args.File;
    }
}
