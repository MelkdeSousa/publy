using System;

namespace Publy.Domain.Entities
{
  public class CollaboratorDepartment
  {
    public Guid CollaboratorId { get; private set; }
    public Collaborator Collaborator { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Department Department { get; private set; }

    public CollaboratorDepartment()
    { }
  }
}
