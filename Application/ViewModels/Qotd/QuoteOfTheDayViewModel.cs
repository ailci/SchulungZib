using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Qotd;

public class QuoteOfTheDayViewModel
{
    public Guid Id { get; set; }
    public required string QuoteText { get; set; }
    public required string AuthorName { get; set; }
    public required string AuthorDescription { get; set; }
    public DateOnly? AuthorBirthDate { get; set; }
    public byte[]? AuthorPhoto { get; set; }
    public string? AuthorPhotoMimeType { get; set; }
}