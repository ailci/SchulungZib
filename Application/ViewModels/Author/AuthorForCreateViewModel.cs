using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Application.Validations;

namespace Application.ViewModels.Author;

public class AuthorForCreateViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie ienen Namen ein")]
    [Length(2, 150, ErrorMessage = "Name ist zu kurz/lang")]
    [DeniedValues(["administrator","admin","root","god"], ErrorMessage = "Der Name ist nicht erlaubt")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie ienen Namen ein")]
    [MinLength(2, ErrorMessage = "Name ist zu kurz")]
    public required string Description { get; set; }

    [NoFutureDate(ErrorMessage = "Geburtsdatum liegt in der Zukunft")]
    public DateOnly? BirthDate { get; set; }
    public IBrowserFile? Photo { get; set; }
}