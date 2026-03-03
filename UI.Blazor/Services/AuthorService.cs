using Application.Contracts.Services;
using Application.ViewModels.Author;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace UI.Blazor.Services;

public class AuthorService(ILogger<AuthorService> logger, IDbContextFactory<QotdDbContext> contextFactory) : IAuthorService
{
    public async Task<IEnumerable<AuthorViewModel>> GetAuthorsAsync()
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();
        var authors = await context.Authors.ToListAsync();

        return authors.Select(a => new AuthorViewModel
        {
            Id = a.Id,
            Name = a.Name,
            Description = a.Description,
            BirthDate = a.BirthDate,
            Photo = a.Photo,
            PhotoMimeType = a.PhotoMimeType
        });
    }
}