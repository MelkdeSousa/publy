using FluentValidation;
using Publy.Domain.Entities;

namespace Publy.Domain.Validators
{
  public class CollaboratorValidator : AbstractValidator<Collaborator>
  {
    public CollaboratorValidator()
    {
      RuleFor(x => x)
        .NotEmpty()
        .WithMessage("Collaborator must not be empty.")

        .NotNull()
        .WithMessage("Collaborator must not be null");
    }
  }
}
