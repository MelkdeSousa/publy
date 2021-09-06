using System;

namespace Publy.Domain.Entities
{
  public class CollaboratorGroup
  {
    public Guid CollaboratorId { get; private set; }
    public Collaborator Collaborator { get; private set; }
    public Guid GroupId { get; private set; }
    public Group Group { get; private set; }

    public CollaboratorGroup()
    { }
  }
}
