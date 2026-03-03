using Application.Contracts.Services;
using Application.Utilities;
using Application.ViewModels.Qotd;
using Infrastructure;
using Microsoft.AspNetCore.Components;

namespace UI.Blazor.Components.Pages;

public partial class Home //: IDisposable
{
    [Inject] public ILogger<Home> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    [Inject] public PersistentComponentState ApplicationState { get; set; } = null!;
    private PersistingComponentStateSubscription _persistingComponentStateSubscription;

    [PersistentState] //https://learn.microsoft.com/en-us/aspnet/core/blazor/state-management/prerendered-state-persistence?view=aspnetcore-10.0
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        Logger.LogInformation("Home aufgerufen...");

        //3.Lösung
        //_persistingComponentStateSubscription = ApplicationState.RegisterOnPersisting(PersistData);
        //if (!ApplicationState.TryTakeFromJson<QuoteOfTheDayViewModel>(nameof(QotdViewModel), out var restoredData))
        //{
        //    //Im PersistState nicht vorhanden
        //    QotdViewModel = await ServiceManager.QotdService.GetQuoteOfTheDayAsync();
        //}
        //else
        //{
        //    QotdViewModel = restoredData;
        //}

        //4.Lösung
        QotdViewModel ??= await ServiceManager.QotdService.GetQuoteOfTheDayAsync();

        //Logger.LogInformation($"QotdViewModel => {QotdViewModel?.LogAsJson()}");
    }

    //private Task PersistData()
    //{
    //    ApplicationState.PersistAsJson(nameof(QotdViewModel), QotdViewModel);
    //    return Task.CompletedTask;
    //}

    //public void Dispose() => _persistingComponentStateSubscription.Dispose();

    // 2. Lösung
    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    if (firstRender)
    //    {
    //        QotdViewModel = await ServiceManager.QotdService.GetQuoteOfTheDayAsync();
    //        StateHasChanged();
    //    }
    //}
}
