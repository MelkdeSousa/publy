using System;

namespace Publy.Api.ViewModels
{
  public class UpdateCollaboratorViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string SocialNetworks { get; set; }
    public string DescriptionProfile { get; set; }
  }
}
