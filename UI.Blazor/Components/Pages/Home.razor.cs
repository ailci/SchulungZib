using System.Text.Json;
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
    [Inject] public IQotdService QotdApiService { get; set; } = null!;
    [Inject] public PersistentComponentState ApplicationState { get; set; } = null!;
    [Inject] public IHttpClientFactory HttpClientFactory { get; set; } = null!;
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
        //QotdViewModel ??= await ServiceManager.QotdService.GetQuoteOfTheDayAsync();

        //5. Lösung WebApi
        //var client = HttpClientFactory.CreateClient("qotdapiservice");
        //var response = await client.GetAsync("api/qotd");
        //response.EnsureSuccessStatusCode();
        //var content = await response.Content.ReadAsStringAsync();
        //Logger.LogInformation($"Rückgabe API: {content}");
        //QotdViewModel = JsonSerializer.Deserialize<QuoteOfTheDayViewModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

        //6.Lösung Abkürzung
        //var client = HttpClientFactory.CreateClient("qotdapiservice");
        //QotdViewModel = await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("api/qotd");

        //7.Lösung als Service
        QotdViewModel ??= await QotdApiService.GetQuoteOfTheDayAsync();

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
