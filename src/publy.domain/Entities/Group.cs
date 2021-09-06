using System.Collections.Generic;
using Publy.Core.Exceptions;
using Publy.Domain.Validators;

namespace Publy.Domain.Entities
{
  public class Group : Base
  {
    public ICollection<CollaboratorGroup> Collaborators { get; private set; }

    protected Group()
    {
      _errors = new List<string>();

      Validate();
    }

    public override bool Validate()
    {
      var validator = new GroupValidator();
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
