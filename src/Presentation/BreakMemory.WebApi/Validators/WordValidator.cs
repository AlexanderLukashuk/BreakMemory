using BreakMemory.Infrastructure.Models.Requests;
using FastEndpoints;
using FluentValidation;

namespace BreakMemory.WebApi.Validators;

public class WordValidator : Validator<WordRequest>
{
    public WordValidator()
    {
        RuleFor(w => w.Original)
            .NotEmpty()
            .WithMessage("Word cant be empty");

        RuleFor(w => w.Translation)
            .NotEmpty()
            .WithMessage("Translation cant be empty");
    }
}