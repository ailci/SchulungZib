using Application.Contracts.Services;
using Application.ViewModels.Author;
using Domain.Entities;
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

    public async Task<bool> DeleteAuthorAsync(Guid authorId)
    {
        logger.LogInformation($"{nameof(DeleteAuthorAsync)} aufgerufen...");
        await using var context = await contextFactory.CreateDbContextAsync();

        var author = await context.Authors.FindAsync([authorId]);
        if (author is null) return false;

        //2. Variante ohne FindAsync
        //var author2 = new Author { Id = authorId, Name = "", Description = "" };

        context.Authors.Remove(author);

        return await context.SaveChangesAsync() > 0;

    }
}