using FluentValidation;
using Publy.Domain.Entities;

namespace Publy.Domain.Validators
{
  public class DepartmentValidator : AbstractValidator<Department>
  {
    public DepartmentValidator()
    {
      RuleFor(x => x)
        .NotEmpty()
        .WithMessage("Department must not be empty.")

        .NotNull()
        .WithMessage("Department must not be null");
    }
  }
}
