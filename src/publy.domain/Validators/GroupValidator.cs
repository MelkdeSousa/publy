using FluentValidation;
using Publy.Domain.Entities;

namespace Publy.Domain.Validators
{
  public class GroupValidator : AbstractValidator<Group>
  {
    public GroupValidator()
    {
      RuleFor(x => x)
        .NotEmpty()
        .WithMessage("Group must not be empty.")

        .NotNull()
        .WithMessage("Group must not be null");
    }
  }
}
