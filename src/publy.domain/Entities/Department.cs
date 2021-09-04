using System.Collections.Generic;
using Publy.Core.Exceptions;
using Publy.Domain.Validators;

namespace Publy.Domain.Entities
{
  public class Department : Base
  {
    public ICollection<CollaboratorDepartment> Collaborators { get; private set; }

    protected Department()
    {
      _errors = new List<string>();

      Validate();
    }

    public override bool Validate()
    {
      var validator = new DepartmentValidator();
      var validation = validator.Validate(this);

      if (!validation.IsValid)
      {
        foreach (var error in validation.Errors)
          _errors.Add(error.ErrorMessage);

        throw new DomainException("Some fields are missing, please fix them!", _errors);
      }

      return true;
    }

  }
}
