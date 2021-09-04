using System;
using System.Collections.Generic;
using Publy.Domain.Validators;
using Publy.Core.Exceptions;

namespace Publy.Domain.Entities
{
  public class Collaborator : Base
  {
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime BirthDate { get; private set; }
    public ICollection<CollaboratorDepartment> Departments { get; private set; }
    public List<string> SocialNetworks { get; private set; }
    public string DescriptionProfile { get; private set; }

    protected Collaborator()
    { }

    public Collaborator(
      string email,
      string password,
      DateTime birthDate,
      List<string> socialNetworks,
      string descriptionProfile
      )
    {

      Email = email;
      Password = password;
      BirthDate = birthDate;
      SocialNetworks = socialNetworks;
      DescriptionProfile = descriptionProfile;

      _errors = new List<string>();

      Validate();
    }

    public override bool Validate()
    {
      var validator = new CollaboratorValidator();
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
