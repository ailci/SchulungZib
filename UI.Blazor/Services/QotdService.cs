using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace UI.Blazor.Services;

public class QotdService(ILogger<QotdService> logger, IDbContextFactory<QotdDbContext> contextFactory) : IQotdService
{
    public async Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var quotes = await context.Quotes.Include(c => c.Author).ToListAsync();
        var randomQuote = quotes.Shuffle().First();

        return new QuoteOfTheDayViewModel
        {
            Id = randomQuote.Id,
            QuoteText = randomQuote.QuoteText,
            AuthorName = randomQuote.Author?.Name ?? string.Empty,
            AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
            AuthorBirthDate = randomQuote.Author?.BirthDate,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType
        };
    }
}