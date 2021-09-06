using System;
using Publy.Domain.Entities;

namespace Publy.Services.DTO
{
  public class CollaboratorDepartmentDTO
  {
    public Guid CollaboratorId { get; private set; }
    public Collaborator Collaborator { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Department Department { get; private set; }

    public CollaboratorDepartmentDTO()
    { }

    public CollaboratorDepartmentDTO(Guid collaboratorId, Collaborator collaborator, Guid departmentId, Department department)
    {
      CollaboratorId = collaboratorId;
      Collaborator = collaborator;
      DepartmentId = departmentId;
      Department = department;
    }
  }
}
