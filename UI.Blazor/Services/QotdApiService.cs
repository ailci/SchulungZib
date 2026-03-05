using Application.Contracts.Services;
using Application.ViewModels.Qotd;

namespace UI.Blazor.Services;

public class QotdApiService(ILogger<QotdApiService> logger, IHttpClientFactory clientFactory) : IQotdService
{
    public async Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        var client = clientFactory.CreateClient("qotdapiservice");
        
        return await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("api/qotd");
    }
}