using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using AutoMapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services;

public class QotdDbService(ILogger<QotdDbService> logger, IDbContextFactory<QotdDbContext> contextFactory, IMapper mapper) : IQotdService
{
    public async Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var quotes = await context.Quotes.Include(c => c.Author).ToListAsync();
        var randomQuote = quotes.Shuffle().First();

        return mapper.Map<QuoteOfTheDayViewModel>(randomQuote);
    }
}