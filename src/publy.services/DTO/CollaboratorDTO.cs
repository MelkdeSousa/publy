using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Publy.Domain.Entities;

namespace Publy.Services.DTO
{
  public class CollaboratorDTO
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public string SocialNetworks { get; set; }
    public string DescriptionProfile { get; set; }

    public CollaboratorDTO()
    { }

    public CollaboratorDTO(Guid id, string name, string email, string password, DateTime birthDate, string socialNetworks, string descriptionProfile)
    {
      Id = id;
      Name = name;
      Email = email;
      Password = password;
      BirthDate = birthDate;
      SocialNetworks = socialNetworks;
      DescriptionProfile = descriptionProfile;
    }
  }
}
