using System.Collections;
using Application.ViewModels.Author;

namespace UI.Blazor.Components.Pages.Author;
public partial class Overview
{
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }
}
