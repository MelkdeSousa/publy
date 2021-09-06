using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Publy.Domain.Entities;

namespace Publy.Infra.Interfaces
{
  public interface ICollaboratorDepartmentRepository
  {
    Task<CollaboratorDepartment> Create(CollaboratorDepartment collaboratorDepartment);
    Task<CollaboratorDepartment> Update(CollaboratorDepartment collaboratorDepartment);
    Task<List<CollaboratorDepartment>> GetAll();
    Task RemoveCollaboratorDepartment(Guid collaboratorId, Guid departmentId);
    Task<CollaboratorDepartment> GetCollaboratorDepartmentById(Guid collaboratorId, Guid departmentId);
    Task<List<CollaboratorDepartment>> SearchCollaboratorDepartmentByName(string collaboratorName, string departmentName);
  }
}
