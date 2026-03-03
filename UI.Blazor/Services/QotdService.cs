using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using Infrastructure;

namespace UI.Blazor.Services;

public class QotdService(ILogger<QotdService> logger, QotdDbContext context) : IQotdService
{
    public Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        return Task.FromResult(new QuoteOfTheDayViewModel()
        {
            AuthorName = "dfgd", 
            AuthorDescription = "dfs",
            QuoteText = "bla"
        });
    }
}